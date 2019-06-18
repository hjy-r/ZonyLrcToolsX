using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZonyLrcToolsX.Infrastructure.Configuration;
using ZonyLrcToolsX.Infrastructure.ItemDtos;

namespace ZonyLrcToolsX.Forms
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
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
            if (AppConfiguration.Instance.Configuration.CodePage == 0) comboBox_LyricFileEncoding.SelectedIndex = comboBoxItems.Count - 1;
            else
            {
                comboBox_LyricFileEncoding.SelectedItem = comboBoxItems.FindIndex(item => item.Value == AppConfiguration.Instance.Configuration.CodePage);
            }

            checkBox_IsEnableProxy.Checked = AppConfiguration.Instance.Configuration.IsEnableProxy;
            CheckBox_IsEnableProxy_CheckedChanged(sender,e);
            checkBox_IsCoverSourceLyricFile.Checked = AppConfiguration.Instance.Configuration.IsCoverSourceLyricFile;

            var suffixNameBuilder = new StringBuilder();
            AppConfiguration.Instance.Configuration.SuffixName.ForEach(name=>suffixNameBuilder.Append(name).Append(','));
            textBox_SuffixName.Text = suffixNameBuilder.ToString().Trim(',');

            checkBox_IsAutoCheckUpdate.Checked = AppConfiguration.Instance.Configuration.IsAutoCheckUpdate;
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
            AppConfiguration.Instance.Configuration.IsAutoCheckUpdate = checkBox_IsAutoCheckUpdate.Checked;
            AppConfiguration.Instance.Configuration.IsCoverSourceLyricFile = checkBox_IsCoverSourceLyricFile.Checked;
            AppConfiguration.Instance.Configuration.IsEnableProxy = checkBox_IsEnableProxy.Checked;
            AppConfiguration.Instance.Configuration.SuffixName = textBox_SuffixName.Text.Split(';').ToList();
            AppConfiguration.Instance.Configuration.CodePage = (comboBox_LyricFileEncoding.SelectedItem as ComboboxLyricFileEncodingItemDto)?.Value ?? 0;
            AppConfiguration.Instance.Configuration.ProxyIp = textBox_ProxyIp.Text;
            AppConfiguration.Instance.Configuration.ProxyPort = int.Parse(textBox_ProxyPort.Text);

            AppConfiguration.Instance.Save();
            Close();
        }
    }
}
