﻿using OrganizationUser.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Usecase
{
    class GetEmployees : UsecaseBase
    {
        public ICallBack presenterCallback;
        Request request;
        ICallBack usecaseCallback;
        public GetEmployees(Request req,ICallBack obj)
        {
            request = req;
            presenterCallback = obj;
            //ActionTodo = GetDepartmentPeople;
            //dataRequestObject = new DataManager();
            usecaseCallback = new UseCaseCallback(this);
        }
        public override void Action()
        {
            SingletonVariables.DataManager.GetEmployeesData(request, usecaseCallback);
        }
        private class UseCaseCallback : ICallBack
        {
            public GetEmployees myUseCase;
            public UseCaseCallback(GetEmployees obj)
            {
                myUseCase = obj;
            }
            public void OnSuccess<T>(T resp)
            {
                myUseCase.presenterCallback.OnSuccess(resp);
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
