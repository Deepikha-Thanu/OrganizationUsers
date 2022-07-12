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
    class EmployeeDataTemplateSelector :DataTemplateSelector
    {
        public DataTemplate Women { get; set; }
        public DataTemplate Men { get; set; }
        protected override DataTemplate SelectTemplateCore(object item)
        {
            if((item as BusinessPeopleModel).ImageUrl.Contains("WomenUser"))
            {
                return Women;
            }
            else
            {
                return Men;
            }
        }
    }
}
