using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.ViewModel
{
    public class PeopleDataUserControlViewModel : INotifyPropertyChanged
    {
        public People _EmployeeToShow;
        public People EmployeeToShow
        {
            get { return _EmployeeToShow; }
            set
            {
                _EmployeeToShow = value;
                RaisePropertyChanged("EmployeeToShow");
            }
        }

        //internal EventManager NotifyInstance { get => _NotifyInstance; set => _NotifyInstance = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
