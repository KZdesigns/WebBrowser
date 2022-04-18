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
    public partial class HistoryManagerForm : Form
    {
        public HistoryManagerForm()
        {
            InitializeComponent();
        }

        private void HistoryManagerForm_Load(object sender, EventArgs e)
        {
            var items = HistoryManager.GetItems();
            listBoxHistory.Items.Clear();

            foreach(var item in items)
            {
                listBoxHistory.Items.Add(string.Format("[{0}] {1} ({2})", item.Date, item.Title, item.URL));
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var items = HistoryManager.GetItems();

            string searchTerm = textBoxSearch.Text;

            listBoxHistory.Items.Clear();

            foreach(var item in items)
            {
                if(item.Title.Contains(searchTerm) || item.URL.Contains(searchTerm) || item.Date.ToString().Contains(searchTerm))
                {
                    listBoxHistory.Items.Add(string.Format("[{0}] {1} ({2})", item.Date, item.Title, item.URL));
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Deletehistory();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var items = HistoryManager.GetItems();
            HistoryManager.Remove(items[listBoxHistory.SelectedIndex]);
            HistoryManagerForm_Load(sender, e);
        }

        public void Deletehistory()
        {
            var items = HistoryManager.GetItems();

            foreach (var item in items)
            {
                HistoryManager.Remove(item);
            }

            listBoxHistory.Items.Clear();
        }
    }
}
