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
    class EmployeeDataManager : IEmployeeDataManager
    {
        IDataHandler DataHandlerInstance;
        public EmployeeDataManager()
        {
            DataHandlerInstance = (DependencyInitializer.DependencyInitializerInstance.IntializeDependencies()).GetService(typeof(IDataHandler)) as IDataHandler;
        }

        public void GetBusinessData(EmployeeRequest req, IUsecaseCallback<EmployeeResponse> callBack)
        {
            EmployeeResponse response = new EmployeeResponse();
            try
            {
                if (req.MyDepartmentId == 0)
                {
                    response.BusinessEmployeesData = DataHandlerInstance.ReadPeopleData(req.Start, req.Offset);
                    if (response.BusinessEmployeesData.Count < 12)
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
                            response.ReportingToPair = DataHandlerInstance.GetReportingToDetails(SearchAlgorithm.ListToStringConvertion(response.BusinessEmployeesData));
                            callBack.OnSuccess(response);
                            return;
                        }
                    }
                }

                else
                {
                    response.BusinessEmployeesData = DataHandlerInstance.ReadDepartmentData(req.MyDepartmentId, req.Start, req.Offset);
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
                            response.ReportingToPair = DataHandlerInstance.GetReportingToDetails(SearchAlgorithm.ListToStringConvertion(response.BusinessEmployeesData));
                            callBack.OnSuccess(response);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                callBack.OnError();
            }
        }
    }
}
