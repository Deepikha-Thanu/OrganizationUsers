using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser
{
    public class EventManager
    {
        public delegate void EmployeeDisplayEventHandler(object sender, People selectedEmp);
        public delegate void EmployeeSearchedEventHandler(object sender, string data);
        public static event EmployeeDisplayEventHandler EmployeeClicked;
        public static  event EmployeeSearchedEventHandler EmployeeSearched;

        public static void OnEmployeeClicked(People selectedEmp)
        {
            EmployeeClicked?.Invoke(null, selectedEmp);
        }
        public static void OnEmployeeSearched(string toSearch)
        {
            EmployeeSearched?.Invoke(null,toSearch);
        }
    }
}
