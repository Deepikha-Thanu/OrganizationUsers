using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser
{
    public interface IView
    {
        void ShowError();
        void ShowErrorMessage(string message);
    }
}
