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
    public sealed partial class MyDepartment : Page,INotifyPropertyChanged
    {
        ObservableCollection<People> _Peoples;
        ObservableCollection<People> _DepartPeoples=new ObservableCollection<People>();
        Dictionary<int, People> RemovedPosPeople = new Dictionary<int, People>();
        Dictionary<int, string> PeoplePosition = new Dictionary<int, string>();
        public int j = 0;
        //EventManager _NotifyInstance;


        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string name)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        internal ObservableCollection<People> DepartPeoples 
        { 
            get => _DepartPeoples;
            set
            {
                _DepartPeoples = value;
                RaisePropertyChanged("DepartPeoples");
            }
          }

        internal ObservableCollection<People> Peoples { get => _Peoples; set => _Peoples = value; }
        //internal EventManager NotifyInstance { get => _NotifyInstance; set => _NotifyInstance = value; }

        public MyDepartment()
        {
            this.InitializeComponent();
            Peoples=EmployeeManager.getEmployees();
            DepartPeoples=FilterDepartment();
            //NotifyInstance = new EventManager();
            EventManager.EmployeeSearched += EventManager_EmployeeSearched;
            DictionaryInitialise();

        }
        public void DictionaryInitialise()
        {
            for (int i = 0; i < DepartPeoples.Count; i++)
            {
                PeoplePosition.Add(i, DepartPeoples[i].Fullname);
            }
        }

        private void EventManager_EmployeeSearched(object sender, string data)
        {
            int Length = DepartPeoples.Count;
            for (int i = 0; i < DepartPeoples.Count; i++)
            {
                if (!DepartPeoples[i].Fullname.StartsWith(data, StringComparison.OrdinalIgnoreCase))
                {
                    int pos = PeoplePosition.FirstOrDefault(x => x.Value == DepartPeoples[i].Fullname).Key;
                    if (!RemovedPosPeople.Keys.Contains(pos))
                    {
                        RemovedPosPeople.Add(pos, DepartPeoples[i]);
                    }
                    DepartPeoples.RemoveAt(i);
                    i--;
                }
                j++;
            }
            Length = FilterDepartment().Count;
            for (int i = 0; i < Length; i++)
            {
                if (RemovedPosPeople.ContainsKey(i))
                {
                    if (RemovedPosPeople[i].Fullname.StartsWith(data, StringComparison.OrdinalIgnoreCase))
                    {
                        int pos = RemovedPosPeople.FirstOrDefault(x => x.Value == RemovedPosPeople[i]).Key;
                        if (pos < RemovedPosPeople.Count)
                        {
                            DepartPeoples.Insert(pos, RemovedPosPeople[i]);
                        }
                        else
                        {
                            DepartPeoples.Add(RemovedPosPeople[i]);
                        }
                        RemovedPosPeople.Remove(i);
                    }
                }
            }
        }

        ObservableCollection<People> FilterDepartment()
        {
            ObservableCollection<People> toReturn = new ObservableCollection<People>(); 
            for(int i=0;i<Peoples.Count;i++)
            {
                if(EmployeeManager.me.Depart.Id==Peoples[i].Depart.Id)
                {
                    toReturn.Add(Peoples[i]);
                }
            }
            return toReturn;
        }

        //private void MyDepartmentGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        //{
        //    Panel root = sender as Panel;
        //    StackPanel ChildPopup = (StackPanel)root.FindName("TaskStackPanel");
        //    TextBlock departTextblock = (TextBlock)root.FindName("DepartmentText");
        //    TextBlock designTextblock = (TextBlock)root.FindName("DesignationText");
        //    departTextblock.Visibility = Visibility.Collapsed;
        //    designTextblock.Visibility = Visibility.Collapsed;
        //    ChildPopup.Visibility = Visibility.Visible;
        //}

        //private void MyDepartmentGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        //{
        //    Panel root = sender as Panel;
        //    StackPanel ChildPopup = (StackPanel)root.FindName("TaskStackPanel");
        //    TextBlock departTextblock = (TextBlock)root.FindName("DepartmentText");
        //    TextBlock designTextblock = (TextBlock)root.FindName("DesignationText");
        //    departTextblock.Visibility = Visibility.Visible;
        //    designTextblock.Visibility = Visibility.Visible;
        //    ChildPopup.Visibility = Visibility.Collapsed;
        //}

        //private void MyDepartmentGrid_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    People chosen = (sender as FrameworkElement).DataContext as People;
        //    EventManager.OnEmployeeClicked(chosen);
        //}

        //private void InfoButton_Click(object sender, RoutedEventArgs e)
        //{
        //    People chosen = (sender as FrameworkElement).DataContext as People;
        //    EventManager.OnEmployeeClicked(chosen);
        //}

    }
}
