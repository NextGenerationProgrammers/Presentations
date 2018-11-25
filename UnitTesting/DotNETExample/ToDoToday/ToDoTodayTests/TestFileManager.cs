using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoToday;

namespace ToDoTodayTests
{
    class TestFileManager : IFileManager
    {
        public string[] Content;
        public string[] ReadFile(string path)
        {
            return Content;
        }

        public bool SaveFile(string content, string path)
        {
            return true;
        }
    }
}
