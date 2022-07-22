using OrganizationUser.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    class ReportingToWithIdDataManager : IReportingToWithIdDataManager
    {
        IDataHandler DataHandlerInstance;
        public ReportingToWithIdDataManager()
        {
            DataHandlerInstance = DependencyInitializer.DependencyInitializerInstance.IntializeDependencies().GetService(typeof(IDataHandler)) as IDataHandler;
        }
        public void GetEmployeeWithId(RequestEmployeeChange request, IUsecaseCallback<ResponseEmployeeChange> callBack)
        {
            ResponseEmployeeChange response = new ResponseEmployeeChange();
            response.EmployeeFromId = DataHandlerInstance.GetReportingToEmployee(request.EmployeeId);
            if (response.EmployeeFromId == null)
            {
                callBack.OnFailure("Something went wrong!");
                return;
            }
            else
            {
                callBack.OnSuccess(response);
                return;
            }
        }
    }
}
