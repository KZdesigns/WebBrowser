using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.BookmarksDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class BookmarkManager
    {
        public static void AddItem(BookmarkItem item)
        {
            var adapter = new BookmarksTableAdapter();
            var items = adapter.GetData();
            int count = 0;

            foreach(var bookmark in items)
            {
                if(bookmark.URL != item.URL)
                {
                    count++;   
                }
            }

            if(count == items.Count)
            {
                adapter.Insert(item.URL, item.Title);
            } 
        }

        public static List<BookmarkItem> GetItems()
        {
            var adapter = new BookmarksTableAdapter();
            var results = new List<BookmarkItem>();
            var rows = adapter.GetData();

            foreach(var row in rows)
            {
                var item = new BookmarkItem();
                item.Title = row.Title;
                item.URL = row.URL;
                item.Id = row.Id;

                results.Add(item);
            }

            return results;
        }

        public static void Remove(BookmarkItem item)
        {
            var adapter = new BookmarksTableAdapter();
            adapter.DeleteQuery(item.Id);
        }

    }
}
