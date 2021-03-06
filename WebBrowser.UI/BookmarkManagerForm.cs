using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class BookmarkManagerForm : Form
    {
        public BookmarkManagerForm()
        {
            InitializeComponent();
        }

        private void BookmarkManagerForm_Load(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();
            listBoxBookmark.Items.Clear();

            foreach(var item in items)
            {
                listBoxBookmark.Items.Add(string.Format("{0} ({1})", item.Title, item.URL));
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();

            string searchTerm = textBoxSearch.Text;

            listBoxBookmark.Items.Clear();

            foreach(var item in items)
            {
                if(item.Title.Contains(searchTerm) || item.URL.Contains(searchTerm))
                {
                    listBoxBookmark.Items.Add(string.Format("{0} ({1})", item.Title, item.URL));
                }
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();
            BookmarkManager.Remove(items[listBoxBookmark.SelectedIndex]);
            BookmarkManagerForm_Load(sender, e);
        }
    }
}
