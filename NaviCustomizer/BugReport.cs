using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaviCustomizer
{
    public partial class BugReport : Form
    {
        List<string> bugMsgs;
        public BugReport(List<string> bugMsgs)
        {
            InitializeComponent();
            this.bugMsgs = bugMsgs;
        }

        private void BugReport_Load(object sender, EventArgs e)
        {
            Label l = new Label();
            l.Width = 300;
            foreach (string s in bugMsgs)
            {
                l.Text += s + "\n";
                l.Height += 25;
                Console.WriteLine(s);
            }
            bugPanel.Controls.Add(l);
        }
    }
}
