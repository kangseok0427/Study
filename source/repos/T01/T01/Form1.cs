using System;
using System.Drawing;
using System.Windows.Forms;
using ACTMULTILIB_K;

namespace T01
{
    public partial class Form1 : Form
    {
        ActEasyIF control;
        private bool isAutoRunning = false;
        private int _step = 0;
        private Timer pollTimer;

        private const int Y_LIFT_A_UP = 1 << 5; // Y5
        private const int Y_LIFT_A_DOWN = 1 << 6; // Y6
        private const int Y_LIFT_B_UP = 1 << 7; // Y7 
        private const int Y_LIFT_B_DOWN = 1 << 8; // Y8 
        private const int Y_CYL_B_FWD = 1 << 1; // Y1
        private const int Y_CYL_B_BCK = 1 << 2; // Y2
        private const int Y_CYL_C_FWD = 1 << 3; // Y3
        private const int Y_CYL_C_BCK = 1 << 4; // Y4

        public Form1()
        {
            InitializeComponent();
            control = new ActEasyIF();

            pollTimer = new Timer { Interval = 200 };
            pollTimer.Tick += PollTimer_Tick;

            btnDisconnect.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            SetManualButtons(false);

            picB.Image = Properties.Resources.cylinderoff;
            picC.Image = Properties.Resources.cylinderoff;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (control.Open() == 0)
            {
                Log("연결 성공");
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnStart.Enabled = true;
                SetManualButtons(true);
                lblStatus.Text = "● 연결됨";
                lblStatus.ForeColor = Color.Green;
            }
            else { Log("연결 실패"); }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            StopAuto();
            try { control.Close(); } catch { }
            Log("연결 해제");
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnStart.Enabled = false;
            SetManualButtons(false);
            lblStatus.Text = "● 연결 안됨";
            lblStatus.ForeColor = Color.Gray;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _step = 1;
            isAutoRunning = true;
            pollTimer.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            SetManualButtons(false);
            lblStatus.Text = "● 자동운전 중";
            lblStatus.ForeColor = Color.Green;
            Log("자동운전 시작");
        }

        private void btnStop_Click(object sender, EventArgs e) => StopAuto();

        private void StopAuto()
        {
            isAutoRunning = false;
            pollTimer.Stop();
            _step = 0;
            try { AllOff(); } catch { }
            picB.Image = Properties.Resources.cylinderoff;
            picC.Image = Properties.Resources.cylinderoff;
            lblBState.Text = "대기";
            lblCState.Text = "대기";
            UpdateLiftStatus("대기", "대기");
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            SetManualButtons(true);
            lblStatus.Text = "● 연결됨";
            lblStatus.ForeColor = Color.Green;
            Log("정지");
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            if (!isAutoRunning) return;
            try
            {
                short raw = 0;
                control.ReadDeviceBlock2("X0", 1, out raw);

                bool x3 = GetBit(raw, 3); // CylinderB 후진완료
                bool x4 = GetBit(raw, 4); // CylinderC 후진완료
                bool x6 = GetBit(raw, 6); // LiftA Up 도착
                bool x9 = GetBit(raw, 9); // LiftB Down 도착
                bool xA = GetBit(raw, 10); // LiftA 물체감지
                bool xB = GetBit(raw, 11); // LiftB 물체감지

                UpdateSensor(lblSensorA, "리프트 A", xA);
                UpdateSensor(lblSensorB, "리프트 B", xB);

                switch (_step)
                {
                    // ── Step 1~2: 리프트 둘 다 UP 대기 위치 ──────────
                    case 1:
                        WriteY(Y_LIFT_A_UP | Y_LIFT_B_UP);
                        UpdateLiftStatus("↑ 상승 중", "↑ 상승 중");
                        Log("[1] LiftA+B Up");
                        _step = 2;
                        break;

                    case 2: // 상단 도착 + XB 물체 감지 대기
                        WriteY(Y_LIFT_A_UP | Y_LIFT_B_UP);
                        if (x6 && xB)
                        {
                            Log("[2] 상단도착+XB감지 → LiftA+B Down");
                            _step = 3;
                        }
                        break;

                    // ── Step 3~4: 리프트 둘 다 DOWN ──────────────────
                    case 3:
                        WriteY(Y_LIFT_A_DOWN | Y_LIFT_B_DOWN);
                        UpdateLiftStatus("↓ 하강 중", "↓ 하강 중");
                        Log("[3] LiftA+B Down");
                        _step = 4;
                        break;

                    case 4: // 하단 도착 대기
                        WriteY(Y_LIFT_A_DOWN | Y_LIFT_B_DOWN);
                        if (x9)
                        {
                            Log("[4] 하단도착 → C전진");
                            _step = 5;
                        }
                        break;

                    // ── Step 5~6: C실린더 전진 ───────────────────────
                    case 5:
                        WriteY(Y_CYL_C_FWD);
                        picC.Image = Properties.Resources.cylinderon;
                        lblCState.Text = "전진 중...";
                        Log("[5] C전진");
                        _step = 6;
                        break;

                    case 6: // XB OFF 대기 (물체 이탈)
                        WriteY(Y_CYL_C_FWD);
                        if (!xB)
                        {
                            Log("[6] XB OFF → C후진");
                            _step = 7;
                        }
                        break;

                    // ── Step 7~8: C실린더 후진 ───────────────────────
                    case 7:
                        WriteY(Y_CYL_C_BCK);
                        picC.Image = Properties.Resources.cylinderoff;
                        lblCState.Text = "후진 중...";
                        Log("[7] C후진");
                        _step = 8;
                        break;

                    case 8: // XA 물체 도착 대기
                        WriteY(Y_CYL_C_BCK);
                        if (xA)
                        {
                            Log("[8] XA감지 → LiftA+B Up");
                            _step = 1;
                        }
                        break;

                        // ── Step 상단: B실린더 전진 (XA 감지 시) ─────────
                        // Step2 대기 중 XA 감지되면 B전진으로 분기
                }

                // XA 감지는 Step2 대기 중 언제든 처리
                if (_step == 2 && x6 && xA && !xB)
                {
                    Log("[B] XA감지 → B전진");
                    WriteY(Y_CYL_B_FWD);
                    picB.Image = Properties.Resources.cylinderon;
                    lblBState.Text = "전진 중...";
                    _step = 20;
                }
                else if (_step == 20 && !xA)
                {
                    Log("[B] XA OFF → B후진");
                    WriteY(Y_CYL_B_BCK);
                    picB.Image = Properties.Resources.cylinderoff;
                    lblBState.Text = "후진 중...";
                    _step = 21;
                }
                else if (_step == 20)
                {
                    WriteY(Y_CYL_B_FWD); // 유지
                }
                else if (_step == 21 && x3)
                {
                    Log("[B] B후진완료 → 대기");
                    lblBState.Text = "대기";
                    _step = 2; // 다시 대기로
                }
                else if (_step == 21)
                {
                    WriteY(Y_CYL_B_BCK); // 유지
                }
            }
            catch (Exception ex)
            {
                Log($"오류: {ex.Message}");
            }
        }

        // ── 수동 조작 ────────────────────────────────────────────────
        private void btnLiftAUp_Click(object sender, EventArgs e) { WriteY(Y_LIFT_A_UP); UpdateLiftStatus("↑(수동)", lblCLiftState.Text); Log("[수동] LiftA Up"); }
        private void btnLiftADown_Click(object sender, EventArgs e) { WriteY(Y_LIFT_A_DOWN); UpdateLiftStatus("↓(수동)", lblCLiftState.Text); Log("[수동] LiftA Down"); }
        private void btnLiftBUp_Click(object sender, EventArgs e) { WriteY(Y_LIFT_B_UP); UpdateLiftStatus(lblALiftState.Text, "↑(수동)"); Log("[수동] LiftB Up"); }
        private void btnLiftBDown_Click(object sender, EventArgs e) { WriteY(Y_LIFT_B_DOWN); UpdateLiftStatus(lblALiftState.Text, "↓(수동)"); Log("[수동] LiftB Down"); }
        private void btnBFwd_Click(object sender, EventArgs e) { WriteY(Y_CYL_B_FWD); picB.Image = Properties.Resources.cylinderon; lblBState.Text = "전진(수동)"; Log("[수동] B전진"); }
        private void btnBBck_Click(object sender, EventArgs e) { WriteY(Y_CYL_B_BCK); picB.Image = Properties.Resources.cylinderoff; lblBState.Text = "후진(수동)"; Log("[수동] B후진"); }
        private void btnCFwd_Click(object sender, EventArgs e) { WriteY(Y_CYL_C_FWD); picC.Image = Properties.Resources.cylinderon; lblCState.Text = "전진(수동)"; Log("[수동] C전진"); }
        private void btnCBck_Click(object sender, EventArgs e) { WriteY(Y_CYL_C_BCK); picC.Image = Properties.Resources.cylinderoff; lblCState.Text = "후진(수동)"; Log("[수동] C후진"); }
        private void btnAllOff_Click(object sender, EventArgs e)
        {
            AllOff();
            picB.Image = Properties.Resources.cylinderoff;
            picC.Image = Properties.Resources.cylinderoff;
            lblBState.Text = "대기"; lblCState.Text = "대기";
            UpdateLiftStatus("대기", "대기");
            Log("[수동] 전체 OFF");
        }

        private bool GetBit(short raw, int bit) => (raw & (1 << bit)) != 0;

        private void WriteY(int mask)
        {
            short val = (short)mask;
            control.WriteDeviceBlock2("Y0", 1, ref val);
        }

        private void AllOff()
        {
            short zero = 0;
            control.WriteDeviceBlock2("Y0", 1, ref zero);
        }

        private void UpdateSensor(Label lbl, string name, bool on)
        {
            lbl.Text = $"{name} : {(on ? "ON" : "OFF")}";
            lbl.ForeColor = on ? Color.Black : Color.Gray;
            lbl.BackColor = on ? Color.Lime : Color.LightGray;
        }

        private void UpdateLiftStatus(string aState, string bState)
        {
            lblALiftState.Text = aState;
            lblALiftState.ForeColor = aState == "대기" ? Color.Gray : Color.DarkOrange;
            lblCLiftState.Text = bState;
            lblCLiftState.ForeColor = bState == "대기" ? Color.Gray : Color.DarkOrange;
        }

        private void SetManualButtons(bool enabled)
        {
            btnLiftAUp.Enabled = enabled; btnLiftADown.Enabled = enabled;
            btnLiftBUp.Enabled = enabled; btnLiftBDown.Enabled = enabled;
            btnBFwd.Enabled = enabled; btnBBck.Enabled = enabled;
            btnCFwd.Enabled = enabled; btnCBck.Enabled = enabled;
            btnAllOff.Enabled = enabled;
        }

        private void Log(string msg)
        {
            logBox.AppendText($"[{DateTime.Now:HH:mm:ss.fff}] {msg}\n");
            logBox.ScrollToCaret();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopAuto();
            try { control.Close(); } catch { }
            base.OnFormClosing(e);
        }
    }
}