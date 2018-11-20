using System;

namespace ToDoToday
{
    public class ToDoItem
    {
        int id;
        string name;
        DateTime date;
        ToDoItemType type;
        bool done;

        public ToDoItem(string[] data)
        {
            Id = Convert.ToInt32(data[0]);
            Name = data[1];
            Date = Convert.ToDateTime(data[2]);
            Type = new ToDoItemType(data[3]);
            Done = Convert.ToBoolean(data[4]);
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public ToDoItemType Type { get => type; set => type = value; }
        public bool Done { get => done; set => done = value; }
    }
}