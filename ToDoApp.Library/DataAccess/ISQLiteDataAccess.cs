﻿using System.Collections.Generic;

namespace ToDoApp.Library.DataAccess
{
    public interface ISQLiteDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName);
        void SaveData<T>(string sqlStatement, T parameters, string connectionStringName);
    }
}