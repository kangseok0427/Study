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
            this.picB = new System.Windows.Forms.PictureBox();
            this.picC = new System.Windows.Forms.PictureBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            var lblBTitle = new System.Windows.Forms.Label();
            var lblCTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picC)).BeginInit();
            this.SuspendLayout();

            // btnConnect
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Size = new System.Drawing.Size(80, 30);
            this.btnConnect.Text = "연결";
            this.btnConnect.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            // btnDisconnect
            this.btnDisconnect.Location = new System.Drawing.Point(102, 12);
            this.btnDisconnect.Size = new System.Drawing.Size(80, 30);
            this.btnDisconnect.Text = "해제";
            this.btnDisconnect.BackColor = System.Drawing.Color.SlateGray;
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(220, 12);
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.Text = "▶ 시작";
            this.btnStart.BackColor = System.Drawing.Color.SeaGreen;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // btnStop
            this.btnStop.Location = new System.Drawing.Point(330, 12);
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.Text = "■ 정지";
            this.btnStop.BackColor = System.Drawing.Color.Firebrick;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(450, 18);
            this.lblStatus.Size = new System.Drawing.Size(200, 20);
            this.lblStatus.Text = "● 연결 안됨";
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);

            // lblBTitle
            lblBTitle.Location = new System.Drawing.Point(12, 55);
            lblBTitle.Size = new System.Drawing.Size(100, 20);
            lblBTitle.Text = "B 실린더";
            lblBTitle.ForeColor = System.Drawing.Color.White;
            lblBTitle.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            lblBTitle.BackColor = System.Drawing.Color.Transparent;

            // picB
            this.picB.Location = new System.Drawing.Point(12, 78);
            this.picB.Size = new System.Drawing.Size(300, 80);
            this.picB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picB.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // lblBState
            this.lblBState.Location = new System.Drawing.Point(12, 162);
            this.lblBState.Size = new System.Drawing.Size(300, 20);
            this.lblBState.Text = "대기";
            this.lblBState.ForeColor = System.Drawing.Color.Silver;
            this.lblBState.BackColor = System.Drawing.Color.Transparent;
            this.lblBState.Font = new System.Drawing.Font("맑은 고딕", 9f);

            // lblSensorA
            this.lblSensorA.Location = new System.Drawing.Point(330, 100);
            this.lblSensorA.Size = new System.Drawing.Size(140, 28);
            this.lblSensorA.Text = "리프트 A : OFF";
            this.lblSensorA.ForeColor = System.Drawing.Color.Silver;
            this.lblSensorA.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblSensorA.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.lblSensorA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSensorA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblCTitle
            lblCTitle.Location = new System.Drawing.Point(12, 195);
            lblCTitle.Size = new System.Drawing.Size(100, 20);
            lblCTitle.Text = "C 실린더";
            lblCTitle.ForeColor = System.Drawing.Color.White;
            lblCTitle.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            lblCTitle.BackColor = System.Drawing.Color.Transparent;

            // picC
            this.picC.Location = new System.Drawing.Point(12, 218);
            this.picC.Size = new System.Drawing.Size(300, 80);
            this.picC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picC.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // lblCState
            this.lblCState.Location = new System.Drawing.Point(12, 302);
            this.lblCState.Size = new System.Drawing.Size(300, 20);
            this.lblCState.Text = "대기";
            this.lblCState.ForeColor = System.Drawing.Color.Silver;
            this.lblCState.BackColor = System.Drawing.Color.Transparent;
            this.lblCState.Font = new System.Drawing.Font("맑은 고딕", 9f);

            // lblSensorB
            this.lblSensorB.Location = new System.Drawing.Point(330, 240);
            this.lblSensorB.Size = new System.Drawing.Size(140, 28);
            this.lblSensorB.Text = "리프트 B : OFF";
            this.lblSensorB.ForeColor = System.Drawing.Color.Silver;
            this.lblSensorB.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblSensorB.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
            this.lblSensorB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSensorB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // logBox
            this.logBox.Location = new System.Drawing.Point(12, 335);
            this.logBox.Size = new System.Drawing.Size(630, 100);
            this.logBox.ReadOnly = true;
            this.logBox.BackColor = System.Drawing.Color.Black;
            this.logBox.ForeColor = System.Drawing.Color.Lime;
            this.logBox.Font = new System.Drawing.Font("Consolas", 8.5f);
            this.logBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Form
            this.ClientSize = new System.Drawing.Size(660, 450);
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
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
            this.Controls.Add(lblCTitle);
            this.Controls.Add(this.picC);
            this.Controls.Add(this.lblCState);
            this.Controls.Add(this.lblSensorB);
            this.Controls.Add(this.logBox);

            ((System.ComponentModel.ISupportInitialize)(this.picB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picC)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblBState;
        private System.Windows.Forms.Label lblCState;
        private System.Windows.Forms.Label lblSensorA;
        private System.Windows.Forms.Label lblSensorB;
        private System.Windows.Forms.PictureBox picB;
        private System.Windows.Forms.PictureBox picC;
        private System.Windows.Forms.RichTextBox logBox;
    }
}