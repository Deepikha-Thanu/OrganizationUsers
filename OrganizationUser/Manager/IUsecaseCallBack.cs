using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    interface IUsecaseCallBack
    {
        void OnSuccess(Response response);
        void OnError(string message);
    }
}
