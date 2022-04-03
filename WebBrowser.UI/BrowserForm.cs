using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI
{
    public partial class BrowserForm : Form
    {
        public BrowserForm()
        {
            InitializeComponent();
        }

        private void tabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && (e.KeyCode == Keys.T))
            {
                TabPage tab = new TabPage();
                tab.Controls.Add(new WebBrowserTab());
                tab.Text = "New Tab";
                this.tabControl.TabPages.Add(tab);
            }
        }
    }
}
