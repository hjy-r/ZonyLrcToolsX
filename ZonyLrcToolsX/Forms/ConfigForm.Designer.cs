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
            this.button_Mp3TagPath = new System.Windows.Forms.Button();
            this.textBox_Mp3TagPath = new System.Windows.Forms.TextBox();
            this.label_Mp3TagPath = new System.Windows.Forms.Label();
            this.numericUpDown_DownloadThreadNumber = new System.Windows.Forms.NumericUpDown();
            this.label_DownloadThreadNumber = new System.Windows.Forms.Label();
            this.textBox_ProxyPort = new System.Windows.Forms.TextBox();
            this.label_ProxyPort = new System.Windows.Forms.Label();
            this.textBox_ProxyIp = new System.Windows.Forms.TextBox();
            this.label_ProxyIp = new System.Windows.Forms.Label();
            this.checkBox_IsEnableProxy = new System.Windows.Forms.CheckBox();
            this.textBox_SuffixName = new System.Windows.Forms.TextBox();
            this.label_SuffixName = new System.Windows.Forms.Label();
            this.groupBox_ProgramConfig = new System.Windows.Forms.GroupBox();
            this.checkBox_IsAutoCheckUpdate = new System.Windows.Forms.CheckBox();
            this.button_SaveChanges = new System.Windows.Forms.Button();
            this.groupBox_LyricConfig = new System.Windows.Forms.GroupBox();
            this.comboBox_LineBreak = new System.Windows.Forms.ComboBox();
            this.label_LineBreak = new System.Windows.Forms.Label();
            this.comboBox_LyricDownloader = new System.Windows.Forms.ComboBox();
            this.label_LyricDownloader = new System.Windows.Forms.Label();
            this.comboBox_LyricContentType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_IsCoverSourceLyricFile = new System.Windows.Forms.CheckBox();
            this.comboBox_LyricFileEncoding = new System.Windows.Forms.ComboBox();
            this.label_LyricFileEncoding = new System.Windows.Forms.Label();
            this.groupBox_DownloadConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DownloadThreadNumber)).BeginInit();
            this.groupBox_ProgramConfig.SuspendLayout();
            this.groupBox_LyricConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_DownloadConfig
            // 
            this.groupBox_DownloadConfig.Controls.Add(this.button_Mp3TagPath);
            this.groupBox_DownloadConfig.Controls.Add(this.textBox_Mp3TagPath);
            this.groupBox_DownloadConfig.Controls.Add(this.label_Mp3TagPath);
            this.groupBox_DownloadConfig.Controls.Add(this.numericUpDown_DownloadThreadNumber);
            this.groupBox_DownloadConfig.Controls.Add(this.label_DownloadThreadNumber);
            this.groupBox_DownloadConfig.Controls.Add(this.textBox_ProxyPort);
            this.groupBox_DownloadConfig.Controls.Add(this.label_ProxyPort);
            this.groupBox_DownloadConfig.Controls.Add(this.textBox_ProxyIp);
            this.groupBox_DownloadConfig.Controls.Add(this.label_ProxyIp);
            this.groupBox_DownloadConfig.Controls.Add(this.checkBox_IsEnableProxy);
            this.groupBox_DownloadConfig.Controls.Add(this.textBox_SuffixName);
            this.groupBox_DownloadConfig.Controls.Add(this.label_SuffixName);
            this.groupBox_DownloadConfig.Location = new System.Drawing.Point(16, 112);
            this.groupBox_DownloadConfig.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_DownloadConfig.Name = "groupBox_DownloadConfig";
            this.groupBox_DownloadConfig.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_DownloadConfig.Size = new System.Drawing.Size(552, 316);
            this.groupBox_DownloadConfig.TabIndex = 0;
            this.groupBox_DownloadConfig.TabStop = false;
            this.groupBox_DownloadConfig.Text = "下载设置";
            // 
            // button_Mp3TagPath
            // 
            this.button_Mp3TagPath.Location = new System.Drawing.Point(444, 260);
            this.button_Mp3TagPath.Margin = new System.Windows.Forms.Padding(6);
            this.button_Mp3TagPath.Name = "button_Mp3TagPath";
            this.button_Mp3TagPath.Size = new System.Drawing.Size(88, 46);
            this.button_Mp3TagPath.TabIndex = 20;
            this.button_Mp3TagPath.Text = "...";
            this.button_Mp3TagPath.UseVisualStyleBackColor = true;
            this.button_Mp3TagPath.Click += new System.EventHandler(this.Button_Mp3TagPath_Click);
            // 
            // textBox_Mp3TagPath
            // 
            this.textBox_Mp3TagPath.Location = new System.Drawing.Point(170, 262);
            this.textBox_Mp3TagPath.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Mp3TagPath.Name = "textBox_Mp3TagPath";
            this.textBox_Mp3TagPath.Size = new System.Drawing.Size(260, 35);
            this.textBox_Mp3TagPath.TabIndex = 19;
            // 
            // label_Mp3TagPath
            // 
            this.label_Mp3TagPath.AutoSize = true;
            this.label_Mp3TagPath.Location = new System.Drawing.Point(8, 268);
            this.label_Mp3TagPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Mp3TagPath.Name = "label_Mp3TagPath";
            this.label_Mp3TagPath.Size = new System.Drawing.Size(154, 24);
            this.label_Mp3TagPath.TabIndex = 18;
            this.label_Mp3TagPath.Text = "Mp3Tag 路径:";
            // 
            // numericUpDown_DownloadThreadNumber
            // 
            this.numericUpDown_DownloadThreadNumber.Location = new System.Drawing.Point(208, 212);
            this.numericUpDown_DownloadThreadNumber.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_DownloadThreadNumber.Name = "numericUpDown_DownloadThreadNumber";
            this.numericUpDown_DownloadThreadNumber.Size = new System.Drawing.Size(226, 35);
            this.numericUpDown_DownloadThreadNumber.TabIndex = 17;
            this.numericUpDown_DownloadThreadNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_DownloadThreadNumber
            // 
            this.label_DownloadThreadNumber.AutoSize = true;
            this.label_DownloadThreadNumber.Location = new System.Drawing.Point(8, 216);
            this.label_DownloadThreadNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_DownloadThreadNumber.Name = "label_DownloadThreadNumber";
            this.label_DownloadThreadNumber.Size = new System.Drawing.Size(118, 24);
            this.label_DownloadThreadNumber.TabIndex = 0;
            this.label_DownloadThreadNumber.Text = "下载线程:";
            // 
            // textBox_ProxyPort
            // 
            this.textBox_ProxyPort.Location = new System.Drawing.Point(208, 162);
            this.textBox_ProxyPort.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ProxyPort.Name = "textBox_ProxyPort";
            this.textBox_ProxyPort.Size = new System.Drawing.Size(320, 35);
            this.textBox_ProxyPort.TabIndex = 6;
            // 
            // label_ProxyPort
            // 
            this.label_ProxyPort.AutoSize = true;
            this.label_ProxyPort.Location = new System.Drawing.Point(8, 168);
            this.label_ProxyPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProxyPort.Name = "label_ProxyPort";
            this.label_ProxyPort.Size = new System.Drawing.Size(118, 24);
            this.label_ProxyPort.TabIndex = 0;
            this.label_ProxyPort.Text = "代理端口:";
            // 
            // textBox_ProxyIp
            // 
            this.textBox_ProxyIp.Location = new System.Drawing.Point(208, 116);
            this.textBox_ProxyIp.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ProxyIp.Name = "textBox_ProxyIp";
            this.textBox_ProxyIp.Size = new System.Drawing.Size(320, 35);
            this.textBox_ProxyIp.TabIndex = 5;
            // 
            // label_ProxyIp
            // 
            this.label_ProxyIp.AutoSize = true;
            this.label_ProxyIp.Location = new System.Drawing.Point(8, 120);
            this.label_ProxyIp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProxyIp.Name = "label_ProxyIp";
            this.label_ProxyIp.Size = new System.Drawing.Size(190, 24);
            this.label_ProxyIp.TabIndex = 0;
            this.label_ProxyIp.Text = "代理服务器地址:";
            // 
            // checkBox_IsEnableProxy
            // 
            this.checkBox_IsEnableProxy.AutoSize = true;
            this.checkBox_IsEnableProxy.Location = new System.Drawing.Point(12, 84);
            this.checkBox_IsEnableProxy.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_IsEnableProxy.Name = "checkBox_IsEnableProxy";
            this.checkBox_IsEnableProxy.Size = new System.Drawing.Size(186, 28);
            this.checkBox_IsEnableProxy.TabIndex = 4;
            this.checkBox_IsEnableProxy.Text = "启用网络代理";
            this.checkBox_IsEnableProxy.UseVisualStyleBackColor = true;
            this.checkBox_IsEnableProxy.CheckedChanged += new System.EventHandler(this.CheckBox_IsEnableProxy_CheckedChanged);
            // 
            // textBox_SuffixName
            // 
            this.textBox_SuffixName.Location = new System.Drawing.Point(152, 36);
            this.textBox_SuffixName.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_SuffixName.Name = "textBox_SuffixName";
            this.textBox_SuffixName.Size = new System.Drawing.Size(376, 35);
            this.textBox_SuffixName.TabIndex = 2;
            // 
            // label_SuffixName
            // 
            this.label_SuffixName.AutoSize = true;
            this.label_SuffixName.Location = new System.Drawing.Point(8, 40);
            this.label_SuffixName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SuffixName.Name = "label_SuffixName";
            this.label_SuffixName.Size = new System.Drawing.Size(142, 24);
            this.label_SuffixName.TabIndex = 0;
            this.label_SuffixName.Text = "后缀名定义:";
            // 
            // groupBox_ProgramConfig
            // 
            this.groupBox_ProgramConfig.Controls.Add(this.checkBox_IsAutoCheckUpdate);
            this.groupBox_ProgramConfig.Location = new System.Drawing.Point(16, 16);
            this.groupBox_ProgramConfig.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_ProgramConfig.Name = "groupBox_ProgramConfig";
            this.groupBox_ProgramConfig.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_ProgramConfig.Size = new System.Drawing.Size(552, 84);
            this.groupBox_ProgramConfig.TabIndex = 0;
            this.groupBox_ProgramConfig.TabStop = false;
            this.groupBox_ProgramConfig.Text = "程序设置";
            // 
            // checkBox_IsAutoCheckUpdate
            // 
            this.checkBox_IsAutoCheckUpdate.AutoSize = true;
            this.checkBox_IsAutoCheckUpdate.Enabled = false;
            this.checkBox_IsAutoCheckUpdate.Location = new System.Drawing.Point(12, 36);
            this.checkBox_IsAutoCheckUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_IsAutoCheckUpdate.Name = "checkBox_IsAutoCheckUpdate";
            this.checkBox_IsAutoCheckUpdate.Size = new System.Drawing.Size(186, 28);
            this.checkBox_IsAutoCheckUpdate.TabIndex = 1;
            this.checkBox_IsAutoCheckUpdate.Text = "自动检查更新";
            this.checkBox_IsAutoCheckUpdate.UseVisualStyleBackColor = true;
            this.checkBox_IsAutoCheckUpdate.CheckedChanged += new System.EventHandler(this.CheckBox_IsAutoCheckUpdate_CheckedChanged);
            // 
            // button_SaveChanges
            // 
            this.button_SaveChanges.Location = new System.Drawing.Point(836, 388);
            this.button_SaveChanges.Margin = new System.Windows.Forms.Padding(4);
            this.button_SaveChanges.Name = "button_SaveChanges";
            this.button_SaveChanges.Size = new System.Drawing.Size(176, 68);
            this.button_SaveChanges.TabIndex = 8;
            this.button_SaveChanges.Text = "保存并应用";
            this.button_SaveChanges.UseVisualStyleBackColor = true;
            this.button_SaveChanges.Click += new System.EventHandler(this.Button_SaveChanges_Click);
            // 
            // groupBox_LyricConfig
            // 
            this.groupBox_LyricConfig.Controls.Add(this.comboBox_LineBreak);
            this.groupBox_LyricConfig.Controls.Add(this.label_LineBreak);
            this.groupBox_LyricConfig.Controls.Add(this.comboBox_LyricDownloader);
            this.groupBox_LyricConfig.Controls.Add(this.label_LyricDownloader);
            this.groupBox_LyricConfig.Controls.Add(this.comboBox_LyricContentType);
            this.groupBox_LyricConfig.Controls.Add(this.label1);
            this.groupBox_LyricConfig.Controls.Add(this.checkBox_IsCoverSourceLyricFile);
            this.groupBox_LyricConfig.Controls.Add(this.comboBox_LyricFileEncoding);
            this.groupBox_LyricConfig.Controls.Add(this.label_LyricFileEncoding);
            this.groupBox_LyricConfig.Location = new System.Drawing.Point(576, 16);
            this.groupBox_LyricConfig.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_LyricConfig.Name = "groupBox_LyricConfig";
            this.groupBox_LyricConfig.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_LyricConfig.Size = new System.Drawing.Size(436, 364);
            this.groupBox_LyricConfig.TabIndex = 9;
            this.groupBox_LyricConfig.TabStop = false;
            this.groupBox_LyricConfig.Text = "歌词配置";
            // 
            // comboBox_LineBreak
            // 
            this.comboBox_LineBreak.FormattingEnabled = true;
            this.comboBox_LineBreak.Location = new System.Drawing.Point(184, 220);
            this.comboBox_LineBreak.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_LineBreak.Name = "comboBox_LineBreak";
            this.comboBox_LineBreak.Size = new System.Drawing.Size(228, 32);
            this.comboBox_LineBreak.TabIndex = 16;
            // 
            // label_LineBreak
            // 
            this.label_LineBreak.AutoSize = true;
            this.label_LineBreak.Location = new System.Drawing.Point(8, 224);
            this.label_LineBreak.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LineBreak.Name = "label_LineBreak";
            this.label_LineBreak.Size = new System.Drawing.Size(142, 24);
            this.label_LineBreak.TabIndex = 15;
            this.label_LineBreak.Text = "歌词换行符:";
            // 
            // comboBox_LyricDownloader
            // 
            this.comboBox_LyricDownloader.FormattingEnabled = true;
            this.comboBox_LyricDownloader.Location = new System.Drawing.Point(184, 176);
            this.comboBox_LyricDownloader.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_LyricDownloader.Name = "comboBox_LyricDownloader";
            this.comboBox_LyricDownloader.Size = new System.Drawing.Size(228, 32);
            this.comboBox_LyricDownloader.TabIndex = 14;
            // 
            // label_LyricDownloader
            // 
            this.label_LyricDownloader.AutoSize = true;
            this.label_LyricDownloader.Location = new System.Drawing.Point(8, 180);
            this.label_LyricDownloader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LyricDownloader.Name = "label_LyricDownloader";
            this.label_LyricDownloader.Size = new System.Drawing.Size(94, 24);
            this.label_LyricDownloader.TabIndex = 0;
            this.label_LyricDownloader.Text = "歌词源:";
            // 
            // comboBox_LyricContentType
            // 
            this.comboBox_LyricContentType.FormattingEnabled = true;
            this.comboBox_LyricContentType.Location = new System.Drawing.Point(184, 88);
            this.comboBox_LyricContentType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_LyricContentType.Name = "comboBox_LyricContentType";
            this.comboBox_LyricContentType.Size = new System.Drawing.Size(228, 32);
            this.comboBox_LyricContentType.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "歌词内容:";
            // 
            // checkBox_IsCoverSourceLyricFile
            // 
            this.checkBox_IsCoverSourceLyricFile.AutoSize = true;
            this.checkBox_IsCoverSourceLyricFile.Location = new System.Drawing.Point(12, 140);
            this.checkBox_IsCoverSourceLyricFile.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_IsCoverSourceLyricFile.Name = "checkBox_IsCoverSourceLyricFile";
            this.checkBox_IsCoverSourceLyricFile.Size = new System.Drawing.Size(186, 28);
            this.checkBox_IsCoverSourceLyricFile.TabIndex = 10;
            this.checkBox_IsCoverSourceLyricFile.Text = "覆盖歌词文件";
            this.checkBox_IsCoverSourceLyricFile.UseVisualStyleBackColor = true;
            // 
            // comboBox_LyricFileEncoding
            // 
            this.comboBox_LyricFileEncoding.FormattingEnabled = true;
            this.comboBox_LyricFileEncoding.Location = new System.Drawing.Point(184, 44);
            this.comboBox_LyricFileEncoding.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_LyricFileEncoding.Name = "comboBox_LyricFileEncoding";
            this.comboBox_LyricFileEncoding.Size = new System.Drawing.Size(228, 32);
            this.comboBox_LyricFileEncoding.TabIndex = 9;
            // 
            // label_LyricFileEncoding
            // 
            this.label_LyricFileEncoding.AutoSize = true;
            this.label_LyricFileEncoding.Location = new System.Drawing.Point(8, 48);
            this.label_LyricFileEncoding.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LyricFileEncoding.Name = "label_LyricFileEncoding";
            this.label_LyricFileEncoding.Size = new System.Drawing.Size(166, 24);
            this.label_LyricFileEncoding.TabIndex = 0;
            this.label_LyricFileEncoding.Text = "歌词文件编码:";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 468);
            this.Controls.Add(this.groupBox_LyricConfig);
            this.Controls.Add(this.button_SaveChanges);
            this.Controls.Add(this.groupBox_ProgramConfig);
            this.Controls.Add(this.groupBox_DownloadConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件设置";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.groupBox_DownloadConfig.ResumeLayout(false);
            this.groupBox_DownloadConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DownloadThreadNumber)).EndInit();
            this.groupBox_ProgramConfig.ResumeLayout(false);
            this.groupBox_ProgramConfig.PerformLayout();
            this.groupBox_LyricConfig.ResumeLayout(false);
            this.groupBox_LyricConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_DownloadConfig;
        private System.Windows.Forms.TextBox textBox_SuffixName;
        private System.Windows.Forms.Label label_SuffixName;
        private System.Windows.Forms.GroupBox groupBox_ProgramConfig;
        private System.Windows.Forms.CheckBox checkBox_IsAutoCheckUpdate;
        private System.Windows.Forms.CheckBox checkBox_IsEnableProxy;
        private System.Windows.Forms.Label label_ProxyIp;
        private System.Windows.Forms.TextBox textBox_ProxyIp;
        private System.Windows.Forms.Label label_ProxyPort;
        private System.Windows.Forms.TextBox textBox_ProxyPort;
        private System.Windows.Forms.Button button_SaveChanges;
        private System.Windows.Forms.GroupBox groupBox_LyricConfig;
        private System.Windows.Forms.ComboBox comboBox_LyricFileEncoding;
        private System.Windows.Forms.Label label_LyricFileEncoding;
        private System.Windows.Forms.CheckBox checkBox_IsCoverSourceLyricFile;
        private System.Windows.Forms.ComboBox comboBox_LyricContentType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_LyricDownloader;
        private System.Windows.Forms.ComboBox comboBox_LyricDownloader;
        private System.Windows.Forms.Label label_DownloadThreadNumber;
        private System.Windows.Forms.NumericUpDown numericUpDown_DownloadThreadNumber;
        private System.Windows.Forms.ComboBox comboBox_LineBreak;
        private System.Windows.Forms.Label label_LineBreak;
        private System.Windows.Forms.Label label_Mp3TagPath;
        private System.Windows.Forms.TextBox textBox_Mp3TagPath;
        private System.Windows.Forms.Button button_Mp3TagPath;
    }
}