using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    interface IPresenterCallback<T>
    {
        void OnSuccess(T response);
        void OnError();
        void OnFailure(string message);
    }
}
