using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoToday
{
    public class FileManager:IFileManager
    {
        public string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public bool SaveFile(string toDoList, string path)
        {
            try
            {
                File.WriteAllText(path, toDoList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
