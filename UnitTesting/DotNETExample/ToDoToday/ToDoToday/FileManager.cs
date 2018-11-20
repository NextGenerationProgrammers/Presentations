using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoToday
{
    class FileManager:IFileManager
    {
        public string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
