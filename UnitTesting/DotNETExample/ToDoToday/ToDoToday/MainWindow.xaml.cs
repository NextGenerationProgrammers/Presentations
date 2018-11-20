using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoToday
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ToDoItem> todoItems;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ReadList()
        {
            ToDoList list = new ToDoList(new FileManager());
            list.ReadList("C:\\tmp\\test.txt");
        }
    }
}
