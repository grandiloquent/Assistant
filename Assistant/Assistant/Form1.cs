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
using LiveCharts;
using LiveCharts.Wpf;
using System.Text.RegularExpressions;
using System.Xml.Linq;
namespace Assistant
{
    public partial class Form1 : Form
    {
        private List<string> mFileList;

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



        private void 湖北快3ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }


        private void openDirectoryButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("".GetCommandLinePath());
        }



        private void 格式化C代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Methods.FormatCSharpCode(Clipboard.GetText()));
            try
            {

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

                foreach (var item in Directory.GetFiles(Clipboard.GetText().Trim(), "*.zip"))
                {
                    Methods.UnCompressFile(item);
                }

            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);

            }
        }

        private void lotteryButton_ButtonClick(object sender, EventArgs e)
        {
            var dlg = new Hbk3();
            dlg.Show();
        }

        private void 格式化CSVJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var str = Helpers.CSVReaderExtension.ProcessCSVFile(Clipboard.GetText(), false, null);
                //foreach (string line in lines)
                //    csv.Add(line.Split(' ')); // or, populate YourClass          
                //string json = new
                //    System.Web.Script.Serialization.JavaScriptSerializer().Serialize(csv);
            }
            catch (Exception
            exc)
            {

            }
        }

        private void 单行代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Clipboard.SetText(Regex.Replace(Regex.Replace(Clipboard.GetText(), "\r", "").Replace("\n", "\\n"), "\t+", ","));
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            var dlg = new CodePreViewForm();
            dlg.Show();
        }

        private void colordefinitionsscssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("$palette-red:");
            sb.AppendLine("\"255,235,238\"");
            sb.AppendLine("\"255,205,210\"");
            sb.AppendLine("\"239,154,154\"");
            sb.AppendLine("\"229,115,115\"");
            sb.AppendLine("\"239,83,80\"");
            sb.AppendLine("\"244,67,54\"");
            sb.AppendLine("\"229,57,53\"");
            sb.AppendLine("\"211,47,47\"");
            sb.AppendLine("\"198,40,40\"");
            sb.AppendLine("\"183,28,28\"");
            sb.AppendLine("\"255,138,128\"");
            sb.AppendLine("\"255,82,82\"");
            sb.AppendLine("\"255,23,68\"");
            sb.AppendLine("\"213,0,0\";");
            sb.AppendLine("$palette-red-50: nth($palette-red, 1);");
            sb.AppendLine("$palette-red-100: nth($palette-red, 2);");
            sb.AppendLine("$palette-red-200: nth($palette-red, 3);");
            sb.AppendLine("$palette-red-300: nth($palette-red, 4);");
            sb.AppendLine("$palette-red-400: nth($palette-red, 5);");
            sb.AppendLine("$palette-red-500: nth($palette-red, 6);");
            sb.AppendLine("$palette-red-600: nth($palette-red, 7);");
            sb.AppendLine("$palette-red-700: nth($palette-red, 8);");
            sb.AppendLine("$palette-red-800: nth($palette-red, 9);");
            sb.AppendLine("$palette-red-900: nth($palette-red, 10);");
            sb.AppendLine("$palette-red-A100: nth($palette-red, 11);");
            sb.AppendLine("$palette-red-A200: nth($palette-red, 12);");
            sb.AppendLine("$palette-red-A400: nth($palette-red, 13);");
            sb.AppendLine("$palette-red-A700: nth($palette-red, 14);");
            sb.AppendLine("$palette-pink:");
            sb.AppendLine("\"252,228,236\"");
            sb.AppendLine("\"248,187,208\"");
            sb.AppendLine("\"244,143,177\"");
            sb.AppendLine("\"240,98,146\"");
            sb.AppendLine("\"236,64,122\"");
            sb.AppendLine("\"233,30,99\"");
            sb.AppendLine("\"216,27,96\"");
            sb.AppendLine("\"194,24,91\"");
            sb.AppendLine("\"173,20,87\"");
            sb.AppendLine("\"136,14,79\"");
            sb.AppendLine("\"255,128,171\"");
            sb.AppendLine("\"255,64,129\"");
            sb.AppendLine("\"245,0,87\"");
            sb.AppendLine("\"197,17,98\";");
            sb.AppendLine("$palette-pink-50: nth($palette-pink, 1);");
            sb.AppendLine("$palette-pink-100: nth($palette-pink, 2);");
            sb.AppendLine("$palette-pink-200: nth($palette-pink, 3);");
            sb.AppendLine("$palette-pink-300: nth($palette-pink, 4);");
            sb.AppendLine("$palette-pink-400: nth($palette-pink, 5);");
            sb.AppendLine("$palette-pink-500: nth($palette-pink, 6);");
            sb.AppendLine("$palette-pink-600: nth($palette-pink, 7);");
            sb.AppendLine("$palette-pink-700: nth($palette-pink, 8);");
            sb.AppendLine("$palette-pink-800: nth($palette-pink, 9);");
            sb.AppendLine("$palette-pink-900: nth($palette-pink, 10);");
            sb.AppendLine("$palette-pink-A100: nth($palette-pink, 11);");
            sb.AppendLine("$palette-pink-A200: nth($palette-pink, 12);");
            sb.AppendLine("$palette-pink-A400: nth($palette-pink, 13);");
            sb.AppendLine("$palette-pink-A700: nth($palette-pink, 14);");
            sb.AppendLine("$palette-purple:");
            sb.AppendLine("\"243,229,245\"");
            sb.AppendLine("\"225,190,231\"");
            sb.AppendLine("\"206,147,216\"");
            sb.AppendLine("\"186,104,200\"");
            sb.AppendLine("\"171,71,188\"");
            sb.AppendLine("\"156,39,176\"");
            sb.AppendLine("\"142,36,170\"");
            sb.AppendLine("\"123,31,162\"");
            sb.AppendLine("\"106,27,154\"");
            sb.AppendLine("\"74,20,140\"");
            sb.AppendLine("\"234,128,252\"");
            sb.AppendLine("\"224,64,251\"");
            sb.AppendLine("\"213,0,249\"");
            sb.AppendLine("\"170,0,255\";");
            sb.AppendLine("$palette-purple-50: nth($palette-purple, 1);");
            sb.AppendLine("$palette-purple-100: nth($palette-purple, 2);");
            sb.AppendLine("$palette-purple-200: nth($palette-purple, 3);");
            sb.AppendLine("$palette-purple-300: nth($palette-purple, 4);");
            sb.AppendLine("$palette-purple-400: nth($palette-purple, 5);");
            sb.AppendLine("$palette-purple-500: nth($palette-purple, 6);");
            sb.AppendLine("$palette-purple-600: nth($palette-purple, 7);");
            sb.AppendLine("$palette-purple-700: nth($palette-purple, 8);");
            sb.AppendLine("$palette-purple-800: nth($palette-purple, 9);");
            sb.AppendLine("$palette-purple-900: nth($palette-purple, 10);");
            sb.AppendLine("$palette-purple-A100: nth($palette-purple, 11);");
            sb.AppendLine("$palette-purple-A200: nth($palette-purple, 12);");
            sb.AppendLine("$palette-purple-A400: nth($palette-purple, 13);");
            sb.AppendLine("$palette-purple-A700: nth($palette-purple, 14);");
            sb.AppendLine("$palette-deep-purple:");
            sb.AppendLine("\"237,231,246\"");
            sb.AppendLine("\"209,196,233\"");
            sb.AppendLine("\"179,157,219\"");
            sb.AppendLine("\"149,117,205\"");
            sb.AppendLine("\"126,87,194\"");
            sb.AppendLine("\"103,58,183\"");
            sb.AppendLine("\"94,53,177\"");
            sb.AppendLine("\"81,45,168\"");
            sb.AppendLine("\"69,39,160\"");
            sb.AppendLine("\"49,27,146\"");
            sb.AppendLine("\"179,136,255\"");
            sb.AppendLine("\"124,77,255\"");
            sb.AppendLine("\"101,31,255\"");
            sb.AppendLine("\"98,0,234\";");
            sb.AppendLine("$palette-deep-purple-50: nth($palette-deep-purple, 1);");
            sb.AppendLine("$palette-deep-purple-100: nth($palette-deep-purple, 2);");
            sb.AppendLine("$palette-deep-purple-200: nth($palette-deep-purple, 3);");
            sb.AppendLine("$palette-deep-purple-300: nth($palette-deep-purple, 4);");
            sb.AppendLine("$palette-deep-purple-400: nth($palette-deep-purple, 5);");
            sb.AppendLine("$palette-deep-purple-500: nth($palette-deep-purple, 6);");
            sb.AppendLine("$palette-deep-purple-600: nth($palette-deep-purple, 7);");
            sb.AppendLine("$palette-deep-purple-700: nth($palette-deep-purple, 8);");
            sb.AppendLine("$palette-deep-purple-800: nth($palette-deep-purple, 9);");
            sb.AppendLine("$palette-deep-purple-900: nth($palette-deep-purple, 10);");
            sb.AppendLine("$palette-deep-purple-A100: nth($palette-deep-purple, 11);");
            sb.AppendLine("$palette-deep-purple-A200: nth($palette-deep-purple, 12);");
            sb.AppendLine("$palette-deep-purple-A400: nth($palette-deep-purple, 13);");
            sb.AppendLine("$palette-deep-purple-A700: nth($palette-deep-purple, 14);");
            sb.AppendLine("$palette-indigo:");
            sb.AppendLine("\"232,234,246\"");
            sb.AppendLine("\"197,202,233\"");
            sb.AppendLine("\"159,168,218\"");
            sb.AppendLine("\"121,134,203\"");
            sb.AppendLine("\"92,107,192\"");
            sb.AppendLine("\"63,81,181\"");
            sb.AppendLine("\"57,73,171\"");
            sb.AppendLine("\"48,63,159\"");
            sb.AppendLine("\"40,53,147\"");
            sb.AppendLine("\"26,35,126\"");
            sb.AppendLine("\"140,158,255\"");
            sb.AppendLine("\"83,109,254\"");
            sb.AppendLine("\"61,90,254\"");
            sb.AppendLine("\"48,79,254\";");
            sb.AppendLine("$palette-indigo-50: nth($palette-indigo, 1);");
            sb.AppendLine("$palette-indigo-100: nth($palette-indigo, 2);");
            sb.AppendLine("$palette-indigo-200: nth($palette-indigo, 3);");
            sb.AppendLine("$palette-indigo-300: nth($palette-indigo, 4);");
            sb.AppendLine("$palette-indigo-400: nth($palette-indigo, 5);");
            sb.AppendLine("$palette-indigo-500: nth($palette-indigo, 6);");
            sb.AppendLine("$palette-indigo-600: nth($palette-indigo, 7);");
            sb.AppendLine("$palette-indigo-700: nth($palette-indigo, 8);");
            sb.AppendLine("$palette-indigo-800: nth($palette-indigo, 9);");
            sb.AppendLine("$palette-indigo-900: nth($palette-indigo, 10);");
            sb.AppendLine("$palette-indigo-A100: nth($palette-indigo, 11);");
            sb.AppendLine("$palette-indigo-A200: nth($palette-indigo, 12);");
            sb.AppendLine("$palette-indigo-A400: nth($palette-indigo, 13);");
            sb.AppendLine("$palette-indigo-A700: nth($palette-indigo, 14);");
            sb.AppendLine("$palette-blue:");
            sb.AppendLine("\"227,242,253\"");
            sb.AppendLine("\"187,222,251\"");
            sb.AppendLine("\"144,202,249\"");
            sb.AppendLine("\"100,181,246\"");
            sb.AppendLine("\"66,165,245\"");
            sb.AppendLine("\"33,150,243\"");
            sb.AppendLine("\"30,136,229\"");
            sb.AppendLine("\"25,118,210\"");
            sb.AppendLine("\"21,101,192\"");
            sb.AppendLine("\"13,71,161\"");
            sb.AppendLine("\"130,177,255\"");
            sb.AppendLine("\"68,138,255\"");
            sb.AppendLine("\"41,121,255\"");
            sb.AppendLine("\"41,98,255\";");
            sb.AppendLine("$palette-blue-50: nth($palette-blue, 1);");
            sb.AppendLine("$palette-blue-100: nth($palette-blue, 2);");
            sb.AppendLine("$palette-blue-200: nth($palette-blue, 3);");
            sb.AppendLine("$palette-blue-300: nth($palette-blue, 4);");
            sb.AppendLine("$palette-blue-400: nth($palette-blue, 5);");
            sb.AppendLine("$palette-blue-500: nth($palette-blue, 6);");
            sb.AppendLine("$palette-blue-600: nth($palette-blue, 7);");
            sb.AppendLine("$palette-blue-700: nth($palette-blue, 8);");
            sb.AppendLine("$palette-blue-800: nth($palette-blue, 9);");
            sb.AppendLine("$palette-blue-900: nth($palette-blue, 10);");
            sb.AppendLine("$palette-blue-A100: nth($palette-blue, 11);");
            sb.AppendLine("$palette-blue-A200: nth($palette-blue, 12);");
            sb.AppendLine("$palette-blue-A400: nth($palette-blue, 13);");
            sb.AppendLine("$palette-blue-A700: nth($palette-blue, 14);");
            sb.AppendLine("$palette-light-blue:");
            sb.AppendLine("\"225,245,254\"");
            sb.AppendLine("\"179,229,252\"");
            sb.AppendLine("\"129,212,250\"");
            sb.AppendLine("\"79,195,247\"");
            sb.AppendLine("\"41,182,246\"");
            sb.AppendLine("\"3,169,244\"");
            sb.AppendLine("\"3,155,229\"");
            sb.AppendLine("\"2,136,209\"");
            sb.AppendLine("\"2,119,189\"");
            sb.AppendLine("\"1,87,155\"");
            sb.AppendLine("\"128,216,255\"");
            sb.AppendLine("\"64,196,255\"");
            sb.AppendLine("\"0,176,255\"");
            sb.AppendLine("\"0,145,234\";");
            sb.AppendLine("$palette-light-blue-50: nth($palette-light-blue, 1);");
            sb.AppendLine("$palette-light-blue-100: nth($palette-light-blue, 2);");
            sb.AppendLine("$palette-light-blue-200: nth($palette-light-blue, 3);");
            sb.AppendLine("$palette-light-blue-300: nth($palette-light-blue, 4);");
            sb.AppendLine("$palette-light-blue-400: nth($palette-light-blue, 5);");
            sb.AppendLine("$palette-light-blue-500: nth($palette-light-blue, 6);");
            sb.AppendLine("$palette-light-blue-600: nth($palette-light-blue, 7);");
            sb.AppendLine("$palette-light-blue-700: nth($palette-light-blue, 8);");
            sb.AppendLine("$palette-light-blue-800: nth($palette-light-blue, 9);");
            sb.AppendLine("$palette-light-blue-900: nth($palette-light-blue, 10);");
            sb.AppendLine("$palette-light-blue-A100: nth($palette-light-blue, 11);");
            sb.AppendLine("$palette-light-blue-A200: nth($palette-light-blue, 12);");
            sb.AppendLine("$palette-light-blue-A400: nth($palette-light-blue, 13);");
            sb.AppendLine("$palette-light-blue-A700: nth($palette-light-blue, 14);");
            sb.AppendLine("$palette-cyan:");
            sb.AppendLine("\"224,247,250\"");
            sb.AppendLine("\"178,235,242\"");
            sb.AppendLine("\"128,222,234\"");
            sb.AppendLine("\"77,208,225\"");
            sb.AppendLine("\"38,198,218\"");
            sb.AppendLine("\"0,188,212\"");
            sb.AppendLine("\"0,172,193\"");
            sb.AppendLine("\"0,151,167\"");
            sb.AppendLine("\"0,131,143\"");
            sb.AppendLine("\"0,96,100\"");
            sb.AppendLine("\"132,255,255\"");
            sb.AppendLine("\"24,255,255\"");
            sb.AppendLine("\"0,229,255\"");
            sb.AppendLine("\"0,184,212\";");
            sb.AppendLine("$palette-cyan-50: nth($palette-cyan, 1);");
            sb.AppendLine("$palette-cyan-100: nth($palette-cyan, 2);");
            sb.AppendLine("$palette-cyan-200: nth($palette-cyan, 3);");
            sb.AppendLine("$palette-cyan-300: nth($palette-cyan, 4);");
            sb.AppendLine("$palette-cyan-400: nth($palette-cyan, 5);");
            sb.AppendLine("$palette-cyan-500: nth($palette-cyan, 6);");
            sb.AppendLine("$palette-cyan-600: nth($palette-cyan, 7);");
            sb.AppendLine("$palette-cyan-700: nth($palette-cyan, 8);");
            sb.AppendLine("$palette-cyan-800: nth($palette-cyan, 9);");
            sb.AppendLine("$palette-cyan-900: nth($palette-cyan, 10);");
            sb.AppendLine("$palette-cyan-A100: nth($palette-cyan, 11);");
            sb.AppendLine("$palette-cyan-A200: nth($palette-cyan, 12);");
            sb.AppendLine("$palette-cyan-A400: nth($palette-cyan, 13);");
            sb.AppendLine("$palette-cyan-A700: nth($palette-cyan, 14);");
            sb.AppendLine("$palette-teal:");
            sb.AppendLine("\"224,242,241\"");
            sb.AppendLine("\"178,223,219\"");
            sb.AppendLine("\"128,203,196\"");
            sb.AppendLine("\"77,182,172\"");
            sb.AppendLine("\"38,166,154\"");
            sb.AppendLine("\"0,150,136\"");
            sb.AppendLine("\"0,137,123\"");
            sb.AppendLine("\"0,121,107\"");
            sb.AppendLine("\"0,105,92\"");
            sb.AppendLine("\"0,77,64\"");
            sb.AppendLine("\"167,255,235\"");
            sb.AppendLine("\"100,255,218\"");
            sb.AppendLine("\"29,233,182\"");
            sb.AppendLine("\"0,191,165\";");
            sb.AppendLine("$palette-teal-50: nth($palette-teal, 1);");
            sb.AppendLine("$palette-teal-100: nth($palette-teal, 2);");
            sb.AppendLine("$palette-teal-200: nth($palette-teal, 3);");
            sb.AppendLine("$palette-teal-300: nth($palette-teal, 4);");
            sb.AppendLine("$palette-teal-400: nth($palette-teal, 5);");
            sb.AppendLine("$palette-teal-500: nth($palette-teal, 6);");
            sb.AppendLine("$palette-teal-600: nth($palette-teal, 7);");
            sb.AppendLine("$palette-teal-700: nth($palette-teal, 8);");
            sb.AppendLine("$palette-teal-800: nth($palette-teal, 9);");
            sb.AppendLine("$palette-teal-900: nth($palette-teal, 10);");
            sb.AppendLine("$palette-teal-A100: nth($palette-teal, 11);");
            sb.AppendLine("$palette-teal-A200: nth($palette-teal, 12);");
            sb.AppendLine("$palette-teal-A400: nth($palette-teal, 13);");
            sb.AppendLine("$palette-teal-A700: nth($palette-teal, 14);");
            sb.AppendLine("$palette-green:");
            sb.AppendLine("\"232,245,233\"");
            sb.AppendLine("\"200,230,201\"");
            sb.AppendLine("\"165,214,167\"");
            sb.AppendLine("\"129,199,132\"");
            sb.AppendLine("\"102,187,106\"");
            sb.AppendLine("\"76,175,80\"");
            sb.AppendLine("\"67,160,71\"");
            sb.AppendLine("\"56,142,60\"");
            sb.AppendLine("\"46,125,50\"");
            sb.AppendLine("\"27,94,32\"");
            sb.AppendLine("\"185,246,202\"");
            sb.AppendLine("\"105,240,174\"");
            sb.AppendLine("\"0,230,118\"");
            sb.AppendLine("\"0,200,83\";");
            sb.AppendLine("$palette-green-50: nth($palette-green, 1);");
            sb.AppendLine("$palette-green-100: nth($palette-green, 2);");
            sb.AppendLine("$palette-green-200: nth($palette-green, 3);");
            sb.AppendLine("$palette-green-300: nth($palette-green, 4);");
            sb.AppendLine("$palette-green-400: nth($palette-green, 5);");
            sb.AppendLine("$palette-green-500: nth($palette-green, 6);");
            sb.AppendLine("$palette-green-600: nth($palette-green, 7);");
            sb.AppendLine("$palette-green-700: nth($palette-green, 8);");
            sb.AppendLine("$palette-green-800: nth($palette-green, 9);");
            sb.AppendLine("$palette-green-900: nth($palette-green, 10);");
            sb.AppendLine("$palette-green-A100: nth($palette-green, 11);");
            sb.AppendLine("$palette-green-A200: nth($palette-green, 12);");
            sb.AppendLine("$palette-green-A400: nth($palette-green, 13);");
            sb.AppendLine("$palette-green-A700: nth($palette-green, 14);");
            sb.AppendLine("$palette-light-green:");
            sb.AppendLine("\"241,248,233\"");
            sb.AppendLine("\"220,237,200\"");
            sb.AppendLine("\"197,225,165\"");
            sb.AppendLine("\"174,213,129\"");
            sb.AppendLine("\"156,204,101\"");
            sb.AppendLine("\"139,195,74\"");
            sb.AppendLine("\"124,179,66\"");
            sb.AppendLine("\"104,159,56\"");
            sb.AppendLine("\"85,139,47\"");
            sb.AppendLine("\"51,105,30\"");
            sb.AppendLine("\"204,255,144\"");
            sb.AppendLine("\"178,255,89\"");
            sb.AppendLine("\"118,255,3\"");
            sb.AppendLine("\"100,221,23\";");
            sb.AppendLine("$palette-light-green-50: nth($palette-light-green, 1);");
            sb.AppendLine("$palette-light-green-100: nth($palette-light-green, 2);");
            sb.AppendLine("$palette-light-green-200: nth($palette-light-green, 3);");
            sb.AppendLine("$palette-light-green-300: nth($palette-light-green, 4);");
            sb.AppendLine("$palette-light-green-400: nth($palette-light-green, 5);");
            sb.AppendLine("$palette-light-green-500: nth($palette-light-green, 6);");
            sb.AppendLine("$palette-light-green-600: nth($palette-light-green, 7);");
            sb.AppendLine("$palette-light-green-700: nth($palette-light-green, 8);");
            sb.AppendLine("$palette-light-green-800: nth($palette-light-green, 9);");
            sb.AppendLine("$palette-light-green-900: nth($palette-light-green, 10);");
            sb.AppendLine("$palette-light-green-A100: nth($palette-light-green, 11);");
            sb.AppendLine("$palette-light-green-A200: nth($palette-light-green, 12);");
            sb.AppendLine("$palette-light-green-A400: nth($palette-light-green, 13);");
            sb.AppendLine("$palette-light-green-A700: nth($palette-light-green, 14);");
            sb.AppendLine("$palette-lime:");
            sb.AppendLine("\"249,251,231\"");
            sb.AppendLine("\"240,244,195\"");
            sb.AppendLine("\"230,238,156\"");
            sb.AppendLine("\"220,231,117\"");
            sb.AppendLine("\"212,225,87\"");
            sb.AppendLine("\"205,220,57\"");
            sb.AppendLine("\"192,202,51\"");
            sb.AppendLine("\"175,180,43\"");
            sb.AppendLine("\"158,157,36\"");
            sb.AppendLine("\"130,119,23\"");
            sb.AppendLine("\"244,255,129\"");
            sb.AppendLine("\"238,255,65\"");
            sb.AppendLine("\"198,255,0\"");
            sb.AppendLine("\"174,234,0\";");
            sb.AppendLine("$palette-lime-50: nth($palette-lime, 1);");
            sb.AppendLine("$palette-lime-100: nth($palette-lime, 2);");
            sb.AppendLine("$palette-lime-200: nth($palette-lime, 3);");
            sb.AppendLine("$palette-lime-300: nth($palette-lime, 4);");
            sb.AppendLine("$palette-lime-400: nth($palette-lime, 5);");
            sb.AppendLine("$palette-lime-500: nth($palette-lime, 6);");
            sb.AppendLine("$palette-lime-600: nth($palette-lime, 7);");
            sb.AppendLine("$palette-lime-700: nth($palette-lime, 8);");
            sb.AppendLine("$palette-lime-800: nth($palette-lime, 9);");
            sb.AppendLine("$palette-lime-900: nth($palette-lime, 10);");
            sb.AppendLine("$palette-lime-A100: nth($palette-lime, 11);");
            sb.AppendLine("$palette-lime-A200: nth($palette-lime, 12);");
            sb.AppendLine("$palette-lime-A400: nth($palette-lime, 13);");
            sb.AppendLine("$palette-lime-A700: nth($palette-lime, 14);");
            sb.AppendLine("$palette-yellow:");
            sb.AppendLine("\"255,253,231\"");
            sb.AppendLine("\"255,249,196\"");
            sb.AppendLine("\"255,245,157\"");
            sb.AppendLine("\"255,241,118\"");
            sb.AppendLine("\"255,238,88\"");
            sb.AppendLine("\"255,235,59\"");
            sb.AppendLine("\"253,216,53\"");
            sb.AppendLine("\"251,192,45\"");
            sb.AppendLine("\"249,168,37\"");
            sb.AppendLine("\"245,127,23\"");
            sb.AppendLine("\"255,255,141\"");
            sb.AppendLine("\"255,255,0\"");
            sb.AppendLine("\"255,234,0\"");
            sb.AppendLine("\"255,214,0\";");
            sb.AppendLine("$palette-yellow-50: nth($palette-yellow, 1);");
            sb.AppendLine("$palette-yellow-100: nth($palette-yellow, 2);");
            sb.AppendLine("$palette-yellow-200: nth($palette-yellow, 3);");
            sb.AppendLine("$palette-yellow-300: nth($palette-yellow, 4);");
            sb.AppendLine("$palette-yellow-400: nth($palette-yellow, 5);");
            sb.AppendLine("$palette-yellow-500: nth($palette-yellow, 6);");
            sb.AppendLine("$palette-yellow-600: nth($palette-yellow, 7);");
            sb.AppendLine("$palette-yellow-700: nth($palette-yellow, 8);");
            sb.AppendLine("$palette-yellow-800: nth($palette-yellow, 9);");
            sb.AppendLine("$palette-yellow-900: nth($palette-yellow, 10);");
            sb.AppendLine("$palette-yellow-A100: nth($palette-yellow, 11);");
            sb.AppendLine("$palette-yellow-A200: nth($palette-yellow, 12);");
            sb.AppendLine("$palette-yellow-A400: nth($palette-yellow, 13);");
            sb.AppendLine("$palette-yellow-A700: nth($palette-yellow, 14);");
            sb.AppendLine("$palette-amber:");
            sb.AppendLine("\"255,248,225\"");
            sb.AppendLine("\"255,236,179\"");
            sb.AppendLine("\"255,224,130\"");
            sb.AppendLine("\"255,213,79\"");
            sb.AppendLine("\"255,202,40\"");
            sb.AppendLine("\"255,193,7\"");
            sb.AppendLine("\"255,179,0\"");
            sb.AppendLine("\"255,160,0\"");
            sb.AppendLine("\"255,143,0\"");
            sb.AppendLine("\"255,111,0\"");
            sb.AppendLine("\"255,229,127\"");
            sb.AppendLine("\"255,215,64\"");
            sb.AppendLine("\"255,196,0\"");
            sb.AppendLine("\"255,171,0\";");
            sb.AppendLine("$palette-amber-50: nth($palette-amber, 1);");
            sb.AppendLine("$palette-amber-100: nth($palette-amber, 2);");
            sb.AppendLine("$palette-amber-200: nth($palette-amber, 3);");
            sb.AppendLine("$palette-amber-300: nth($palette-amber, 4);");
            sb.AppendLine("$palette-amber-400: nth($palette-amber, 5);");
            sb.AppendLine("$palette-amber-500: nth($palette-amber, 6);");
            sb.AppendLine("$palette-amber-600: nth($palette-amber, 7);");
            sb.AppendLine("$palette-amber-700: nth($palette-amber, 8);");
            sb.AppendLine("$palette-amber-800: nth($palette-amber, 9);");
            sb.AppendLine("$palette-amber-900: nth($palette-amber, 10);");
            sb.AppendLine("$palette-amber-A100: nth($palette-amber, 11);");
            sb.AppendLine("$palette-amber-A200: nth($palette-amber, 12);");
            sb.AppendLine("$palette-amber-A400: nth($palette-amber, 13);");
            sb.AppendLine("$palette-amber-A700: nth($palette-amber, 14);");
            sb.AppendLine("$palette-orange:");
            sb.AppendLine("\"255,243,224\"");
            sb.AppendLine("\"255,224,178\"");
            sb.AppendLine("\"255,204,128\"");
            sb.AppendLine("\"255,183,77\"");
            sb.AppendLine("\"255,167,38\"");
            sb.AppendLine("\"255,152,0\"");
            sb.AppendLine("\"251,140,0\"");
            sb.AppendLine("\"245,124,0\"");
            sb.AppendLine("\"239,108,0\"");
            sb.AppendLine("\"230,81,0\"");
            sb.AppendLine("\"255,209,128\"");
            sb.AppendLine("\"255,171,64\"");
            sb.AppendLine("\"255,145,0\"");
            sb.AppendLine("\"255,109,0\";");
            sb.AppendLine("$palette-orange-50: nth($palette-orange, 1);");
            sb.AppendLine("$palette-orange-100: nth($palette-orange, 2);");
            sb.AppendLine("$palette-orange-200: nth($palette-orange, 3);");
            sb.AppendLine("$palette-orange-300: nth($palette-orange, 4);");
            sb.AppendLine("$palette-orange-400: nth($palette-orange, 5);");
            sb.AppendLine("$palette-orange-500: nth($palette-orange, 6);");
            sb.AppendLine("$palette-orange-600: nth($palette-orange, 7);");
            sb.AppendLine("$palette-orange-700: nth($palette-orange, 8);");
            sb.AppendLine("$palette-orange-800: nth($palette-orange, 9);");
            sb.AppendLine("$palette-orange-900: nth($palette-orange, 10);");
            sb.AppendLine("$palette-orange-A100: nth($palette-orange, 11);");
            sb.AppendLine("$palette-orange-A200: nth($palette-orange, 12);");
            sb.AppendLine("$palette-orange-A400: nth($palette-orange, 13);");
            sb.AppendLine("$palette-orange-A700: nth($palette-orange, 14);");
            sb.AppendLine("$palette-deep-orange:");
            sb.AppendLine("\"251,233,231\"");
            sb.AppendLine("\"255,204,188\"");
            sb.AppendLine("\"255,171,145\"");
            sb.AppendLine("\"255,138,101\"");
            sb.AppendLine("\"255,112,67\"");
            sb.AppendLine("\"255,87,34\"");
            sb.AppendLine("\"244,81,30\"");
            sb.AppendLine("\"230,74,25\"");
            sb.AppendLine("\"216,67,21\"");
            sb.AppendLine("\"191,54,12\"");
            sb.AppendLine("\"255,158,128\"");
            sb.AppendLine("\"255,110,64\"");
            sb.AppendLine("\"255,61,0\"");
            sb.AppendLine("\"221,44,0\";");
            sb.AppendLine("$palette-deep-orange-50: nth($palette-deep-orange, 1);");
            sb.AppendLine("$palette-deep-orange-100: nth($palette-deep-orange, 2);");
            sb.AppendLine("$palette-deep-orange-200: nth($palette-deep-orange, 3);");
            sb.AppendLine("$palette-deep-orange-300: nth($palette-deep-orange, 4);");
            sb.AppendLine("$palette-deep-orange-400: nth($palette-deep-orange, 5);");
            sb.AppendLine("$palette-deep-orange-500: nth($palette-deep-orange, 6);");
            sb.AppendLine("$palette-deep-orange-600: nth($palette-deep-orange, 7);");
            sb.AppendLine("$palette-deep-orange-700: nth($palette-deep-orange, 8);");
            sb.AppendLine("$palette-deep-orange-800: nth($palette-deep-orange, 9);");
            sb.AppendLine("$palette-deep-orange-900: nth($palette-deep-orange, 10);");
            sb.AppendLine("$palette-deep-orange-A100: nth($palette-deep-orange, 11);");
            sb.AppendLine("$palette-deep-orange-A200: nth($palette-deep-orange, 12);");
            sb.AppendLine("$palette-deep-orange-A400: nth($palette-deep-orange, 13);");
            sb.AppendLine("$palette-deep-orange-A700: nth($palette-deep-orange, 14);");
            sb.AppendLine("// Color order: 50, 100, 200, 300, 400, 500, 600, 700, 800, 900.");
            sb.AppendLine("$palette-brown:");
            sb.AppendLine("\"239,235,233\"");
            sb.AppendLine("\"215,204,200\"");
            sb.AppendLine("\"188,170,164\"");
            sb.AppendLine("\"161,136,127\"");
            sb.AppendLine("\"141,110,99\"");
            sb.AppendLine("\"121,85,72\"");
            sb.AppendLine("\"109,76,65\"");
            sb.AppendLine("\"93,64,55\"");
            sb.AppendLine("\"78,52,46\"");
            sb.AppendLine("\"62,39,35\";");
            sb.AppendLine("$palette-brown-50: nth($palette-brown, 1);");
            sb.AppendLine("$palette-brown-100: nth($palette-brown, 2);");
            sb.AppendLine("$palette-brown-200: nth($palette-brown, 3);");
            sb.AppendLine("$palette-brown-300: nth($palette-brown, 4);");
            sb.AppendLine("$palette-brown-400: nth($palette-brown, 5);");
            sb.AppendLine("$palette-brown-500: nth($palette-brown, 6);");
            sb.AppendLine("$palette-brown-600: nth($palette-brown, 7);");
            sb.AppendLine("$palette-brown-700: nth($palette-brown, 8);");
            sb.AppendLine("$palette-brown-800: nth($palette-brown, 9);");
            sb.AppendLine("$palette-brown-900: nth($palette-brown, 10);");
            sb.AppendLine("$palette-grey:");
            sb.AppendLine("\"250,250,250\"");
            sb.AppendLine("\"245,245,245\"");
            sb.AppendLine("\"238,238,238\"");
            sb.AppendLine("\"224,224,224\"");
            sb.AppendLine("\"189,189,189\"");
            sb.AppendLine("\"158,158,158\"");
            sb.AppendLine("\"117,117,117\"");
            sb.AppendLine("\"97,97,97\"");
            sb.AppendLine("\"66,66,66\"");
            sb.AppendLine("\"33,33,33\";");
            sb.AppendLine("$palette-grey-50: nth($palette-grey, 1);");
            sb.AppendLine("$palette-grey-100: nth($palette-grey, 2);");
            sb.AppendLine("$palette-grey-200: nth($palette-grey, 3);");
            sb.AppendLine("$palette-grey-300: nth($palette-grey, 4);");
            sb.AppendLine("$palette-grey-400: nth($palette-grey, 5);");
            sb.AppendLine("$palette-grey-500: nth($palette-grey, 6);");
            sb.AppendLine("$palette-grey-600: nth($palette-grey, 7);");
            sb.AppendLine("$palette-grey-700: nth($palette-grey, 8);");
            sb.AppendLine("$palette-grey-800: nth($palette-grey, 9);");
            sb.AppendLine("$palette-grey-900: nth($palette-grey, 10);");
            sb.AppendLine("$palette-blue-grey:");
            sb.AppendLine("\"236,239,241\"");
            sb.AppendLine("\"207,216,220\"");
            sb.AppendLine("\"176,190,197\"");
            sb.AppendLine("\"144,164,174\"");
            sb.AppendLine("\"120,144,156\"");
            sb.AppendLine("\"96,125,139\"");
            sb.AppendLine("\"84,110,122\"");
            sb.AppendLine("\"69,90,100\"");
            sb.AppendLine("\"55,71,79\"");
            sb.AppendLine("\"38,50,56\";");
            sb.AppendLine("$palette-blue-grey-50: nth($palette-blue-grey, 1);");
            sb.AppendLine("$palette-blue-grey-100: nth($palette-blue-grey, 2);");
            sb.AppendLine("$palette-blue-grey-200: nth($palette-blue-grey, 3);");
            sb.AppendLine("$palette-blue-grey-300: nth($palette-blue-grey, 4);");
            sb.AppendLine("$palette-blue-grey-400: nth($palette-blue-grey, 5);");
            sb.AppendLine("$palette-blue-grey-500: nth($palette-blue-grey, 6);");
            sb.AppendLine("$palette-blue-grey-600: nth($palette-blue-grey, 7);");
            sb.AppendLine("$palette-blue-grey-700: nth($palette-blue-grey, 8);");
            sb.AppendLine("$palette-blue-grey-800: nth($palette-blue-grey, 9);");
            sb.AppendLine("$palette-blue-grey-900: nth($palette-blue-grey, 10);");
            sb.AppendLine("$color-black: \"0,0,0\";");
            sb.AppendLine("$color-white: \"255,255,255\";");
            sb.AppendLine("/* colors.scss */");
            sb.AppendLine("$styleguide-generate-template: false !default;");
            sb.AppendLine("// The two possible colors for overlayed text.");
            sb.AppendLine("$color-dark-contrast: $color-white !default;");
            sb.AppendLine("$color-light-contrast: $color-black !default;");

            // https://github.com/google/material-design-lite/blob/mdl-1.x/src/_color-definitions.scss
            var ls = Regex.Split(sb.ToString(), "\\$palette\\-[a-z]+:").
                Where(i => i.IsReadable()).Select(i => i.Trim().Split('\n').ElementAt(5).Trim()).Select(i => $"\'rgb({i.Trim('"')})\'").ToArray();

            Clipboard.SetText(string.Join(",", ls));
        }

        private void 十二生肖ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Clipboard.SetText($"[{string.Join(",", Formatter.ChineseZodiac.ToCharArray().Select(i => $"\"{i}\""))}]");
        }

        private void 自然数0100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"[{string.Join(",", Enumerable.Range(0, 101).Select(i => $"{i}"))}]");

        }

        private void 生成wkhtmltopdf命令行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dir = Clipboard.GetText().Trim();
            if (!Directory.Exists(dir))
                return;

            foreach (var item in Directory.GetDirectories(dir))
            {
                InvokeWkhtmltopdf(item);
            }

        }
        private void InvokeWkhtmltopdf(string f)
        {

            if (!File.Exists(Path.Combine(f, "目录.html"))) return;

            var styleFile = @"C:\Users\Administrator\Desktop\Safari\style.css";
            if (File.Exists(styleFile))
            {
                var targetStyleFile = Path.Combine(f, "style.css");
                if (File.Exists(targetStyleFile))
                    File.Delete(targetStyleFile);
                File.Copy(styleFile, targetStyleFile);
            }
            var hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(Path.Combine(f, "目录.html").ReadAllText());
            var nodes = hd.DocumentNode.SelectNodes("//a");
            var ls = new List<string>();
            foreach (var item in nodes)
            {
                var href = item.GetAttributeValue("href", "").Split('#').First();

                if (ls.Contains(href)) continue;
                ls.Add(href);
            }

            var str = "\"C:\\wkhtmltox\\wkhtmltopdf.exe\"";
            var arg = "--footer-center [page] -s Letter " + string.Join(" ", ls.Select(i => $"\"{i}\"")) + $" \"{f}.pdf\"";

            var p = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = str,
                Arguments = arg,
                WorkingDirectory = f
            });
            p.WaitForExit();
        }

        private void combinektFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dir = Clipboard.GetText().Trim();
            if (!Directory.Exists(dir))
                return;
            CombineKtFile(dir, true);

            foreach (var item in Directory.GetDirectories(dir))
            {
                CombineKtFile(item);
            }
        }
        void CombineKtFile(string dir, bool isParent = false)
        {

            var files = Directory.GetFiles(dir, "*.kt");
            var targetFile = isParent ? Path.Combine(dir, dir.GetFileName() + ".kt") : dir + ".kt";
            var count = 0;
            while (File.Exists(targetFile))
            {
                targetFile = isParent ? Path.Combine(dir, dir.GetFileName() + $" - {++count}" + ".kt") : dir + $" - {++count}" + ".kt";
            }
            var sb = new StringBuilder();
            // android.databinding.BindingAdapter
            var importList = new List<string>();
            foreach (var item in files)
            {
                var ls = Formatter.RemoveComments(item.ReadAllText()).Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                var codeList = ls.Where(i => !i.StartsWith("import ") && !i.StartsWith("package "));
                importList.AddRange(ls.Where(i => i.StartsWith("import ") && !i.StartsWith("package ")));
                sb.AppendLine(string.Join(Environment.NewLine, codeList));
            }
            sb.AppendLine(string.Join(Environment.NewLine, importList.Distinct().OrderBy(i => i)));
            targetFile.WriteAllText(sb.ToString());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var v = Clipboard.GetText().Trim().Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).OrderBy(i => i);
            Clipboard.SetText(string.Join(Environment.NewLine, v));
        }

        private void 合并SafariHTML文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dir = Clipboard.GetText().Trim();
            if (!Directory.Exists(dir))
                return;

            foreach (var item in Directory.GetDirectories(dir))
            {
                CombineSafariHTML(item);
            }
        }

        private void CombineSafariHTML(string dir)
        {
            var toc = Path.Combine(dir, "目录.html");

            if (!File.Exists(toc)) return;

            var hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(toc.ReadAllText());
            var nodes = hd.DocumentNode.SelectNodes("//a");
            var ls = new List<string>();
            foreach (var item in nodes)
            {
                var h = item.GetAttributeValue("href", "").Split(new[] { '#' }, 2).First().GetFileNameWithoutExtension();
                if (ls.Contains(h)) continue;
                ls.Add(h);
            }
            var targetFile = Path.Combine(dir, dir.GetFileName() + ".htm");
            var files = Directory.GetFiles(dir).Where(i => Regex.IsMatch(i, "\\.(?:html|xhtml|htm)$")).ToArray();

            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html> <html lang=en> <head> <meta charset=utf-8> <meta content=\"IE=edge\" http-equiv=X-UA-Compatible> <meta content=\"width=device-width,initial-scale=1\" name=viewport><link href=\"style.css\" rel=\"stylesheet\"></head><body>");

            foreach (var item in ls)
            {
                var f = files.Where(i => i.GetFileName().StartsWith(item)).First();
                try
                {

                    hd.LoadHtml(f.ReadAllText());

                    sb.Append(hd.DocumentNode.SelectSingleNode("//body").InnerHtml);
                }
                catch
                {

                }
            }
            sb.AppendLine("</body></html>");

            targetFile.WriteAllText(sb.ToString());

            foreach (var item in files)
            {
                File.Delete(item);

            }

        }

        private void kotlin_Click(object sender, EventArgs e)
        {
            var ls = Regex.Matches(Clipboard.GetText(), "(?<=var|val) +([0-9a-zA-Z_]+)").Cast<Match>().Select(i => i.Groups[1].Value);

            ls = ls.Union(Regex.Matches(Clipboard.GetText(), "([0-9a-zA-Z_]+) *?(?:[%\\*\\-\\+/]*?\\=|\\:)").Cast<Match>().Select(i => i.Groups[1].Value)).Distinct();

            var sb = new StringBuilder();
            sb.Append("Log.e(TAG,\"");
            foreach (var item in ls)
            {
                sb.Append(item + " => ${" + item + "} \\n");
            }
            sb.Append("\")");
            Clipboard.SetText(sb.ToString());
        }

        private void 提取方法名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var value = Clipboard.GetText();
            var ls = new List<string>();


            foreach (var item in Directory.GetFiles(value, "*.kt", SearchOption.AllDirectories))
            {
                var m = Regex.Matches(item.ReadAllText(), "fun ([^\\(]*?)(?:\\()");

                foreach (var v in m.Cast<Match>().ToArray())
                {
                    var vs = v.Groups[1].Value;
                    if (vs.Where(i => i == '<' || vs.StartsWith("<")).Count() > 1)
                    {
                        var c = 0;
                        var o = 0;
                        foreach (var vc in vs)
                        {
                            o++;
                            if (vc == '<')
                                c++;
                            else if (vc == '>')
                            {
                                c--;

                                if (c == 0)
                                {
                                    vs = vs.Substring(o);
                                    break;
                                }
                            }
                        }
                    }
                    ls.Add("- `" + vs.Trim() + "`");
                }
            }
            Clipboard.SetText(string.Join(Environment.NewLine, ls.Distinct().OrderBy(i => i)));
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            var value = Clipboard.GetText().Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            Clipboard.SetText(string.Join(Environment.NewLine, value));
        }

        private void 移除空行目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dir = Clipboard.GetText().Trim();
            if (!Directory.Exists(dir))
                return;

            var files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Where(i => Regex.IsMatch(i, "\\.(?:kt|java)$")).ToArray();
            foreach (var item in files)
            {
                var ls = item.ReadAllText().Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                item.WriteAllText(string.Join("\n", ls));
            }
        }

        private void 排序方法ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 压缩IntellijAndroid项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = Clipboard.GetText().Trim();
            if (!Directory.Exists(path))
                return;
            using (var zip = new Ionic.Zip.ZipFile(Encoding.GetEncoding("gb2312")))
            {

                zip.AddFiles(Directory.GetFiles(path), "");
                zip.AddFiles(Directory.GetFiles(Path.Combine(path, "app")), "app");
                zip.AddDirectory(Path.Combine(Path.Combine(path, "app"), "src"), "app/src");

                var fileName = Path.Combine(path, path.GetFileName() + ".zip");

                zip.Save(fileName);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var str = Clipboard.GetText();

            var hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(str);
            var nodes = hd.DocumentNode.SelectNodes("//code");

            var ls = new List<string>();
            foreach (var item in nodes)
            {
                ls.Add(item.InnerText.Trim().Trim('.'));
            }
            Clipboard.SetText(string.Join("|", ls.OrderBy(i => i).Distinct()));
        }

        private void 排序属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 生成Kotlin文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加const关键字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Clipboard.GetText().Replace(" val ", " const val "));
        }

        private void 提取声明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = string.Join("|", Regex.Matches(Clipboard.GetText(), "(?<=val|var) ([a-zA-Z_0-9]+)").Cast<Match>().Select(i => "\\b" + i.Groups[1].Value + "\\b"));

        }

        private void 替换全局声明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pattern = textBox.Text;

            var str = Regex.Replace(Clipboard.GetText(), pattern, new MatchEvaluator(v =>
                {
                    return "m" + v.Value[0].ToString().ToUpper() + new string(v.Value.Skip(1).ToArray());

                }));
            Clipboard.SetText(str);
        }

        private void 合并Kotlin文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dir = Clipboard.GetText().Trim();
            if (!Directory.Exists(dir))
                return;
            var files = Directory.GetFiles(dir, "*.kt", SearchOption.AllDirectories);
            var sb = new StringBuilder();

            foreach (var item in files)
            {
                var ls = Formatter.RemoveComments(item.ReadAllText()).Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                var codeList = ls.Where(i => !i.StartsWith("import ") && !i.StartsWith("package "));
                sb.AppendLine(string.Join(Environment.NewLine, codeList));

            }

            Path.Combine(dir, Path.GetFileName(dir) + ".kt").WriteAllText(sb.ToString());
        }

        private void orderFunButton_Click(object sender, EventArgs e)
        {
            OrderFunKotlin();
        }

        private void generateFile_Click(object sender, EventArgs e)
        {
            GenerateFileKotlin();
        }

        private void orderbyProperty_Click(object sender, EventArgs e)
        {
            OrderPropertyKotlin();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var dir = Clipboard.GetText().Trim();
            if (!Directory.Exists(dir))
                return;
            dir = dir + @"\src\main";

            var v = SummaryString(dir);

            v += "SummaryDrawable" + Environment.NewLine + Helper.SummaryDrawable(dir) + Environment.NewLine + Environment.NewLine;
            v += "SummaryColor" + Environment.NewLine + SummaryColor(dir) + Environment.NewLine + Environment.NewLine;
            v += "SummaryDimen" + Environment.NewLine + SummaryDimen(dir) + Environment.NewLine + Environment.NewLine;

            textBox.Text = v;

        }


        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var dir = Clipboard.GetText().Trim();
            RefreshFileList(dir);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                textBox.Text = Regex.Replace(mFileList[listBox1.SelectedIndex].ReadAllText(), "[\r\n]+", "\r\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dir = "dir.txt".GetCommandLinePath();
            if (File.Exists(dir))
            {
                var lines = dir.ReadAllLines().Where(i => !string.IsNullOrEmpty(i)).OrderBy(i => i).Select(i => i.Trim()).Distinct();
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(lines.ToArray());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dir = comboBox1.Text;
            if (!Directory.Exists(dir))
                return;
            RefreshFileList(dir);
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var dir = comboBox1.Text;
            if (!Directory.Exists(dir))
                return;

            mFileList = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Where(i => Regex.IsMatch(i, "\\.(?:xml|java|kt|cs|h|cpp|c)$")).OrderBy(i => i.GetFileName()).ToList();
            var ls = new List<string>();
            foreach (var item in mFileList)
            {
                if (Regex.IsMatch(item.ReadAllText(), comboBox2.Text))
                {
                    ls.Add(item);
                }
            }
            mFileList = ls;

            listBox1.Items.Clear();
            listBox1.Items.AddRange(mFileList.Select(i => i.GetFileName()).ToArray());

        }

        #region

        private string SummaryDimen(string dir)
        {
            var files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Where(i => Regex.IsMatch(i, "\\.(?:xml|java|kt|cs|h|cpp|c)$")).ToArray();
            var stringList = new List<string>();

            var stringFile = "";
            foreach (var item in files)
            {
                if (item.EndsWith("values\\dimens.xml"))
                    stringFile = item;
                //var m = Regex.Match(item.ReadAllText(), "(\\@string/([a-zA-Z0-9\\-_]+))|(R\\.string\\.([^\\s+]*?))");

                //if (m.Success)
                //{
                //    var xx = m.Groups[2];
                //    var i = 0;
                //}
                var items = Regex.Matches(item.ReadAllText(), "(\\@dimen/([a-zA-Z0-9\\-_]+))|(R\\.dimen\\.([a-zA-Z0-9\\-_]+))").Cast<Match>().Select((v) =>
                {
                    if (v.Groups[2].Length > 0)
                        return v.Groups[2].Value;
                    else
                        return v.Groups[4].Value;
                });
                stringList.AddRange(items.Distinct());

            }
            var xml = XDocument.Load(stringFile);
            var x = xml.Root.Descendants().Where(i => i.Name == "dimen").Where(i => stringList.Contains(i.Attribute("name").Value)).ToArray();
            var sb = new StringBuilder();
            foreach (var item in x)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
        private string SummaryColor(string dir)
        {
            var files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Where(i => Regex.IsMatch(i, "\\.(?:xml|java|kt|cs|h|cpp|c)$")).ToArray();
            var stringList = new List<string>();

            var stringFile = "";
            foreach (var item in files)
            {
                if (item.EndsWith("values\\colors.xml"))
                    stringFile = item;
                //var m = Regex.Match(item.ReadAllText(), "(\\@string/([a-zA-Z0-9\\-_]+))|(R\\.string\\.([^\\s+]*?))");

                //if (m.Success)
                //{
                //    var xx = m.Groups[2];
                //    var i = 0;
                //}
                var items = Regex.Matches(item.ReadAllText(), "(\\@color/([a-zA-Z0-9\\-_]+))|(R\\.color\\.([a-zA-Z0-9\\-_]+))").Cast<Match>().Select((v) =>
                {
                    if (v.Groups[2].Length > 0)
                        return v.Groups[2].Value;
                    else
                        return v.Groups[4].Value;
                });
                stringList.AddRange(items.Distinct());

            }
            var xml = XDocument.Load(stringFile);
            var x = xml.Root.Descendants().Where(i => i.Name == "color").Where(i => stringList.Contains(i.Attribute("name").Value)).ToArray();
            var sb = new StringBuilder();
            foreach (var item in x)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
        private string SummaryString(string dir)
        {
            var files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Where(i => Regex.IsMatch(i, "\\.(?:xml|java|kt|cs|h|cpp|c)$")).ToArray();
            var stringList = new List<string>();

            var stringFile = "";
            foreach (var item in files)
            {
                if (item.EndsWith("values\\strings.xml"))
                    stringFile = item;
                //var m = Regex.Match(item.ReadAllText(), "(\\@string/([a-zA-Z0-9\\-_]+))|(R\\.string\\.([^\\s+]*?))");

                //if (m.Success)
                //{
                //    var xx = m.Groups[2];
                //    var i = 0;
                //}
                var items = Regex.Matches(item.ReadAllText(), "(\\@string/([a-zA-Z0-9\\-_]+))|(R\\.string\\.([a-zA-Z0-9\\-_]+))").Cast<Match>().Select((v) =>
                {
                    if (v.Groups[2].Length > 0)
                        return v.Groups[2].Value;
                    else
                        return v.Groups[4].Value;
                });
                stringList.AddRange(items.Distinct());

            }
            var xml = XDocument.Load(stringFile);
            var x = xml.Root.Descendants().Where(i => i.Name == "string").Where(i => stringList.Contains(i.Attribute("name").Value)).ToArray();
            var sb = new StringBuilder();
            foreach (var item in x)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
        private void RefreshFileList(string dir)
        {
            if (!Directory.Exists(dir))
                return;

            mFileList = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Where(i => Regex.IsMatch(i, "\\.(?:xml|java|kt|cs|h|cpp|c)$")).OrderBy(i => i.GetFileName()).ToList();

            listBox1.Items.Clear();
            listBox1.Items.AddRange(mFileList.Select(i => i.GetFileName()).ToArray());
        }
        private void OrderFunKotlin()
        {
            var str = Clipboard.GetText();
            var lines = str.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var singleItems = lines.Where(i => (i.StartsWith("val") || i.StartsWith("fun ") || i.StartsWith("private fun") || i.StartsWith("private val")) && i.Contains(") = ") && !i.EndsWith("{")).ToArray();
            var sss = lines.Except(singleItems).ToArray();
            var ls = Formatter.FormatMethodList(string.Join("\n", lines.Where(i => !singleItems.Contains(i)))).Select(i => i.Trim()).OrderBy(i => Regex.Match(i, "fun ([^\\(]*?)(?:\\()").Groups[1].Value).ToArray();

            Clipboard.SetText(string.Join("\n", singleItems.OrderBy(i => i)) + "\n" + string.Join("\n", ls));
        }
        private void GenerateFileKotlin()
        {
            var v = Clipboard.GetText();
            // class DataProvider extends SQLiteOpenHelper 
            var fileName = Regex.Match(v, "(?<=class|interface) ([a-zA-Z_0-9]+)");

            if (fileName.Success)
            {
                (fileName.Groups[1].Value + ".kt").GetDesktopPath().WriteAllText(v);
            }
        }
        private void OrderPropertyKotlin()
        {
            var str = Clipboard.GetText();

            var ls = Formatter.FormatMethodList(str).ToArray();

            var list = new List<String>();
            for (int i = 0; i < ls.Length; i++)
            {

                if (i + 1 < ls.Length && ((ls[i + 1].TrimStart().StartsWith("get(") || ls[i + 1].TrimStart().StartsWith("set("))))
                {

                    list.Add(ls[i] + ls[++i]);
                }
                else
                    list.Add(ls[i]);


            }

            Clipboard.SetText(string.Join("\n", list.OrderBy(i => Regex.Match(i, "(?<=val|var) ([a-zA-Z_0-9]+)").Groups[1].Value)));
        }
        #endregion

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Enter) return;

            var pattern = textBox.SelectedText;
            if (string.IsNullOrWhiteSpace(pattern))
                pattern = comboBox3.Text.Trim();
            var pos = textBox.Text.IndexOf(pattern, textBox.SelectionStart + pattern.Length);
            if (pos < 0)
            {
                pos = textBox.Text.IndexOf(pattern);
            }
            if (pos > -1)
            {
                textBox.Focus();
                textBox.SelectionStart = pos;
                textBox.SelectionLength = pattern.Length;
                textBox.ScrollToCaret();
            }

        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var pattern = textBox.SelectedText;
            if (string.IsNullOrWhiteSpace(pattern))
                pattern = comboBox3.Text.Trim();
            var pos = textBox.Text.IndexOf(pattern, textBox.SelectionStart + pattern.Length);
            if (pos < 0)
            {
                pos = textBox.Text.IndexOf(pattern);
            }
            if (pos > -1)
            {
                textBox.Focus();
                textBox.SelectionStart = pos;
                textBox.SelectionLength = pattern.Length;
                textBox.ScrollToCaret();
            }
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                System.Diagnostics.Process.Start(mFileList[listBox1.SelectedIndex].GetDirectoryName());
            }
        }

        private void 生成目录列表文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.OnClipboardDirectory((v) =>
            {
                "dir.txt".GetCommandLinePath().WriteAllText(Helper.GenerateDirectoriesList(v));
            });
        }

        private void markdownToHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.OnClipboardDirectory((v) =>
            {
                var files = Directory.GetFiles(v, "*.md");
                foreach (var item in files)
                {
                    item.ChangeExtension(".html").WriteAllText(Helper.ConvertMarkdownToHtml(item.ReadAllText()));
                }
            });
        }

        private void java属性转KotlinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.OnClipboardString((v) =>
            {
                return Helper.FormatJavaFieldToKotlin(v);
            });
        }

        private void c常量属性转KotlinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.OnClipboardString((v) =>
            {
                return Helper.FormatCSharpConstFieldToKotlin(v);
            });
        }

        private void java常量属性转KotlinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.OnClipboardString((v) =>
            {
                return Helper.FormatJavaConstFieldToKotlin(v);
            });
        }
    }
}
