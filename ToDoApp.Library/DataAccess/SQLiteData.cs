using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Library.Models;

namespace ToDoApp.Library.DataAccess
{
    public class SQLiteData : ISQLiteData
    {
        private readonly ISQLiteDataAccess _db;
        private const string connectionStringName = "DbConnection";

        public SQLiteData(ISQLiteDataAccess db)
        {
            _db = db;
        }


        // Data Access Methods

        public List<ToDoItemModel> LoadAllItems()
        {
            string sql = @"select Id, DateAdded, ToDoItem, IsCompleted from ToDoItemsList";

            return _db.LoadData<ToDoItemModel, dynamic>(sql, new { }, connectionStringName);
        }


    }
}
