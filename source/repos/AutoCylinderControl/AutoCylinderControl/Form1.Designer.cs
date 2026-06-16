namespace AutoCylinderControl
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.picB = new System.Windows.Forms.PictureBox();
            this.picC = new System.Windows.Forms.PictureBox();
            this.lblBState = new System.Windows.Forms.Label();
            this.lblCState = new System.Windows.Forms.Label();
            this.lblSensorA = new System.Windows.Forms.Label();
            this.lblSensorB = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 32);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click_1);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(93, 12);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 32);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "해제";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(174, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 32);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(255, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 32);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "정지";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click_1);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(347, 22);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 12);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "label2";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // picB
            // 
            this.picB.Location = new System.Drawing.Point(14, 50);
            this.picB.Name = "picB";
            this.picB.Size = new System.Drawing.Size(433, 88);
            this.picB.TabIndex = 6;
            this.picB.TabStop = false;
            // 
            // picC
            // 
            this.picC.Location = new System.Drawing.Point(14, 144);
            this.picC.Name = "picC";
            this.picC.Size = new System.Drawing.Size(435, 87);
            this.picC.TabIndex = 7;
            this.picC.TabStop = false;
            // 
            // lblBState
            // 
            this.lblBState.AutoSize = true;
            this.lblBState.Location = new System.Drawing.Point(15, 246);
            this.lblBState.Name = "lblBState";
            this.lblBState.Size = new System.Drawing.Size(38, 12);
            this.lblBState.TabIndex = 8;
            this.lblBState.Text = "label3";
            // 
            // lblCState
            // 
            this.lblCState.AutoSize = true;
            this.lblCState.Location = new System.Drawing.Point(91, 246);
            this.lblCState.Name = "lblCState";
            this.lblCState.Size = new System.Drawing.Size(38, 12);
            this.lblCState.TabIndex = 9;
            this.lblCState.Text = "label4";
            // 
            // lblSensorA
            // 
            this.lblSensorA.AutoSize = true;
            this.lblSensorA.Location = new System.Drawing.Point(172, 246);
            this.lblSensorA.Name = "lblSensorA";
            this.lblSensorA.Size = new System.Drawing.Size(38, 12);
            this.lblSensorA.TabIndex = 10;
            this.lblSensorA.Text = "label5";
            // 
            // lblSensorB
            // 
            this.lblSensorB.AutoSize = true;
            this.lblSensorB.Location = new System.Drawing.Point(253, 246);
            this.lblSensorB.Name = "lblSensorB";
            this.lblSensorB.Size = new System.Drawing.Size(38, 12);
            this.lblSensorB.TabIndex = 11;
            this.lblSensorB.Text = "label6";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(12, 272);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(437, 73);
            this.logBox.TabIndex = 12;
            this.logBox.Text = "";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(594, 357);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.lblSensorB);
            this.Controls.Add(this.lblSensorA);
            this.Controls.Add(this.lblCState);
            this.Controls.Add(this.lblBState);
            this.Controls.Add(this.picC);
            this.Controls.Add(this.picB);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

}

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox picB;
        private System.Windows.Forms.PictureBox picC;
        private System.Windows.Forms.Label lblBState;
        private System.Windows.Forms.Label lblCState;
        private System.Windows.Forms.Label lblSensorA;
        private System.Windows.Forms.Label lblSensorB;
        private System.Windows.Forms.RichTextBox logBox;
    }
}

