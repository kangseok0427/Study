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
        private bool prevXA = false;
        private bool prevXB = false;

        private Timer pollTimer;

        public Form1()
        {
            InitializeComponent();

            control = new ActEasyIF();

            pollTimer = new Timer { Interval = 200 };
            pollTimer.Tick += PollTimer_Tick;

            btnDisconnect.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;

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
                lblStatus.Text = "● 연결됨";
                lblStatus.ForeColor = Color.LimeGreen;
            }
            else
            {
                Log("연결 실패");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            StopAuto();
            control.Close();
            Log("연결 해제");
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
            pollTimer.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "● 자동운전 중";
            lblStatus.ForeColor = Color.Lime;
            Log("자동운전 시작");
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
            prevXA = false;
            prevXB = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblStatus.Text = "● 연결됨";
            lblStatus.ForeColor = Color.LimeGreen;
            Log("정지");
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            short sensors = 0;
            control.ReadDeviceBlock2("X0", 1, out sensors);

            // Devices 패널 기준:
            // bit0=B전진센서, bit1=B후진센서
            // bit2=C전진센서, bit3=C후진센서
            // bit4=리프트A,   bit5=리프트B
            bool bFwd = (sensors & (1 << 0)) != 0;
            bool bBwd = (sensors & (1 << 1)) != 0;
            bool cFwd = (sensors & (1 << 2)) != 0;
            bool cBwd = (sensors & (1 << 3)) != 0;
            bool xA = (sensors & (1 << 4)) != 0;
            bool xB = (sensors & (1 << 5)) != 0;

            // raw 비트값 로그
            Log($"RAW: {Convert.ToString(sensors, 2).PadLeft(8, '0')} | bFwd={bFwd} bBwd={bBwd} cFwd={cFwd} cBwd={cBwd} XA={xA} XB={xB}");

            UpdateSensor(lblSensorA, "리프트 A", xA);
            UpdateSensor(lblSensorB, "리프트 B", xB);

            if (!isAutoRunning) return;

            // B실린더: XA ON → 전진(Y01), XA OFF → 후진(Y02)
            if (xA && !prevXA)
            {
                short val = (short)(1 << 1); // Y01
                control.WriteDeviceBlock2("Y0", 1, ref val);
                picB.Image = Properties.Resources.cylinderon;
                lblBState.Text = "전진 중...";
                Log("[B] 리프트A ON → 전진 (Y01)");
            }
            else if (!xA && prevXA)
            {
                short val = (short)(1 << 2); // Y02
                control.WriteDeviceBlock2("Y0", 1, ref val);
                picB.Image = Properties.Resources.cylinderoff;
                lblBState.Text = "후진 중...";
                Log("[B] 리프트A OFF → 후진 (Y02)");
            }

            // C실린더: XB ON → 전진(Y03), XB OFF → 후진(Y04)
            if (xB && !prevXB)
            {
                short val = (short)(1 << 3); // Y03
                control.WriteDeviceBlock2("Y0", 1, ref val);
                picC.Image = Properties.Resources.cylinderon;
                lblCState.Text = "전진 중...";
                Log("[C] 리프트B ON → 전진 (Y03)");
            }
            else if (!xB && prevXB)
            {
                short val = (short)(1 << 4); // Y04
                control.WriteDeviceBlock2("Y0", 1, ref val);
                picC.Image = Properties.Resources.cylinderoff;
                lblCState.Text = "후진 중...";
                Log("[C] 리프트B OFF → 후진 (Y04)");
            }

            prevXA = xA;
            prevXB = xB;
        }

        private void AllOff()
        {
            short zero = 0;
            control.WriteDeviceBlock2("Y0", 1, ref zero);
        }

        private void UpdateSensor(Label lbl, string name, bool on)
        {
            lbl.Text = $"{name} : {(on ? "ON" : "OFF")}";
            lbl.ForeColor = on ? Color.Black : Color.Silver;
            lbl.BackColor = on ? Color.Lime : Color.FromArgb(50, 50, 50);
        }

        private void Log(string msg)
        {
            logBox.AppendText($"[{DateTime.Now:HH:mm:ss.fff}] {msg}\n");
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