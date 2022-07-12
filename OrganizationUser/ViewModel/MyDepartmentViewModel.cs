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

        ICallBack presenterCallback;
        public MyDepartmentViewModel(MyDepartment obj)
        {
            DepartmentPeoples = new ObservableCollection<BusinessPeopleModel>();
            presenterCallback= new PresenterCallback(this);
            view = obj;
            Request request = new Request() { myDepartmentId = DepartmentId };
            new GetEmployeesBusinessData(request,presenterCallback).Execute();
            //departmentUseCase.Execute();
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
                    for (int i=0;i<resp.BusinessEmployeesData.Count;i++)
                    {
                        myDepartmentViewModel.DepartmentPeoples.Add(resp.BusinessEmployeesData[i]);
                    }
                });
                myDepartmentViewModel.searchObject=new SearchAlgorithm(myDepartmentViewModel.DepartmentPeoples.ToList<BusinessPeopleModel>());
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
