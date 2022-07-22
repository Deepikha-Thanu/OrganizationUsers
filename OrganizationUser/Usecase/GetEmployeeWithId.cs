using OrganizationUser.Manager;
using OrganizationUser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Usecase
{
    class GetEmployeeWithId : UsecaseBase
    {
        IPresenterCallback<ResponseEmployeeChange> presentercallback;
        RequestEmployeeChange request;
        IUsecaseCallback<ResponseEmployeeChange> usecaseCallBack;
        public GetEmployeeWithId(IPresenterCallback<ResponseEmployeeChange> obj,RequestEmployeeChange req)
        {
            presentercallback = obj;
            request = req;
            usecaseCallBack=new UsecaseCallback(this);
        }
        public override void Action()
        {
            (DependencyInitializer.DependencyInitializerInstance.IntializeDependencies().GetService(typeof(IReportingToWithIdDataManager)) as IReportingToWithIdDataManager).GetEmployeeWithId(request,usecaseCallBack);
        }

        private class UsecaseCallback : IUsecaseCallback<ResponseEmployeeChange>
        {
            GetEmployeeWithId usecase;
            public UsecaseCallback(GetEmployeeWithId obj)
            {
                usecase = obj;
            }
            public void OnError()
            {
                usecase.presentercallback.OnError();
            }

            public void OnFailure(string message)
            {
                usecase.presentercallback.OnFailure(message);
            }

            public void OnSuccess(ResponseEmployeeChange response)
            {
                if(response.EmployeeFromId.ReportingToId==0)
                {
                    response.EmployeeFromId.ReportingToName = "-";
                }
                usecase.presentercallback.OnSuccess(response);
            }
        }
    }
}
