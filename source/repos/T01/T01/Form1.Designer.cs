namespace T01
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
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.picB = new System.Windows.Forms.PictureBox();
            this.picC = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(22, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 48);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "button1";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(103, 12);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 49);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "button2";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(184, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 48);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "button3";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(265, 13);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 48);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "button4";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(346, 31);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 12);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "label1";
            // 
            // lblBState
            // 
            this.lblBState.AutoSize = true;
            this.lblBState.Location = new System.Drawing.Point(20, 316);
            this.lblBState.Name = "lblBState";
            this.lblBState.Size = new System.Drawing.Size(38, 12);
            this.lblBState.TabIndex = 5;
            this.lblBState.Text = "label2";
            // 
            // lblCState
            // 
            this.lblCState.AutoSize = true;
            this.lblCState.Location = new System.Drawing.Point(101, 316);
            this.lblCState.Name = "lblCState";
            this.lblCState.Size = new System.Drawing.Size(38, 12);
            this.lblCState.TabIndex = 6;
            this.lblCState.Text = "label3";
            // 
            // lblSensorA
            // 
            this.lblSensorA.AutoSize = true;
            this.lblSensorA.Location = new System.Drawing.Point(182, 316);
            this.lblSensorA.Name = "lblSensorA";
            this.lblSensorA.Size = new System.Drawing.Size(38, 12);
            this.lblSensorA.TabIndex = 7;
            this.lblSensorA.Text = "label4";
            // 
            // lblSensorB
            // 
            this.lblSensorB.AutoSize = true;
            this.lblSensorB.Location = new System.Drawing.Point(263, 316);
            this.lblSensorB.Name = "lblSensorB";
            this.lblSensorB.Size = new System.Drawing.Size(38, 12);
            this.lblSensorB.TabIndex = 8;
            this.lblSensorB.Text = "label5";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(22, 342);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(397, 96);
            this.logBox.TabIndex = 9;
            this.logBox.Text = "";
            // 
            // picB
            // 
            this.picB.Location = new System.Drawing.Point(24, 88);
            this.picB.Name = "picB";
            this.picB.Size = new System.Drawing.Size(360, 91);
            this.picB.TabIndex = 10;
            this.picB.TabStop = false;
            // 
            // picC
            // 
            this.picC.Location = new System.Drawing.Point(22, 185);
            this.picC.Name = "picC";
            this.picC.Size = new System.Drawing.Size(362, 91);
            this.picC.TabIndex = 11;
            this.picC.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 450);
            this.Controls.Add(this.picC);
            this.Controls.Add(this.picB);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.lblSensorB);
            this.Controls.Add(this.lblSensorA);
            this.Controls.Add(this.lblCState);
            this.Controls.Add(this.lblBState);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Label lblBState;
        private System.Windows.Forms.Label lblCState;
        private System.Windows.Forms.Label lblSensorA;
        private System.Windows.Forms.Label lblSensorB;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.PictureBox picB;
        private System.Windows.Forms.PictureBox picC;
    }
}

