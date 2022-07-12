using OrganizationUser.Model;
using System;
using System.Collections.Generic;
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
    public sealed partial class WomenUserControl : UserControl
    {
        public BusinessPeopleModel _People;
        public BusinessPeopleModel People { set { _People = value; } get { return this.DataContext as BusinessPeopleModel; } }
        public delegate void EmployeeDisplayEventHandler(object sender, BusinessPeopleModel selectedEmp);
        public event EmployeeDisplayEventHandler InfoEmployeeClicked;
        public WomenUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();   
        }

        private void AllUserDataGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {

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
            ReportingToText.Visibility = Visibility.Collapsed;
            ChildPopup.Visibility = Visibility.Visible;
        }
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
            ReportingToText.Visibility = Visibility.Visible;
            ChildPopup.Visibility = Visibility.Collapsed;
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            BusinessPeopleModel chosen = (sender as FrameworkElement).DataContext as BusinessPeopleModel;
            if (chosen != null)
            {
                InfoEmployeeClicked.Invoke(this, chosen);
            }
        }

        public void ShowError()
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string message)
        {
            throw new NotImplementedException();
        }

    }
}
