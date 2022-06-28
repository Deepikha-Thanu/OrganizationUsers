using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OrganizationUser.DataBase;

namespace OrganizationUser
{
    class DependencyInitializer
    {
        public static ServiceProvider IntializeDependencies()
        {
            ServiceCollection collections = new ServiceCollection();
            collections.AddSingleton<IDataAdapter,DataAdapter>();
            ServiceProvider provider = collections.BuildServiceProvider();
            return provider;
        }
    }
}
