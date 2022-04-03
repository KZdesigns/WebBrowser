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
            createTab();
        }

        private void exitBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a Web Browser application was developed using C#. Developer Credit: Kyle Zimmerman AU ID: kaz0010.");
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTab();
        }

        private void createTab()
        {
            WebBrowserTab newTab = new WebBrowserTab();
            TabPage newPage = new TabPage("New Tab");
            newTab.Dock = DockStyle.Fill;
            newPage.Controls.Add(newTab);
            tabControl.TabPages.Add(newPage);
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(this.tabControl.SelectedTab);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
