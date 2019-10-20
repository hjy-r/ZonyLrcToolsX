using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZonyLrcToolsX.Downloader.Album.NetEase;
using ZonyLrcToolsX.Downloader.Lyric;
using ZonyLrcToolsX.Downloader.Lyric.Exceptions;
using ZonyLrcToolsX.Infrastructure;
using ZonyLrcToolsX.Infrastructure.Configuration;
using ZonyLrcToolsX.Infrastructure.MusicTag;
using ZonyLrcToolsX.Infrastructure.MusicTag.TagLib;
using ZonyLrcToolsX.Infrastructure.Network.Http.Exceptions;
using ZonyLrcToolsX.Infrastructure.Utils;
using ZonyLrcToolsX.Properties;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.application;
        }

        #region > 工具栏按钮点击事件 <

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

        private async void ToolStripButton_DownloadLyric_Click(object sender, EventArgs e)
        {
            if (listView_MusicList.Items.Count == 0)
            {
                MessageBox.Show("没有可用的歌曲文件，请先扫描之后再点击下载。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SetBottomStatusLabelText("开始下载歌词数据。");

            using (BeginImportantOperation())
            {
                var items = listView_MusicList.Items.Cast<ListViewItem>();
                InitializeProgress(listView_MusicList.Items.Count);

                var defaultDownloader = _lyricDownloaderContainer.GetDownloader();
                if (defaultDownloader == null) throw new NullReferenceException("程序初始化失败，无法获取到歌词下载器。");

                var worker = new TaskWorker(AppConfiguration.Instance.Configuration.DownloadThreadNumber);
                var tasks = items.Select(item => worker.RunAsync( () =>
                {
                    return Task.Run(async () =>
                    {
                        IncreaseProgressValue();

                        var musicInfo = item.Tag as MusicInfo;
                        if (FileUtils.Instance.IsIgnoreWriteLyricFile(musicInfo))
                        {
                            SetViewItemStatus(item, "略过");
                            return;
                        }

                        try
                        {
                            var result = await defaultDownloader.DownloadAsync(musicInfo);

                            if (result.IsPureMusic)
                            {
                                SetViewItemStatus(item, "无歌词");
                                return;
                            }

                            await FileUtils.Instance.WriteToLyricFileAsync(musicInfo, result);
                            SetViewItemStatus(item, "完成");
                        }
                        catch (HttpRequestFailedException exception)
                        {
                            HandleNetEaseAbroadUser(item, exception);
                        }
                        catch (NotFoundSongException)
                        {
                            SetViewItemStatus(item, "没有找到歌词");
                        }
                    });
                }));

                await Task.WhenAll(tasks);
            }

            SetBottomStatusLabelText($"{listView_MusicList.Items.Count} 首歌词已经下载完成。");
        }

        private void ToolStripButton_DownloadAlbumImage_Click(object sender, EventArgs e)
        {
            if (listView_MusicList.Items.Count == 0)
            {
                MessageBox.Show("没有可用的歌曲文件，请先扫描之后再点击下载。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SetBottomStatusLabelText("开始下载歌词专辑数据。");

            using (BeginImportantOperation())
            {
                var items = listView_MusicList.Items.Cast<ListViewItem>();
                InitializeProgress(listView_MusicList.Items.Count);

                var defaultAlbumImageDownloader = new NetEaseCloudMusicAlbumDownloader();

                foreach (var item in items)
                {
                    IncreaseProgressValue();

                    if (item.Tag is MusicInfo musicInfo)
                    {
                        SetBottomStatusLabelText($"正在下载 {musicInfo.Name} - {musicInfo.Artist} 的专辑图像。");
                        SetViewItemStatus(item, "下载中");

                        var result = defaultAlbumImageDownloader.Download(musicInfo);
                        musicInfo.AlbumImage = result;
                        
                        _musicInfoLoader.Save(musicInfo);
                        SetViewItemStatus(item, "完成");
                        SetBottomStatusLabelText($"已经将专辑图像写入到了 {musicInfo.FilePath}");
                    }
                }
                
                SetBottomStatusLabelText($"{listView_MusicList.Items.Count} 首专辑图像已经下载完成，并已成功写入到歌曲文件。");
            }
        }

        private void Button_OpenMp3Tag_Click(object sender, EventArgs e)
        {
            if (listView_MusicList.SelectedItems.Count == 1)
            {
                if (listView_MusicList.SelectedItems[0].Tag is MusicInfo selectedMusicInfo)
                {
                    Process.Start(AppConfiguration.Instance.Configuration.Mp3TagPath, $"/fn:\"{selectedMusicInfo.FilePath}\"");
                }
            }
        }

        private void toolStripMenuItem_ConvertNcm_Click(object sender, EventArgs e)
        {
            var selectNcmFileFolder = new FolderBrowserDialog
            {
                Description = "请选择 NCM 文件所在的文件夹路径。"
            };

            if (selectNcmFileFolder.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(selectNcmFileFolder.SelectedPath))
                {
                    MessageBox.Show("选择的目录不存在，请重新选择。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                WinFormUtils.InvokeAction(this, async () =>
                {
                    SetBottomStatusLabelText("搜索 NCM 文件中。");
                    var ncmFiles = await FileUtils.Instance.FindFilesAsync(selectNcmFileFolder.SelectedPath,new List<string>{"*.ncm"});
                    if (ncmFiles.Count == 0) MessageBox.Show("没有搜索到有效的 NCM 文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listView_MusicList.Items.Clear();
                    foreach (var ncmFile in ncmFiles.FirstOrDefault().Value)
                    {
                        listView_MusicList.Items.Add(new ListViewItem(new string[] { })
                        {
                            Tag = ncmFile
                        });
                    }
                    
                    SetBottomStatusLabelText($"已经找到 {ncmFiles.Count} 个 NCM 文件，等待进行转换操作。");
                });
            }
        }

        #endregion

        private void listView_MusicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_MusicList.SelectedItems.Count == 1)
            {
                if (listView_MusicList.SelectedItems[0].Tag is MusicInfo selectedMusicInfo)
                {
                    pictureBox_AblumImage.Image = null;
                    if (selectedMusicInfo.AlbumImage != null)
                    {
                        try
                        {
                            pictureBox_AblumImage.Image = Image.FromStream(new MemoryStream(selectedMusicInfo.AlbumImage));
                        }
                        catch (ArgumentException)
                        {
                            // 忽略参数异常导致专辑封面加载失败的 BUG。
                        }
                    }
                    
                    linkLabel_MusicPath.Text = $"歌曲文件路径: {selectedMusicInfo.FilePath}";
                    textBox_MusicName.Text = selectedMusicInfo.Name;
                    textBox_MusicArtist.Text = selectedMusicInfo.Artist;
                }
            }
        }

        private void LinkLabel_MusicPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listView_MusicList.SelectedItems.Count == 1)
            {
                if (listView_MusicList.SelectedItems[0].Tag is MusicInfo selectedMusicInfo)
                {
                    Process.Start("explorer", $"/select, {selectedMusicInfo.FilePath}");
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
            toolStripButton_DownloadAlbumImage.Enabled = false;
            toolStripButton_Config.Enabled = false;

            return new DisposeAction(() =>
            {
                toolStripButton_SearchMusicFile.Enabled = true;
                toolStripButton_DownloadLyric.Enabled = true;
                toolStripButton_DownloadAlbumImage.Enabled = true;
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
            if (InvokeRequired)
            {
                Invoke(new Action(() => listViewItem.SubItems[3].Text = text));
            }
            else
            {
                listViewItem.SubItems[3].Text = text;
            }
        }

        private void SetBottomStatusLabelText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => toolStripStatusLabel1.Text = $"软件状态: {text}"));
            }
            else
            {
                toolStripStatusLabel1.Text = $"软件状态: {text}";
            }
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
            if (InvokeRequired)
            {
                Invoke(new Action(() => toolStripProgressBar1.Value += 1));
            }
            else
            {
                toolStripProgressBar1.Value += 1;
            }
        }
        
        private void HandleNetEaseAbroadUser(ListViewItem item, HttpRequestFailedException exception)
        {
            if (JObject.Parse(exception.Data["Response"] as string).SelectToken("$.abroad").Value<bool>())
            {
                SetViewItemStatus(item,"海外用户，无法下载");
            }
            else
            {
                SetViewItemStatus(item,"接口错误");
            }
        }
    }
}