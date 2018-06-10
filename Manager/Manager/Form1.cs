/*
 * Install-Package System.Threading.Tasks.Extensions -Version 4.5.0
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;

namespace Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DebugHelper.Init("error.log");
        }
        // nslookup nuget.org 8.8.8.8

        private async void 创建数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var value = await Methods.CreateDatabase(Methods.ConnectionString);
            MessageBox.Show($"{value}");


        }
    }
}
