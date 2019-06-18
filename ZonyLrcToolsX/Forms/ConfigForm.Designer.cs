namespace ZonyLrcToolsX.Forms
{
    partial class ConfigForm
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
            this.groupBox_DownloadConfig = new System.Windows.Forms.GroupBox();
            this.comboBox_LyricFileEncoding = new System.Windows.Forms.ComboBox();
            this.label_LyricFileEncoding = new System.Windows.Forms.Label();
            this.textBox_ProxyPort = new System.Windows.Forms.TextBox();
            this.label_ProxyPort = new System.Windows.Forms.Label();
            this.textBox_ProxyIp = new System.Windows.Forms.TextBox();
            this.label_ProxyIp = new System.Windows.Forms.Label();
            this.checkBox_IsEnableProxy = new System.Windows.Forms.CheckBox();
            this.checkBox_IsCoverSourceLyricFile = new System.Windows.Forms.CheckBox();
            this.textBox_SuffixName = new System.Windows.Forms.TextBox();
            this.label_SuffixName = new System.Windows.Forms.Label();
            this.groupBox_ProgramConfig = new System.Windows.Forms.GroupBox();
            this.checkBox_IsAutoCheckUpdate = new System.Windows.Forms.CheckBox();
            this.button_SaveChanges = new System.Windows.Forms.Button();
            this.groupBox_DownloadConfig.SuspendLayout();
            this.groupBox_ProgramConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_DownloadConfig
            // 
            this.groupBox_DownloadConfig.Controls.Add(this.comboBox_LyricFileEncoding);
            this.groupBox_DownloadConfig.Controls.Add(this.label_LyricFileEncoding);
            this.groupBox_DownloadConfig.Controls.Add(this.textBox_ProxyPort);
            this.groupBox_DownloadConfig.Controls.Add(this.label_ProxyPort);
            this.groupBox_DownloadConfig.Controls.Add(this.textBox_ProxyIp);
            this.groupBox_DownloadConfig.Controls.Add(this.label_ProxyIp);
            this.groupBox_DownloadConfig.Controls.Add(this.checkBox_IsEnableProxy);
            this.groupBox_DownloadConfig.Controls.Add(this.checkBox_IsCoverSourceLyricFile);
            this.groupBox_DownloadConfig.Controls.Add(this.textBox_SuffixName);
            this.groupBox_DownloadConfig.Controls.Add(this.label_SuffixName);
            this.groupBox_DownloadConfig.Location = new System.Drawing.Point(12, 78);
            this.groupBox_DownloadConfig.Name = "groupBox_DownloadConfig";
            this.groupBox_DownloadConfig.Size = new System.Drawing.Size(414, 214);
            this.groupBox_DownloadConfig.TabIndex = 0;
            this.groupBox_DownloadConfig.TabStop = false;
            this.groupBox_DownloadConfig.Text = "下载设置";
            // 
            // comboBox_LyricFileEncoding
            // 
            this.comboBox_LyricFileEncoding.FormattingEnabled = true;
            this.comboBox_LyricFileEncoding.Location = new System.Drawing.Point(142, 175);
            this.comboBox_LyricFileEncoding.Name = "comboBox_LyricFileEncoding";
            this.comboBox_LyricFileEncoding.Size = new System.Drawing.Size(254, 25);
            this.comboBox_LyricFileEncoding.TabIndex = 7;
            // 
            // label_LyricFileEncoding
            // 
            this.label_LyricFileEncoding.AutoSize = true;
            this.label_LyricFileEncoding.Location = new System.Drawing.Point(6, 178);
            this.label_LyricFileEncoding.Name = "label_LyricFileEncoding";
            this.label_LyricFileEncoding.Size = new System.Drawing.Size(119, 17);
            this.label_LyricFileEncoding.TabIndex = 0;
            this.label_LyricFileEncoding.Text = "歌词文件编码:";
            // 
            // textBox_ProxyPort
            // 
            this.textBox_ProxyPort.Location = new System.Drawing.Point(142, 142);
            this.textBox_ProxyPort.Name = "textBox_ProxyPort";
            this.textBox_ProxyPort.Size = new System.Drawing.Size(254, 27);
            this.textBox_ProxyPort.TabIndex = 6;
            // 
            // label_ProxyPort
            // 
            this.label_ProxyPort.AutoSize = true;
            this.label_ProxyPort.Location = new System.Drawing.Point(6, 145);
            this.label_ProxyPort.Name = "label_ProxyPort";
            this.label_ProxyPort.Size = new System.Drawing.Size(85, 17);
            this.label_ProxyPort.TabIndex = 0;
            this.label_ProxyPort.Text = "代理端口:";
            // 
            // textBox_ProxyIp
            // 
            this.textBox_ProxyIp.Location = new System.Drawing.Point(142, 109);
            this.textBox_ProxyIp.Name = "textBox_ProxyIp";
            this.textBox_ProxyIp.Size = new System.Drawing.Size(254, 27);
            this.textBox_ProxyIp.TabIndex = 5;
            // 
            // label_ProxyIp
            // 
            this.label_ProxyIp.AutoSize = true;
            this.label_ProxyIp.Location = new System.Drawing.Point(6, 112);
            this.label_ProxyIp.Name = "label_ProxyIp";
            this.label_ProxyIp.Size = new System.Drawing.Size(136, 17);
            this.label_ProxyIp.TabIndex = 0;
            this.label_ProxyIp.Text = "代理服务器地址:";
            // 
            // checkBox_IsEnableProxy
            // 
            this.checkBox_IsEnableProxy.AutoSize = true;
            this.checkBox_IsEnableProxy.Location = new System.Drawing.Point(9, 86);
            this.checkBox_IsEnableProxy.Name = "checkBox_IsEnableProxy";
            this.checkBox_IsEnableProxy.Size = new System.Drawing.Size(132, 21);
            this.checkBox_IsEnableProxy.TabIndex = 4;
            this.checkBox_IsEnableProxy.Text = "启用网络代理";
            this.checkBox_IsEnableProxy.UseVisualStyleBackColor = true;
            this.checkBox_IsEnableProxy.CheckedChanged += new System.EventHandler(this.CheckBox_IsEnableProxy_CheckedChanged);
            // 
            // checkBox_IsCoverSourceLyricFile
            // 
            this.checkBox_IsCoverSourceLyricFile.AutoSize = true;
            this.checkBox_IsCoverSourceLyricFile.Location = new System.Drawing.Point(9, 59);
            this.checkBox_IsCoverSourceLyricFile.Name = "checkBox_IsCoverSourceLyricFile";
            this.checkBox_IsCoverSourceLyricFile.Size = new System.Drawing.Size(132, 21);
            this.checkBox_IsCoverSourceLyricFile.TabIndex = 3;
            this.checkBox_IsCoverSourceLyricFile.Text = "覆盖歌词文件";
            this.checkBox_IsCoverSourceLyricFile.UseVisualStyleBackColor = true;
            // 
            // textBox_SuffixName
            // 
            this.textBox_SuffixName.Location = new System.Drawing.Point(114, 26);
            this.textBox_SuffixName.Name = "textBox_SuffixName";
            this.textBox_SuffixName.Size = new System.Drawing.Size(282, 27);
            this.textBox_SuffixName.TabIndex = 2;
            // 
            // label_SuffixName
            // 
            this.label_SuffixName.AutoSize = true;
            this.label_SuffixName.Location = new System.Drawing.Point(6, 29);
            this.label_SuffixName.Name = "label_SuffixName";
            this.label_SuffixName.Size = new System.Drawing.Size(102, 17);
            this.label_SuffixName.TabIndex = 0;
            this.label_SuffixName.Text = "后缀名定义:";
            // 
            // groupBox_ProgramConfig
            // 
            this.groupBox_ProgramConfig.Controls.Add(this.checkBox_IsAutoCheckUpdate);
            this.groupBox_ProgramConfig.Location = new System.Drawing.Point(12, 12);
            this.groupBox_ProgramConfig.Name = "groupBox_ProgramConfig";
            this.groupBox_ProgramConfig.Size = new System.Drawing.Size(414, 60);
            this.groupBox_ProgramConfig.TabIndex = 0;
            this.groupBox_ProgramConfig.TabStop = false;
            this.groupBox_ProgramConfig.Text = "程序设置";
            // 
            // checkBox_IsAutoCheckUpdate
            // 
            this.checkBox_IsAutoCheckUpdate.AutoSize = true;
            this.checkBox_IsAutoCheckUpdate.Location = new System.Drawing.Point(9, 26);
            this.checkBox_IsAutoCheckUpdate.Name = "checkBox_IsAutoCheckUpdate";
            this.checkBox_IsAutoCheckUpdate.Size = new System.Drawing.Size(132, 21);
            this.checkBox_IsAutoCheckUpdate.TabIndex = 1;
            this.checkBox_IsAutoCheckUpdate.Text = "自动检查更新";
            this.checkBox_IsAutoCheckUpdate.UseVisualStyleBackColor = true;
            this.checkBox_IsAutoCheckUpdate.CheckedChanged += new System.EventHandler(this.CheckBox_IsAutoCheckUpdate_CheckedChanged);
            // 
            // button_SaveChanges
            // 
            this.button_SaveChanges.Location = new System.Drawing.Point(154, 298);
            this.button_SaveChanges.Name = "button_SaveChanges";
            this.button_SaveChanges.Size = new System.Drawing.Size(131, 47);
            this.button_SaveChanges.TabIndex = 8;
            this.button_SaveChanges.Text = "保存并应用";
            this.button_SaveChanges.UseVisualStyleBackColor = true;
            this.button_SaveChanges.Click += new System.EventHandler(this.Button_SaveChanges_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 354);
            this.Controls.Add(this.button_SaveChanges);
            this.Controls.Add(this.groupBox_ProgramConfig);
            this.Controls.Add(this.groupBox_DownloadConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件设置";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.groupBox_DownloadConfig.ResumeLayout(false);
            this.groupBox_DownloadConfig.PerformLayout();
            this.groupBox_ProgramConfig.ResumeLayout(false);
            this.groupBox_ProgramConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox_DownloadConfig;
        private System.Windows.Forms.TextBox textBox_SuffixName;
        private System.Windows.Forms.Label label_SuffixName;
        private System.Windows.Forms.GroupBox groupBox_ProgramConfig;
        private System.Windows.Forms.CheckBox checkBox_IsAutoCheckUpdate;
        private System.Windows.Forms.CheckBox checkBox_IsCoverSourceLyricFile;
        private System.Windows.Forms.CheckBox checkBox_IsEnableProxy;
        private System.Windows.Forms.Label label_ProxyIp;
        private System.Windows.Forms.TextBox textBox_ProxyIp;
        private System.Windows.Forms.Label label_ProxyPort;
        private System.Windows.Forms.TextBox textBox_ProxyPort;
        private System.Windows.Forms.Label label_LyricFileEncoding;
        private System.Windows.Forms.ComboBox comboBox_LyricFileEncoding;
        private System.Windows.Forms.Button button_SaveChanges;
    }
}