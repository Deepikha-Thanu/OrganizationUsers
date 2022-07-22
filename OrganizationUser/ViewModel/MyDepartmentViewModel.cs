using OrganizationUser.Manager;
using OrganizationUser.Model;
using OrganizationUser.Usecase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace OrganizationUser.ViewModel
{
    public class MyDepartmentViewModel : ViewModelBase
    {
        public ObservableCollection<BusinessPeopleModel> DepartmentPeoples;
        IView view;
        public const int DepartmentId = 15;
        public List<People> ReportingTo;
        public bool IsDataAvailable = true;
        public bool IsSearchResults = false;
        IPresenterCallback<EmployeeResponse> DataPresenterCallback;
        IPresenterCallback<SearchResponse> SearchPresenterCallbackInstance;
        public MyDepartmentViewModel(MyDepartment obj)
        {
            DepartmentPeoples = new ObservableCollection<BusinessPeopleModel>();
            DataPresenterCallback= new EmployeePresenterCallback(this);
            SearchPresenterCallbackInstance = new SearchPresenterCallback(this);
            view = obj;
        }
        public void SearchEmployees(double start, double offset, string searchString)
        {
            SearchRequest req = new SearchRequest { SearchString = searchString, Start = start, Offset = offset,MyDepartmentId=DepartmentId };
            new GetSearchedEmployees(req, SearchPresenterCallbackInstance).Execute();
        }
        public void GetDataForOffset(double start,double offset)
        {
            EmployeeRequest request = new EmployeeRequest() { MyDepartmentId = DepartmentId, Start=start,Offset=offset};
            new GetEmployeesBusinessData(request, DataPresenterCallback).Execute();
        }
        private class EmployeePresenterCallback : IPresenterCallback<EmployeeResponse>
        {
            MyDepartmentViewModel myDepartmentViewModel;
            public EmployeePresenterCallback(MyDepartmentViewModel obj)
            {
                myDepartmentViewModel = obj;
            }
            public async void OnSuccess(EmployeeResponse response)
            {
                myDepartmentViewModel.IsDataAvailable = response.IsDataAvailable;
                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    for (int i = 0; i < response.BusinessEmployeesData.Count; i++)
                    {
                        myDepartmentViewModel.DepartmentPeoples.Add(response.BusinessEmployeesData[i]);
                    }
                });
               // myDepartmentViewModel.searchObject=new SearchAlgorithm(myDepartmentViewModel.DepartmentPeoples.ToList<BusinessPeopleModel>());
            }
            public void OnError()
            {
                myDepartmentViewModel.view.ShowError();
            }
            public void OnFailure(string message)
            {
                myDepartmentViewModel.view.ShowErrorMessage(message);
            }
        }
        private class SearchPresenterCallback : IPresenterCallback<SearchResponse>
        {
            MyDepartmentViewModel myDepartmentViewModel;
            public SearchPresenterCallback(MyDepartmentViewModel obj)
            {
                myDepartmentViewModel = obj;
            }
            public async void OnSuccess(SearchResponse response)
            {
                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    myDepartmentViewModel.DepartmentPeoples.Clear();
                    for (int i = 0; i < response.BusinessEmployeesData.Count; i++)
                    {
                        myDepartmentViewModel.DepartmentPeoples.Add(response.BusinessEmployeesData[i]);
                    }
                });
                // myDepartmentViewModel.searchObject=new SearchAlgorithm(myDepartmentViewModel.DepartmentPeoples.ToList<BusinessPeopleModel>());
            }
            public void OnError()
            {
                myDepartmentViewModel.view.ShowError();
            }
            public void OnFailure(string message)
            {
                myDepartmentViewModel.view.ShowErrorMessage(message);
            }
        }
    }
}
