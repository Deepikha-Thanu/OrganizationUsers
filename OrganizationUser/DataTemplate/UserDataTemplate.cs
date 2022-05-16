using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OrganizationUser
{
    class UserDataTemplate: DataTemplateSelector
    {
        public new DataTemplate SelectTemplate(object item,DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if(element != null && item !=null && element is People)
            {
                if (((People)item).Stat == Status.Away)
                    return element.FindName("AwayDataTemplate") as DataTemplate;
                else
                    return element.FindName("InDataTemplate") as DataTemplate;
            }
            return null;
        }
    }
}
