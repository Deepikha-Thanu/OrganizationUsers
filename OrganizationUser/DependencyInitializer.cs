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
        ServiceCollection Collections = new ServiceCollection();
        public static DependencyInitializer DependencyInitializerInstance = new DependencyInitializer();
        ServiceProvider provider;
        DependencyInitializer()
        {
            Collections.AddSingleton<IDataAdapter, DataAdapter>();
            Collections.AddSingleton<IDataHandler, DataHandler>();
            Collections.AddSingleton<IEmployeeDataManager, EmployeeDataManager>();
            Collections.AddSingleton<ISearchDataManager, SearchDataManager>();
            Collections.AddSingleton<IReportingToWithIdDataManager, ReportingToWithIdDataManager>();
            provider = Collections.BuildServiceProvider();
        }

        public ServiceProvider IntializeDependencies()
        {
            
            return provider;
        }
    }
}
