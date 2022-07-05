using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OrganizationUser.DataBase;
using OrganizationUser.Manager;

namespace OrganizationUser
{
    class DependencyInitializer
    {
        public static ServiceProvider IntializeDependencies()
        {
            ServiceCollection collections = new ServiceCollection();
            collections.AddScoped<IDataAdapter,DataAdapter>();
            collections.AddScoped<IDataHandler, DataHandler>();
            collections.AddScoped<IDataManager, DataManager>();
            ServiceProvider provider = collections.BuildServiceProvider();
            return provider;
        }
    }
}
