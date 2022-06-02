using OrganizationUser.Manager;
using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OrganizationUser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
    public sealed partial class MainPage : Page
    {
        PeopleDataUserControl peopleDataUserControl;
        public MainPage()
        {
            this.InitializeComponent();
            //PeopleFrame.Navigate(typeof(AllUser),this);
            //EventManager.EmployeeClicked += EventManager_EmployeeClicked;
        }
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    if(e.Parameter as Type==typeof(AllUser))
        //    {
        //        allUserPage
        //    }
        //}
        //private void EventManager_EmployeeClicked(object sender, People selectedEmp)
        //{
            
        //}

       //private void InitialiseAllUser()
       // {
       //     allUserPage = PeopleFrame.Content as AllUser;
       // }

        public void MainPage_EmployeeClicked(object sender, People selectedEmp)
        {
            peopleDataUserControl = this.FindName("PeopleUserControl") as PeopleDataUserControl;
            peopleDataUserControl.MakeVisible();
            peopleDataUserControl.EmployeeToShow=selectedEmp;
        }

        private void PeopleTabView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllUserButton.IsSelected)
            {
                //InitialiseAllUser();
                new EmployeeManager();
                this.UnloadObject(PeopleUserControl);
                MyReportButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(0);
                AllUserButton.BorderThickness = new Thickness(2, 0, 0, 0);
                PeopleFrame.Navigate(typeof(AllUser),this);
                
            }
            if (MyDepartmentButton.IsSelected)
            {
                //InitialiseDepartment();
                this.UnloadObject(PeopleUserControl);
                AllUserButton.BorderThickness = new Thickness(0);
                MyReportButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(2, 0, 0, 0);
                PeopleFrame.Navigate(typeof(MyDepartment),this);
            }
            if (MyReportButton.IsSelected)
            {
                this.UnloadObject(PeopleUserControl);
                AllUserButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(0);
                MyReportButton.BorderThickness = new Thickness(2, 0, 0, 0);
                PeopleFrame.Navigate(typeof(MyDirectReports),this);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(peopleDataUserControl != null) 
            { 
            peopleDataUserControl.MakeCollapsed();
            }
            string toSearch=SearchBox.Text;
            AllUser allUserPage = PeopleFrame.Content as AllUser;
            MyDepartment department=PeopleFrame.Content as MyDepartment;
            if (allUserPage != null)
            {
                allUserPage.EmployeeSearched(toSearch);
            }
            else if (department != null)
            {
                department.EmployeeSearched(toSearch);
            }
        }

        //private void Page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    TextBlock empText = (sender as UserControl).FindName("NameText") as TextBlock;
        //    empText.Text = "Changed the name";
        //}
    }
}
