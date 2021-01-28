using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<ToDoItemModel> toDoItemList = new ObservableCollection<ToDoItemModel>();
        
        public MainAppControl()
        {
            InitializeComponent();
            PopulateItemList();
        }

        private void PopulateItemList()
        {
           
            // Test data to load on application start - just simulating a load from database/file
            for (int i = 1; i < 6; i++)
            {
                ToDoItemModel listItem = new ToDoItemModel();
                listItem.DateAdded = DateTime.Now.ToString("dd-MM-yyyy");
                listItem.ToDoItem = $"Item {i} - Thing I need to do";

                toDoItemList.Add(listItem);
            }

            toDoItemListGrid.ItemsSource = toDoItemList;
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
            toDoItemList.Add(toDoItem);

            toDoListItemText.Clear();
        }

        private void deleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = toDoItemListGrid.SelectedItem as ToDoItemModel;
            toDoItemList.Remove(selectedItem);
        }

        public void OnChecked(object sender, RoutedEventArgs e)
        {
                        
            var row = toDoItemListGrid.ItemContainerGenerator.ContainerFromItem(toDoItemListGrid.SelectedItem) as DataGridRow;
            row.Background = Brushes.LightGreen;
            toDoItemListGrid.SelectedItem = null;
                
        }

        public void OnUnChecked(object sender, RoutedEventArgs e)
        {
            var row = toDoItemListGrid.ItemContainerGenerator.ContainerFromItem(toDoItemListGrid.SelectedItem) as DataGridRow;
            row.Background = Brushes.White;
            toDoItemListGrid.SelectedItem = null;
        }

    }
}
