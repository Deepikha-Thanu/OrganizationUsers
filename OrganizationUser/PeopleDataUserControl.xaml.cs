using OrganizationUser.Model;
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
    public sealed partial class PeopleDataUserControl : UserControl,INotifyPropertyChanged
    {
        public People _EmployeeToShow;
        public People EmployeeToShow
        {
            get { return _EmployeeToShow; }
            set
            {
                _EmployeeToShow = value;
                RaisePropertyChanged("EmployeeToShow");
            }
        }

        //internal EventManager NotifyInstance { get => _NotifyInstance; set => _NotifyInstance = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public PeopleDataUserControl()
        {
            this.InitializeComponent();
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
            if (EmployeeToShow.ReportingTo == null || EmployeeToShow.ReportingTo.Name == "-")
                return;
            if (EmployeeToShow.ReportingTo.ReportingTo == null)
            {
                EmployeeToShow.ReportingTo.ReportingTo = new People();
                EmployeeToShow.ReportingTo.ReportingTo.Name = "-";
            }
            EmployeeToShow = EmployeeToShow.ReportingTo;
            EmployeeViewGrid.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
        }
    }
}
