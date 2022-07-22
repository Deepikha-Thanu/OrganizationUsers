using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    interface IReportingToWithIdDataManager
    {
        void GetEmployeeWithId(RequestEmployeeChange req, IUsecaseCallback<ResponseEmployeeChange> callBack);
    }
}
