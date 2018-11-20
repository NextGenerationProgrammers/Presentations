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
            var item = new List<ToDoItem>();
            item[0].Id = 1;
            item[0].Name = "TestToDo1";
            item[0].Date = DateTime.Parse("2018-11-03");
            item[0].Done = true;
            item[0].Type = new ToDoItemType("1");
            Assert.AreEqual(item, items[0]);

        }

        [TestMethod()]
        public void WriteFile()
        {
            Assert.Fail();
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