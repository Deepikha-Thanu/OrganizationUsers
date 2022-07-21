using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    class Request
    {
        public int MyDepartmentId { get; set; }
        public double Start { get; set; }
        public double Offset { get; set; }
        public string SearchString {get; set;}
    }
}
