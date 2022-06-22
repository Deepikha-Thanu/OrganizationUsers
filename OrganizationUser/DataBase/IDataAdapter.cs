using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.DataBase
{
    interface IDataAdapter
    {
        SqliteConnection GetConnection();
    }
}
