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
            createPlusTab();
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
            var lastIndex = this.tabConrtol.TabCount - 1;
            WebBrowserTab newTab = new WebBrowserTab();
            TabPage newPage = new TabPage("New Tab");
            newTab.Dock = DockStyle.Fill;
            newPage.Controls.Add(newTab);
            this.tabConrtol.TabPages.Insert(lastIndex, newPage);
            this.tabConrtol.SelectedIndex = lastIndex;
            
        }

        private void createTab()
        {
            WebBrowserTab newTab = new WebBrowserTab();
            TabPage newPage = new TabPage("New Tab");
            newTab.Dock = DockStyle.Fill;
            newPage.Controls.Add(newTab);
            tabConrtol.TabPages.Add(newPage);
        }

        private void createPlusTab()
        {
            WebBrowserTab newTab = new WebBrowserTab();
            TabPage newPage = new TabPage("+");
            tabConrtol.TabPages.Add(newPage);
        }



        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.tabConrtol.SelectedTab == null)
            {
                Application.Exit();
            }
            else
            {
                tabConrtol.TabPages.Remove(this.tabConrtol.SelectedTab);
            }
            
        }

        private void manageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var history = new HistoryManagerForm();
            history.ShowDialog();
        }

        private void manageBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bookmarks = new BookmarkManagerForm();
            bookmarks.ShowDialog();
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var history = new HistoryManagerForm();
            history.Deletehistory();
        }

        // implemented half of the bonus with the + tab "button"
        private void tabConrtol_MouseClick(object sender, MouseEventArgs e)
        {
            var lastIndex = this.tabConrtol.TabCount - 1;
            if(tabConrtol.GetTabRect(lastIndex).Contains(e.Location))
            {
                WebBrowserTab newTab = new WebBrowserTab();
                TabPage newPage = new TabPage("New Tab");
                newTab.Dock = DockStyle.Fill;
                newPage.Controls.Add(newTab);
                this.tabConrtol.TabPages.Insert(lastIndex, newPage);
                this.tabConrtol.SelectedIndex = lastIndex;
            }
        }

        private void tabConrtol_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPageIndex == this.tabConrtol.TabCount -1)
            {
                e.Cancel = true;
            }
        }
    }
}
