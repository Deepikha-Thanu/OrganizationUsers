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
        public ICallBack presenterCallback;
        Request request;
        ICallBack usecaseCallback;
        IDataManager dataManagerInstance;
        public IDataManager DataManagerInstance
        {
            get
            {
                dataManagerInstance = (DependencyInitializer.IntializeDependencies()).GetService(typeof(IDataManager)) as IDataManager;
                return dataManagerInstance;
            }
        }
        public GetEmployeesBusinessData(Request req,ICallBack obj)
        {
            request = req;
            presenterCallback = obj;
            //ActionTodo = GetDepartmentPeople;
            //dataRequestObject = new DataManager();
            usecaseCallback = new UseCaseCallback(this);
        }
        public override void Action()
        {
            DataManagerInstance.GetBusinessData(request, usecaseCallback);
        }
        private class UseCaseCallback : ICallBack
        {
            public GetEmployeesBusinessData myUseCase;
            public UseCaseCallback(GetEmployeesBusinessData obj)
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
