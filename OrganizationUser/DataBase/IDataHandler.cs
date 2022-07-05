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
        List<People> ReadData();
        List<People> GetReportingTo();
        List<People> ReadDepartmentData(int departId);
        People GetPeopleObj(int id);
        Department GetDepartmentObj(int id);
        Designation GetDesignObj(int id);

    }
}
