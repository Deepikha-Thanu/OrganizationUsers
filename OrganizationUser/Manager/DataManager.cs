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
    class DataManager : IDataManager
    {
        //public static IDataManager dataManagerInstance;
        //public static IDataManager DataManagerInstance
        //{
        //    get
        //    {
        //        dataManagerInstance =(DependencyInitializer.IntializeDependencies()).GetService(typeof(IDataManager)) as IDataManager;
        //        return dataManagerInstance;
        //    }
        //}
        IDataHandler dataHandler;
        public DataManager()
        {
            dataHandler=(DependencyInitializer.IntializeDependencies()).GetService(typeof(IDataHandler)) as IDataHandler;
        }
        
        public void GetEmployeesData(Request req,ICallBack callBack)
        {
            Response response = new Response();
            try
            {
                if (req.myDepartmentId == 0)
                {
                    response.EmployeesFromDB = dataHandler.ReadData();
                    response.ReportingTo = dataHandler.GetReportingTo();
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
                else
                {
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
            }
            catch(Exception ex)
            {
                callBack.OnError();
            }
        }
    }
}
