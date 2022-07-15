using OrganizationUser.Model;
using OrganizationUser.ViewModel;
using System;
using System.Collections.Generic;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace OrganizationUser
{
    public sealed partial class PeopleDataUserControl : UserControl,IView
    {
        public PeopleDataUserControlViewModel viewModel; 
        
        public PeopleDataUserControl()
        {
            viewModel = new PeopleDataUserControlViewModel(this);
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
        private void CommonChatButton_Click(object sender, RoutedEventArgs e)
        {
            CommonChatGrid.Visibility = Visibility.Visible;
            PeopleGrid.Visibility = Visibility.Collapsed;
            PeopleButton.BorderThickness = new Thickness(0);
            CommonChatButton.BorderThickness = new Thickness(0, 0, 0, 2);
        }
        private void PeopleButton_Click(object sender, RoutedEventArgs e)
        {
            PeopleGrid.Visibility = Visibility.Visible;
            CommonChatGrid.Visibility = Visibility.Collapsed;
            PeopleButton.BorderThickness = new Thickness(0, 0, 0, 2);
            CommonChatButton.BorderThickness = new Thickness(0);
        }

        //private void CloseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    EmployeeViewGrid.Visibility = Visibility.Collapsed;
        //    CloseButton.Visibility = Visibility.Collapsed;
        //    //this.UnloadObject(this);
        //}

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            //if (viewModel.EmployeeToShow.ReportingTo == null || viewModel.EmployeeToShow.ReportingTo.Name == "-")
            //    return;
            //if (viewModel.EmployeeToShow.ReportingTo.ReportingTo == null)
            //{
            //    viewModel.EmployeeToShow.ReportingTo.ReportingTo = new People();
            //    viewModel.EmployeeToShow.ReportingTo.ReportingTo.Name = "-";
            //}
            //viewModel.EmployeeToShow = viewModel.EmployeeToShow.ReportingTo;
            viewModel.ChangeEmployeeToShow();
            EmployeeViewGrid.Visibility = Visibility.Visible;
            //CloseButton.Visibility = Visibility.Visible;
        }

        public async void ShowError()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                EmployeeViewGrid.Visibility = Visibility.Collapsed;
                ErrorText.Text = "Something went wrong";
            });
        }

        public async void ShowErrorMessage(string message)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
             {
                 EmployeeViewGrid.Visibility = Visibility.Collapsed;
                 ErrorText.Text = message;
             });
            
        }
        public SolidColorBrush StatusColor(Status status)
        {
            if (status == Status.Out)
            {
                return new SolidColorBrush(Windows.UI.Colors.Gray);
            }
            else
            {
                return new SolidColorBrush(Windows.UI.Colors.LimeGreen);
            }
        }
        public string CheckinStatusEnumToString(Status status)
        {
            if (status == Status.OfficeIn)
            {
                return "Office In";
            }
            else if (status == Status.Out)
            {
                return "Out";
            }
            else
            {
                return "Remote In";
            }
        }
    }
}
