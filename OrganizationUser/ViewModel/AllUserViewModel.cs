using OrganizationUser.Manager;
using OrganizationUser.Model;
using OrganizationUser.Usecase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace OrganizationUser.ViewModel
{
    public class AllUserViewModel : ViewModelBase
    {
        //public ObservableCollection<People> Peoples { get; set; }
        public ObservableCollection<BusinessPeopleModel> Employees { get; set; }
        IView view;
        IPresenterCallback<EmployeeResponse> DataPresenterCallback;
        IPresenterCallback<SearchResponse> SearchPresenterCallbackInstance;
        public bool IsDataAvailable = true;
        public bool IsSearchResults = false;
        //GetEmployees Usecase { get; set; }
        //Sample data
        public AllUserViewModel(AllUser obj)
        {
            DataPresenterCallback= new EmployeePresenterCallback(this);
            SearchPresenterCallbackInstance = new SearchPresenterCallback(this);
            Employees = new ObservableCollection<BusinessPeopleModel>();
            //ReportingToPeople = new ObservableCollection<People>();
            view = obj;
            //Usecase.Execute();
        }
        public void GetDataForOffset(double start,double offset)
        {
            EmployeeRequest req = new EmployeeRequest();
            req.Offset = offset;
            req.Start = start;
            new GetEmployeesBusinessData(req, DataPresenterCallback).Execute();
        }
        public void SearchEmployees(double start,double offset,string searchString)
        {
            SearchRequest req = new SearchRequest { SearchString = searchString,Start=start,Offset=offset };
            new GetSearchedEmployees(req, SearchPresenterCallbackInstance).Execute();
        }
        //public void InitializeReportingTo()
        //{
        //    var ReportingToGroup = from employee in Peoples
        //                           group employee by employee.ReportingToId into ReportsGroup
        //                           select ReportsGroup;
        //    int i = 0;
        //    foreach(var empGroup in ReportingToGroup)
        //    {
        //        foreach(var employee in empGroup)
        //        {
        //            if(employee.Id==Peoples[i].Id)
        //            {
        //               foreach(var people in Peoples)
        //                {
        //                    if(empGroup.Key==people.Id)
        //                    {
        //                        ReportingTo.Add(people);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //}
        private class EmployeePresenterCallback : IPresenterCallback<EmployeeResponse>
        {
            AllUserViewModel allUserViewModel;
            public EmployeePresenterCallback(AllUserViewModel viewModelObj)
            {
                allUserViewModel = viewModelObj;
            }
            public void OnError()
            {
                allUserViewModel.view.ShowError();
            }
            public async void OnSuccess(EmployeeResponse response)
            {
                allUserViewModel.IsDataAvailable = response.IsDataAvailable;
                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    for(int i=0;i<response.BusinessEmployeesData.Count;i++)
                    { 
                        allUserViewModel.Employees.Add(response.BusinessEmployeesData[i]);
                    }
                });
                //allUserViewModel.searchObject = new SearchAlgorithm(allUserViewModel.Employees.ToList<BusinessPeopleModel>())
            }
            public void OnFailure(string message)
            {
                allUserViewModel.view.ShowErrorMessage(message);
            }
        }
        private class SearchPresenterCallback : IPresenterCallback<SearchResponse>
        {
            AllUserViewModel ViewModel;
            public SearchPresenterCallback(AllUserViewModel obj)
            {
                ViewModel = obj;
            }

            public void OnError()
            {
                ViewModel.view.ShowError();
            }

            public void OnFailure(string message)
            {
                ViewModel.view.ShowErrorMessage(message);
            }

            public async void OnSuccess(SearchResponse response)
            {
                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    ViewModel.Employees.Clear();
                    for(int i=0;i<response.BusinessEmployeesData.Count;i++)
                    {
                        ViewModel.Employees.Add(response.BusinessEmployeesData[i]);
                    }
                });
            }
        }
        //public Task PauseNavigation(string contentToChange)
        //{
        //    Task t = new Task(async () =>
        //    {
        //        bool isTimeExceeded = false;
        //        for (int i = 0; Peoples.Count == 0; i++)
        //        {
        //            await Task.Delay(1000);
        //            if (i == 10)
        //            {
        //                isTimeExceeded = true;
        //                break;
        //            }
        //        }
        //        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
        //            if (!isTimeExceeded && contentToChange == "MyDepartment")
        //            {
        //                PeopleFrame.Navigate(typeof(MyDepartment), this, new SuppressNavigationTransitionInfo());
        //                MyDepartment departmentPage = PeopleFrame.Content as MyDepartment;
        //                if (departmentPage != null)
        //                {
        //                    departmentPage.EmployeeClicked += OnEmployeeClicked;
        //                }
        //            }

        //            else if (!isTimeExceeded && contentToChange == "AllUser")
        //            {
        //                PeopleFrame.Navigate(typeof(AllUser), this, new SuppressNavigationTransitionInfo());
        //                AllUser allUserPage = PeopleFrame.Content as AllUser;
        //                if (allUserPage != null)
        //                {
        //                    allUserPage.EmployeeClicked += OnEmployeeClicked;
        //                }
        //            }
        //            else if (!isTimeExceeded && contentToChange == "MyDirectReport")
        //            {
        //                PeopleFrame.Navigate(typeof(MyDirectReports), this, new SuppressNavigationTransitionInfo());
        //            }
        //            else
        //            {
        //                NavigationStatus.Text = "Not Able to access data for the moment";
        //            }
        //        });
        //    });

        //    return t;
        //}
    }
}
