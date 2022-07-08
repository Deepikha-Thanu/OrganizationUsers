using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Model
{
    public class BusinessPeopleModel : People
    {
        public string ReportingToName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
    }
}
