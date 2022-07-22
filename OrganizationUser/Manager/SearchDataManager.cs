using OrganizationUser.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    class SearchDataManager : ISearchDataManager
    {
        IDataHandler DataHandlerInstance;
        public SearchDataManager()
        {
            DataHandlerInstance = DependencyInitializer.DependencyInitializerInstance.IntializeDependencies().GetService(typeof(IDataHandler)) as IDataHandler;
        }
        public void GetSearchedEmployees(SearchRequest request, IUsecaseCallback<SearchResponse> usecaseCallback)
        {
            SearchResponse response = new SearchResponse();
            if (request.MyDepartmentId == 0)
            {
                response.BusinessEmployeesData = DataHandlerInstance.SearchEmployee(request.Start, request.Offset, request.SearchString);
                response.IsSearchResults = true;
                if (response.BusinessEmployeesData == null)
                {
                    usecaseCallback.OnFailure("Something went wrong!");
                    return;
                }
                else
                {
                    if (response.BusinessEmployeesData.Count == 0)
                    {
                        usecaseCallback.OnFailure("No Results Found");
                        return;
                    }
                    else
                    {
                        response.ReportingToPair = DataHandlerInstance.GetReportingToDetails(SearchAlgorithm.ListToStringConvertion(response.BusinessEmployeesData));
                        usecaseCallback.OnSuccess(response);
                        return;
                    }
                }
            }
            else
            {
                response.BusinessEmployeesData = DataHandlerInstance.SearchEmployeeForId(request.Start, request.Offset, request.SearchString, request.MyDepartmentId);
                response.IsSearchResults = true;
                if (response.BusinessEmployeesData == null)
                {
                    usecaseCallback.OnFailure("Something went wrong!");
                    return;
                }
                else
                {
                    if (response.BusinessEmployeesData.Count == 0)
                    {
                        usecaseCallback.OnFailure("No Results Found");
                        return;
                    }
                    else
                    {
                        response.ReportingToPair = DataHandlerInstance.GetReportingToDetails(SearchAlgorithm.ListToStringConvertion(response.BusinessEmployeesData));
                        usecaseCallback.OnSuccess(response);
                        return;
                    }
                }
            }
        }
    }
}
