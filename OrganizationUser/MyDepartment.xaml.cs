using OrganizationUser.Manager;
using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OrganizationUser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyDepartment : Page,INotifyPropertyChanged
    {
        ObservableCollection<People> _Peoples;
        ObservableCollection<People> _DepartPeoples=new ObservableCollection<People>();
        SearchAlgo searchObj;
        EmployeeManager employeeManager;

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string name)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        internal ObservableCollection<People> DepartPeoples 
        { 
            get => _DepartPeoples;
            set
            {
                _DepartPeoples = value;
                RaisePropertyChanged("DepartPeoples");
            }
          }

        internal ObservableCollection<People> Peoples { get => _Peoples; set => _Peoples = value; }
        //internal EventManager NotifyInstance { get => _NotifyInstance; set => _NotifyInstance = value; }

        public MyDepartment()
        {
            this.InitializeComponent();
            employeeManager = new EmployeeManager();
            Peoples=new ObservableCollection<People>(employeeManager.getEmployees());
            DepartPeoples=FilterDepartment();
            //NotifyInstance = new EventManager();
            EventManager.EmployeeSearched += EventManager_EmployeeSearched;
            searchObj=new SearchAlgo(DepartPeoples.ToList<People>());
        }


        private void EventManager_EmployeeSearched(object sender, string data)
        {
            searchObj.search(DepartPeoples,data);
        }

        ObservableCollection<People> FilterDepartment()
        {
            ObservableCollection<People> toReturn = new ObservableCollection<People>(); 
            for(int i=0;i<Peoples.Count;i++)
            {
                if(EmployeeManager.me.Depart.Id==Peoples[i].Depart.Id)
                {
                    toReturn.Add(Peoples[i]);
                }
            }
            return toReturn;
        }
    }
}
