using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZonyLrcToolsX.Infrastructure.Configuration;
using ZonyLrcToolsX.Infrastructure.MusicTag;
using ZonyLrcToolsX.Infrastructure.MusicTag.TagLib;
using ZonyLrcToolsX.Infrastructure.Utils;

namespace ZonyLrcToolsX.Forms
{
    public partial class MainForm : Form
    {
        private IMusicInfoLoader _musicInfoLoader;

        public MainForm()
        {
            AppConfiguration.Instance.Load();

            InitializeInfrastructure();
            InitializeComponent();
        }

        private void InitializeInfrastructure()
        {
            _musicInfoLoader = new MusicInfoLoaderByTagLib();
        }

        private void ToolStripButton_About_Click(object sender, System.EventArgs e) => new AboutForm().ShowDialog();

        private void ToolStripButton_Config_Click(object sender, System.EventArgs e) => new ConfigForm().ShowDialog();

        private void ToolStripButton_PayMoney_Click(object sender, System.EventArgs e) => new DonateForm().ShowDialog();

        private void ToolStripButton_SearchMusicFile_Click(object sender, System.EventArgs e)
        {
            var dirDlg = new FolderBrowserDialog();

            if (dirDlg.ShowDialog() != DialogResult.OK) return;
            if (!Directory.Exists(dirDlg.SelectedPath))
            {
                MessageBox.Show("请选择有效的音乐文件夹路径。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            WinFormUtils.InvokeAction(this, async () =>
            {
                toolStripStatusLabel1.Text = "软件状态: 正在搜索文件...";
                var files = await FileSearchUtils.Instance.FindFilesAsync(dirDlg.SelectedPath, AppConfiguration.Instance.Configuration.SuffixName);

                // 构建提示信息。
                var messageBuilder = new StringBuilder();
                messageBuilder.Append($"文件搜索完毕，一共找到了 {files.SelectMany(x=>x.Value).Count()} 个文件。").Append("\r\n");
                messageBuilder.Append("------------------------------").Append("\r\n");
                foreach (var file in files)
                {
                    messageBuilder.Append($"{file.Key} 文件共 {file.Value.Count} 个。").Append("\r\n");
                }

                MessageBox.Show(messageBuilder.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                toolStripStatusLabel1.Text = "软件状态: 正在加载文件数据...";
                foreach (var file in files.SelectMany(x=>x.Value))
                {
                    var musicInfo = await _musicInfoLoader.LoadAsync(file);
                }
            });
        }
    }
}