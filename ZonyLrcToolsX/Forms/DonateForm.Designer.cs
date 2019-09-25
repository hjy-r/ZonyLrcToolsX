namespace ZonyLrcToolsX.Forms
{
    partial class DonateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_WechatPay = new System.Windows.Forms.PictureBox();
            this.pictureBox_Alipay = new System.Windows.Forms.PictureBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Exit2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WechatPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Alipay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1180, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "如果您觉得本工具帮助到您了，可以选择捐赠作者来让工具更加完善，作者也十分感谢您的支持。\r\n留卡号，心意钱，打多打少是个缘。";
            // 
            // pictureBox_WechatPay
            // 
            this.pictureBox_WechatPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_WechatPay.Location = new System.Drawing.Point(20, 61);
            this.pictureBox_WechatPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_WechatPay.Name = "pictureBox_WechatPay";
            this.pictureBox_WechatPay.Size = new System.Drawing.Size(501, 775);
            this.pictureBox_WechatPay.TabIndex = 2;
            this.pictureBox_WechatPay.TabStop = false;
            // 
            // pictureBox_Alipay
            // 
            this.pictureBox_Alipay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Alipay.Location = new System.Drawing.Point(551, 61);
            this.pictureBox_Alipay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_Alipay.Name = "pictureBox_Alipay";
            this.pictureBox_Alipay.Size = new System.Drawing.Size(501, 775);
            this.pictureBox_Alipay.TabIndex = 1;
            this.pictureBox_Alipay.TabStop = false;
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(264, 859);
            this.button_Exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(257, 55);
            this.button_Exit.TabIndex = 3;
            this.button_Exit.Text = "软件不错，给包烟钱";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // button_Exit2
            // 
            this.button_Exit2.Location = new System.Drawing.Point(551, 859);
            this.button_Exit2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Exit2.Name = "button_Exit2";
            this.button_Exit2.Size = new System.Drawing.Size(257, 55);
            this.button_Exit2.TabIndex = 4;
            this.button_Exit2.Text = "我也穷，下次一定";
            this.button_Exit2.UseVisualStyleBackColor = true;
            this.button_Exit2.Click += new System.EventHandler(this.Button_Exit2_Click);
            // 
            // DonateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 929);
            this.Controls.Add(this.button_Exit2);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.pictureBox_WechatPay);
            this.Controls.Add(this.pictureBox_Alipay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DonateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "捐赠作者";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WechatPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Alipay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_Alipay;
        private System.Windows.Forms.PictureBox pictureBox_WechatPay;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Exit2;
    }
}