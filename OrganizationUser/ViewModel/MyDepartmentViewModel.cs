using OrganizationUser.Manager;
using OrganizationUser.Model;
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
        public ObservableCollection<People> DepartmentPeoples;
        public MyDepartment view;
//        public  People me=new People();
        
        public IPresenterCallBack presenterCallback;
        public MyDepartmentViewModel(MyDepartment obj)
        {
            //Peoples = EmployeeManager.Employees;
            DepartmentPeoples = new ObservableCollection<People>();
            presenterCallback= new PresenterCallback(this);
            view = obj;
            //FilterDepartment();
            searchObject = new SearchAlgo(DepartmentPeoples.ToList<People>());
        }
        //void FilterDepartment()
        //{
        //    if (Peoples != null) { 
        //    for (int i = 0; i < Peoples.Count; i++)
        //    {
        //        if (Peoples[i].Id == myId)
        //        {
        //            me = Peoples[i];
        //            break;
        //        }
        //    }
           
        //    for (int i = 0; i < Peoples.Count; i++)
        //    {
        //        if (me.Depart.Id == Peoples[i].Depart.Id)
        //        {
        //            DepartmentPeoples.Add(Peoples[i]);
        //        }
        //    }
        //    //return toReturn;
        //    }
        //}
        private class PresenterCallback : IPresenterCallBack
        {
            MyDepartmentViewModel myDepartmentViewModel;
            public PresenterCallback(MyDepartmentViewModel obj)
            {
                myDepartmentViewModel = obj;
            }
            public async void OnSuccess(List<People> DepartPeoples)
            {
                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    for (int i=0;i<DepartPeoples.Count;i++)
                    {
                        myDepartmentViewModel.DepartmentPeoples.Add(DepartPeoples[i]);
                    }
                });
                myDepartmentViewModel.searchObject=new SearchAlgo(myDepartmentViewModel.DepartmentPeoples.ToList<People>());
            }
            public void OnError(string message)
            {
                myDepartmentViewModel.view.ShowErrorMessage(message);
            }
        }
    }
}
