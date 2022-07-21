using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.DataBase
{
    interface IDataHandler
    {
        void CreateTable();
        void InsertDepartment();
        void InsertDesignation();
        void InsertPeople();
        void InsertDepartmentData(Department depart);
        void InsertDesignationData(Designation design);
        void InsertPeopleData(People people);
        Dictionary<long, string> GetReportingToDetails(string reportingToList);
        //Dictionary<long, string> GetReportingToDetailsOfDepartment(int id,double start,double offset);
        List<BusinessPeopleModel> ReadPeopleData(double start,double offset);
        BusinessPeopleModel GetReportingToEmployee(long id);
        List<BusinessPeopleModel> ReadDepartmentData(int departId,double start,double offset);
        //People GetPeopleObj(int id);
        Department GetDepartmentObj(int id);
        Designation GetDesignObj(int id);
        List<BusinessPeopleModel> SearchEmployee(double start,double offset,string searchString);
        //Dictionary<long, string> SearchReportingTo(string searchString,string reportingToList);
        List<BusinessPeopleModel> SearchEmployeeForId(double start, double offset, string searchString, long deptId);

    }
}
