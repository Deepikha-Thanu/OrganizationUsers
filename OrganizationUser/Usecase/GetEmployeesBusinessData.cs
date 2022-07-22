using OrganizationUser.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Usecase
{
    class GetEmployeesBusinessData : UsecaseBase
    {
        public IPresenterCallback<EmployeeResponse> presenterCallback;
        EmployeeRequest request;
        IUsecaseCallback<EmployeeResponse> usecaseCallback;
        public GetEmployeesBusinessData(EmployeeRequest req,IPresenterCallback<EmployeeResponse> obj)
        {
            request = req;
            presenterCallback = obj;
            //ActionTodo = GetDepartmentPeople;
            //dataRequestObject = new DataManager();
            usecaseCallback = new UseCaseCallback(this);
        }
        public override void Action()
        {
            (DependencyInitializer.DependencyInitializerInstance.IntializeDependencies().GetService(typeof(IEmployeeDataManager)) as IEmployeeDataManager).GetBusinessData(request, usecaseCallback);
        }
        private class UseCaseCallback : IUsecaseCallback<EmployeeResponse>
        {
            public GetEmployeesBusinessData myUseCase;
            public UseCaseCallback(GetEmployeesBusinessData obj)
            {
                myUseCase = obj;
            }
            public void OnSuccess(EmployeeResponse resp)
            {
                EmployeeResponse response = resp as EmployeeResponse;
                for(int i=0;i<response.BusinessEmployeesData.Count;i++)
                {
                    if(response.BusinessEmployeesData[i].ReportingToId!=0)
                    {
                        response.BusinessEmployeesData[i].ReportingToName = response.ReportingToPair[response.BusinessEmployeesData[i].ReportingToId];
                    }
                    else
                    {
                        response.BusinessEmployeesData[i].ReportingToName = "-";
                    }
                }
                myUseCase.presenterCallback.OnSuccess(response);
            }
            public void OnError()
            {
                myUseCase.presenterCallback.OnError();
            }
            public void OnFailure(string message)
            {
                myUseCase.presenterCallback.OnFailure(message);
            }
        }
    }
}
