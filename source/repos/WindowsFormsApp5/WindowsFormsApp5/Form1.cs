using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        // ─── DLL Import ───────────────────────────────────────────────
        [DllImport("ACTMULTILIB_K.dll")] static extern int ActOpenDeviceEx(int nPortNo, int nBaudRate);
        [DllImport("ACTMULTILIB_K.dll")] static extern int ActCloseDevice(int hDev);
        [DllImport("ACTMULTILIB_K.dll")] static extern int ActGetWordDeviceStatus(int hDev, string szDevice, ref short lpData);
        [DllImport("ACTMULTILIB_K.dll")] static extern int ActSetWordDeviceStatus(int hDev, string szDevice, short lpData);

        // ─── 디바이스 핸들 & 상태 ──────────────────────────────────────
        private int hDev = -1;
        private bool isAutoRunning = false;

        // X 입력 비트 주소 (워드 단위 읽고 비트 추출)
        // X00~X0F → 워드 X0 읽기 (하위 16비트)
        // XA, XB → 워드 XA(10), XB(11) 위치
        private const string X_WORD = "X0";   // X00~X0F 포함 (X02,X03,X04,X05)
        private const string XAB_WORD = "XA"; // XA, XB 리프트 센서

        // Y 출력 비트 주소 (워드 Y0 내 비트 제어)
        private const string Y_WORD = "Y0";   // Y01~Y04 포함

        // 현재 Y 출력 상태 (비트 마스크 유지용)
        private short yStatus = 0;

        // B, C 실린더 상태머신
        private enum CylState { Idle, Forward, Backward }
        private CylState bState = CylState.Idle;
        private CylState cState = CylState.Idle;

        public Form1()
        {
            InitializeComponent();

            pollTimer = new Timer { Interval = 200 };
            pollTimer.Tick += PollTimer_Tick;
        }

        // ─── UI 구성 ──────────────────────────────────────────────────
        private void BuildUI()
        {
            this.Text = "자동 실린더 제어 - 융합UI실습 과제3";
            this.Size = new System.Drawing.Size(600, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // 연결 버튼
            btnConnect = MakeBtn("연결", 20, 15, 80, 32, Color.SteelBlue, BtnConnect_Click);
            btnDisconnect = MakeBtn("해제", 110, 15, 80, 32, Color.Gray, BtnDisconnect_Click);
            btnDisconnect.Enabled = false;

            // 자동운전 버튼
            btnStart = MakeBtn("▶ 시작", 220, 15, 100, 36, Color.Green, BtnStart_Click);
            btnStop = MakeBtn("■ 정지", 330, 15, 100, 36, Color.Firebrick, BtnStop_Click);
            btnStart.Enabled = false;
            btnStop.Enabled = false;

            lblAutoStatus = MakeLabel("● 대기", 450, 22, 120, 22, Color.Gray, true);

            // 센서 상태 그룹
            var grpSensor = new GroupBox { Text = "X 입력 (센서)", Location = new Point(20, 65), Size = new Size(260, 130) };
            lblXA = MakeLed("리프트센서 A (XA)", 10, 25, grpSensor);
            lblXB = MakeLed("리프트센서 B (XB)", 10, 50, grpSensor);
            lblX02 = MakeLed("B실린더 후진완료 X02", 10, 75, grpSensor);
            lblX03 = MakeLed("B실린더 전진완료 X03", 10, 100, grpSensor);
            Controls.Add(grpSensor);

            var grpSensor2 = new GroupBox { Text = "X 입력 (C실린더)", Location = new Point(300, 65), Size = new Size(260, 80) };
            lblX05 = MakeLed("C실린더 후진완료 X05", 10, 25, grpSensor2);
            lblX04 = MakeLed("C실린더 전진완료 X04", 10, 50, grpSensor2);
            Controls.Add(grpSensor2);

            // 출력 상태 그룹
            var grpOut = new GroupBox { Text = "Y 출력 (실린더 구동)", Location = new Point(20, 205), Size = new Size(260, 110) };
            lblY01 = MakeLed("B실린더 전진 Y01", 10, 25, grpOut);
            lblY02 = MakeLed("B실린더 후진 Y02", 10, 50, grpOut);
            lblY03 = MakeLed("C실린더 전진 Y03", 10, 75, grpOut);
            lblY04 = MakeLed("C실린더 후진 Y04", 10, 100, grpOut);
            Controls.Add(grpOut);

            // 상태머신 표시
            var grpState = new GroupBox { Text = "실린더 상태", Location = new Point(300, 155), Size = new Size(260, 80) };
            lblBState = MakeLabel("B실린더: 대기", 10, 25, 240, 20, Color.Black, false);
            lblCState = MakeLabel("C실린더: 대기", 10, 50, 240, 20, Color.Black, false);
            grpState.Controls.Add(lblBState);
            grpState.Controls.Add(lblCState);
            Controls.Add(grpState);

            // 로그
            var grpLog = new GroupBox { Text = "동작 로그", Location = new Point(20, 325), Size = new Size(540, 165) };
            logBox = new RichTextBox
            {
                Location = new Point(10, 20),
                Size = new Size(520, 135),
                ReadOnly = true,
                BackColor = Color.Black,
                ForeColor = Color.LimeGreen,
                Font = new Font("Consolas", 8.5f),
                ScrollBars = RichTextBoxScrollBars.Vertical
            };
            grpLog.Controls.Add(logBox);
            Controls.Add(grpLog);
        }

        // ─── 연결 / 해제 ──────────────────────────────────────────────
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            hDev = ActOpenDeviceEx(1, 9600);
            if (hDev < 0)
            {
                Log("❌ 연결 실패 (포트 확인 필요)");
                return;
            }
            Log("✅ 시뮬레이터 연결 성공");
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnStart.Enabled = true;
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            StopAuto();
            ActCloseDevice(hDev);
            hDev = -1;
            Log("🔌 연결 해제");
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
        }

        // ─── 자동운전 시작 / 정지 ────────────────────────────────────
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (hDev < 0) return;
            isAutoRunning = true;
            bState = CylState.Idle;
            cState = CylState.Idle;
            pollTimer.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblAutoStatus.Text = "● 자동운전 중";
            lblAutoStatus.ForeColor = Color.Lime;
            Log("▶ 자동운전 시작");
        }

        private void BtnStop_Click(object sender, EventArgs e) => StopAuto();

        private void StopAuto()
        {
            isAutoRunning = false;
            pollTimer.Stop();
            AllOutputOff();
            bState = CylState.Idle;
            cState = CylState.Idle;
            btnStart.Enabled = hDev >= 0;
            btnStop.Enabled = false;
            lblAutoStatus.Text = "● 대기";
            lblAutoStatus.ForeColor = Color.Gray;
            Log("■ 자동운전 정지");
        }

        // ─── 폴링 Tick (200ms) ────────────────────────────────────────
        private void PollTimer_Tick(object sender, EventArgs e)
        {
            if (hDev < 0) return;

            // X 워드 읽기
            short xWord = 0;
            short xabWord = 0;
            ActGetWordDeviceStatus(hDev, X_WORD, ref xWord);
            ActGetWordDeviceStatus(hDev, XAB_WORD, ref xabWord);

            // 비트 추출
            bool x02 = GetBit(xWord, 2);   // B후진 리밋
            bool x03 = GetBit(xWord, 3);   // B전진 리밋
            bool x04 = GetBit(xWord, 4);   // C전진 리밋
            bool x05 = GetBit(xWord, 5);   // C후진 리밋
            bool xA = GetBit(xabWord, 0); // 리프트A
            bool xB = GetBit(xabWord, 1); // 리프트B

            // LED 업데이트
            SetLed(lblXA, xA);
            SetLed(lblXB, xB);
            SetLed(lblX02, x02);
            SetLed(lblX03, x03);
            SetLed(lblX04, x04);
            SetLed(lblX05, x05);

            if (isAutoRunning)
            {
                RunBCylinder(xA, x02, x03);
                RunCCylinder(xB, x04, x05);
            }

            // Y 출력 LED 반영
            ActGetWordDeviceStatus(hDev, Y_WORD, ref yStatus);
            SetLed(lblY01, GetBit(yStatus, 1));
            SetLed(lblY02, GetBit(yStatus, 2));
            SetLed(lblY03, GetBit(yStatus, 3));
            SetLed(lblY04, GetBit(yStatus, 4));
        }

        // ─── B실린더 상태머신 ─────────────────────────────────────────
        // 조건:
        //   Idle   → XA ON → 전진(Y01 ON)
        //   Forward  → X03 ON → 후진(Y01 OFF, Y02 ON)
        //   Backward → X02 ON → 대기(Y02 OFF)
        private void RunBCylinder(bool xA, bool x02, bool x03)
        {
            switch (bState)
            {
                case CylState.Idle:
                    if (xA)
                    {
                        SetOutput(1, true);   // Y01 ON: B전진
                        bState = CylState.Forward;
                        lblBState.Text = "B실린더: 전진 중";
                        Log("[B] 리프트A 감지 → B실린더 전진");
                    }
                    break;

                case CylState.Forward:
                    if (x03)
                    {
                        SetOutput(1, false);  // Y01 OFF
                        SetOutput(2, true);   // Y02 ON: B후진
                        bState = CylState.Backward;
                        lblBState.Text = "B실린더: 후진 중";
                        Log("[B] 전진 완료(X03) → B실린더 후진");
                    }
                    break;

                case CylState.Backward:
                    if (x02)
                    {
                        SetOutput(2, false);  // Y02 OFF
                        bState = CylState.Idle;
                        lblBState.Text = "B실린더: 대기";
                        Log("[B] 후진 완료(X02) → 대기");
                    }
                    break;
            }
        }

        // ─── C실린더 상태머신 ─────────────────────────────────────────
        // 조건:
        //   Idle     → XB ON → 전진(Y03 ON)
        //   Forward  → X04 ON → 후진(Y03 OFF, Y04 ON)
        //   Backward → X05 ON → 대기(Y04 OFF)
        private void RunCCylinder(bool xB, bool x04, bool x05)
        {
            switch (cState)
            {
                case CylState.Idle:
                    if (xB)
                    {
                        SetOutput(3, true);   // Y03 ON: C전진
                        cState = CylState.Forward;
                        lblCState.Text = "C실린더: 전진 중";
                        Log("[C] 리프트B 감지 → C실린더 전진");
                    }
                    break;

                case CylState.Forward:
                    if (x04)
                    {
                        SetOutput(3, false);  // Y03 OFF
                        SetOutput(4, true);   // Y04 ON: C후진
                        cState = CylState.Backward;
                        lblCState.Text = "C실린더: 후진 중";
                        Log("[C] 전진 완료(X04) → C실린더 후진");
                    }
                    break;

                case CylState.Backward:
                    if (x05)
                    {
                        SetOutput(4, false);  // Y04 OFF
                        cState = CylState.Idle;
                        lblCState.Text = "C실린더: 대기";
                        Log("[C] 후진 완료(X05) → 대기");
                    }
                    break;
            }
        }

        // ─── 출력 제어 헬퍼 ──────────────────────────────────────────
        // bitPos: Y 워드 내 비트 번호 (Y01=1, Y02=2, Y03=3, Y04=4)
        private void SetOutput(int bitPos, bool on)
        {
            short cur = 0;
            ActGetWordDeviceStatus(hDev, Y_WORD, ref cur);
            if (on)
                cur = (short)(cur | (1 << bitPos));
            else
                cur = (short)(cur & ~(1 << bitPos));
            ActSetWordDeviceStatus(hDev, Y_WORD, cur);
        }

        private void AllOutputOff()
        {
            if (hDev >= 0)
                ActSetWordDeviceStatus(hDev, Y_WORD, 0);
        }

        // ─── 유틸리티 ─────────────────────────────────────────────────
        private static bool GetBit(short word, int bit) => (word & (1 << bit)) != 0;

        private void SetLed(Label lbl, bool on)
        {
            lbl.BackColor = on ? Color.Lime : Color.DimGray;
        }

        private void Log(string msg)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] {msg}\n";
            logBox.AppendText(line);
            logBox.ScrollToCaret();
        }

        // ─── UI 팩토리 ────────────────────────────────────────────────
        private Button MakeBtn(string text, int x, int y, int w, int h, Color back, EventHandler click)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(w, h),
                BackColor = back,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("맑은 고딕", 9.5f, FontStyle.Bold)
            };
            btn.Click += click;
            Controls.Add(btn);
            return btn;
        }

        private Label MakeLabel(string text, int x, int y, int w, int h, Color fore, bool bold)
        {
            var lbl = new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(w, h),
                ForeColor = fore,
                Font = new Font("맑은 고딕", 9f, bold ? FontStyle.Bold : FontStyle.Regular)
            };
            Controls.Add(lbl);
            return lbl;
        }

        // LED 라벨: 텍스트 + 네모 표시용
        private Label MakeLed(string text, int x, int y, Control parent)
        {
            var lbl = new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(230, 20),
                BackColor = Color.DimGray,
                ForeColor = Color.White,
                Font = new Font("맑은 고딕", 8.5f),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0)
            };
            parent.Controls.Add(lbl);
            return lbl;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopAuto();
            if (hDev >= 0) ActCloseDevice(hDev);
            base.OnFormClosing(e);
        }

        private void btnDisconnect_Click_1(object sender, EventArgs e)
        {

        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {

        }
    }
}