using OrganizationUser.Manager;
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
using OrganizationUser.ViewModel;
using OrganizationUser.Usecase;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OrganizationUser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllUser : Page,IView
    {
        //ObservableCollection<People> Peoples { get; set; }
        //SearchAlgo searchObj;
        public delegate void EmployeeDisplayEventHandler(object sender, BusinessPeopleModel selectedEmp);
        public event EmployeeDisplayEventHandler EmployeeClicked;
        private AllUserViewModel viewModel;
        //public event PropertyChangedEventHandler PropertyChanged;
        //void RaisePropertyChanged(string name)
        //{
        //    if(PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(name));
        //    }
        //}
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    mainPage = (MainPage)e.Parameter;
        //    if(mainPage!=null)
        //    { 
        //      EmployeeClicked += mainPage.MainPage_EmployeeClicked;
        //    }
        //}
        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    if (mainPage != null)
        //    {
        //        EmployeeClicked -= mainPage.EmployeeClicked;
        //    }
        //}
        public AllUser()
        {
            this.InitializeComponent();
            viewModel=new AllUserViewModel(this);
            this.DataContext = viewModel;
            //AllUserUseCase getAllEmployees= new AllUserUseCase(viewModel.presenterCallBack);
            //getAllEmployees.Execute();
            //Peoples=new ObservableCollection<People>(EmployeeManager.Employees);
            //searchObj=new SearchAlgo(Peoples.ToList<People>());
        }
        public async void ShowErrorMessage(string message)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                SearchResult.Text = message;
            });
        }
        public async void ShowError()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                SearchResult.Text = "Something went wrong!";
            });
        }

        public void EmployeeSearched(string data)
        {
           bool result= viewModel.searchObject.search(viewModel.Employees,data);
           SearchResult.Text = result? "" : "No Results Found";
        }
        //private void OrgUsersUC_Tapped(object sender, TappedRoutedEventArgs e)
        //{
            
        //}

        private void AllUserGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            BusinessPeopleModel chosen = e.ClickedItem as BusinessPeopleModel;
            EmployeeClicked?.Invoke(this, chosen);
        }

        private void OrgUsersUC_EmployeeClicked(object sender, BusinessPeopleModel selectedEmp)
        {
            EmployeeClicked?.Invoke(this, selectedEmp);   
        }

        //private void AllUserGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    People chosen = (sender as FrameworkElement).DataContext as People;
        //    OrgUserControl orgUserObj = sender as OrgUserControl;
        //    if (orgUserObj != null)
        //    {
        //        EmployeeClicked?.Invoke(orgUserObj, chosen);
        //    }
        //}

        //private void OrgUserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Rectangle tappedRect= (Rectangle)(sender as UserControl).FindName("TransRectangle");
        //    Image empImage= (sender as UserControl).FindName("EmployeeImage") as Image;
        //    Grid dataGrid= (sender as UserControl).FindName("DataGrid") as Grid;
        //    TextBlock emailText= (sender as UserControl).FindName("EmailIDText") as TextBlock;
        //    Button infoButton = (sender as UserControl).FindName("InfoButton") as Button;
        //    tappedRect.Tapped += EmployeeTapped;
        //    empImage.Tapped += EmployeeTapped;
        //    dataGrid.Tapped += EmployeeTapped;
        //    emailText.Tapped += EmployeeTapped;
        //    infoButton.Click += InfoButton_Click;
        //}

        //private void InfoButton_Click(object sender, RoutedEventArgs e)
        //{
        //    People chosen = (sender as FrameworkElement).DataContext as People;
        //    EmployeeClicked?.Invoke(this, chosen);
        //}

        //private void EmployeeTapped(object sender, TappedRoutedEventArgs e)
        //{
        //    People chosen = (sender as FrameworkElement).DataContext as People;
        //    EmployeeClicked?.Invoke(this, chosen);
        //}
    }
}
