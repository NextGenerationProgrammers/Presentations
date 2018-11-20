using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoToday
{
    public interface IFileManager
    {
        string[] ReadFile(string path);
    }
}
