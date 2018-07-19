namespace Manager
{
    using Helpers;
    using Npgsql;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
            DebugHelper.Init("error.log");
        }


        private async void MainForm_Load(object sender, EventArgs e)
        {
           

            //this.WindowState = FormWindowState.Minimized;
            //var n = new Notification();
            //n.UpdateMessage("正在启动中...");
            //this.BeginInvoke(new Action(() =>
            //{
            //    n.ShowDialog();
            //}));
            //_npgsqlConnection = await DatabaseMethods.GetNpgsqlConnection();
            //n.Close();
            //this.WindowState = FormWindowState.Normal;
        }

        private async void 初始化表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {



                var result = await DatabaseMethods.CreateTable();
                DebugHelper.WriteLine($"{result}");
            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);
            }


        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DatabaseMethods.Cleanup();
        }

        private void 添加商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new ProductEditorForm(() =>
            {
            });
            dlg.ShowDialog();
        }
    }
}