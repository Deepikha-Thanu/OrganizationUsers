using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    interface IDataManager
    {
        void GetBusinessData(Request req, ICallBack callBack);
        void GetEmployeeWithId(RequestEmployeeChange req, ICallBack callBack);
    }
}
