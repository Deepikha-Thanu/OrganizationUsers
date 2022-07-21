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
        public string ListToStringConvertion(List<BusinessPeopleModel> listToConvert)
        {
            int i;
            string ReportingToList = "";
            if(listToConvert.Count==1)
            {
                ReportingToList = ReportingToList + listToConvert[0].ReportingToId.ToString();
                return ReportingToList;
            }
            for (i = 0; i < listToConvert.Count; i++)
            {
                if (!ReportingToList.Contains(listToConvert[i].ReportingToId + ","))
                {
                    if(i==0)
                    {
                        ReportingToList = ReportingToList + listToConvert[i].ReportingToId.ToString();
                    }
                    else
                    { 
                        ReportingToList = ReportingToList+ ", " + listToConvert[i].ReportingToId.ToString();
                    }
                }
            }
            //if (!ReportingToList.Contains(listToConvert[i].ReportingToId + ","))
            //{
            //    ReportingToList = ReportingToList + listToConvert[i].ReportingToId.ToString();
            //}
            return ReportingToList;
        }
        public void GetBusinessData(Request req,ICallBack callBack)
        {
            Response response = new Response();
            try
            {
                if (req.MyDepartmentId == 0)
                {
                    response.BusinessEmployeesData = dataHandler.ReadPeopleData(req.Start,req.Offset);
                    if(response.BusinessEmployeesData.Count<12)
                    {
                        response.IsDataAvailable = false;
                    }
                    
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
                            response.ReportingToPair = dataHandler.GetReportingToDetails(ListToStringConvertion(response.BusinessEmployeesData));
                            callBack.OnSuccess(response);
                            return;
                        }
                    }
                }
                
                else
                {
                    response.BusinessEmployeesData = dataHandler.ReadDepartmentData(req.MyDepartmentId,req.Start,req.Offset);
                    if (response.BusinessEmployeesData.Count < 12)
                    {
                        response.IsDataAvailable = false;
                    }
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
                            response.ReportingToPair = dataHandler.GetReportingToDetails(ListToStringConvertion(response.BusinessEmployeesData));
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
        public void GetSearchedEmployees(Request request,ICallBack usecaseCallback)
        {
            Response response = new Response();
            if (request.MyDepartmentId == 0)
            {
                response.BusinessEmployeesData = dataHandler.SearchEmployee(request.Start, request.Offset, request.SearchString);
                response.IsSearchResults = true;
                if (response.BusinessEmployeesData == null)
                {
                    usecaseCallback.OnFailure("Something went wrong!");
                    return;
                }
                else
                {
                    if (response.BusinessEmployeesData.Count == 0)
                    {
                        usecaseCallback.OnFailure("No Results Found");
                        return;
                    }
                    else
                    {
                        response.ReportingToPair = dataHandler.GetReportingToDetails(ListToStringConvertion(response.BusinessEmployeesData));
                        usecaseCallback.OnSuccess(response);
                        return;
                    }
                }
            }
            else
            {
               response.BusinessEmployeesData = dataHandler.SearchEmployeeForId(request.Start, request.Offset, request.SearchString,request.MyDepartmentId);
                response.IsSearchResults = true;
                if (response.BusinessEmployeesData == null)
                {
                    usecaseCallback.OnFailure("Something went wrong!");
                    return;
                }
                else
                {
                    if (response.BusinessEmployeesData.Count == 0)
                    {
                        usecaseCallback.OnFailure("No Results Found");
                        return;
                    }
                    else
                    {
                        response.ReportingToPair = dataHandler.GetReportingToDetails(ListToStringConvertion(response.BusinessEmployeesData));
                        usecaseCallback.OnSuccess(response);
                        return;
                    }
                }
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
