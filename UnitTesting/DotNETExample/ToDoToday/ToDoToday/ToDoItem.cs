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

        public ToDoItem()
        {
        }

        public ToDoItem(string[] data)
        {
            Id = Convert.ToInt32(data[0]);
            Name = data[1];
            Date = Convert.ToDateTime(data[2]);
            Type = new ToDoItemType(data[3]);
            if (data[4] == "1")
            {
                Done = true;
            }
            else
            {
                Done = false;
            }
        }

        public override string ToString()
        {
            string done = (Done == true ? "1" : "0");
            string date = Date.ToString("yyyy-MM-dd");
            return Convert.ToString(Id) + ";" + Name + ";" + date + ";" + Convert.ToString(Type.getInt()) + ";" + done;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public ToDoItemType Type { get => type; set => type = value; }
        public bool Done { get => done; set => done = value; }
    }
}