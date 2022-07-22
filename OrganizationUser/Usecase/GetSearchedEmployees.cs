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
        private IPresenterCallback<SearchResponse> PresenterCallback;
        private IUsecaseCallback<SearchResponse> CallBackOfUsecase;
        private SearchRequest RequestOfSearch;
        public GetSearchedEmployees(SearchRequest req,IPresenterCallback<SearchResponse> obj)
        {
            RequestOfSearch = req;
            PresenterCallback = obj;
            CallBackOfUsecase = new UsecaseCallback(this);
        }
        public override void Action()
        {
            (DependencyInitializer.DependencyInitializerInstance.IntializeDependencies().GetService(typeof(ISearchDataManager)) as ISearchDataManager).GetSearchedEmployees(RequestOfSearch, CallBackOfUsecase);
        }
        class UsecaseCallback : IUsecaseCallback<SearchResponse>
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

            public void OnSuccess(SearchResponse response)
            {
                
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
