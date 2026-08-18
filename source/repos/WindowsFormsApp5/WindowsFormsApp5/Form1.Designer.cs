namespace WindowsFormsApp5
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
            this.lblAutoStatus = new System.Windows.Forms.Label();
            this.lblXA = new System.Windows.Forms.Label();
            this.lblXB = new System.Windows.Forms.Label();
            this.lblX02 = new System.Windows.Forms.Label();
            this.lblX03 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(0, 0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(81, 0);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "해제";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(162, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(243, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "정지";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // lblAutoStatus
            // 
            this.lblAutoStatus.AutoSize = true;
            this.lblAutoStatus.Location = new System.Drawing.Point(325, 10);
            this.lblAutoStatus.Name = "lblAutoStatus";
            this.lblAutoStatus.Size = new System.Drawing.Size(29, 12);
            this.lblAutoStatus.TabIndex = 4;
            this.lblAutoStatus.Text = "대기";
            // 
            // lblXA
            // 
            this.lblXA.AutoSize = true;
            this.lblXA.BackColor = System.Drawing.Color.DimGray;
            this.lblXA.ForeColor = System.Drawing.Color.White;
            this.lblXA.Location = new System.Drawing.Point(13, 30);
            this.lblXA.Name = "lblXA";
            this.lblXA.Size = new System.Drawing.Size(107, 12);
            this.lblXA.TabIndex = 5;
            this.lblXA.Text = "리프트센서 A (XA)";
            // 
            // lblXB
            // 
            this.lblXB.AutoSize = true;
            this.lblXB.BackColor = System.Drawing.Color.DimGray;
            this.lblXB.ForeColor = System.Drawing.Color.White;
            this.lblXB.Location = new System.Drawing.Point(13, 61);
            this.lblXB.Name = "lblXB";
            this.lblXB.Size = new System.Drawing.Size(107, 12);
            this.lblXB.TabIndex = 6;
            this.lblXB.Text = "리프트센서 B (XB)";
            // 
            // lblX02
            // 
            this.lblX02.AutoSize = true;
            this.lblX02.BackColor = System.Drawing.Color.DimGray;
            this.lblX02.ForeColor = System.Drawing.Color.White;
            this.lblX02.Location = new System.Drawing.Point(13, 90);
            this.lblX02.Name = "lblX02";
            this.lblX02.Size = new System.Drawing.Size(85, 12);
            this.lblX02.TabIndex = 7;
            this.lblX02.Text = "B후진완료 X02";
            // 
            // lblX03
            // 
            this.lblX03.AutoSize = true;
            this.lblX03.BackColor = System.Drawing.Color.DimGray;
            this.lblX03.ForeColor = System.Drawing.Color.White;
            this.lblX03.Location = new System.Drawing.Point(13, 123);
            this.lblX03.Name = "lblX03";
            this.lblX03.Size = new System.Drawing.Size(85, 12);
            this.lblX03.TabIndex = 8;
            this.lblX03.Text = "B전진완료 X03";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.lblX03);
            this.Controls.Add(this.lblX02);
            this.Controls.Add(this.lblXB);
            this.Controls.Add(this.lblXA);
            this.Controls.Add(this.lblAutoStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblAutoStatus;
        private System.Windows.Forms.Label lblXA;
        private System.Windows.Forms.Label lblXB;
        private System.Windows.Forms.Label lblX02;
        private System.Windows.Forms.Label lblX03;
    }
}

