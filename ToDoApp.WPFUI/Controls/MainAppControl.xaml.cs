using System;
using System.Collections;
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
using ToDoApp.Library.DataAccess;
using ToDoApp.Library.Models;

namespace ToDoApp.WPFUI.Controls
{
    /// <summary>
    /// Interaction logic for MainAppControl.xaml
    /// </summary>
    public partial class MainAppControl : UserControl
    {
        ObservableCollection<ToDoItemModel> toDoItemList = new ObservableCollection<ToDoItemModel>();
        private readonly ISQLiteData _db;

        public MainAppControl(ISQLiteData db)
        {
            _db = db;
            InitializeComponent();
            PopulateItemList();
        }

        private void PopulateItemList()
        {
            List<ToDoItemModel> alltemList = _db.LoadAllItems();
            
            foreach (ToDoItemModel item in alltemList)
            {
                toDoItemList.Add(item);
            }
            //// Test data to load on application start - just simulating a load from database/file
            //for (int i = 1; i < 6; i++)
            //{
            //    ToDoItemModel listItem = new ToDoItemModel();
            //    listItem.DateAdded = DateTime.Now.ToString("dd-MM-yyyy");
            //    listItem.ToDoItem = $"Item {i} - Thing I need to do";

            //    toDoItemList.Add(listItem);
            //}
            toDoItemListGrid.ItemsSource = toDoItemList;

        }

        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddItemToList();
        }

        private void AddItemToList()
        {
            ToDoItemModel toDoItem = new ToDoItemModel();
            toDoItem.DateAdded = DateTime.Now.ToString("yyyy-MM-dd");
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
            hideCompletedItem();
        }

        public void hideCompletedItem()
        {

            try
            {
                var selectedItem = toDoItemListGrid.SelectedItem as ToDoItemModel;
                var row = toDoItemListGrid.ItemContainerGenerator.ContainerFromItem(toDoItemListGrid.SelectedItem) as DataGridRow;
                row.Background = Brushes.LightGreen;

                if (showCompletedItemsChk.IsChecked == false)
                {
                    row.Visibility = Visibility.Collapsed;

                }
                toDoItemListGrid.SelectedItem = null;
            }
            catch (NullReferenceException)
            {

                var itemsSource = toDoItemListGrid.ItemsSource as IEnumerable;
                if (itemsSource != null)
                {
                    foreach (ToDoItemModel item in itemsSource)
                    {
                        if (item.IsCompleted == true)
                        {
                            var checkedRow = toDoItemListGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                            if (checkedRow != null)
                            {
                                checkedRow.Background = Brushes.LightGreen;
                                checkedRow.Visibility = Visibility.Collapsed;
                            }

                            if (showCompletedItemsChk.IsChecked == true)
                            {
                                checkedRow.Visibility = Visibility.Collapsed;
                            }

                        }
                    }
                }
            }
        }


        public void OnUnChecked(object sender, RoutedEventArgs e)
        {
            var row = toDoItemListGrid.ItemContainerGenerator.ContainerFromItem(toDoItemListGrid.SelectedItem) as DataGridRow;
            row.Background = Brushes.White;
            row.Visibility = Visibility.Visible;
            toDoItemListGrid.SelectedItem = null;
        }

        private void showHideCompletedItems(object sender, RoutedEventArgs e)
        {
            var itemsSource = toDoItemListGrid.ItemsSource as ObservableCollection<ToDoItemModel>;

            if (showCompletedItemsChk.IsChecked == true)
            {
                showCompleted(itemsSource);
            }
            else
            {
                hideCompleted(itemsSource);
            }
        }

        private void showCompleted(ObservableCollection<ToDoItemModel> itemList)
        {
            foreach (ToDoItemModel item in itemList)
            {
                var row = toDoItemListGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;

                if (item.IsCompleted == true && row.Visibility == Visibility.Collapsed)
                {
                    ToggleToDoItemVisibility(true, row);
                }
            }
        }

        private void hideCompleted(ObservableCollection<ToDoItemModel> itemList)
        {
            var itemsSource = toDoItemListGrid.ItemsSource as ObservableCollection<ToDoItemModel>;

            foreach (ToDoItemModel item in itemsSource)
            {
                var row = toDoItemListGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;

                if (item.IsCompleted == true && row.Visibility == Visibility.Visible)
                {
                    ToggleToDoItemVisibility(false, row);
                }
            }
        }

        public void ToggleToDoItemVisibility(bool displayRow, DataGridRow row)
        {
            Visibility display = displayRow ? Visibility.Visible : Visibility.Collapsed;
            row.Visibility = display;
        }
    }
}
