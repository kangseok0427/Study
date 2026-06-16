using System;
using System.Drawing;
using System.Windows.Forms;
using ACTMULTILIB_K;

namespace T01
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();

        private bool isAutoRunning = false;
        private bool prevXA = false;
        private bool prevXB = false;
        private bool bForward = false;
        private bool cForward = false;

        private Timer pollTimer;

        public Form1()
        {
            InitializeComponent();

            pollTimer = new Timer { Interval = 200 };
            pollTimer.Tick += PollTimer_Tick;

            btnDisconnect.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;

            picB.SizeMode = PictureBoxSizeMode.StretchImage;
            picC.SizeMode = PictureBoxSizeMode.StretchImage;
            picB.Image = Properties.Resources.cylinderoff;
            picC.Image = Properties.Resources.cylinderoff;
        }

        private void btnConnect_Click(object sender, EventArgs e)
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

        private void btnDisconnect_Click(object sender, EventArgs e)
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            isAutoRunning = true;
            prevXA = false;
            prevXB = false;
            bForward = false;
            cForward = false;
            pollTimer.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "● 자동운전 중";
            lblStatus.ForeColor = Color.Lime;
            Log("▶ 자동운전 시작");
        }

        private void btnStop_Click(object sender, EventArgs e) => StopAuto();

        private void StopAuto()
        {
            isAutoRunning = false;
            pollTimer.Stop();
            AllOff();
            picB.Image = Properties.Resources.cylinderoff;
            picC.Image = Properties.Resources.cylinderoff;
            lblBState.Text = "대기";
            lblCState.Text = "대기";
            bForward = false;
            cForward = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblStatus.Text = "● 연결됨";
            lblStatus.ForeColor = Color.LimeGreen;
            Log("■ 정지");
        }

        // 센서 ON → 전진 / 센서 OFF → 후진 (엣지 감지)
        private void PollTimer_Tick(object sender, EventArgs e)
        {
            short xWord = 0;
            control.ReadDeviceBlock2("X0", 1, out xWord);

            bool xA = Bit(xWord, 10);
            bool xB = Bit(xWord, 11);

            UpdateSensor(lblSensorA, "리프트 A", xA);
            UpdateSensor(lblSensorB, "리프트 B", xB);

            if (isAutoRunning)
            {
                // B실린더: XA 상승 → 전진 / XA 하강 → 후진
                if (xA && !prevXA)
                {
                    short val = (short)(1 << 2); // Y02 전진
                    control.WriteDeviceBlock2("Y0", 1, ref val);
                    bForward = true;
                    picB.Image = Properties.Resources.cylinderon;
                    lblBState.Text = "전진 중...";
                    Log("[B] 리프트A ON → 전진");
                }
                else if (!xA && prevXA && bForward)
                {
                    short val = (short)(1 << 3); // Y03 후진
                    control.WriteDeviceBlock2("Y0", 1, ref val);
                    bForward = false;
                    picB.Image = Properties.Resources.cylinderoff;
                    lblBState.Text = "후진 중...";
                    Log("[B] 리프트A OFF → 후진");
                }

                // C실린더: XB 상승 → 전진 / XB 하강 → 후진
                if (xB && !prevXB)
                {
                    short val = (short)(1 << 4); // Y04 전진
                    control.WriteDeviceBlock2("Y0", 1, ref val);
                    cForward = true;
                    picC.Image = Properties.Resources.cylinderon;
                    lblCState.Text = "전진 중...";
                    Log("[C] 리프트B ON → 전진");
                }
                else if (!xB && prevXB && cForward)
                {
                    short val = (short)(1 << 5); // Y05 후진
                    control.WriteDeviceBlock2("Y0", 1, ref val);
                    cForward = false;
                    picC.Image = Properties.Resources.cylinderoff;
                    lblCState.Text = "후진 중...";
                    Log("[C] 리프트B OFF → 후진");
                }

                prevXA = xA;
                prevXB = xB;
            }
        }

        private void AllOff()
        {
            short zero = 0;
            control.WriteDeviceBlock2("Y0", 1, ref zero);
        }

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
    }
}