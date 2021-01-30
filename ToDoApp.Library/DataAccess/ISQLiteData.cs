using System.Collections.Generic;
using ToDoApp.Library.Models;

namespace ToDoApp.Library.DataAccess
{
    public interface ISQLiteData
    {
        List<ToDoItemModel> LoadAllItems();
    }
}