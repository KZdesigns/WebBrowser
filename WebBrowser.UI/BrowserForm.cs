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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a Web Browser application was developed using C#. Developer Credit: Kyle Zimmerman AU ID: kaz0010.");
        }

        private void exitBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addressTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchBtn_Click(sender, e);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(addressTextBox.Text);
        }
    }
}
