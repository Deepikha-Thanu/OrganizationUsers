using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Model
{
    class Designation
    {
        long _Id;
        string _Name;

        public long Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
    }
}
