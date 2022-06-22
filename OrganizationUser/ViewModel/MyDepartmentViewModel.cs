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
        public ObservableCollection<People> DepartmentPeoples;
        IView view;
        MyDepartmentUseCase departmentUseCase;
        private Request request = new Request();
        public const int DepartmentId = 15;
        //        public  People me=new People();

        ICallBack presenterCallback;
        public MyDepartmentViewModel(MyDepartment obj)
        {
            DepartmentPeoples = new ObservableCollection<People>();
            presenterCallback= new PresenterCallback(this);
            view = obj;
            request.myDepartmentId = DepartmentId;
            departmentUseCase = new MyDepartmentUseCase(request,presenterCallback);
            departmentUseCase.Execute();
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
        private class PresenterCallback : ICallBack
        {
            MyDepartmentViewModel myDepartmentViewModel;
            public PresenterCallback(MyDepartmentViewModel obj)
            {
                myDepartmentViewModel = obj;
            }
            public async void OnSuccess<T>(T response)
            {
                Response resp = response as Response;
                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    for (int i=0;i<resp.EmployeesFromDB.Count;i++)
                    {
                        myDepartmentViewModel.DepartmentPeoples.Add(resp.EmployeesFromDB[i]);
                    }
                });
                myDepartmentViewModel.searchObject=new SearchAlgo(myDepartmentViewModel.DepartmentPeoples.ToList<People>());
            }
            public void OnError<T>(T message)
            {
                myDepartmentViewModel.view.ShowErrorMessage(message.ToString());
            }
        }
    }
}
