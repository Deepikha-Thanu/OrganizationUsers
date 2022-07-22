using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    interface IEmployeeDataManager
    {
        void GetBusinessData(EmployeeRequest req, IUsecaseCallback<EmployeeResponse> callBack);
    }
}
