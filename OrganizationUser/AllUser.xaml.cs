using OrganizationUser.Manager;
using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class AllUser : Page,INotifyPropertyChanged
    {
        ObservableCollection<People> _Peoples;
        //EventManager _AllUserNotifyInstance;
        //public delegate void EmployeeDisplayEventHandler(object sender, People selectedEmp);
        //public event EmployeeDisplayEventHandler EmployeeClicked;
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

        //internal EventManager AllUserNotifyInstance { get => _AllUserNotifyInstance; set => _AllUserNotifyInstance = value; }
        //internal NotificationManager NotificationManager { get => _NotificationManager; set => _NotificationManager = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public AllUser()
        {
            this.InitializeComponent();
            Peoples=EmployeeManager.getEmployees();
            //NotificationManager.NotifyMainPage(AllUserNotifyInstance);
            //StatusCheck();
            EventManager.EmployeeSearched += EventManager_EmployeeSearched;
            Window.Current.Closed += Current_Closed;
        }

        private void Current_Closed(object sender, Windows.UI.Core.CoreWindowEventArgs e)
        {
            EventManager.EmployeeSearched -= EventManager_EmployeeSearched;
        }

        //public void subscription(EventManager NotifyInstance)
        //{
        //    NotifyInstance.EmployeeSearched += allUser.EventManager_EmployeeSearched;
        //    //NotifyInstance.OnEmployeeClicked(chosen);
        //}


        public void StatusCheck()
        {
            //for(int i=0;i<Peoples.Count;i++)
            //{
            //    GridViewItem gridViewItem=AllUserGridView.ContainerFromIndex(2) as GridViewItem;
            //    Grid grid = gridViewItem.ContentTemplate.LoadContent() as Grid;
            //    TextBlock tb=grid.FindName("StatusText") as TextBlock;
            //    tb.Foreground=new SolidColorBrush(Colors.Orange);
            //}
            //for(int i=0;i<Peoples.Count;i++)
            //{
            //    if(Peoples[i].CheckinStatus_Text == "Away")
            //    { 
            //        GridViewItem AlluserGridviewItem = AllUserGridView.ContainerFromIndex(i) as GridViewItem;

            //        TextBlock StatusTextBlock= AlluserGridviewItem.FindName("StatusText") as TextBlock;
            //        StatusTextBlock.Foreground = new SolidColorBrush(Colors.Orange);
            //    }

            //}

        }
        private void EventManager_EmployeeSearched(object sender, string data)
        {
            ObservableCollection<People> original=EmployeeManager.getEmployees();
            data=data.ToLower();
            if (data != "")
            {
                ObservableCollection<People> temp = new ObservableCollection<People>();
                for (int i = 0; i < original.Count; i++)
                {
                    if (original[i].Fullname.StartsWith(data,StringComparison.OrdinalIgnoreCase))
                    {
                        temp.Add(original[i]);
                    }
                }
                Peoples = temp;
            }
            else
            {
                Peoples= EmployeeManager.getEmployees();
            }
        }

        private void AllUserDataGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            //int index = AllUserGridView.SelectedIndex;
            //int i = 0;
            //foreach(var popup in FindVisualChildren<Popup>(AllUserGridView))
            //{
            //    if(index==i)
            //    { 
            //            popup.IsOpen = true;
            //    }
            //    i++;
            //}

            //GridViewItem gridViewItem = (GridViewItem)AllUserGridView.ItemContainerGenerator.ContainerFromItem(AllUserGridView.SelectedItem);
            //ContentPresenter myContent = FindVisualChild<ContentPresenter>(gridViewItem);
            //DataTemplate myDataTemplate=myContent.ContentTemplate as DataTemplate;
            //Popup childPopup = (Popup)myDataTemplate.FindName("TaskPopup", myContent);

            //GridViewItem gridViewItem= (GridViewItem)AllUserGridView.ContainerFromIndex(AllUserGridView.SelectedIndex);
            //Grid childGrid = (Grid)gridViewItem.ContentTemplateRoot;
            //Popup childPopup = (Popup)childGrid.FindName("TaskPopup");
            //childPopup.IsOpen = true;

            Panel root = sender as Panel;
            StackPanel ChildPopup = (StackPanel)root.FindName("TaskStackPanel");
            TextBlock departTextblock = (TextBlock)root.FindName("DepartmentText");
            TextBlock designTextblock = (TextBlock)root.FindName("DesignationText");
            departTextblock.Visibility = Visibility.Collapsed;
            designTextblock.Visibility = Visibility.Collapsed;
            ChildPopup.Visibility = Visibility.Visible;
        }
    //    private childItem FindVisualChild<childItem>(DependencyObject obj)
    //where childItem : DependencyObject
    //    {
    //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
    //        {
    //            DependencyObject child = VisualTreeHelper.GetChild(obj, i);
    //            if (child != null && child is childItem)
    //            {
    //                return (childItem)child;
    //            }
    //            else
    //            {
    //                childItem childOfChild = FindVisualChild<childItem>(child);
    //                if (childOfChild != null)
    //                    return childOfChild;
    //            }
    //        }
    //        return null;
    //    }
        private void AllUserDataGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            //int index = AllUserGridView.SelectedIndex;
            //int i = 0;
            //foreach (var popup in FindVisualChildren<Popup>(AllUserGridView))
            //{
            //    if (index == i)
            //    {
            //            popup.IsOpen = false;

            //    }
            //    i++;
            //}

            //GridViewItem gridViewItem = (GridViewItem)AllUserGridView.ContainerFromIndex(AllUserGridView.SelectedIndex);
            //Grid childGrid = (Grid)gridViewItem.ContentTemplateRoot;
            //Popup childPopup = (Popup)childGrid.FindName("TaskPopup");
            //childPopup.IsOpen = false;

            Panel root = sender as Panel;
            StackPanel ChildPopup = (StackPanel)root.FindName("TaskStackPanel");
            TextBlock departTextblock = (TextBlock)root.FindName("DepartmentText");
            TextBlock designTextblock = (TextBlock)root.FindName("DesignationText");
            departTextblock.Visibility = Visibility.Visible;
            designTextblock.Visibility = Visibility.Visible;
            ChildPopup.Visibility = Visibility.Collapsed;
        }

        //private void AllUserGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int index = AllUserGridView.SelectedIndex;
        //    //EmployeeViewGrid.Visibility = Visibility.Visible;
        //    EventManager.OnEmployeeClicked(index);
        //    //GridViewItem gridViewItem = (GridViewItem)AllUserGridView.ContainerFromItem(AllUserGridView.SelectedItem);
        //    //Grid childGrid = (Grid)gridViewItem.ContentTemplateRoot;
        //    //Popup childPopup = (Popup)childGrid.FindName("TaskPopup");
        //    //TextBlock departTextblock = (TextBlock)childGrid.FindName("DepartmentText");
        //    //TextBlock designTextblock = (TextBlock)childGrid.FindName("DesignationText");
        //    //if(childPopup.IsOpen)
        //    //{ 
        //    //  departTextblock.Visibility = Visibility.Visible;
        //    //  designTextblock.Visibility= Visibility.Visible;
        //    //  childPopup.IsOpen = false;
        //    //}
        //    //else
        //    //{
        //    //    departTextblock.Visibility = Visibility.Collapsed;
        //    //    designTextblock.Visibility = Visibility.Collapsed;
        //    //    childPopup.IsOpen = true;
        //    //}
        //}

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            People chosen = (sender as FrameworkElement).DataContext as People;
            //People chosen=(People)AllUserGridView.SelectedItem;
           EventManager.OnEmployeeClicked(chosen);
        }

        private void AllUserDataGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            People chosen= (sender as FrameworkElement).DataContext as People;
            EventManager.OnEmployeeClicked(chosen);
            //subscription(chosen);
            //allUser.EmployeeClicked?.Invoke(null,chosen);
        }

       
    }
}
