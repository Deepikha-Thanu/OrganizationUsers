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
        public ICallBack presenterCallback;
        Request request;
        DataManager dataRequestObject;
        ICallBack usecaseCallback;
        public MyDepartmentUseCase(Request req,ICallBack obj)
        {
            request = req;
            presenterCallback = obj;
            //ActionTodo = GetDepartmentPeople;
            dataRequestObject = new DataManager();
            usecaseCallback = new UseCaseCallback(this);
        }
        public override void Action()
        {
            dataRequestObject.GetDepartmentEmployees(request, usecaseCallback);
        }
        private class UseCaseCallback : ICallBack
        {
            public MyDepartmentUseCase myDepartmentUseCase;
            public UseCaseCallback(MyDepartmentUseCase obj)
            {
                myDepartmentUseCase = obj;
            }
            public void OnSuccess<T>(T resp)
            {
                myDepartmentUseCase.presenterCallback.OnSuccess(resp);
            }
            public void OnError()
            {
                myDepartmentUseCase.presenterCallback.OnError();
            }
            public void OnFailure(string message)
            {
                myDepartmentUseCase.presenterCallback.OnFailure(message);
            }
        }
    }
}
