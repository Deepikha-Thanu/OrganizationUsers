﻿using OrganizationUser.Manager;
using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Shapes;
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
        MainPage mainPage;
        public delegate void EmployeeDisplayEventHandler(object sender, People selectedEmp);
        public event EmployeeDisplayEventHandler EmployeeClicked;
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainPage = (MainPage)e.Parameter;
            if(mainPage!=null)
            { 
              EmployeeClicked += mainPage.MainPage_EmployeeClicked;
            }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (mainPage != null)
            {
                EmployeeClicked -= mainPage.MainPage_EmployeeClicked;
            }
        }
        public AllUser()
        {
            this.InitializeComponent();
            Peoples=new ObservableCollection<People>(EmployeeManager.Employees);
            searchObj=new SearchAlgo(Peoples.ToList<People>());
        }

        public void EmployeeSearched(string data)
        {
           bool result= searchObj.search(Peoples,data);
           SearchResult.Text = !result ? "No Results Found" : "";
        }

        private void OrgUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Rectangle tappedRect= (Rectangle)(sender as UserControl).FindName("TransRectangle");
            Image empImage= (sender as UserControl).FindName("EmployeeImage") as Image;
            Grid dataGrid= (sender as UserControl).FindName("DataGrid") as Grid;
            TextBlock emailText= (sender as UserControl).FindName("EmailIDText") as TextBlock;
            Button infoButton = (sender as UserControl).FindName("InfoButton") as Button;
            tappedRect.Tapped += EmployeeTapped;
            empImage.Tapped += EmployeeTapped;
            dataGrid.Tapped += EmployeeTapped;
            emailText.Tapped += EmployeeTapped;
            infoButton.Click += InfoButton_Click;
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            People chosen = (sender as FrameworkElement).DataContext as People;
            EmployeeClicked?.Invoke(this, chosen);
        }

        private void EmployeeTapped(object sender, TappedRoutedEventArgs e)
        {
            People chosen = (sender as FrameworkElement).DataContext as People;
            EmployeeClicked?.Invoke(this, chosen);
        }
    }
}
