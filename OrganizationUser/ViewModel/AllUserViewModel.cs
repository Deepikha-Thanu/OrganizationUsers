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
        //public ObservableCollection<BusinessPeopleModel> ReportingToPeople { get; set; }
       
        IView view;
        ICallBack presenterCallBack;
        //GetEmployees Usecase { get; set; }
        //Sample data
        public AllUserViewModel(AllUser obj)
        {
            presenterCallBack= new PresenterCallback(this);
            Employees = new ObservableCollection<BusinessPeopleModel>();
            //ReportingToPeople = new ObservableCollection<People>();
            view = obj;
            Request req = new Request();
            new GetEmployeesBusinessData(req,presenterCallBack).Execute();
            //Usecase.Execute();
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
        private class PresenterCallback : ICallBack
        {
            AllUserViewModel allUserViewModel;
            //just for github comment
            public PresenterCallback(AllUserViewModel viewModelObj)
            {
                allUserViewModel = viewModelObj;
            }
            public void OnError()
            {
                allUserViewModel.view.ShowError();
            }
            public async void OnSuccess<T>(T response)
            {
                Response resp = response as Response;
                List<long> ReportingToId = new List<long>();
                //foreach (var people in resp.EmployeesFromDB)
                //{
                //    if (people.ReportingTo != null && !ReportingToId.Contains(people.ReportingTo.Id))
                //    {
                //        ReportingToId.Add(people.ReportingTo.Id);
                //    }
                //    else
                //    {
                //        ReportingToId.Add(0);
                //    }
                //}

                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    for(int i=0;i<resp.BusinessEmployeesData.Count;i++)
                    {
                        //if(resp.EmployeesFromDB[i].ReportingTo==null)
                        //{
                        //    resp.EmployeesFromDB[i].ReportingTo = new People();
                        //    resp.EmployeesFromDB[i].ReportingTo.Name = "-";
                        //}
                        allUserViewModel.Employees.Add(resp.BusinessEmployeesData[i]);
                    }

                    //var ListOfReporting = allUserViewModel.Employees.Where(x => ReportingToId.Contains(x.Id));
                    //foreach(var emp in ListOfReporting)
                    //{
                    //    allUserViewModel.ReportingToPeople.Add(emp);
                    //}
                    //allUserViewModel.InitializeReportingTo();
                    //for (int i = 0; i < resp.ReportingToPair.Count; i++)
                    //{
                    //allUserViewModel.ReportingTo=resp.ReportingToPair;
                    //}
                });
                allUserViewModel.searchObject = new SearchAlgorithm(allUserViewModel.Employees.ToList<BusinessPeopleModel>());
            }
            public void OnFailure(string message)
            {
                allUserViewModel.view.ShowErrorMessage(message);
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
