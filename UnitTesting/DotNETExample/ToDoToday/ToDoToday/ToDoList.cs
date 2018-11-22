using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoToday
{
    public class ToDoList:IToDoList
    {
        private IFileManager manager;
        public ToDoList(IFileManager manager)
        {
            this.manager = manager;
        }

        public string Content { get; set; }
        public List<ToDoItem> Items { get; set; }

        public List<ToDoItem> ReadList(string path)
        {
            List<ToDoItem> listItems = new List<ToDoItem>();
            string[] items = manager.ReadFile(path);
            foreach (string item in items)
            {
                string[] data = CSVToArray(item);
                if (data != null)
                {
                    listItems.Add(new ToDoItem(data));
                    Content += data;
                }
            }
            this.Items = listItems;
            return listItems;
        }

        public void KeepList(List<ToDoItem> items)
        {
            this.Items = items;
        }

        private string[] CSVToArray(string item)
        {
            string[] data = item.Split(';');
            if (data.Length == 5)
            {
                return data;
            }
            return null;
        }
    }
}
