using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    class SearchRequest : EmployeeRequest
    {
        public string SearchString { get; set; }
    }
}
