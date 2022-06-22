using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    interface ICallBack
    {
        void OnSuccess<T>(T response);
        void OnError<T>(T message);
    }
}
