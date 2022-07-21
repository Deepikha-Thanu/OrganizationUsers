using OrganizationUser.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Usecase
{
    class GetSearchedEmployees : UsecaseBase
    {
        private  ICallBack PresenterCallback;
        private ICallBack CallBackOfUsecase;
        private IDataManager dataManagerInstance;
        private Request RequestOfSearch;
        private IDataManager DataManagerInstance
        {
            get
            {
                dataManagerInstance = (DependencyInitializer.dependencyInitializer.IntializeDependencies()).GetService(typeof(IDataManager)) as IDataManager;
                return dataManagerInstance;
            }
        }
        public GetSearchedEmployees(Request req,ICallBack obj)
        {
            RequestOfSearch = req;
            PresenterCallback = obj;
            CallBackOfUsecase = new UsecaseCallback(this);
        }
        public override void Action()
        {
            DataManagerInstance.GetSearchedEmployees(RequestOfSearch, CallBackOfUsecase);
        }
        class UsecaseCallback : ICallBack
        {
            public GetSearchedEmployees Usecase;
            public UsecaseCallback(GetSearchedEmployees obj)
            {
                Usecase = obj;
            }
            public void OnError()
            {
                Usecase.PresenterCallback.OnError();
            }

            public void OnFailure(string message)
            {
                Usecase.PresenterCallback.OnFailure(message);
            }

            public void OnSuccess<T>(T resp)
            {
                Response response = resp as Response;
                for (int i = 0; i < response.BusinessEmployeesData.Count; i++)
                {
                    if (response.BusinessEmployeesData[i].ReportingToId != 0)
                    {
                        response.BusinessEmployeesData[i].ReportingToName = response.ReportingToPair[response.BusinessEmployeesData[i].ReportingToId];
                    }
                    else
                    {
                        response.BusinessEmployeesData[i].ReportingToName = "-";
                    }
                }
                Usecase.PresenterCallback.OnSuccess(response);
            }
        }
    }
}
