using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.DataBase
{
    class DataAdapter : IDataAdapter
    {
        SqliteConnection connection;
        public SqliteConnection GetConnection()
        {
            string dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path , "EmployeeDatabase.db");
            connection = new SqliteConnection($"FileName={dbPath}");
            return connection;
        }
    }
}
