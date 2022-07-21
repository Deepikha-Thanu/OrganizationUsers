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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OrganizationUser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyDepartment : Page,IView
    {
        //List<People> Peoples { get; set; }
        //ObservableCollection<People> DepartPeoples { get; set; }
        //SearchAlgo searchObj;
        private MyDepartmentViewModel viewModel;
        public delegate void EmployeeDisplayEventHandler(object sender, BusinessPeopleModel selectedEmp);
        public event EmployeeDisplayEventHandler EmployeeClicked;
        private double PreviousOffset;
        private double Start = 0;
        private const int Offset = 12;
        private string SearchString;
        //internal EventManager NotifyInstance { get => _NotifyInstance; set => _NotifyInstance = value; }

        public MyDepartment()
        {
            this.InitializeComponent();
            viewModel = new MyDepartmentViewModel(this);
            //useCase = new MyDepartmentUseCase(request,viewModel.presenterCallback);
            //useCase.Execute();
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
            //bool res= viewModel.searchObject.search(viewModel.DepartmentPeoples,data);
            //SearchResult.Text = !res ? "No Results Found" : "";
            viewModel.IsSearchResults = String.IsNullOrWhiteSpace(data) ? false : true;
            SearchString = data;
            viewModel.SearchEmployees(0, Offset, data);
            viewModel.IsDataAvailable = true;
            PreviousOffset = 0;
            Start = String.IsNullOrWhiteSpace(data) ? Offset : 0;
            SearchResult.Text = "";
        }

        public async void ShowErrorMessage(string message)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                viewModel.DepartmentPeoples.Clear();
                SearchResult.Text = message;
            });
        }
        public async void ShowError()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                viewModel.DepartmentPeoples.Clear();
                SearchResult.Text = "Something went wrong!";
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
            BusinessPeopleModel chosen = e.ClickedItem as BusinessPeopleModel;
            //OrgUserControl orgUser = sender as OrgUserControl;
            //if (orgUser != null)
            //{
                EmployeeClicked.Invoke(this, chosen);
            //}
        }

        private void OrgUsersUC_InfoEmployeeClicked(object sender, BusinessPeopleModel selectedEmp)
        {
            EmployeeClicked.Invoke(this, selectedEmp);
        }

        private void OrgUsersUC_EmployeeClicked(object sender, BusinessPeopleModel selectedEmp)
        {
            EmployeeClicked?.Invoke(this, selectedEmp);
        }

        private void WomenUserTemplate_InfoEmployeeClicked(object sender, BusinessPeopleModel selectedEmp)
        {
            EmployeeClicked?.Invoke(this, selectedEmp);
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.GetDataForOffset(0, 12);
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if(DepartmentScrollbar.VerticalOffset > PreviousOffset && DepartmentScrollbar.VerticalOffset - PreviousOffset > 80 && viewModel.IsDataAvailable && !viewModel.IsSearchResults)
            {
                viewModel.GetDataForOffset(Start, Offset);
                Start = Start + 12;
                PreviousOffset = DepartmentScrollbar.VerticalOffset;
            }
            if (DepartmentScrollbar.VerticalOffset > PreviousOffset && DepartmentScrollbar.VerticalOffset - PreviousOffset > 80 && viewModel.IsDataAvailable && viewModel.IsSearchResults)
            {
                viewModel.SearchEmployees(Start, Offset, SearchString);
                Start = Start + 12;
                PreviousOffset = DepartmentScrollbar.VerticalOffset;
            }

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
