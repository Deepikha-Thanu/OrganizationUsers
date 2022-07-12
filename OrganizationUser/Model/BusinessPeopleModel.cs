using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace OrganizationUser.Model
{
    public class BusinessPeopleModel : People
    {
        public string ReportingToName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }

        public SolidColorBrush StatusColor(string status)
        {
            if(status=="Away")
            {
                return new SolidColorBrush(Windows.UI.Colors.Orange);
            }
            else
            {
                return new SolidColorBrush(Windows.UI.Colors.LimeGreen);
            }
        }
    }
}
