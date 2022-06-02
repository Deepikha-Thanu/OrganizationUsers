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
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OrganizationUser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyDepartment : Page,INotifyPropertyChanged
    {
        List<People> _Peoples;
        ObservableCollection<People> _DepartPeoples=new ObservableCollection<People>();
        SearchAlgo searchObj;
        MainPage mainPage;
        public delegate void EmployeeDisplayEventHandler(object sender, People selectedEmp);
        public event EmployeeDisplayEventHandler EmployeeClicked;
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

        internal List<People> Peoples { get => _Peoples; set => _Peoples = value; }
        //internal EventManager NotifyInstance { get => _NotifyInstance; set => _NotifyInstance = value; }

        public MyDepartment()
        {
            this.InitializeComponent();
            Peoples=EmployeeManager.Employees;
            DepartPeoples=new ObservableCollection<People>(FilterDepartment());
            searchObj=new SearchAlgo(DepartPeoples.ToList<People>());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainPage=e.Parameter as MainPage;
            EmployeeClicked += mainPage.MainPage_EmployeeClicked;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (mainPage != null)
            {
                EmployeeClicked -= mainPage.MainPage_EmployeeClicked;
            }
        }
        public void EmployeeSearched(string data)
        {
            searchObj.search(DepartPeoples,data);
        }

        List<People> FilterDepartment()
        {
            List<People> toReturn = new List<People>(); 
            for(int i=0;i<Peoples.Count;i++)
            {
                if(EmployeeManager.me.Depart.Id==Peoples[i].Depart.Id)
                {
                    toReturn.Add(Peoples[i]);
                }
            }
            return toReturn;
        }

        private void OrgUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Rectangle tappedRect = (Rectangle)(sender as UserControl).FindName("TransRectangle");
            Image empImage = (sender as UserControl).FindName("EmployeeImage") as Image;
            Grid dataGrid = (sender as UserControl).FindName("DataGrid") as Grid;
            TextBlock emailText = (sender as UserControl).FindName("EmailIDText") as TextBlock;
            Button infoButton = (sender as UserControl).FindName("InfoButton") as Button;
            tappedRect.Tapped += EmployeeTapped;
            empImage.Tapped += EmployeeTapped;
            dataGrid.Tapped += EmployeeTapped;
            emailText.Tapped += EmployeeTapped;
            infoButton.Click += InfoButton_Click;
        }
        private void EmployeeTapped(object sender, TappedRoutedEventArgs e)
        {
            People chosen = (sender as FrameworkElement).DataContext as People;
            EmployeeClicked?.Invoke(this, chosen);
        }
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            People chosen = (sender as FrameworkElement).DataContext as People;
            EmployeeClicked?.Invoke(this, chosen);
        }
    }
}
