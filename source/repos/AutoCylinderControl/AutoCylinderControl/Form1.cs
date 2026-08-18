using System;
using System.Drawing;
using System.Windows.Forms;
using ACTMULTILIB_K;

namespace AutoCylinderControl
{
    public partial class Form1 : Form
    {
        // ── COM 객체 ───────────────────────────────────────────────────
        ActEasyIF control = new ActEasyIF();

        // ── 상태머신 ───────────────────────────────────────────────────
        private bool isAutoRunning = false;
        private enum CylState { Idle, Forward, Backward }
        private CylState bState = CylState.Idle;
        private CylState cState = CylState.Idle;

        private Timer pollTimer;

        public Form1()
        {
            InitializeComponent();
            pollTimer = new Timer { Interval = 200 };
            pollTimer.Tick += PollTimer_Tick;

            btnDisconnect.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;

            picB.Image = Properties.Resources.cylinderoff;
            picC.Image = Properties.Resources.cylinderoff;
        }

        // ── 연결 ───────────────────────────────────────────────────────
        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            if (control.Open() == 0)
            {
                Log("✅ 연결 성공");
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnStart.Enabled = true;
                lblStatus.Text = "● 연결됨";
                lblStatus.ForeColor = Color.LimeGreen;
            }
            else
            {
                Log("❌ 연결 실패");
            }
        }

        // ── 해제 ───────────────────────────────────────────────────────
        private void btnDisconnect_Click_1(object sender, EventArgs e)
        {
            StopAuto();
            control.Close();
            Log("🔌 연결 해제");
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnStart.Enabled = false;
            lblStatus.Text = "● 연결 안됨";
            lblStatus.ForeColor = Color.Gray;
        }

        // ── 자동운전 시작 ──────────────────────────────────────────────
        private void btnStart_Click_1(object sender, EventArgs e)
        {
            isAutoRunning = true;
            bState = CylState.Idle;
            cState = CylState.Idle;
            pollTimer.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "● 자동운전 중";
            lblStatus.ForeColor = Color.Lime;
            Log("▶ 자동운전 시작");
        }

        // ── 자동운전 정지 ──────────────────────────────────────────────
        private void btnStop_Click_1(object sender, EventArgs e) => StopAuto();

        private void StopAuto()
        {
            isAutoRunning = false;
            pollTimer.Stop();
            AllOff();
            picB.Image = Properties.Resources.cylinderoff;
            picC.Image = Properties.Resources.cylinderoff;
            lblBState.Text = "대기";
            lblCState.Text = "대기";
            bState = CylState.Idle;
            cState = CylState.Idle;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblStatus.Text = "● 연결됨";
            lblStatus.ForeColor = Color.LimeGreen;
            Log("■ 정지");
        }

        // ── 폴링 200ms ─────────────────────────────────────────────────
        private void PollTimer_Tick(object sender, EventArgs e)
        {
            short xWord = 0;
            control.ReadDeviceBlock2("X0", 1, out xWord);

            bool x02 = Bit(xWord, 3);   // B 후진 리밋
            bool x03 = Bit(xWord, 2);   // B 전진 리밋
            bool x04 = Bit(xWord, 4);   // C 전진 리밋
            bool x05 = Bit(xWord, 5);   // C 후진 리밋
            bool xA = Bit(xWord, 10);  // 리프트 센서 A (XA)
            bool xB = Bit(xWord, 11);  // 리프트 센서 B (XB)

            UpdateSensor(lblSensorA, "리프트 A", xA);
            UpdateSensor(lblSensorB, "리프트 B", xB);

            if (isAutoRunning)
            {
                RunB(xA, x02, x03);
                RunC(xB, x04, x05);
            }
        }

        // ── B실린더 상태머신 ───────────────────────────────────────────
        // Idle     : XA ON  → Y01(bit1) ON  전진
        // Forward  : X03 ON → Y01 OFF, Y02(bit2) ON 후진
        // Backward : X02 ON → Y02 OFF → 대기
        private void RunB(bool xA, bool x02, bool x03)
        {
            switch (bState)
            {
                case CylState.Idle:
                    if (xA)
                    {
                        WriteY(1, true);
                        picB.Image = Properties.Resources.cylinderon;
                        lblBState.Text = "전진 중...";
                        bState = CylState.Forward;
                        Log("[B] 리프트A 감지 → 전진");
                    }
                    break;
                case CylState.Forward:
                    if (x03)
                    {
                        WriteY(1, false); WriteY(2, true);
                        lblBState.Text = "후진 중...";
                        bState = CylState.Backward;
                        Log("[B] 전진완료(X03) → 후진");
                    }
                    break;
                case CylState.Backward:
                    if (x02)
                    {
                        WriteY(2, false);
                        picB.Image = Properties.Resources.cylinderoff;
                        lblBState.Text = "대기";
                        bState = CylState.Idle;
                        Log("[B] 후진완료(X02) → 대기");
                    }
                    break;
            }
        }

        // ── C실린더 상태머신 ───────────────────────────────────────────
        // Idle     : XB ON  → Y03(bit3) ON 전진
        // Forward  : X04 ON → Y03 OFF, Y04(bit4) ON 후진
        // Backward : X05 ON → Y04 OFF → 대기
        private void RunC(bool xB, bool x04, bool x05)
        {
            switch (cState)
            {
                case CylState.Idle:
                    if (xB)
                    {
                        WriteY(3, true);
                        picC.Image = Properties.Resources.cylinderon;
                        lblCState.Text = "전진 중...";
                        cState = CylState.Forward;
                        Log("[C] 리프트B 감지 → 전진");
                    }
                    break;
                case CylState.Forward:
                    if (x04)
                    {
                        WriteY(3, false); WriteY(4, true);
                        lblCState.Text = "후진 중...";
                        cState = CylState.Backward;
                        Log("[C] 전진완료(X04) → 후진");
                    }
                    break;
                case CylState.Backward:
                    if (x05)
                    {
                        WriteY(4, false);
                        picC.Image = Properties.Resources.cylinderoff;
                        lblCState.Text = "대기";
                        cState = CylState.Idle;
                        Log("[C] 후진완료(X05) → 대기");
                    }
                    break;
            }
        }

        // ── 출력 헬퍼 ──────────────────────────────────────────────────
        private void WriteY(int bit, bool on)
        {
            short cur = 0;
            control.ReadDeviceBlock2("Y0", 1, out cur);
            cur = on ? (short)(cur | (1 << bit)) : (short)(cur & ~(1 << bit));
            control.WriteDeviceBlock2("Y0", 1, ref cur);
        }

        private void AllOff()
        {
            short zero = 0;
            control.WriteDeviceBlock2("Y0", 1, ref zero);
        }

        // ── 유틸 ───────────────────────────────────────────────────────
        private static bool Bit(short w, int b) => (w & (1 << b)) != 0;

        private void UpdateSensor(Label lbl, string name, bool on)
        {
            lbl.Text = $"{name} : {(on ? "ON" : "OFF")}";
            lbl.ForeColor = on ? Color.Black : Color.Silver;
            lbl.BackColor = on ? Color.Lime : Color.FromArgb(50, 50, 50);
        }

        private void Log(string msg)
        {
            logBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\n");
            logBox.ScrollToCaret();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopAuto();
            control.Close();
            base.OnFormClosing(e);
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}