using OrganizationUser.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Usecase
{
    class MyDepartmentUseCase : UsecaseBase
    {
        public IPresenterCallBack presenterCallback;
        Request request;
        DataManager dataRequestObject;
        IUsecaseCallBack usecaseCallback;
        public MyDepartmentUseCase(Request req,IPresenterCallBack obj)
        {
            request = req;
            presenterCallback = obj;
            ActionTodo = GetDepartmentPeople;
            dataRequestObject = new DataManager();
            usecaseCallback = new UseCaseCallback(this);
        }
        public void GetDepartmentPeople()
        {
            dataRequestObject.GetDepartmentEmployees(request, usecaseCallback);
        }
        private class UseCaseCallback : IUsecaseCallBack
        {
            public MyDepartmentUseCase myDepartmentUseCase;
            public UseCaseCallback(MyDepartmentUseCase obj)
            {
                myDepartmentUseCase = obj;
            }
            public void OnSuccess(Response resp)
            {
                myDepartmentUseCase.presenterCallback.OnSuccess(resp.EmployeesFromDB);
            }
            public void OnError(string message)
            {
                myDepartmentUseCase.presenterCallback.OnError(message);
            }
        }
    }
}
