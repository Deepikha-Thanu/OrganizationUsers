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
    
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        People _EmployeeToShow;
        //EventManager _NotifyInstance;
        People EmployeeToShow
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
        public MainPage()
        {
            this.InitializeComponent();
            new EmployeeManager();
            PeopleFrame.Navigate(typeof(AllUser));
            //AllUserButton.IsSelected = true;
            //subscription();
            EventManager.EmployeeClicked += EventManager_EmployeeClicked;
            Window.Current.Closed += Current_Closed;
        }
        //public void subscription(EventManager ReceivedNotifyInstance)
        //{
        //    this.NotifyInstance = ReceivedNotifyInstance;
        //    .EmployeeClicked += EventManager_EmployeeClicked;
        //    //NotifyInstance.OnEmployeeClicked(chosen);
        //}
        //public static void subscription()
        //{
        //    MainPage mainPage = new MainPage();
        //    mainPage.NotifyInstance.EmployeeClicked += mainPage.EventManager_EmployeeClicked;
        //}

        private void Current_Closed(object sender, Windows.UI.Core.CoreWindowEventArgs e)
        {
            EventManager.EmployeeClicked -= EventManager_EmployeeClicked;
        }

        private async void EventManager_EmployeeClicked(object sender,People selectedEmp)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
             {
                 EmployeeToShow = selectedEmp;
             });
            EmployeeViewGrid.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
        }

        //public static Color HexToColor(string hexColor)
        //{
        //    //Remove # if present
        //    if (hexColor.IndexOf('#') != -1)
        //        hexColor = hexColor.Replace("#", "");
        //    byte alpha = 0;
        //    byte red = 0;
        //    byte green = 0;
        //    byte blue = 0;

        //    if (hexColor.Length == 8)
        //    {
        //        //#AARRGGBB
        //        alpha = byte.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
        //        red = byte.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
        //        green = byte.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
        //        blue = byte.Parse(hexColor.Substring(6, 2), NumberStyles.AllowHexSpecifier);


        //    }
        //    return Color.FromArgb(alpha, red, green, blue);
        //}


        private void PeopleTabView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllUserButton.IsSelected)
            {
                EmployeeViewGrid.Visibility=Visibility.Collapsed;
                CloseButton.Visibility=Visibility.Collapsed;
                MyReportButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(0);
                AllUserButton.BorderThickness = new Thickness(2, 0, 0, 0);
                PeopleFrame.Navigate(typeof(AllUser));
            }
            if (MyDepartmentButton.IsSelected)
            {
                EmployeeViewGrid.Visibility = Visibility.Collapsed;
                CloseButton.Visibility =Visibility.Collapsed;
                AllUserButton.BorderThickness = new Thickness(0);
                MyReportButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(2, 0, 0, 0);
                PeopleFrame.Navigate(typeof(MyDepartment));
            }
            if (MyReportButton.IsSelected)
            {
                EmployeeViewGrid.Visibility = Visibility.Collapsed;
                CloseButton.Visibility = Visibility.Collapsed;
                AllUserButton.BorderThickness = new Thickness(0);
                MyDepartmentButton.BorderThickness = new Thickness(0);
                MyReportButton.BorderThickness = new Thickness(2, 0, 0, 0);
                PeopleFrame.Navigate(typeof(MyDirectReports));
            }
        }

        //private void CloseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    EmployeeViewGrid.Visibility = Visibility.Collapsed;
        //}


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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeViewGrid.Visibility = Visibility.Collapsed;
            CloseButton.Visibility = Visibility.Collapsed;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string toSearch=SearchBox.Text;
            EventManager.OnEmployeeSearched(toSearch);
        }
    }
}
