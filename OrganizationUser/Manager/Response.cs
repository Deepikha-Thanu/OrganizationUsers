﻿using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    class Response
    {
        public List<BusinessPeopleModel> BusinessEmployeesData { get; set; }
        //public Dictionary<int,string> ReportingToPair { get; set; }
    }
}
