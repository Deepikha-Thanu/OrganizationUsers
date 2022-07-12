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

        public SolidColorBrush StatusColor(Status status)
        {
            if(status==Status.Out)
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
            if(status==Status.OfficeIn)
            {
                return "Office In";
            }
            else if(status==Status.Out)
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
