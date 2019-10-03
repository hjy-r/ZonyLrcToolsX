namespace ZonyLrcToolsX.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip_Bottom = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_SearchMusicFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_DownloadLyric = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_DownloadAlbumImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton_MusicConvert = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem_ConvertNcm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Config = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PayMoney = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_About = new System.Windows.Forms.ToolStripButton();
            this.listView_MusicList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_SaveChanges = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_MusicArtist = new System.Windows.Forms.TextBox();
            this.label_MusicArtist = new System.Windows.Forms.Label();
            this.textBox_MusicName = new System.Windows.Forms.TextBox();
            this.label_MusicName = new System.Windows.Forms.Label();
            this.linkLabel_MusicPath = new System.Windows.Forms.LinkLabel();
            this.pictureBox_AblumImage = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.button_OpenMp3Tag = new System.Windows.Forms.Button();
            this.toolStrip_Bottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AblumImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_Bottom
            // 
            this.toolStrip_Bottom.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip_Bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_SearchMusicFile,
            this.toolStripSeparator1,
            this.toolStripButton_DownloadLyric,
            this.toolStripButton_DownloadAlbumImage,
            this.toolStripSeparator2,
            this.toolStripSplitButton_MusicConvert,
            this.toolStripSeparator3,
            this.toolStripButton_Config,
            this.toolStripButton_PayMoney,
            this.toolStripButton_About});
            this.toolStrip_Bottom.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Bottom.Name = "toolStrip_Bottom";
            this.toolStrip_Bottom.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip_Bottom.Size = new System.Drawing.Size(1102, 39);
            this.toolStrip_Bottom.TabIndex = 0;
            this.toolStrip_Bottom.Text = "toolStrip1";
            // 
            // toolStripButton_SearchMusicFile
            // 
            this.toolStripButton_SearchMusicFile.Image = global::ZonyLrcToolsX.Properties.Resources.Scan;
            this.toolStripButton_SearchMusicFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SearchMusicFile.Name = "toolStripButton_SearchMusicFile";
            this.toolStripButton_SearchMusicFile.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_SearchMusicFile.Text = "扫描歌曲";
            this.toolStripButton_SearchMusicFile.Click += new System.EventHandler(this.ToolStripButton_SearchMusicFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_DownloadLyric
            // 
            this.toolStripButton_DownloadLyric.Image = global::ZonyLrcToolsX.Properties.Resources.Download;
            this.toolStripButton_DownloadLyric.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DownloadLyric.Name = "toolStripButton_DownloadLyric";
            this.toolStripButton_DownloadLyric.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_DownloadLyric.Text = "下载歌词";
            this.toolStripButton_DownloadLyric.Click += new System.EventHandler(this.ToolStripButton_DownloadLyric_Click);
            // 
            // toolStripButton_DownloadAlbumImage
            // 
            this.toolStripButton_DownloadAlbumImage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_DownloadAlbumImage.Image")));
            this.toolStripButton_DownloadAlbumImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DownloadAlbumImage.Name = "toolStripButton_DownloadAlbumImage";
            this.toolStripButton_DownloadAlbumImage.Size = new System.Drawing.Size(116, 36);
            this.toolStripButton_DownloadAlbumImage.Text = "下载专辑图像";
            this.toolStripButton_DownloadAlbumImage.Click += new System.EventHandler(this.ToolStripButton_DownloadAlbumImage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSplitButton_MusicConvert
            // 
            this.toolStripSplitButton_MusicConvert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ConvertNcm});
            this.toolStripSplitButton_MusicConvert.Enabled = false;
            this.toolStripSplitButton_MusicConvert.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_MusicConvert.Image")));
            this.toolStripSplitButton_MusicConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_MusicConvert.Name = "toolStripSplitButton_MusicConvert";
            this.toolStripSplitButton_MusicConvert.Size = new System.Drawing.Size(104, 36);
            this.toolStripSplitButton_MusicConvert.Text = "歌曲转换";
            // 
            // toolStripMenuItem_ConvertNcm
            // 
            this.toolStripMenuItem_ConvertNcm.Name = "toolStripMenuItem_ConvertNcm";
            this.toolStripMenuItem_ConvertNcm.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem_ConvertNcm.Text = "NCM 转换";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_Config
            // 
            this.toolStripButton_Config.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Config.Image")));
            this.toolStripButton_Config.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Config.Name = "toolStripButton_Config";
            this.toolStripButton_Config.Size = new System.Drawing.Size(68, 36);
            this.toolStripButton_Config.Text = "设置";
            this.toolStripButton_Config.Click += new System.EventHandler(this.ToolStripButton_Config_Click);
            // 
            // toolStripButton_PayMoney
            // 
            this.toolStripButton_PayMoney.Enabled = false;
            this.toolStripButton_PayMoney.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_PayMoney.Image")));
            this.toolStripButton_PayMoney.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PayMoney.Name = "toolStripButton_PayMoney";
            this.toolStripButton_PayMoney.Size = new System.Drawing.Size(68, 36);
            this.toolStripButton_PayMoney.Text = "捐赠";
            this.toolStripButton_PayMoney.Click += new System.EventHandler(this.ToolStripButton_PayMoney_Click);
            // 
            // toolStripButton_About
            // 
            this.toolStripButton_About.Enabled = false;
            this.toolStripButton_About.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_About.Image")));
            this.toolStripButton_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_About.Name = "toolStripButton_About";
            this.toolStripButton_About.Size = new System.Drawing.Size(68, 36);
            this.toolStripButton_About.Text = "关于";
            this.toolStripButton_About.Click += new System.EventHandler(this.ToolStripButton_About_Click);
            // 
            // listView_MusicList
            // 
            this.listView_MusicList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_MusicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_MusicList.HideSelection = false;
            this.listView_MusicList.Location = new System.Drawing.Point(194, 41);
            this.listView_MusicList.Margin = new System.Windows.Forms.Padding(2);
            this.listView_MusicList.Name = "listView_MusicList";
            this.listView_MusicList.Size = new System.Drawing.Size(897, 447);
            this.listView_MusicList.TabIndex = 1;
            this.listView_MusicList.UseCompatibleStateImageBehavior = false;
            this.listView_MusicList.View = System.Windows.Forms.View.Details;
            this.listView_MusicList.SelectedIndexChanged += new System.EventHandler(this.listView_MusicList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "歌曲名";
            this.columnHeader1.Width = 272;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "歌手/艺术家";
            this.columnHeader2.Width = 230;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "专辑名称";
            this.columnHeader3.Width = 229;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "状态";
            this.columnHeader4.Width = 134;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.button_OpenMp3Tag);
            this.groupBox1.Controls.Add(this.button_SaveChanges);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_MusicArtist);
            this.groupBox1.Controls.Add(this.label_MusicArtist);
            this.groupBox1.Controls.Add(this.textBox_MusicName);
            this.groupBox1.Controls.Add(this.label_MusicName);
            this.groupBox1.Controls.Add(this.linkLabel_MusicPath);
            this.groupBox1.Controls.Add(this.pictureBox_AblumImage);
            this.groupBox1.Location = new System.Drawing.Point(8, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(182, 447);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "歌曲详细信息";
            // 
            // button_SaveChanges
            // 
            this.button_SaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SaveChanges.Location = new System.Drawing.Point(110, 417);
            this.button_SaveChanges.Margin = new System.Windows.Forms.Padding(2);
            this.button_SaveChanges.Name = "button_SaveChanges";
            this.button_SaveChanges.Size = new System.Drawing.Size(64, 26);
            this.button_SaveChanges.TabIndex = 3;
            this.button_SaveChanges.Text = "保存更改";
            this.button_SaveChanges.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 310);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "歌曲标签:";
            // 
            // textBox_MusicArtist
            // 
            this.textBox_MusicArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MusicArtist.Location = new System.Drawing.Point(54, 276);
            this.textBox_MusicArtist.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MusicArtist.Name = "textBox_MusicArtist";
            this.textBox_MusicArtist.Size = new System.Drawing.Size(122, 21);
            this.textBox_MusicArtist.TabIndex = 10;
            // 
            // label_MusicArtist
            // 
            this.label_MusicArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_MusicArtist.AutoSize = true;
            this.label_MusicArtist.Location = new System.Drawing.Point(4, 280);
            this.label_MusicArtist.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_MusicArtist.Name = "label_MusicArtist";
            this.label_MusicArtist.Size = new System.Drawing.Size(47, 12);
            this.label_MusicArtist.TabIndex = 9;
            this.label_MusicArtist.Text = "艺术家:";
            // 
            // textBox_MusicName
            // 
            this.textBox_MusicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MusicName.Location = new System.Drawing.Point(54, 246);
            this.textBox_MusicName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MusicName.Name = "textBox_MusicName";
            this.textBox_MusicName.Size = new System.Drawing.Size(122, 21);
            this.textBox_MusicName.TabIndex = 3;
            // 
            // label_MusicName
            // 
            this.label_MusicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_MusicName.AutoSize = true;
            this.label_MusicName.Location = new System.Drawing.Point(4, 248);
            this.label_MusicName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_MusicName.Name = "label_MusicName";
            this.label_MusicName.Size = new System.Drawing.Size(47, 12);
            this.label_MusicName.TabIndex = 7;
            this.label_MusicName.Text = "歌曲名:";
            // 
            // linkLabel_MusicPath
            // 
            this.linkLabel_MusicPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_MusicPath.Location = new System.Drawing.Point(4, 208);
            this.linkLabel_MusicPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel_MusicPath.Name = "linkLabel_MusicPath";
            this.linkLabel_MusicPath.Size = new System.Drawing.Size(170, 36);
            this.linkLabel_MusicPath.TabIndex = 5;
            this.linkLabel_MusicPath.TabStop = true;
            this.linkLabel_MusicPath.Text = "歌曲文件路径:";
            this.linkLabel_MusicPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_MusicPath_LinkClicked);
            // 
            // pictureBox_AblumImage
            // 
            this.pictureBox_AblumImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_AblumImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_AblumImage.Location = new System.Drawing.Point(4, 18);
            this.pictureBox_AblumImage.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_AblumImage.Name = "pictureBox_AblumImage";
            this.pictureBox_AblumImage.Size = new System.Drawing.Size(172, 182);
            this.pictureBox_AblumImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_AblumImage.TabIndex = 4;
            this.pictureBox_AblumImage.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1102, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(938, 17);
            this.toolStripStatusLabel1.Text = "软件状态:";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            // 
            // button_OpenMp3Tag
            // 
            this.button_OpenMp3Tag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OpenMp3Tag.Location = new System.Drawing.Point(6, 417);
            this.button_OpenMp3Tag.Margin = new System.Windows.Forms.Padding(2);
            this.button_OpenMp3Tag.Name = "button_OpenMp3Tag";
            this.button_OpenMp3Tag.Size = new System.Drawing.Size(64, 26);
            this.button_OpenMp3Tag.TabIndex = 11;
            this.button_OpenMp3Tag.Text = "Mp3Tag";
            this.button_OpenMp3Tag.UseVisualStyleBackColor = true;
            this.button_OpenMp3Tag.Click += new System.EventHandler(this.Button_OpenMp3Tag_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1102, 512);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView_MusicList);
            this.Controls.Add(this.toolStrip_Bottom);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ZonyLrcToolsX";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip_Bottom.ResumeLayout(false);
            this.toolStrip_Bottom.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AblumImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Bottom;
        private System.Windows.Forms.ToolStripButton toolStripButton_SearchMusicFile;
        private System.Windows.Forms.ToolStripButton toolStripButton_DownloadLyric;
        private System.Windows.Forms.ToolStripButton toolStripButton_DownloadAlbumImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_MusicConvert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_PayMoney;
        private System.Windows.Forms.ToolStripButton toolStripButton_About;
        private System.Windows.Forms.ListView listView_MusicList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox_AblumImage;
        private System.Windows.Forms.LinkLabel linkLabel_MusicPath;
        private System.Windows.Forms.Label label_MusicName;
        private System.Windows.Forms.TextBox textBox_MusicArtist;
        private System.Windows.Forms.Label label_MusicArtist;
        private System.Windows.Forms.TextBox textBox_MusicName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_SaveChanges;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ConvertNcm;
        private System.Windows.Forms.ToolStripButton toolStripButton_Config;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button button_OpenMp3Tag;
    }
}