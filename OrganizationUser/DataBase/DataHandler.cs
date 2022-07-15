﻿using Microsoft.Data.Sqlite;
using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OrganizationUser.DataBase
{
    class DataHandler : IDataHandler
    {
        IDataAdapter dataAdapter;
        SqliteConnection connection;
        public DataHandler()
        {
            dataAdapter = (DependencyInitializer.dependencyInitializer.IntializeDependencies()).GetService(typeof(IDataAdapter)) as IDataAdapter;
            connection = dataAdapter.GetConnection();
            CreateTable();
            InsertDepartment();
            InsertDesignation();
            InsertPeople();
        }
        public void CreateTable()
        {
            try
            { 
                connection.Open();
                SqliteCommand DepartCreateCmd;
                SqliteCommand DesignCreateCmd;
                SqliteCommand PeopleCreateCmd;
                DepartCreateCmd = connection.CreateCommand();
                string DepartCreateQuery = "CREATE TABLE IF NOT EXISTS Department(Id INTEGER PRIMARY KEY,Name TEXT);";
                DepartCreateCmd.CommandText = DepartCreateQuery;
                DepartCreateCmd.ExecuteNonQuery();
                DesignCreateCmd = connection.CreateCommand();
                string DesignCreateQuery = "CREATE TABLE IF NOT EXISTS Designation(Id INTEGER PRIMARY KEY,Name TEXT);";
                DesignCreateCmd.CommandText = DesignCreateQuery;
                DesignCreateCmd.ExecuteNonQuery();
                PeopleCreateCmd = connection.CreateCommand();
                string PeoplecreateQuery = "CREATE TABLE IF NOT EXISTS People(Id INTEGER PRIMARY KEY," +
                    "Employee_Id VARCHAR(20)," +
                    "FirstName TEXT," +
                    "LastName TEXT," +
                    "ReportingToId INTEGER," +
                    "CheckinStatusText TEXT," +
                    "Mobile INTEGER," +
                    "EmpType TEXT," +
                    "Zoid INTEGER," +
                    "OrgId INTEGER," +
                    "EmailId TEXT," +
                    "DateTimeOffset TEXT," +
                    "Language TEXT," +
                    "Status TEXT," +
                    "DepartmentId INTEGER," +
                    "DesignationId INTEGER," +
                    "Fullname TEXT," +
                    "CheckinStatus TEXT," +
                    "ImageUrl TEXT," +
                    "DisplayName TEXT," +
                    "Name TEXT," +
                    "Country TEXT);";
                PeopleCreateCmd.CommandText = PeoplecreateQuery;
                PeopleCreateCmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }
        public void InsertDepartment()
        {
            List<Department> departments = new List<Department>();
            departments.Add(new Department() { Id = 15, Name = "AppX-Windows-Cliq" });
            departments.Add(new Department() { Id = 16, Name = "Appx-Windows-Mail" });
            foreach (Department department in departments)
            {
                InsertDepartmentData(department);
            }
            //insertDepartmentData(appx);
            //insertDepartmentData(mail);
        }
        public void InsertDesignation()
        {
            List<Designation> designations = new List<Designation>();
            designations.Add(new Designation() { Id = 1020, Name = "Project Trainee" });
            designations.Add(new Designation() { Id = 123, Name = "Member Technical Staff" });
            designations.Add(new Designation() { Id = 186, Name = "Project Lead" });
            foreach (Designation designation in designations)
            {
                InsertDesignationData(designation);
            }
            //insertDesignData(pt);
            //insertDesignData(mts);
            //insertDesignData(lead);
        }
        public void InsertPeople()
        {
            try
            {
                connection.Open();
                Department appx = GetDepartmentObj(15);
                Department mail = GetDepartmentObj(16);
                Designation pt = GetDesignObj(1020);
                Designation mts = GetDesignObj(123);
                Designation lead = GetDesignObj(186);
                People Ram = new People() { Employee_id = "1344", Id = 123402, Firstname = "Ram", Lastname = "Sekar", CheckinStatus_Text = "Away", Mobile = 9832391383, Zoid = 149367, Organization_id = 1333, Email_id = "ramsekar.zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Ram Sekar", Checkin_status = true, DisplayName = "Ram", Name = "Ram Sekar", ImageUrl = "Assets/MaleUser.png", Country = "India", ReportingToId = 1, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Out, DesignId = 186, DepartId = 16 };
                People Rahul = new People() { Employee_id = "1290", Id = 129434, Firstname = "Rahul", Lastname = "Takur", CheckinStatus_Text = "Away", Mobile = 9832391383, Zoid = 149367, Organization_id = 1333, Email_id = "rahultakur.zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Rahul Takur", Checkin_status = true, DisplayName = "Rahul", Name = "Rahul", ImageUrl = "Assets/MaleUser1.png", Country = "India", ReportingToId = 123402, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.OfficeIn, DesignId = 186, DepartId = 15 };
                People me = new People() { Employee_id = "PT2339", Id = 235667, Firstname = "Deepikha", Lastname = "Thanu", CheckinStatus_Text = "Office in", Mobile = 7839201283, Zoid = 1920403, Organization_id = 12933, Email_id = "deepikha.thanu@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Deepikha T", Checkin_status = true, DisplayName = "Deepi", Name = "Deepikha", ImageUrl = "Assets/WomenUser.png", Country = "India", ReportingToId = 123402, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.RemoteIn, DesignId = 1020, DepartId = 15 };
                People pratiksha = new People() { Employee_id = "PT4893", Id = 975483, Firstname = "Partiksha", Lastname = "Arun", CheckinStatus_Text = "Office in", Mobile = 94438294313, Zoid = 1223443, Organization_id = 24433, Email_id = "pratiksha.arun@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Pratiksha Arun", Checkin_status = true, DisplayName = "Prati", Name = "Pratiksha", ImageUrl = "Assets/WomenUser1.png", Country = "India", ReportingToId = 123402, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.OfficeIn, DesignId = 1020, DepartId = 15 };
                People srimathi = new People() { Employee_id = "2839", Id = 37989, Firstname = "Srimathi", Lastname = "Selvam", CheckinStatus_Text = "Office in", Mobile = 9372937429, Zoid = 1297853, Organization_id = 16729, Email_id = "srimathi.selvam@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Srimathi", Checkin_status = true, DisplayName = "Sri", Name = "Srimathi", ImageUrl = "Assets/WomenUser2.png", Country = "India", ReportingToId = 123402, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.OfficeIn, DesignId = 123, DepartId = 16 };
                People rajesh = new People() { Employee_id = "2390", Id = 159332, Firstname = "Rajesh", Lastname = "Kumar", CheckinStatus_Text = "Office in", Mobile = 9883749222, Zoid = 1454903, Organization_id = 12315, Email_id = "rajesh.kumar@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Rajesh Kumar", Checkin_status = true, DisplayName = "Rajesh", Name = "Rajesh", ImageUrl = "Assets/MaleUser2.png", Country = "India", ReportingToId = 129434, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Out, DesignId = 123, DepartId = 15 };
                People priya = new People() { Employee_id = "13567", Id = 28903, Firstname = "Priya", Lastname = "Dhasan", CheckinStatus_Text = "Away", Mobile = 94530235532, Zoid = 653232, Organization_id = 17890, Email_id = "priyadhasan@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Priya Dhasan", Checkin_status = true, DisplayName = "Priya Dhasan", Name = "Priya Dhasan", ImageUrl = "Assets/WomenUser3.png", Country = "India", ReportingToId = 129434, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Out, DesignId = 123, DepartId = 15 };
                People EmptyData = new People() { Employee_id = "-", Id = 1, Firstname = "-", Lastname = "-", CheckinStatus_Text = "-", Mobile = 0, Zoid = 0, Organization_id = 0, Email_id = "-", TimeOffset = DateTime.Now, Fullname = "-", Checkin_status = false, DisplayName = "-", Name = "-", ImageUrl = "-", Country = "-", ReportingToId = 0, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.OfficeIn, DesignId = 0, DepartId = 0 };
                InsertPeopleData(Ram);
                InsertPeopleData(Rahul);
                InsertPeopleData(me);
                InsertPeopleData(pratiksha);
                InsertPeopleData(srimathi);
                InsertPeopleData(rajesh);
                InsertPeopleData(priya);
                InsertPeopleData(EmptyData);
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }
        public void InsertDepartmentData(Department depart)
        {
            try
            {
                connection.Open();
                SqliteCommand insertCommand = connection.CreateCommand();
                insertCommand.CommandText = $"INSERT OR IGNORE INTO Department(Id,Name) VALUES(@Id,@Name);";
                insertCommand.Parameters.AddWithValue("@Id", depart.Id);
                insertCommand.Parameters.AddWithValue("@Name", depart.Name);
                insertCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }
        public void InsertDesignationData(Designation design)
        {
            try
            {
                connection.Open();
                SqliteCommand insertCommand = connection.CreateCommand();
                insertCommand.CommandText = "INSERT OR IGNORE INTO Designation(Id,Name) VALUES(@Id,@Name);";
                insertCommand.Parameters.AddWithValue("@Id",design.Id);
                insertCommand.Parameters.AddWithValue("@Name", design.Name);
                insertCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }
        public void InsertPeopleData(People people)
        {
            try {
            //    if (people.ReportingTo == null)
            //    {
            //        people.ReportingTo = new People();
            //        people.ReportingTo.Id = 0;
            //        people.ReportingTo.Name = null;
            //    }
                connection.Open();
            SqliteCommand InsertCommand;
                string InsertQuery = "INSERT OR IGNORE INTO People(Id,Employee_Id,FirstName,LastName,ReportingToId,CheckinStatusText,Mobile,EmpType," +
                    "Zoid,OrgId,EmailId,DateTimeOffset,Language,Status,DepartmentId,DesignationId,Fullname,CheckinStatus,ImageUrl,DisplayName," +
                    "Name,Country) VALUES(@Id,@Employee_id,@Firstname,@Lastname,@ReportingToId,@CheckinStatusText,@Mobile,@Type,@Zoid,@OrganizationId,@EmailId,@TimeOffset,@Lang,@Stat,@DepartId,@DesignId,@Fullname,@CheckinStatus,@ImageUrl,@DisplayName,@Name,@Country);";
            InsertCommand = connection.CreateCommand();
            InsertCommand.CommandText = InsertQuery;
            InsertCommand.Parameters.AddWithValue("@Id", people.Id);
            InsertCommand.Parameters.AddWithValue("@Employee_id", people.Employee_id);
            InsertCommand.Parameters.AddWithValue("@Firstname", people.Firstname);
            InsertCommand.Parameters.AddWithValue("@Lastname", people.Lastname);
            InsertCommand.Parameters.AddWithValue("@ReportingToId", people.ReportingToId);
            InsertCommand.Parameters.AddWithValue("@CheckinStatusText", people.CheckinStatus_Text);
            InsertCommand.Parameters.AddWithValue("@Mobile", people.Mobile);
            InsertCommand.Parameters.AddWithValue("@Type", people.Type.ToString());
            InsertCommand.Parameters.AddWithValue("@Zoid", people.Zoid);
            InsertCommand.Parameters.AddWithValue("@OrganizationId", people.Organization_id);
            InsertCommand.Parameters.AddWithValue("@EmailId", people.Email_id);
            InsertCommand.Parameters.AddWithValue("@TimeOffset", people.TimeOffset.ToString());
            InsertCommand.Parameters.AddWithValue("@Lang", people.Lang.ToString());
            InsertCommand.Parameters.AddWithValue("@Stat", people.Stat.ToString());
            InsertCommand.Parameters.AddWithValue("@DepartId", people.DepartId);
            InsertCommand.Parameters.AddWithValue("@DesignId", people.DesignId);
            InsertCommand.Parameters.AddWithValue("@Fullname", people.Fullname);
            InsertCommand.Parameters.AddWithValue("@CheckinStatus", people.Checkin_status.ToString());
            InsertCommand.Parameters.AddWithValue("@ImageUrl", people.ImageUrl);
            InsertCommand.Parameters.AddWithValue("@DisplayName", people.DisplayName);
            InsertCommand.Parameters.AddWithValue("@Name", people.Name);
            InsertCommand.Parameters.AddWithValue("@Country", people.Country);

            InsertCommand.ExecuteNonQuery();
            connection.Close();
            }
            catch(Exception ex)
            {
                connection.Close();
            }
        }
        public List<BusinessPeopleModel> ReadData()
        {
            try
            {
                connection.Open();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = connection.CreateCommand();
                readCommand.CommandText = "Select reporting.Id,employee.Id,reporting.Employee_Id,reporting.Name,employee.Name,reporting.Fullname,reporting.DisplayName,reporting.EmailId," +
                    "reporting.Mobile,reporting.Country,reporting.CheckinStatusText,reporting.Status,reporting.ImageUrl,dept.Name,design.Name " +
                    "from People as employee " +
                    "Join People as reporting " +
                    "ON employee.ID = reporting.ReportingToId " +
                    "Join Department as dept ON reporting.DepartmentId = dept.Id " +
                    "Join Designation as design On reporting.DesignationId = design.Id; ";
                dataReader = readCommand.ExecuteReader();
                 List<BusinessPeopleModel> toReturn = new List<BusinessPeopleModel>();
                for (int i = 0; dataReader.Read(); i++)
                {
                    toReturn.Add(new BusinessPeopleModel()
                    {
                        Id = dataReader.GetInt32(0),
                        ReportingToId = dataReader.GetInt32(1),
                        Employee_id = dataReader.GetString(2),
                        Name = dataReader.GetString(3),
                        ReportingToName = dataReader.GetString(4),
                        Fullname = dataReader.GetString(5),
                        DisplayName = dataReader.GetString(6),
                        Email_id = dataReader.GetString(7),
                        Mobile = dataReader.GetInt64(8),
                        Country = dataReader.GetString(9),
                        CheckinStatus_Text = dataReader.GetString(10),
                        Stat=(Status)Enum.Parse(typeof(Status),dataReader.GetString(11)),
                        ImageUrl = dataReader.GetString(12),
                        DepartmentName = dataReader.GetString(13),
                        DesignationName = dataReader.GetString(14)
                    }
                    );;
                }
                connection.Close();
                return toReturn;
            }
            catch(Exception ex)
            {
                connection.Close();
                return null;
            }
        }
        public BusinessPeopleModel GetReportingToEmployee(long id)
        {
            try
            {
                connection.Open();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = connection.CreateCommand();
                readCommand.CommandText = "Select reporting.Id,employee.Id,reporting.Employee_Id,reporting.Name,employee.Name,reporting.Fullname,reporting.DisplayName," +
                    "reporting.EmailId,reporting.Mobile,reporting.Country,reporting.CheckinStatusText,reporting.Status,reporting.ImageUrl,dept.Name,design.Name " +
                    "from People as employee " +
                    "Join People as reporting " +
                    "ON employee.ID = reporting.ReportingToId and reporting.Id = @Id " +
                    "Join Department as dept ON reporting.DepartmentId = dept.Id " +
                    "Join Designation as design On reporting.DesignationId = design.Id; ";
                readCommand.Parameters.AddWithValue("@Id", id);
                dataReader = readCommand.ExecuteReader();
                BusinessPeopleModel toReturn=null;
                if(dataReader.Read())
                {
                    toReturn = new BusinessPeopleModel
                    {
                        Id = dataReader.GetInt32(0),
                        ReportingToId = dataReader.GetInt32(1),
                        Employee_id = dataReader.GetString(2),
                        Name = dataReader.GetString(3),
                        ReportingToName = dataReader.GetString(4),
                        Fullname = dataReader.GetString(5),
                        DisplayName = dataReader.GetString(6),
                        Email_id = dataReader.GetString(7),
                        Mobile = dataReader.GetInt64(8),
                        Country = dataReader.GetString(9),
                        CheckinStatus_Text = dataReader.GetString(10),
                        Stat = (Status)Enum.Parse(typeof(Status), dataReader.GetString(11)),
                        ImageUrl = dataReader.GetString(12),
                        DepartmentName = dataReader.GetString(13),
                        DesignationName = dataReader.GetString(14)
                    };
                }
                connection.Close();
                return toReturn;
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;
            }
        }
        public List<BusinessPeopleModel> ReadDepartmentData(int departId)
        {
            try
            {
                connection.Open();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = connection.CreateCommand();
                readCommand.CommandText = "Select reporting.Id,employee.Id,reporting.Employee_Id,reporting.Name,employee.Name,reporting.Fullname,reporting.DisplayName,reporting.EmailId,reporting.Mobile,reporting.Country,reporting.CheckinStatusText,reporting.Status,reporting.ImageUrl,dept.Name,design.Name " +
                    "from People as employee " +
                    "Join People as reporting ON employee.ID = reporting.ReportingToId " +
                    "Join Department as dept ON reporting.DepartmentId = dept.Id and dept.Id = 15 " +
                    "Join Designation as design On reporting.DesignationId = design.Id;" ;
                readCommand.Parameters.AddWithValue("@Id", departId);
                dataReader = readCommand.ExecuteReader();
                List<BusinessPeopleModel> toReturn = new List<BusinessPeopleModel>();
                for (int i = 0; dataReader.Read(); i++)
                {
                    toReturn.Add(new BusinessPeopleModel()
                    {
                        Id = dataReader.GetInt32(0),
                        ReportingToId = dataReader.GetInt32(1),
                        Employee_id = dataReader.GetString(2),
                        Name = dataReader.GetString(3),
                        ReportingToName = dataReader.GetString(4),
                        Fullname = dataReader.GetString(5),
                        DisplayName=dataReader.GetString(6),
                        Email_id = dataReader.GetString(7),
                        Mobile = dataReader.GetInt64(8),
                        Country = dataReader.GetString(9),
                        CheckinStatus_Text = dataReader.GetString(10),
                        Stat= (Status)Enum.Parse(typeof(Status), dataReader.GetString(11)),
                        ImageUrl = dataReader.GetString(12),
                        DepartmentName = dataReader.GetString(13),
                        DesignationName = dataReader.GetString(14)
                    }
                    ); ;
                }
                connection.Close();
                return toReturn;
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;
            }
        }

        //public People GetPeopleObj(int id)
        //{
        //    try
        //    {
        //        if (id == 0)
        //        {
        //            return null;
        //        }
        //        People toReturn = new People();
        //        SqliteDataReader dataReader;
        //        SqliteCommand readCommand = connection.CreateCommand();
        //        readCommand.CommandText = "SELECT * FROM People WHERE Id=@id;";
        //        readCommand.Parameters.AddWithValue("@id", id);
        //        dataReader = readCommand.ExecuteReader();
        //        if (dataReader.Read())
        //        {
        //            toReturn = new People()
        //            {
        //                Id = dataReader.GetInt32(0),
        //                Employee_id = dataReader.GetString(1),
        //                Firstname = dataReader.GetString(2),
        //                Lastname = dataReader.GetString(3),
        //                ReportingToId = dataReader.IsDBNull(4) ? null :dataReader.GetInt32(4)),
        //                CheckinStatus_Text = dataReader.GetString(5),
        //                Mobile = dataReader.GetInt64(6),
        //                Type = (Emp_type)Enum.Parse(typeof(Emp_type), dataReader.GetString(7)),
        //                Zoid = dataReader.GetInt64(8),
        //                Organization_id = dataReader.GetInt32(9),
        //                Email_id = dataReader.GetString(10),
        //                TimeOffset = DateTimeOffset.Parse(dataReader.GetString(11)),
        //                Lang = (Language)Enum.Parse(typeof(Language), dataReader.GetString(12)),
        //                Stat = (Status)Enum.Parse(typeof(Status), dataReader.GetString(13)),
        //                DepartId = dataReader.GetInt32(14),
        //                DesignId = dataReader.GetInt32(15),
        //                Fullname = dataReader.GetString(16),
        //                Checkin_status = Convert.ToBoolean(dataReader.GetString(17)),
        //                ImageUrl = dataReader.GetString(18),
        //                DisplayName = dataReader.GetString(19),
        //                Name = dataReader.GetString(20),
        //                Country = dataReader.GetString(21)
        //            };
        //        }
        //        return toReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        connection.Close();
        //        return null;
        //    }
        //}
        public Department GetDepartmentObj(int id)
        {
            try
            {
                Department toReturn = new Department();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = connection.CreateCommand();
                readCommand.CommandText = "SELECT * FROM Department WHERE Id= @id";
                readCommand.Parameters.AddWithValue("@id", id);
                dataReader = readCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    toReturn.Id = dataReader.GetInt32(0);
                    toReturn.Name = dataReader.GetString(1);
                }   
                return toReturn;
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;
            }
        }
        public Designation GetDesignObj(int id)
        {
            try
            {
                Designation toReturn = new Designation();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = connection.CreateCommand();
                readCommand.CommandText = "SELECT * FROM Designation WHERE Id= @id";
                readCommand.Parameters.AddWithValue("@id", id);
                dataReader = readCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    toReturn.Id = dataReader.GetInt32(0);
                    toReturn.Name = dataReader.GetString(1);
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;
            }
        }
    }
}
