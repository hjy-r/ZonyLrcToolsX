using System;
using System.Collections.Async;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZonyLrcToolsX.Downloader.Lyric;
using ZonyLrcToolsX.Downloader.Lyric.NetEase;
using ZonyLrcToolsX.Infrastructure;
using ZonyLrcToolsX.Infrastructure.Configuration;
using ZonyLrcToolsX.Infrastructure.MusicTag;
using ZonyLrcToolsX.Infrastructure.MusicTag.TagLib;
using ZonyLrcToolsX.Infrastructure.Utils;

// ReSharper disable LocalizableElement

namespace ZonyLrcToolsX.Forms
{
    public partial class MainForm : Form
    {
        private IMusicInfoLoader _musicInfoLoader;
        private ILyricDownloader _lyricDownloader;

        public MainForm()
        {
            AppConfiguration.Instance.Load();

            InitializeInfrastructure();
            InitializeComponent();
        }

        private void InitializeInfrastructure()
        {
            _musicInfoLoader = new MusicInfoLoaderByTagLib();
            _lyricDownloader = new NetEaseCloudMusicLyricDownloader();
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

            listView_MusicList.Items.Clear();
            toolStripStatusLabel1.Text = "软件状态: 正在搜索文件...";

            WinFormUtils.InvokeAction(this, async () =>
            {
                var files = await FileSearchUtils.Instance.FindFilesAsync(dirDlg.SelectedPath,
                    AppConfiguration.Instance.Configuration.SuffixName);

                // 构建提示信息。
                var messageBuilder = new StringBuilder();
                messageBuilder.Append($"文件搜索完毕，一共找到了 {files.SelectMany(x => x.Value).Count()} 个文件。").Append("\r\n");
                messageBuilder.Append("------------------------------").Append("\r\n");
                foreach (var file in files)
                {
                    messageBuilder.Append($"{file.Key} 文件共 {file.Value.Count} 个。").Append("\r\n");
                }

                MessageBox.Show(messageBuilder.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 填充主页面的 ListView 控件。
                toolStripStatusLabel1.Text = "软件状态: 正在加载文件数据...";
                foreach (var file in files.SelectMany(x => x.Value))
                {
                    var musicInfo = await _musicInfoLoader.LoadAsync(file);
                    listView_MusicList.Items.Add(musicInfo.ToListViewItem());
                }
            });

            toolStripStatusLabel1.Text = "软件状态: 歌词数据加载完成...";
        }

        private async void ToolStripButton_DownloadLyric_Click(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "软件状态: 开始下载歌曲歌词...";

            using (BeginImportantOperation())
            {
//                var items = listView_MusicList.Items.Cast<ListViewItem>();
//
//                await items.ParallelForEachAsync(async item =>
//                {
//                    try
//                    {
//                        var musicInfo = item.Tag as MusicInfo;
//                        var result = await _lyricDownloader.DownloadAsync(musicInfo);
//
//                        if (result.IsPureMusic) item.SubItems[3].Text = "无歌词";
//                        item.SubItems[3].Text = "完成";
//                    }
//                    catch (Exception exception)
//                    {
//                        item.SubItems[3].Text = "异常";
//                    }
//                });
            }

            toolStripStatusLabel1.Text = $"软件状态: {listView_MusicList.Items.Count} 歌曲的歌词已经下载完成...";
        }

        private DisposeAction BeginImportantOperation()
        {
            toolStripButton_SearchMusicFile.Enabled = false;
            toolStripButton_DownloadLyric.Enabled = false;
            toolStripButton_DownloadAblumImage.Enabled = false;
            toolStripButton_Config.Enabled = false;

            return new DisposeAction(() =>
            {
                toolStripButton_SearchMusicFile.Enabled = true;
                toolStripButton_DownloadLyric.Enabled = true;
                toolStripButton_DownloadAblumImage.Enabled = true;
                toolStripButton_Config.Enabled = false;
            });
        }
    }
}