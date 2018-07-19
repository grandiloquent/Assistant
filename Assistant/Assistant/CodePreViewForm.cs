using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Assistant
{
    public partial class CodePreViewForm : Form
    {
        public CodePreViewForm()
        {
            InitializeComponent();
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();
            textBox1.Paste();
            var blockComments = @"/\*(.*?)\*/";
            var lineComments = @"//(.*?)\r?\n";
            var strings = @"""((\\[^\n]|[^""\n])*)""";
            var verbatimStrings = @"@(""[^""]*"")+";
   
            string noComments = Regex.Replace(textBox1.Text,
    blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
    me =>
    {
        if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
            return me.Value.StartsWith("//") ? Environment.NewLine : "";
        // Keep the literal strings
        return me.Value;
    },
    RegexOptions.Singleline);
            textBox1.Text = Regex.Replace(noComments, "[\r\n]+", Environment.NewLine);

        }
    }
}
