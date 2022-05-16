using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    internal class EventData : EventArgs
    {
        People _SelectedEmp;

        internal People SelectedEmp { get => _SelectedEmp; set => _SelectedEmp = value; }
    }
}
