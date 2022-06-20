using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    public interface IPresenterCallBack
    {
        void OnSuccess(List<People> EmployeesToReturn);
        void OnError(string message);
    }
}
