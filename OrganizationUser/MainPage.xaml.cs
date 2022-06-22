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
using System.Threading;
using System.Threading.Tasks;
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
using Windows.UI.Xaml.Media.Animation;
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
        }
        
        private void OnEmployeeClicked(object sender, People selectedEmp)
        {
            //this.UnloadObject(PeopleUserControl);
            peopleDataUserControl = this.FindName("PeopleUserControl") as PeopleDataUserControl;
            //peopleDataUserControl.MakeVisible();
            peopleDataUserControl.viewModel.EmployeeToShow=selectedEmp;
        }

        private void PeopleTabView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllUserButton.IsSelected)
            {
                this.UnloadObject(PeopleUserControl);
                MyReportButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(0);
                AllUserButton.BorderThickness = new Thickness(2, 0, 0, 0);
                PeopleFrame.Navigate(typeof(AllUser), this, new SuppressNavigationTransitionInfo());
                AllUser allUserPage = PeopleFrame.Content as AllUser;
                
                if (allUserPage != null)
                {
                    allUserPage.EmployeeClicked += OnEmployeeClicked;
                }
                //Task t1 = PauseNavigation("AllUser");
                //t1.Start();

                //if(EmployeeManager.Employees.Count!=0)
                //{ 
                //    PeopleFrame.Navigate(typeof(AllUser), this,new SuppressNavigationTransitionInfo());
                //    AllUser allUserPage = PeopleFrame.Content as AllUser;
                //    if (allUserPage != null)
                //    {
                //        //orgUserControl.EmployeeClicked += OnEmployeeClicked;
                //        allUserPage.EmployeeClicked += OnEmployeeClicked;
                //    }
                //}
                //else
                //{
                //    NavigationStatus.Text = "Not Able to access data for the moment";
                //}
                //else
                //{
                //    PeopleFrame.Navigate(typeof(AllUser), this);
                //    AllUser allUserPage = PeopleFrame.Content as AllUser;
                //    if (allUserPage != null)
                //    {
                //        //orgUserControl.EmployeeClicked += OnEmployeeClicked;
                //        allUserPage.EmployeeClicked += OnEmployeeClicked;
                //    }
                //}
                //OrgUserControl orgUserControl = allUserPage.userControl as OrgUserControl;

                //allUserPage.EmployeeClicked += OnEmployeeClicked;
            }
            if (MyDepartmentButton.IsSelected)
            {
                //InitialiseDepartment();
                this.UnloadObject(PeopleUserControl);
                AllUserButton.BorderThickness = new Thickness(0);
                MyReportButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(2, 0, 0, 0);
                PeopleFrame.Navigate(typeof(MyDepartment), this, new SuppressNavigationTransitionInfo());
                MyDepartment departmentPage = PeopleFrame.Content as MyDepartment;
               
                if (departmentPage != null)
                {
                    departmentPage.EmployeeClicked += OnEmployeeClicked;
                }
                //Task t1= PauseNavigation("MyDepartment");
                //t1.Start();

                //if(EmployeeManager.Employees.Count!=0)
                //{
                //    PeopleFrame.Navigate(typeof(MyDepartment),this,new SuppressNavigationTransitionInfo());
                //    MyDepartment departmentPage = PeopleFrame.Content as MyDepartment;
                //    //OrgUserControl orgUserControl = departmentPage.FindName("OrgUsersUC") as OrgUserControl;
                //    if (departmentPage != null)
                //    {
                //        departmentPage.EmployeeClicked += OnEmployeeClicked;
                //    }
                //}
                //else
                //{
                //    NavigationStatus.Text = "Not Able to access data for the moment";
                //}
                //departmentPage.EmployeeClicked += OnEmployeeClicked;
            }
            if (MyReportButton.IsSelected)
            {
                this.UnloadObject(PeopleUserControl);
                AllUserButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(0);
                MyReportButton.BorderThickness = new Thickness(2, 0, 0, 0);
                PeopleFrame.Navigate(typeof(MyDirectReports), this, new SuppressNavigationTransitionInfo());
                //Task t1 = PauseNavigation("MyDirectReport");
                //t1.Start();
                //if (!isTimeExceeded)
                //{
                //    PeopleFrame.Navigate(typeof(MyDirectReports), this, new SuppressNavigationTransitionInfo());
                //}
                //else
                //{
                //    NavigationStatus.Text = "Not Able to access data for the moment";
                //}

            }
        }
        //public Task PauseNavigation(string contentToChange)
        //{
        //    Task t=new Task( async() =>
        //     {
        //        bool isTimeExceeded = false;
        //        for (int i = 0; EmployeeManager.Employees.Count == 0;i++)
        //        {
        //        await Task.Delay(1000);
        //            if(i==10)
        //            {
        //                isTimeExceeded = true;
        //                break;
        //            }
        //        }
        //        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { 
        //            if (!isTimeExceeded && contentToChange == "MyDepartment")
        //            {
        //                PeopleFrame.Navigate(typeof(MyDepartment), this, new SuppressNavigationTransitionInfo());
        //                MyDepartment departmentPage = PeopleFrame.Content as MyDepartment;
        //                if (departmentPage != null)
        //                {
        //                    departmentPage.EmployeeClicked += OnEmployeeClicked;
        //                }
        //            }
                 
        //            else if (!isTimeExceeded && contentToChange== "AllUser")
        //            {
        //                PeopleFrame.Navigate(typeof(AllUser), this, new SuppressNavigationTransitionInfo());
        //                AllUser allUserPage = PeopleFrame.Content as AllUser;
        //                if (allUserPage != null)
        //                {
        //                    allUserPage.EmployeeClicked += OnEmployeeClicked;
        //                }
        //            }
        //            else if (!isTimeExceeded && contentToChange == "MyDirectReport")
        //            {
        //                PeopleFrame.Navigate(typeof(MyDirectReports), this, new SuppressNavigationTransitionInfo());
        //            }
        //            else
        //            {
        //                NavigationStatus.Text = "Not Able to access data for the moment";
        //            }
        //         });
        //     });
          
        //    return t;
        //}
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.UnloadObject(PeopleUserControl);
            string toSearch=SearchBox.Text;
            //AllUser allUserPage = PeopleFrame.Content as AllUser;
            //MyDepartment department = PeopleFrame.Content as MyDepartment;
            if (PeopleFrame.Content is AllUser)
            {
                AllUser allUserPage= PeopleFrame.Content as AllUser;
                allUserPage.EmployeeSearched(toSearch);
            }
            else
            {
                MyDepartment departmentPage = PeopleFrame.Content as MyDepartment;
                departmentPage.EmployeeSearched(toSearch);
            }
        }

        private void PeopleUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Button closeButton = (sender as UserControl).FindName("CloseButton") as Button;
            closeButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.UnloadObject(PeopleUserControl);
        }

        //private void Page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    TextBlock empText = (sender as UserControl).FindName("NameText") as TextBlock;
        //    empText.Text = "Changed the name";
        //}
    }
}
