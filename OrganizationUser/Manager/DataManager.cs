using OrganizationUser.DataBase;
using OrganizationUser.Model;
using OrganizationUser.Usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    class DataManager
    {
        DataHandler dataHandler = new DataHandler();

        
        public void GetAllEmployeesData(IUsecaseCallBack callback)
        {
            Response response = new Response();
            try 
            {
                response.EmployeesFromDB = dataHandler.ReadData();
                callback.OnSuccess(response);
            }
            catch(Exception ex)
            {
                callback.OnError(ex.Message);
            }
        }
        public void GetDepartmentEmployees(Request req,IUsecaseCallBack callBack)
        {
            Response response = new Response();
            try
            {
                response.EmployeesFromDB = dataHandler.ReadDepartmentData(req.myDepartmentId);
                callBack.OnSuccess(response);
            }
            catch(Exception ex)
            {
                callBack.OnError(ex.Message);
            }
        }
    }
}
