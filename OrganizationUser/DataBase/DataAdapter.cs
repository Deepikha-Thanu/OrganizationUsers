using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace OrganizationUser.DataBase
{
    class DataAdapter : IDataAdapter
    {
        SqliteConnection connection;
        public SqliteConnection GetConnection()
        {
            //await ApplicationData.Current.LocalFolder.CreateFileAsync("EmployeeDatabase.db", CreationCollisionOption.OpenIfExists);
            string dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path , "EmployeeDatabase.db");
            if(File.Exists(dbPath))
            {
                connection = new SqliteConnection($"FileName={dbPath}");
                return connection;
            }
            else
            {
                CreateFile();
                connection = new SqliteConnection($"FileName={dbPath}");
                return connection;
            }
        }
        public async void CreateFile()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("EmployeeDatabase.db", CreationCollisionOption.OpenIfExists);
        }
    }
}
