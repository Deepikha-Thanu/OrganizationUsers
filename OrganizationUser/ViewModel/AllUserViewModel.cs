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
    public class AllUserViewModel : ViewModelBase
    {
        //public ObservableCollection<People> Peoples { get; set; }
        public ObservableCollection<People> Peoples { get; set; }
        public AllUser view;
        public IPresenterCallBack presenterCallBack;
        public AllUserViewModel(AllUser obj)
        {
            presenterCallBack= new PresenterCallback(this);
            Peoples = new ObservableCollection<People>();
            view = obj;
        }
        private class PresenterCallback : IPresenterCallBack
        {
            AllUserViewModel allUserViewModel;

            public PresenterCallback(AllUserViewModel viewModelObj)
            {
                allUserViewModel = viewModelObj;
            }
            public void OnError(string message)
            {
                allUserViewModel.view.ShowErrorMessage(message);
            }
            public async void OnSuccess(List<People> EmployeesData)
            {
                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    for(int i=0;i<EmployeesData.Count;i++)
                    {
                        allUserViewModel.Peoples.Add(EmployeesData[i]);
                    }
                });
                allUserViewModel.searchObject = new SearchAlgo(allUserViewModel.Peoples.ToList<People>());
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
