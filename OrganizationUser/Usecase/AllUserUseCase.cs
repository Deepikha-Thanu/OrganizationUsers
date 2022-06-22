
using OrganizationUser.Manager;
using OrganizationUser.Model;
using OrganizationUser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Usecase
{
    class AllUserUseCase : UsecaseBase
    {
        public DataManager dataRequestObject;
        ICallBack callback;
        ICallBack usecaseCallback;
        //UsecaseCallback callback = new UsecaseCallback();
        public AllUserUseCase(ICallBack obj)
        {
            //ActionTodo = GetEmployeeOrgData;
            callback = obj;
            usecaseCallback=new UsecaseCallback(this);
            dataRequestObject = new DataManager();
            //UsecaseCallback(this);
        }
        public override void Action()
        {
            dataRequestObject.GetAllEmployeesData(usecaseCallback);
        }

        //public void ReturnEmployeesData(List<People> peoples)
        //{ 
        //    callback.OnSuccess(peoples);
        //}
        //public void ReturnError(string message)
        //{
        //    callback.OnError(message);
        //}
        private class UsecaseCallback : ICallBack
        {
            AllUserUseCase allUserUseCase;
            public UsecaseCallback(AllUserUseCase usecaseObj)
            {
                allUserUseCase = usecaseObj;
            }
            public void OnSuccess<T>(T response)
            {
                    allUserUseCase.callback.OnSuccess(response);
            }
            public void OnError<T>(T message)
            {
                allUserUseCase.callback.OnError(message);
            }
        }
    }
}
