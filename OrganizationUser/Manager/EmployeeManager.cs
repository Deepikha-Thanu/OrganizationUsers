using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    class EmployeeManager
    {
        static List<People> Employees = new List<People>();
        public static People me;
        public EmployeeManager()
        {
            Designation pt = new Designation() { Id = 1020, Name = "Project Trainee" };
            Designation mts = new Designation() { Id = 123, Name = "Member Technical Staff" };
            Designation lead = new Designation() { Id = 186, Name = "Project Lead" };
            Department appx = new Department() { Id = 15, Name = "AppX-Windows-Cliq" };
            Department mail = new Department() { Id = 16, Name = "Appx-Windows-Mail" };
            People Ram = new People() { Employee_id = "1344", Id = 123402, Firstname = "Ram", Lastname = "Sekar", CheckinStatus_Text = "Away", Mobile = 9832391383, Zoid = 149367, Organization_id = 1333, Email_id = "ramsekar.zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Ram Sekar", Checkin_status = true, DisplayName = "Ram", Name = "Ram Sekar", ImageUrl = "Assets/MaleUser.png", Country = "India", ReportingTo = null, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Away, Design = lead, Depart = appx };
            People Rahul = new People() { Employee_id = "1290", Id = 129434, Firstname = "Rahul", Lastname = "Takur", CheckinStatus_Text = "Away", Mobile = 9832391383, Zoid = 149367, Organization_id = 1333, Email_id = "rahultakur.zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Rahul Takur", Checkin_status = true, DisplayName = "Rahul", Name = "Rahul", ImageUrl = "Assets/MaleUser.png", Country = "India", ReportingTo = null, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Away, Design = lead, Depart = mail };
            me = new People() { Employee_id = "PT2339", Id = 123402, Firstname = "Deepikha", Lastname = "Thanu", CheckinStatus_Text = "Office in", Mobile = 7839201283, Zoid = 1920403, Organization_id = 12933, Email_id = "deepikha.thanu@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Deepikha T", Checkin_status = true, DisplayName = "Deepi", Name = "Deepikha", ImageUrl = "Assets/WomenUser.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = pt, Depart = appx };
            Employees.Add(Ram);
            Employees.Add(Rahul);
            Employees.Add(me);
            Employees.Add(new People() { Employee_id = "PT4893", Id = 123402, Firstname = "Partiksha", Lastname = "Arun", CheckinStatus_Text = "Office in", Mobile = 94438294313, Zoid = 1223443, Organization_id = 24433, Email_id = "pratiksha.arun@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Pratiksha Arun", Checkin_status = true, DisplayName = "Prati", Name = "Pratiksha", ImageUrl = "Assets/WomenUser.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = pt, Depart = appx });
            Employees.Add(new People() { Employee_id = "2839", Id = 123402, Firstname = "Srimathi", Lastname = "Selvam", CheckinStatus_Text = "Office in", Mobile = 9372937429, Zoid = 1297853, Organization_id = 16729, Email_id = "srimathi.selvam@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Srimathi", Checkin_status = true, DisplayName = "Sri", Name = "Srimathi", ImageUrl = "Assets/WomenUser.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = mts, Depart = mail });
            Employees.Add(new People() { Employee_id = "2390", Id = 159332, Firstname = "Rajesh", Lastname = "Kumar", CheckinStatus_Text = "Office in", Mobile = 9883749222, Zoid = 1454903, Organization_id = 12315, Email_id = "rajesh.kumar@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Rajesh Kumar", Checkin_status = true, DisplayName = "Rajesh", Name = "Rajesh", ImageUrl = "Assets/MaleUser.png", Country = "India", ReportingTo = Rahul, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = mts, Depart = appx });
        }
        public static ObservableCollection<People> getEmployees()
        {
            ObservableCollection<People> ToReturn = new ObservableCollection<People>();
            for (int i = 0; i < Employees.Count; i++)
            {
                People tempEmployee = new People();
                tempEmployee.Employee_id = Employees[i].Employee_id;
                tempEmployee.Id = Employees[i].Id;
                tempEmployee.Firstname = Employees[i].Firstname;
                tempEmployee.Lastname = Employees[i].Lastname;
                tempEmployee.Mobile = Employees[i].Mobile;
                tempEmployee.Name = Employees[i].Name;
                tempEmployee.Organization_id = Employees[i].Organization_id;
                tempEmployee.Lang = Employees[i].Lang;
                tempEmployee.ImageUrl = Employees[i].ImageUrl;
                tempEmployee.ReportingTo = Employees[i].ReportingTo;
                tempEmployee.Stat = Employees[i].Stat;
                tempEmployee.Zoid = Employees[i].Zoid;
                tempEmployee.TimeOffset = Employees[i].TimeOffset;
                tempEmployee.Timezone = Employees[i].Timezone;
                tempEmployee.Type = Employees[i].Type;
                tempEmployee.Fullname = Employees[i].Fullname;
                tempEmployee.DisplayName = Employees[i].DisplayName;
                tempEmployee.Depart = Employees[i].Depart;
                tempEmployee.CheckinStatus_Text = Employees[i].CheckinStatus_Text;
                tempEmployee.Checkin_status = Employees[i].Checkin_status;
                tempEmployee.Design = Employees[i].Design;
                tempEmployee.Email_id = Employees[i].Email_id;
                tempEmployee.Country = Employees[i].Country;
                ToReturn.Add(tempEmployee);
            }
            return ToReturn;
        }
    }
}
