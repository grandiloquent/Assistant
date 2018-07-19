using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();

        }

        public void UpdateMessage(string str)
        {
            label.Text = str;
        }
    }
}
