using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp.Library.Models;

namespace ToDoApp.WPFUI.Controls
{
    /// <summary>
    /// Interaction logic for MainAppControl.xaml
    /// </summary>
    public partial class MainAppControl : UserControl
    {
        public MainAppControl()
        {
            InitializeComponent();
        }

        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddItemToList();
        }

        private void AddItemToList()
        {
            ToDoItemModel toDoItem = new ToDoItemModel();
            toDoItem.DateAdded = DateTime.Now.ToString("dd-MM-yyyy");
            toDoItem.ToDoItem = toDoListItemText.Text;
            toDoItemListGrid.Items.Add(toDoItem);

            toDoListItemText.Clear();
        }

        private void deleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var itemindex = toDoItemListGrid.SelectedIndex;
            toDoItemListGrid.Items.RemoveAt(toDoItemListGrid.SelectedIndex);
        }
    }
}
