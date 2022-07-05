using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    class SingletonVariables
    {
        public static IDataManager dataManager;
        public static IDataManager DataManager
        {
            get
            {
                dataManager = (DependencyInitializer.IntializeDependencies()).GetService(typeof(IDataManager)) as IDataManager;
                return dataManager;
            }
        }
    }
}
