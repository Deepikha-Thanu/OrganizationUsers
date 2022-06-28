using Microsoft.Extensions.DependencyInjection;
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
        public static DataManager dataManager = new DataManager();
        DataHandler dataHandler = new DataHandler();
        
        public void GetEmployeesData(Request req,ICallBack callBack)
        {
            Response response = new Response();
            try
            {
                if (req.myDepartmentId == 0)
                {
                    response.EmployeesFromDB = dataHandler.ReadData();
                    if (response.EmployeesFromDB == null)
                    {
                        callBack.OnFailure("Something went wrong!");
                        return;
                    }
                    else
                    {
                        if (response.EmployeesFromDB.Count == 0)
                        {
                            callBack.OnFailure("Data is not available!");
                            return;
                        }

                        else
                        {
                            callBack.OnSuccess(response);
                            return;
                        }
                    }
                }
                response.EmployeesFromDB = dataHandler.ReadDepartmentData(req.myDepartmentId);
                if (response.EmployeesFromDB.Count == 0)
                {
                    callBack.OnFailure("Data is not available!");
                    return;
                }
                else
                {
                    if (response.EmployeesFromDB == null)
                    {
                        callBack.OnFailure("Something went wrong!");
                        return;
                    }
                    else
                    {
                        callBack.OnSuccess(response);
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                callBack.OnError();
            }
        }
    }
}
