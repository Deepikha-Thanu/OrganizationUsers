using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Usecase
{
    public abstract class UsecaseBase
    {
        public Action ActionTodo;
        public void Execute()
        {
            try
            {
                Task.Run(delegate ()
                {
                    ActionTodo();
                });
            }
            catch (Exception ex)
            {
                //PresenterCallback errorObj = new PresenterCallback();
                //errorObj.OnError(ex.Message);
            }
        }
    }
}
