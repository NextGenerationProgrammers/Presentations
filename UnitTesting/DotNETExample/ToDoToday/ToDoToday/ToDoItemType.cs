using System;

namespace ToDoToday
{
    public class ToDoItemType
    {
        public bool COMMON;
        public bool YEAR;
        public bool MONTH;
        public bool WEEK;
        public bool DAY;
        private int number;

        public ToDoItemType(string type)
        {
            int _type;
            try 
            {
                _type = int.Parse(type);
                number = _type;
                switch (_type)
                {
                    case 0:
                        COMMON = true;
                        YEAR = false;
                        MONTH = false;
                        WEEK = false;
                        DAY = false;
                        break;
                    case 1:
                        COMMON = false;
                        YEAR = true;
                        MONTH = false;
                        WEEK = false;
                        DAY = false;
                        break;
                    case 2:
                        COMMON = false;
                        YEAR = false;
                        MONTH = true;
                        WEEK = false;
                        DAY = false;
                        break;
                    case 3:
                        COMMON = false;
                        YEAR = false;
                        MONTH = false;
                        WEEK = true;
                        DAY = false;
                        break;
                    case 4:
                        COMMON = false;
                        YEAR = false;
                        MONTH = false;
                        WEEK = false;
                        DAY = true;
                        break;
                    default:
                        COMMON = true;
                        YEAR = false;
                        MONTH = false;
                        WEEK = false;
                        DAY = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                COMMON = true;
                YEAR = false;
                MONTH = false;
                WEEK = false;
                DAY = false;
            }
        }

        public int getInt()
        {
            return number;
        }
    }
}