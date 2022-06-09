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
        bool isTimeExceeded = false;
        public MainPage()
        {
            this.InitializeComponent();
            new EmployeeManager();
            //SubscribeEvents();
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
        //public void SubscribeEvents()
        //{
        //    if (PeopleFrame.Content is AllUser)
        //    {
                
        //        //allUserPage.SampleText.Text = "Hi from Mainpage";
        //    }
        //    else
        //    {
                
        //    }
        //}
        public void OnEmployeeClicked(object sender, People selectedEmp)
        {
            //this.UnloadObject(PeopleUserControl);
            peopleDataUserControl = this.FindName("PeopleUserControl") as PeopleDataUserControl;
            //peopleDataUserControl.MakeVisible();
            peopleDataUserControl.EmployeeToShow=selectedEmp;
        }

        private void PeopleTabView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllUserButton.IsSelected)
            {
                this.UnloadObject(PeopleUserControl);
                MyReportButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(0);
                AllUserButton.BorderThickness = new Thickness(2, 0, 0, 0);
                if (EmployeeManager.Employees.Count==0) {
                    Task t1 = PauseNavigation();
                    t1.Start();
                }
                else
                { 
                    if(!isTimeExceeded)
                    { 
                        PeopleFrame.Navigate(typeof(AllUser), this);
                        AllUser allUserPage = PeopleFrame.Content as AllUser;
                        if (allUserPage != null)
                        {
                            //orgUserControl.EmployeeClicked += OnEmployeeClicked;
                            allUserPage.EmployeeClicked += OnEmployeeClicked;
                        }
                    }
                    else
                    {
                        NavigationStatus.Text = "Not Able to access data for the moment";
                    }
                }
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
                if(!isTimeExceeded)
                {
                    PeopleFrame.Navigate(typeof(MyDepartment),this);
                    MyDepartment departmentPage = PeopleFrame.Content as MyDepartment;
                    //OrgUserControl orgUserControl = departmentPage.FindName("OrgUsersUC") as OrgUserControl;
                    if (departmentPage != null)
                    {
                        departmentPage.EmployeeClicked += OnEmployeeClicked;
                    }
                }
                else
                {
                    NavigationStatus.Text = "Not Able to access data for the moment";
                }
                //departmentPage.EmployeeClicked += OnEmployeeClicked;
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
        public Task PauseNavigation()
        {
            Task t = new Task( async() =>
             {
                 for (int i = 0; EmployeeManager.Employees.Count == 0;i++)
                 {
                    await Task.Delay(500);
                     if(i==20)
                     {
                         isTimeExceeded = true;
                         break;
                     }
                 }
                 if (!isTimeExceeded)
                 {
                     await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                     {
                         PeopleFrame.Navigate(typeof(AllUser), this);
                         AllUser allUserPage = PeopleFrame.Content as AllUser;
                         if (allUserPage != null)
                         {
                             //orgUserControl.EmployeeClicked += OnEmployeeClicked;
                             allUserPage.EmployeeClicked += OnEmployeeClicked;
                         }
                     });
                 }
                 else
                 {
                     await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                     {
                         NavigationStatus.Text = "Not Able to access data for the moment";
                     });
                 }
             });
          
            return t;
        }
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
