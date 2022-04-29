using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class WebBrowserTab : UserControl
    {
        TabPage page;

        public WebBrowserTab()
        {
            InitializeComponent();
        }

        public WebBrowserTab(TabPage pageIn)
        {
            InitializeComponent();
            page = pageIn;
        }

        public static object WebBrowser { get; internal set; }

        private void addressTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchBtn_Click(sender, e);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(addressTextBox.Text);
            toolStripProgressBar.Value = 0;
            toolStripStatusLabel1.Visible = true;
            toolStripProgressBar.Visible = true;
            toolStripStatusLabel1.Text = "Loading...";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            addressTextBox.Text = webBrowser.Url.ToString();
            var item = new HistoryItem();
            item.Title = webBrowser.DocumentTitle.ToString();
            item.Date = DateTime.Now;
            item.URL = webBrowser.Url.ToString();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void bookmarkBtn_Click(object sender, EventArgs e)
        {
            var item = new BookmarkItem();
            item.Title = webBrowser.DocumentTitle.ToString();
            item.URL = webBrowser.Url.ToString();
            BookmarkManager.AddItem(item);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            addressTextBox.Text = webBrowser.Url.ToString();
            var item = new HistoryItem();
            item.Title = webBrowser.DocumentTitle.ToString();
            item.Date = DateTime.Now;
            item.URL = webBrowser.Url.ToString();
            page.Text = item.Title;
            HistoryManager.AddItem(item);
        }

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if(toolStripProgressBar.Value < 100)
            {
                toolStripProgressBar.Value = (int)((e.CurrentProgress / e.MaximumProgress) * 100);
            }
            else
            {
                toolStripStatusLabel1.Text = "Done";
            }
        }

        // Bonus Print 
        public void PrintHtml()
        {
            webBrowser.ShowPrintPreviewDialog();
        }

        // Bonus Save HTML
        public void SaveHtml()
        {
            webBrowser.ShowSaveAsDialog();
        }

        // Bonus added for mouse hover
        private void hoverLabel_MouseLeave(object sender, EventArgs e)
        {
            hoverLabel.Text = "";
        }

        private void hoverLabel_MouseHover(object sender, EventArgs e)
        {
            hoverLabel.Text = addressTextBox.Text;
        }

        private void hoverLabel_MouseEnter(object sender, EventArgs e)
        {
            hoverLabel.Text = addressTextBox.Text;
        }
    }
}
