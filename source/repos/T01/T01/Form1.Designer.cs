namespace T01
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Button MakeBtn(string text, System.Drawing.Point loc, System.Drawing.Color color, System.Drawing.Size size)
        {
            var btn = new System.Windows.Forms.Button();
            btn.Text = text;
            btn.Location = loc;
            btn.Size = size;
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("맑은 고딕", 8f, System.Drawing.FontStyle.Bold);
            return btn;
        }

        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblBState = new System.Windows.Forms.Label();
            this.lblCState = new System.Windows.Forms.Label();
            this.lblSensorA = new System.Windows.Forms.Label();
            this.lblSensorB = new System.Windows.Forms.Label();
            this.lblALiftState = new System.Windows.Forms.Label();
            this.lblCLiftState = new System.Windows.Forms.Label();
            this.picB = new System.Windows.Forms.PictureBox();
            this.picC = new System.Windows.Forms.PictureBox();
            this.logBox = new System.Windows.Forms.RichTextBox();

            var lblBTitle = new System.Windows.Forms.Label();
            var lblCTitle = new System.Windows.Forms.Label();
            var lblManual = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.picB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picC)).BeginInit();
            this.SuspendLayout();

            // ── 상단 연결/제어 버튼 ─────────────────────────────────
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Size = new System.Drawing.Size(80, 30);
            this.btnConnect.Text = "연결";
            this.btnConnect.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            this.btnDisconnect.Location = new System.Drawing.Point(102, 12);
            this.btnDisconnect.Size = new System.Drawing.Size(80, 30);
            this.btnDisconnect.Text = "해제";
            this.btnDisconnect.BackColor = System.Drawing.Color.SlateGray;
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);

            this.btnStart.Location = new System.Drawing.Point(220, 12);
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.Text = "▶ 시작";
            this.btnStart.BackColor = System.Drawing.Color.SeaGreen;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            this.btnStop.Location = new System.Drawing.Point(330, 12);
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.Text = "■ 정지";
            this.btnStop.BackColor = System.Drawing.Color.Firebrick;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            this.lblStatus.Location = new System.Drawing.Point(450, 18);
            this.lblStatus.Size = new System.Drawing.Size(200, 20);
            this.lblStatus.Text = "● 연결 안됨";
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);

            // ── B 실린더 영역 ────────────────────────────────────────
            lblBTitle.Location = new System.Drawing.Point(12, 55);
            lblBTitle.Size = new System.Drawing.Size(100, 20);
            lblBTitle.Text = "B 실린더";
            lblBTitle.ForeColor = System.Drawing.Color.Black;
            lblBTitle.BackColor = System.Drawing.Color.Transparent;
            lblBTitle.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);

            this.picB.Location = new System.Drawing.Point(12, 78);
            this.picB.Size = new System.Drawing.Size(300, 80);
            this.picB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picB.BackColor = System.Drawing.Color.White;

            this.lblBState.Location = new System.Drawing.Point(12, 162);
            this.lblBState.Size = new System.Drawing.Size(300, 20);
            this.lblBState.Text = "대기";
            this.lblBState.ForeColor = System.Drawing.Color.Gray;
            this.lblBState.BackColor = System.Drawing.Color.Transparent;
            this.lblBState.Font = new System.Drawing.Font("맑은 고딕", 9f);

            // LiftA 센서
            this.lblSensorA.Location = new System.Drawing.Point(330, 78);
            this.lblSensorA.Size = new System.Drawing.Size(140, 28);
            this.lblSensorA.Text = "리프트 A : OFF";
            this.lblSensorA.ForeColor = System.Drawing.Color.Gray;
            this.lblSensorA.BackColor = System.Drawing.Color.LightGray;
            this.lblSensorA.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.lblSensorA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSensorA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // LiftA 동작 상태
            this.lblALiftState.Location = new System.Drawing.Point(330, 114);
            this.lblALiftState.Size = new System.Drawing.Size(140, 28);
            this.lblALiftState.Text = "대기";
            this.lblALiftState.ForeColor = System.Drawing.Color.Gray;
            this.lblALiftState.BackColor = System.Drawing.Color.LightGray;
            this.lblALiftState.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.lblALiftState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblALiftState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ── C 실린더 영역 ────────────────────────────────────────
            lblCTitle.Location = new System.Drawing.Point(12, 195);
            lblCTitle.Size = new System.Drawing.Size(100, 20);
            lblCTitle.Text = "C 실린더";
            lblCTitle.ForeColor = System.Drawing.Color.Black;
            lblCTitle.BackColor = System.Drawing.Color.Transparent;
            lblCTitle.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);

            this.picC.Location = new System.Drawing.Point(12, 218);
            this.picC.Size = new System.Drawing.Size(300, 80);
            this.picC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picC.BackColor = System.Drawing.Color.White;

            this.lblCState.Location = new System.Drawing.Point(12, 302);
            this.lblCState.Size = new System.Drawing.Size(300, 20);
            this.lblCState.Text = "대기";
            this.lblCState.ForeColor = System.Drawing.Color.Gray;
            this.lblCState.BackColor = System.Drawing.Color.Transparent;
            this.lblCState.Font = new System.Drawing.Font("맑은 고딕", 9f);

            // LiftB 센서
            this.lblSensorB.Location = new System.Drawing.Point(330, 218);
            this.lblSensorB.Size = new System.Drawing.Size(140, 28);
            this.lblSensorB.Text = "리프트 B : OFF";
            this.lblSensorB.ForeColor = System.Drawing.Color.Gray;
            this.lblSensorB.BackColor = System.Drawing.Color.LightGray;
            this.lblSensorB.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.lblSensorB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSensorB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // LiftB 동작 상태
            this.lblCLiftState.Location = new System.Drawing.Point(330, 254);
            this.lblCLiftState.Size = new System.Drawing.Size(140, 28);
            this.lblCLiftState.Text = "대기";
            this.lblCLiftState.ForeColor = System.Drawing.Color.Gray;
            this.lblCLiftState.BackColor = System.Drawing.Color.LightGray;
            this.lblCLiftState.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.lblCLiftState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCLiftState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ── 수동 조작 패널 ───────────────────────────────────────
            lblManual.Location = new System.Drawing.Point(12, 332);
            lblManual.Size = new System.Drawing.Size(630, 20);
            lblManual.Text = "수동 조작";
            lblManual.ForeColor = System.Drawing.Color.DimGray;
            lblManual.BackColor = System.Drawing.Color.Transparent;
            lblManual.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);

            var btnSize = new System.Drawing.Size(72, 28);

            btnLiftAUp = MakeBtn("LiftA ↑", new System.Drawing.Point(12, 356), System.Drawing.Color.DarkSlateBlue, btnSize);
            btnLiftADown = MakeBtn("LiftA ↓", new System.Drawing.Point(90, 356), System.Drawing.Color.SlateBlue, btnSize);
            btnLiftBUp = MakeBtn("LiftB ↑", new System.Drawing.Point(170, 356), System.Drawing.Color.DarkSlateBlue, btnSize);
            btnLiftBDown = MakeBtn("LiftB ↓", new System.Drawing.Point(248, 356), System.Drawing.Color.SlateBlue, btnSize);
            btnBFwd = MakeBtn("B 전진", new System.Drawing.Point(340, 356), System.Drawing.Color.SeaGreen, btnSize);
            btnBBck = MakeBtn("B 후진", new System.Drawing.Point(418, 356), System.Drawing.Color.Gray, btnSize);
            btnCFwd = MakeBtn("C 전진", new System.Drawing.Point(496, 356), System.Drawing.Color.SeaGreen, btnSize);
            btnCBck = MakeBtn("C 후진", new System.Drawing.Point(574, 356), System.Drawing.Color.Gray, btnSize);
            btnAllOff = MakeBtn("전체 OFF", new System.Drawing.Point(480, 390), System.Drawing.Color.Firebrick,
                                   new System.Drawing.Size(168, 28));

            btnLiftAUp.Click += new System.EventHandler(this.btnLiftAUp_Click);
            btnLiftADown.Click += new System.EventHandler(this.btnLiftADown_Click);
            btnLiftBUp.Click += new System.EventHandler(this.btnLiftBUp_Click);
            btnLiftBDown.Click += new System.EventHandler(this.btnLiftBDown_Click);
            btnBFwd.Click += new System.EventHandler(this.btnBFwd_Click);
            btnBBck.Click += new System.EventHandler(this.btnBBck_Click);
            btnCFwd.Click += new System.EventHandler(this.btnCFwd_Click);
            btnCBck.Click += new System.EventHandler(this.btnCBck_Click);
            btnAllOff.Click += new System.EventHandler(this.btnAllOff_Click);

            // ── 로그박스 ─────────────────────────────────────────────
            this.logBox.Location = new System.Drawing.Point(12, 430);
            this.logBox.Size = new System.Drawing.Size(630, 110);
            this.logBox.ReadOnly = true;
            this.logBox.BackColor = System.Drawing.Color.Black;
            this.logBox.ForeColor = System.Drawing.Color.Lime;
            this.logBox.Font = new System.Drawing.Font("Consolas", 8.5f);
            this.logBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // ── Form ─────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(660, 555);
            this.BackColor = System.Drawing.Color.White;
            this.Text = "자동 실린더 제어";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(lblBTitle);
            this.Controls.Add(this.picB);
            this.Controls.Add(this.lblBState);
            this.Controls.Add(this.lblSensorA);
            this.Controls.Add(this.lblALiftState);
            this.Controls.Add(lblCTitle);
            this.Controls.Add(this.picC);
            this.Controls.Add(this.lblCState);
            this.Controls.Add(this.lblSensorB);
            this.Controls.Add(this.lblCLiftState);
            this.Controls.Add(lblManual);
            this.Controls.Add(this.btnLiftAUp);
            this.Controls.Add(this.btnLiftADown);
            this.Controls.Add(this.btnLiftBUp);
            this.Controls.Add(this.btnLiftBDown);
            this.Controls.Add(this.btnBFwd);
            this.Controls.Add(this.btnBBck);
            this.Controls.Add(this.btnCFwd);
            this.Controls.Add(this.btnCBck);
            this.Controls.Add(this.btnAllOff);
            this.Controls.Add(this.logBox);

            ((System.ComponentModel.ISupportInitialize)(this.picB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picC)).EndInit();
            this.ResumeLayout(false);
        }

        // ── 필드 선언 ────────────────────────────────────────────────
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblBState;
        private System.Windows.Forms.Label lblCState;
        private System.Windows.Forms.Label lblSensorA;
        private System.Windows.Forms.Label lblSensorB;
        private System.Windows.Forms.Label lblALiftState;
        private System.Windows.Forms.Label lblCLiftState;
        private System.Windows.Forms.PictureBox picB;
        private System.Windows.Forms.PictureBox picC;
        private System.Windows.Forms.RichTextBox logBox;

        private System.Windows.Forms.Button btnLiftAUp;
        private System.Windows.Forms.Button btnLiftADown;
        private System.Windows.Forms.Button btnLiftBUp;
        private System.Windows.Forms.Button btnLiftBDown;
        private System.Windows.Forms.Button btnBFwd;
        private System.Windows.Forms.Button btnBBck;
        private System.Windows.Forms.Button btnCFwd;
        private System.Windows.Forms.Button btnCBck;
        private System.Windows.Forms.Button btnAllOff;
    }
}