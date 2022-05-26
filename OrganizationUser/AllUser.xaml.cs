using OrganizationUser.Manager;
using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class AllUser : Page,INotifyPropertyChanged
    {
        ObservableCollection<People> _Peoples;
        SearchAlgo searchObj;
        EmployeeManager employeeManager;
        ObservableCollection<People> Peoples
        {
            get
            {
                return _Peoples;
            }
            set
            {
                _Peoples = value;
                RaisePropertyChanged("Peoples");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public AllUser()
        {
            this.InitializeComponent();
            Peoples=new ObservableCollection<People>(EmployeeManager.Employees);
            EventManager.EmployeeSearched += EventManager_EmployeeSearched;
            Window.Current.Closed += Current_Closed;
            searchObj=new SearchAlgo(Peoples.ToList<People>());
        }

        private void Current_Closed(object sender, Windows.UI.Core.CoreWindowEventArgs e)
        {
            EventManager.EmployeeSearched -= EventManager_EmployeeSearched;
            employeeManager.DeleteTable();
        }



        private void EventManager_EmployeeSearched(object sender, string data)
        {
            searchObj.search(Peoples,data);

        }

    }
}
