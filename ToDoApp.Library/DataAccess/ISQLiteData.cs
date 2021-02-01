using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoApp.Library.Models;

namespace ToDoApp.Library.DataAccess
{
    public interface ISQLiteData
    {
        List<ToDoItemModel> LoadAllItems();
        public void UpdateItemInDatabase(ToDoItemModel listItem);
        public void SaveItemToDatabase(ToDoItemModel listItem);

    }
}