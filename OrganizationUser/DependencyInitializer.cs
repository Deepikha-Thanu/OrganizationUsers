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
        ServiceCollection collections = new ServiceCollection();
        public static DependencyInitializer dependencyInitializer = new DependencyInitializer();
        ServiceProvider provider;
        DependencyInitializer()
        {
            collections.AddSingleton<IDataAdapter, DataAdapter>();
            collections.AddSingleton<IDataHandler, DataHandler>();
            collections.AddSingleton<IDataManager, DataManager>();
            provider = collections.BuildServiceProvider();
        }

        public ServiceProvider IntializeDependencies()
        {
            
            return provider;
        }
    }
}
