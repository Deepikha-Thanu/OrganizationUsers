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
        ICallBack presenterCallback;
        public MyDepartmentViewModel(MyDepartment obj)
        {
            DepartmentPeoples = new ObservableCollection<BusinessPeopleModel>();
            presenterCallback= new PresenterCallback(this);
            view = obj;
        }
        public void SearchEmployees(double start, double offset, string searchString)
        {
            Request req = new Request { SearchString = searchString, Start = start, Offset = offset,MyDepartmentId=DepartmentId };
            new GetSearchedEmployees(req, presenterCallback).Execute();
        }
        public void GetDataForOffset(double start,double offset)
        {
            Request request = new Request() { MyDepartmentId = DepartmentId, Start=start,Offset=offset};
            new GetEmployeesBusinessData(request, presenterCallback).Execute();
        }
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
                if (!resp.IsSearchResults)
                {
                    myDepartmentViewModel.IsDataAvailable = resp.IsDataAvailable;
                    await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        for (int i = 0; i < resp.BusinessEmployeesData.Count; i++)
                        {
                            myDepartmentViewModel.DepartmentPeoples.Add(resp.BusinessEmployeesData[i]);
                        }
                    });
                }
                else
                {
                    await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        myDepartmentViewModel.DepartmentPeoples.Clear();
                        for (int i = 0; i < resp.BusinessEmployeesData.Count; i++)
                        {
                            myDepartmentViewModel.DepartmentPeoples.Add(resp.BusinessEmployeesData[i]);
                        }
                    });
                }
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
