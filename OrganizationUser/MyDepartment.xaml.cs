using OrganizationUser.Manager;
using OrganizationUser.Model;
using OrganizationUser.Usecase;
using OrganizationUser.ViewModel;
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
    public sealed partial class MyDepartment : Page
    {
        //List<People> Peoples { get; set; }
        //ObservableCollection<People> DepartPeoples { get; set; }
        //SearchAlgo searchObj;
        private MyDepartmentViewModel viewModel;
        public delegate void EmployeeDisplayEventHandler(object sender, People selectedEmp);
        public event EmployeeDisplayEventHandler EmployeeClicked;
        private Request request = new Request();
        public const int DepartmentId = 15;
        private MyDepartmentUseCase useCase;

        //internal EventManager NotifyInstance { get => _NotifyInstance; set => _NotifyInstance = value; }

        public MyDepartment()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
            request.myDepartmentId = DepartmentId;
            viewModel = new MyDepartmentViewModel(this);
            useCase = new MyDepartmentUseCase(request,viewModel.presenterCallback);
            useCase.Execute();
            //Peoples=EmployeeManager.Employees;
            //DepartPeoples=new ObservableCollection<People>(FilterDepartment());
        }
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    mainPage=e.Parameter as MainPage;
        //    EmployeeClicked += mainPage.MainPage_EmployeeClicked;
        //}
        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    if (mainPage != null)
        //    {
        //        EmployeeClicked -= mainPage.EmployeeClicked;
        //    }
        //}
        public void EmployeeSearched(string data)
        {
           bool res= viewModel.searchObject.search(viewModel.DepartmentPeoples,data);
           SearchResult.Text = !res ? "No Results Found" : "";
        }

        public async void ShowErrorMessage(string message)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                SearchResult.Text = $"Unable to access the data because of the error{message}";
            });  
        }

        //private void OrgUsersUC_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    People chosen = (sender as FrameworkElement).DataContext as People;
        //    OrgUserControl orgUser= sender as OrgUserControl;
        //    if(orgUser!=null)
        //    {
        //        EmployeeClicked.Invoke(orgUser, chosen);
        //    }
        //}

        private void MyDepartmentGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            People chosen = e.ClickedItem as People;
            //OrgUserControl orgUser = sender as OrgUserControl;
            //if (orgUser != null)
            //{
                EmployeeClicked.Invoke(this, chosen);
            //}
        }

        private void OrgUsersUC_InfoEmployeeClicked(object sender, People selectedEmp)
        {
            EmployeeClicked.Invoke(this, selectedEmp);
        }

        //private void OrgUserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Rectangle tappedRect = (Rectangle)(sender as UserControl).FindName("TransRectangle");
        //    Image empImage = (sender as UserControl).FindName("EmployeeImage") as Image;
        //    Grid dataGrid = (sender as UserControl).FindName("DataGrid") as Grid;
        //    TextBlock emailText = (sender as UserControl).FindName("EmailIDText") as TextBlock;
        //    Button infoButton = (sender as UserControl).FindName("InfoButton") as Button;
        //    tappedRect.Tapped += EmployeeTapped;
        //    empImage.Tapped += EmployeeTapped;
        //    dataGrid.Tapped += EmployeeTapped;
        //    emailText.Tapped += EmployeeTapped;
        //    infoButton.Click += InfoButton_Click;
        //}
        //private void EmployeeTapped(object sender, TappedRoutedEventArgs e)
        //{
        //    People chosen = (sender as FrameworkElement).DataContext as People;
        //    EmployeeClicked?.Invoke(this, chosen);
        //}
        //private void InfoButton_Click(object sender, RoutedEventArgs e)
        //{
        //    People chosen = (sender as FrameworkElement).DataContext as People;
        //    EmployeeClicked?.Invoke(this, chosen);
        //}
    }
}
