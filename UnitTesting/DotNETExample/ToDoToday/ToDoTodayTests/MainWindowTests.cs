using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoToday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ToDoToday.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void GetListTest()
        {
            var mock = new Mock<IFileManager>();
            ToDoList list = new ToDoList(mock.Object);

            mock.Setup(x => x.ReadFile("test")).Returns(new string[] { "1;TestToDo1;2018-11-03;0;1" });
            
            var items = list.ReadList("test");
            ToDoItem item = new ToDoItem();
            item.Id = 1;
            item.Name = "TestToDo1";
            item.Date = DateTime.Parse("2018-11-03");
            item.Done = true;
            item.Type = new ToDoItemType("0");
            Assert.AreEqual(item.Id, items[0].Id); 
            Assert.AreEqual(item.Name, items[0].Name); 
            Assert.AreEqual(item.Date, items[0].Date); 
            Assert.AreEqual(item.Done, items[0].Done); 
            Assert.AreEqual(item.Type.getInt(), items[0].Type.getInt());

        }

        [TestMethod()]
        public void SetToDoItemTypeTest()
        {
            ToDoItemType type = new ToDoItemType("0");
            Assert.IsTrue(type.COMMON);
            type = new ToDoItemType("1");
            Assert.IsTrue(type.YEAR);
            type = new ToDoItemType("2");
            Assert.IsTrue(type.MONTH);
            type = new ToDoItemType("3");
            Assert.IsTrue(type.WEEK);
            type = new ToDoItemType("4");
            Assert.IsTrue(type.DAY);
            type = new ToDoItemType("5");
            Assert.IsTrue(type.COMMON);
            type = new ToDoItemType("a");
            Assert.IsTrue(type.COMMON);
        }

        [TestMethod()]
        public void ConvertToToDoItemNumberTest()
        {
            ToDoItemType type = new ToDoItemType("0");
            Assert.AreEqual(0, type.getInt());
            type = new ToDoItemType("1");
            Assert.AreEqual(1, type.getInt());
            type = new ToDoItemType("a");
            Assert.AreEqual(0, type.getInt());
            type = new ToDoItemType("12938475092384750");
            Assert.AreEqual(0, type.getInt());
        }
    }
}