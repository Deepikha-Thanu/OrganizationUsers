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
        //EventManager _NotifyInstance;

        
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
            Peoples=EmployeeManager.getEmployees();
            DepartPeoples=FilterDepartment();
            //NotifyInstance = new EventManager();
            EventManager.EmployeeSearched += EventManager_EmployeeSearched;
        }

        private void EventManager_EmployeeSearched(object sender, string data)
        {
            ObservableCollection<People> original = FilterDepartment();
            data = data.ToLower();
            if (data != "")
            {
                ObservableCollection<People> temp = new ObservableCollection<People>();
                for (int i = 0; i < original.Count; i++)
                {
                    if (original[i].Fullname.ToLower().StartsWith(data,StringComparison.OrdinalIgnoreCase))
                    {
                        temp.Add(original[i]);
                    }
                }
                DepartPeoples = temp;
            }
            else
            {
                DepartPeoples = FilterDepartment();
            }
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

        private void MyDepartmentGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Panel root = sender as Panel;
            StackPanel ChildPopup = (StackPanel)root.FindName("TaskStackPanel");
            TextBlock departTextblock = (TextBlock)root.FindName("DepartmentText");
            TextBlock designTextblock = (TextBlock)root.FindName("DesignationText");
            departTextblock.Visibility = Visibility.Collapsed;
            designTextblock.Visibility = Visibility.Collapsed;
            ChildPopup.Visibility = Visibility.Visible;
        }

        private void MyDepartmentGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Panel root = sender as Panel;
            StackPanel ChildPopup = (StackPanel)root.FindName("TaskStackPanel");
            TextBlock departTextblock = (TextBlock)root.FindName("DepartmentText");
            TextBlock designTextblock = (TextBlock)root.FindName("DesignationText");
            departTextblock.Visibility = Visibility.Visible;
            designTextblock.Visibility = Visibility.Visible;
            ChildPopup.Visibility = Visibility.Collapsed;
        }

        private void MyDepartmentGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            People chosen = (sender as FrameworkElement).DataContext as People;
            EventManager.OnEmployeeClicked(chosen);
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            People chosen = (sender as FrameworkElement).DataContext as People;
            EventManager.OnEmployeeClicked(chosen);
        }

    }
}
