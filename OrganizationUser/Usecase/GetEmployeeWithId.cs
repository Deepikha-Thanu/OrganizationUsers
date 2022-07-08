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
        ICallBack presentercallback;
        RequestEmployeeChange request;
        ICallBack usecaseCallBack;
        public GetEmployeeWithId(ICallBack obj,RequestEmployeeChange req)
        {
            presentercallback = obj;
            request = req;
            usecaseCallBack=new UsecaseCallback(this);
        }
        public override void Action()
        {
            (DependencyInitializer.dependencyInitializer.IntializeDependencies().GetService(typeof(IDataManager)) as IDataManager).GetEmployeeWithId(request,usecaseCallBack);
        }

        private class UsecaseCallback : ICallBack
        {
            GetEmployeeWithId usecase;
            public UsecaseCallback(GetEmployeeWithId obj)
            {
                usecase = obj;
            }
            public void OnError()
            {
                throw new NotImplementedException();
            }

            public void OnFailure(string message)
            {
                throw new NotImplementedException();
            }

            public void OnSuccess<T>(T response)
            {
                usecase.presentercallback.OnSuccess<T>(response);
            }
        }
    }
}
