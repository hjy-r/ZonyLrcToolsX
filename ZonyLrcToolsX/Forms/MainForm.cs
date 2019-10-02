using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nito.AsyncEx;
using ZonyLrcToolsX.Downloader.Lyric;
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
        private LyricDownloaderContainer _lyricDownloaderContainer;

        public MainForm()
        {
            AppConfiguration.Instance.Load();
            AppConfiguration.Instance.Save();
            
            InitializeInfrastructure();
            InitializeComponent();
        }

        private void InitializeInfrastructure()
        {
            _musicInfoLoader = new MusicInfoLoaderByTagLib();
            _lyricDownloaderContainer = new LyricDownloaderContainer();
        }

        private void ToolStripButton_About_Click(object sender, EventArgs e) => new AboutForm().ShowDialog();

        private void ToolStripButton_Config_Click(object sender, EventArgs e) => new ConfigForm().ShowDialog();

        private void ToolStripButton_PayMoney_Click(object sender, EventArgs e) => new DonateForm().ShowDialog();

        private void ToolStripButton_SearchMusicFile_Click(object sender, EventArgs e)
        {
            var dirDlg = new FolderBrowserDialog();

            if (dirDlg.ShowDialog() != DialogResult.OK) return;
            if (!Directory.Exists(dirDlg.SelectedPath))
            {
                MessageBox.Show("请选择有效的音乐文件夹路径。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listView_MusicList.Items.Clear();
            SetBottomStatusLabelText("正在搜索文件中，请稍候。");

            WinFormUtils.InvokeAction(this, async () =>
            {
                var files = await FileUtils.Instance.FindFilesAsync(dirDlg.SelectedPath,
                    AppConfiguration.Instance.Configuration.SuffixName);
                InitializeProgress(files.SelectMany(x=>x.Value).Count());

                MessageBox.Show(BuildSearchCompletedMessage(files), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 填充主页面的 ListView 控件。
                SetBottomStatusLabelText("正在加载文件的歌曲数据，请稍候。");
                foreach (var file in files.SelectMany(x => x.Value))
                {
                    IncreaseProgressValue();
                    
                    var musicInfo = await _musicInfoLoader.LoadAsync(file);
                    listView_MusicList.Items.Add(musicInfo.ToListViewItem());
                }
            });

            SetDefaultSelectedItem();
            SetBottomStatusLabelText("歌词数据加载完成。");
        }

        private void ToolStripButton_DownloadLyric_Click(object sender, EventArgs e)
        {
            SetBottomStatusLabelText("开始下载歌词数据。");

            using (BeginImportantOperation())
            {
                var items = listView_MusicList.Items.Cast<ListViewItem>();
                InitializeProgress(listView_MusicList.Items.Count);

                var defaultDownloader = _lyricDownloaderContainer.Downloader.FirstOrDefault();
                if (defaultDownloader == null) throw new NullReferenceException("程序初始化失败，无法获取到歌词下载器。");
                
                foreach (var item in items)
                {
                    IncreaseProgressValue();
                    
                    var musicInfo = item.Tag as MusicInfo;
                    if (FileUtils.Instance.IsIgnoreWriteLyricFile(musicInfo))
                    {
                        SetViewItemStatus(item,"略过");
                        continue;
                    }

                    var result = AsyncContext.Run(() => defaultDownloader.DownloadAsync(musicInfo));
                    if (result.IsPureMusic)
                    {
                        SetViewItemStatus(item, "无歌词");
                        continue;
                    }

                    AsyncContext.Run(()=> FileUtils.Instance.WriteToLyricFileAsync(musicInfo, result));
                    SetViewItemStatus(item, "正常");
                }
            }

            SetBottomStatusLabelText($"{listView_MusicList.Items.Count} 首歌词已经下载完成。");
        }
        
        private void listView_MusicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_MusicList.SelectedItems.Count == 1)
            {
                if (listView_MusicList.SelectedItems[0].Tag is MusicInfo selectedMusicInfo)
                {
                    pictureBox_AblumImage.Image = Image.FromStream(new MemoryStream(selectedMusicInfo.AlbumImage));
                    linkLabel_MusicPath.Text = $"歌曲文件路径: {selectedMusicInfo.FilePath}";
                    textBox_MusicName.Text = selectedMusicInfo.Name;
                    textBox_MusicArtist.Text = selectedMusicInfo.Artist;
                }
            }
        }

        /// <summary>
        /// 当执行关键性操作时，调用本方法禁用 MainForm 窗体上的重要控件，防止发生误操作。
        /// </summary>
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
                toolStripButton_Config.Enabled = true;
            });
        }

        /// <summary>
        /// 搜索完成之后，将会调用本方法构建提示文本框。
        /// </summary>
        /// <param name="files">搜索到的文件集合，以 [后缀名-文件路径集合] 的键值对构成。</param>
        private string BuildSearchCompletedMessage(Dictionary<string,List<string>> files)
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.Append($"文件搜索完毕，一共找到了 {files.SelectMany(x => x.Value).Count()} 个文件。").Append("\r\n");
            messageBuilder.Append("------------------------------").Append("\r\n");
            foreach (var file in files)
            {
                messageBuilder.Append($"{file.Key} 文件共 {file.Value.Count} 个。").Append("\r\n");
            }

            return messageBuilder.ToString();
        }

        private void SetViewItemStatus(ListViewItem listViewItem, string text)
        {
            if (listViewItem == null) return;
            listViewItem.SubItems[3].Text = text;
        }

        private void SetBottomStatusLabelText(string text)
        {
            toolStripStatusLabel1.Text = $"软件状态: {text}";
        }

        private void SetDefaultSelectedItem()
        {
            if (listView_MusicList.Items.Count > 0)
            {
                listView_MusicList.Items[0].Selected = true;
            }
        }

        private void InitializeProgress(int filesCount)
        {
            toolStripProgressBar1.Maximum = filesCount;
            toolStripProgressBar1.Value = 0;
        }
        
        private void IncreaseProgressValue()
        {
            toolStripProgressBar1.Value += 1;
        }
    }
}