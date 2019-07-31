using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZonyLrcToolsX.Downloader.Lyric;
using ZonyLrcToolsX.Infrastructure.Configuration;
using ZonyLrcToolsX.Infrastructure.ItemDtos;

namespace ZonyLrcToolsX.Forms
{
    public partial class ConfigForm : Form
    {
        protected readonly AppConfiguration ConfigurationInstance;

        public ConfigForm()
        {
            ConfigurationInstance = AppConfiguration.Instance;

            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            ConfigurationInstance.Load();

            InitializeLyricFileEncoding();
            InitializeLyricContentType();
            InitializeLyricDownloader();
            InitializeDownloadThreadNumber();
            InitializeNetworkProxy(sender, e);
            InitializeSuffixName();

            checkBox_IsAutoCheckUpdate.Checked = ConfigurationInstance.Configuration.IsAutoCheckUpdate;
        }

        private void CheckBox_IsEnableProxy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsEnableProxy.Checked)
            {
                textBox_ProxyIp.Enabled = true;
                textBox_ProxyPort.Enabled = true;
            }
            else
            {
                textBox_ProxyIp.Enabled = false;
                textBox_ProxyPort.Enabled = false;
            }
        }

        private void CheckBox_IsAutoCheckUpdate_CheckedChanged(object sender, EventArgs e)
        {
            // 当勾选自动检查时，马上检查更新。
            if (checkBox_IsAutoCheckUpdate.Enabled)
            {
                // TODO: 检查更新的相关代码。
            }
        }

        private void Button_SaveChanges_Click(object sender, EventArgs e)
        {
            ConfigurationInstance.Configuration.IsAutoCheckUpdate = checkBox_IsAutoCheckUpdate.Checked;
            ConfigurationInstance.Configuration.IsCoverSourceLyricFile = checkBox_IsCoverSourceLyricFile.Checked;
            ConfigurationInstance.Configuration.IsEnableProxy = checkBox_IsEnableProxy.Checked;
            ConfigurationInstance.Configuration.SuffixName = textBox_SuffixName.Text.Split(';').ToList();
            ConfigurationInstance.Configuration.CodePage = (comboBox_LyricFileEncoding.SelectedItem as ComboboxLyricFileEncodingItemDto)?.Value ?? 0;
            if (ConfigurationInstance.Configuration.IsEnableProxy)
            {
                ConfigurationInstance.Configuration.ProxyIp = textBox_ProxyIp.Text;
                ConfigurationInstance.Configuration.ProxyPort = int.Parse(textBox_ProxyPort.Text);
            }
            ConfigurationInstance.Configuration.LyricContentType = (comboBox_LyricContentType.SelectedItem as ComboBoxLyricContentTypeItemDto)?.Value ?? LyricContentTypes.Original;
            ConfigurationInstance.Configuration.SelectedLyricDownloader = (comboBox_LyricDownloader.SelectedItem as ComboBoxLyricDownloaderItemDto)?.Value ?? LyricDownloaderEnum.NetEase;
            ConfigurationInstance.Configuration.DownloadThreadNumber = (int)numericUpDown_DownloadThreadNumber.Value;

            ConfigurationInstance.Save();
            Close();
        }

        private void InitializeLyricContentType()
        {
            // 构建歌词内容类型下拉框。
            var lyricContentTypeComboBox = new List<ComboBoxLyricContentTypeItemDto>
            {
                new ComboBoxLyricContentTypeItemDto {Text = "原始歌词",Value = LyricContentTypes.Original},
                new ComboBoxLyricContentTypeItemDto {Text = "翻译歌词",Value = LyricContentTypes.Translation},
                new ComboBoxLyricContentTypeItemDto {Text = "双语歌词",Value = LyricContentTypes.OriginalAndTranslation}
            };
            comboBox_LyricContentType.DataSource = lyricContentTypeComboBox;
            comboBox_LyricContentType.SelectedItem = lyricContentTypeComboBox.FindIndex(item => item.Value == ConfigurationInstance.Configuration.LyricContentType);
        }

        private void InitializeLyricDownloader()
        {
            // 构建歌词源下拉框。
            var lyricDownloaderComboBox = new List<ComboBoxLyricDownloaderItemDto>
            {
                new ComboBoxLyricDownloaderItemDto {Text = "网易云音乐", Value = LyricDownloaderEnum.NetEase},
                new ComboBoxLyricDownloaderItemDto {Text = "QQ 音乐", Value = LyricDownloaderEnum.QQMusic}
            };
            comboBox_LyricDownloader.DataSource = lyricDownloaderComboBox;
            comboBox_LyricDownloader.SelectedItem = lyricDownloaderComboBox.FindIndex(item => item.Value == ConfigurationInstance.Configuration.SelectedLyricDownloader);
        }

        private void InitializeLyricFileEncoding()
        {
            // 构建常用的歌词文件编码。
            var comboBoxItems = new List<ComboboxLyricFileEncodingItemDto>();
            foreach (var encodingInfo in Encoding.GetEncodings())
            {
                comboBoxItems.Add(new ComboboxLyricFileEncodingItemDto
                {
                    Text = encodingInfo.DisplayName,
                    Value = encodingInfo.CodePage
                });
            }
            comboBox_LyricFileEncoding.DataSource = comboBoxItems;
            if (ConfigurationInstance.Configuration.CodePage == 0) comboBox_LyricFileEncoding.SelectedIndex = comboBoxItems.Count - 1;
            else
            {
                comboBox_LyricFileEncoding.SelectedItem = comboBoxItems.FindIndex(item => item.Value == ConfigurationInstance.Configuration.CodePage);
            }
        }

        private void InitializeDownloadThreadNumber()
        {
            numericUpDown_DownloadThreadNumber.Maximum = 8;
            numericUpDown_DownloadThreadNumber.Minimum = 1;

            numericUpDown_DownloadThreadNumber.Value = ConfigurationInstance.Configuration.DownloadThreadNumber;
        }

        private void InitializeNetworkProxy(object sender,EventArgs e)
        {
            checkBox_IsEnableProxy.Checked = ConfigurationInstance.Configuration.IsEnableProxy;
            CheckBox_IsEnableProxy_CheckedChanged(sender, e);
            checkBox_IsCoverSourceLyricFile.Checked = ConfigurationInstance.Configuration.IsCoverSourceLyricFile;
        }

        private void InitializeSuffixName()
        {
            var suffixNameBuilder = new StringBuilder();
            ConfigurationInstance.Configuration.SuffixName.ForEach(name => suffixNameBuilder.Append(name).Append(','));
            textBox_SuffixName.Text = suffixNameBuilder.ToString().Trim(',');
        }
    }
}
