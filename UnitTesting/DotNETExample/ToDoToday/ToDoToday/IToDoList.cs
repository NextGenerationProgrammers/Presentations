using System.Collections.Generic;

namespace ToDoToday
{
    public interface IToDoList
    {
        string Content { get; set; }
        List<ToDoItem> Items { get; set; }
        List<ToDoItem> ReadList(string path);
    }
}