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
            dataHandler=(DependencyInitializer.dependencyInitializer.IntializeDependencies()).GetService(typeof(IDataHandler)) as IDataHandler;
        }
        
        public void GetBusinessData(Request req,ICallBack callBack)
        {
            Response response = new Response();
            try
            {
                if (req.myDepartmentId == 0)
                {
                    response.BusinessEmployeesData = dataHandler.ReadPeopleData();
                    response.ReportingToPair = dataHandler.GetReportingToDetails();
                    //response.ReportingToPair = dataHandler.GetReportingTo();
                    if (response.BusinessEmployeesData == null)
                    {
                        callBack.OnFailure("Something went wrong!");
                        return;
                    }
                    else
                    {
                        if (response.BusinessEmployeesData.Count == 0)
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
                    response.BusinessEmployeesData = dataHandler.ReadDepartmentData(req.myDepartmentId);
                    response.ReportingToPair = dataHandler.GetReportingToDetailsOfDepartment(req.myDepartmentId);
                    if (response.BusinessEmployeesData == null)
                    {
                        callBack.OnFailure("Something went wrong!");
                        return;
                    }
                    
                    else
                    {
                        if (response.BusinessEmployeesData.Count == 0)
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
            }
            catch(Exception ex)
            {
                callBack.OnError();
            }
        }

        public void GetEmployeeWithId(RequestEmployeeChange request,ICallBack callBack)
        {
            ResponseEmployeeChange response = new ResponseEmployeeChange();
            response.EmployeeFromId = dataHandler.GetReportingToEmployee(request.EmployeeId);
            if (response.EmployeeFromId == null)
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
