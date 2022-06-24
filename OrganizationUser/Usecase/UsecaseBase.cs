using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Usecase
{
    public abstract class UsecaseBase
    {
        public abstract void Action();
        public void Execute()
        {
            try
            {
                Task.Run(delegate ()
                {
                    Action();
                });
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
