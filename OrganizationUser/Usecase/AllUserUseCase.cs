
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
        IPresenterCallBack callback;
        UsecaseCallback usecaseCallback;
        //UsecaseCallback callback = new UsecaseCallback();
        public AllUserUseCase(IPresenterCallBack obj)
        {
            ActionTodo = GetEmployeeOrgData;
            callback = obj;
            usecaseCallback=new UsecaseCallback(this);
            dataRequestObject = new DataManager();
            //UsecaseCallback(this);
        }
        public void GetEmployeeOrgData()
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
        private class UsecaseCallback : IUsecaseCallBack
        {
            AllUserUseCase allUserUseCase;
            public UsecaseCallback(AllUserUseCase usecaseObj)
            {
                allUserUseCase = usecaseObj;
            }
            public void OnSuccess(Response response)
            {
                    allUserUseCase.callback.OnSuccess(response.EmployeesFromDB);
            }
            public void OnError(string message)
            {
                allUserUseCase.callback.OnError(message);
            }
        }
    }
}
