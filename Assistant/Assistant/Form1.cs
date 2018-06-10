using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Helpers;

namespace Assistant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DebugHelper.Init("error.txt");
        }

        private void 压缩目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = Clipboard.GetText().Trim();
                if (!Directory.Exists(dir)) return;

                Methods.CompressDirectory(dir);
            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);

            }

        }

        private void stringBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(Formatter.FormatStringBuilder(Clipboard.GetText()));
            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);

            }
        }

        private void 压缩子目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = Clipboard.GetText().Trim();
                if (!Directory.Exists(dir)) return;

                SynchronizationContext context = SynchronizationContext.Current;
                var n = new Notification();
                n.Show();
                new TaskFactory().StartNew(() =>
                {
                    foreach (var item in Directory.GetDirectories(dir))
                    {
                        context.Post(o =>
                        {
                            n.UpdateLabel(item);
                        }, null);
                        Methods.CompressDirectory(item);

                    }
                })
                .ContinueWith(t =>
                {
                    n.Close();
                }, TaskScheduler.FromCurrentSynchronizationContext());



                //.ContinueWith((t)=> { n.Close(); }, uiScheduler);

            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);

            }
        }



        private async void 湖北快3ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private async void 更新缓存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Lottery.HuBeiK3();
        }

        private void openDirectoryButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("".GetCommandLinePath());
        }

        private void 分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lottery.AnalysisHuBeiK3();
        }

        private void 格式化C代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(Methods.FormatCSharpCode(Clipboard.GetText()));
            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);

            }
        }

        private void 多看WIFI传书文件名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var hd = new HtmlAgilityPack.HtmlDocument();
                hd.LoadHtml(Clipboard.GetText());
                var nodes = hd.DocumentNode.SelectNodes("//*[@class='file']/*[contains(@class,'filename')]");
                var sb = new StringBuilder();

                foreach (var item in nodes)
                {
                    sb.AppendLine(item.InnerText);
                }
                "duokan.txt".GetDesktopPath().WriteAllText(sb.ToString());
            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);

            }
        }

        private void 排除多看WIFI传书文件名已上传书籍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Clipboard.GetText().Trim())) return;

                var f = "duokan.txt".GetDesktopPath();
                if (!File.Exists(f)) return;

                var lines = f.ReadAllLines().Select(i => i.GetFileNameWithoutExtension()).ToArray();

                var files = Directory.GetFiles(Clipboard.GetText().Trim());
                var t = Path.Combine(Clipboard.GetText().Trim(), "Files");

                t.CreateDirectory();

                foreach (var item in files)
                {
                    if (lines.Contains(item.GetFileNameWithoutExtension())) continue;
                    File.Move(item, Path.Combine(t, item.GetFileName()));
                }

            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);

            }
        }

        private void 解压目录下的文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Clipboard.GetText().Trim())) return;

                foreach (var item in Directory.GetFiles(Clipboard.GetText().Trim(),"*.zip"))
                {
                    Methods.UnCompressFile(item);
                }

            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);

            }
        }
    }
}
