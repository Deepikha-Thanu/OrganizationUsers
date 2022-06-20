using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.ViewModel
{
    public class ViewModelBase
    {
        public SearchAlgo searchObject { get; set; }
        public string ErrorMessage { get; set; }
        public bool isError { get; set; }
    }
}
