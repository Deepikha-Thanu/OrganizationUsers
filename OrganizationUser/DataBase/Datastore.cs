﻿using Microsoft.Data.Sqlite;
using OrganizationUser.Manager;
using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace OrganizationUser.DataBase
{
    class Datastore
    {
        //SqliteConnection conn;
        //string connectionString;
        //public Datastore()
        //{
        //    connectionString = Path.Combine(ApplicationData.Current.LocalFolder.Path , "EmployeeDatabase.db");
        //    conn = new SqliteConnection($"FileName={connectionString}");
        //    conn.Open();     
        //}

        public async void CreateDB()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("EmployeeDatabase.db", CreationCollisionOption.OpenIfExists);
        }
        public void InitialiseDB()
        {
            CreateDB();
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "EmployeeDatabase.db");
            using (SqliteConnection conn = new SqliteConnection($"FileName={dbPath}"))
            {
                conn.Open();
                SqliteCommand DepartCreateCmd;
                SqliteCommand DesignCreateCmd;
                SqliteCommand PeopleCreateCmd;
                DepartCreateCmd = conn.CreateCommand();
                string DepartCreateQuery = "CREATE TABLE IF NOT EXISTS Department(Id INTEGER PRIMARY KEY,Name TEXT);";
                DepartCreateCmd.CommandText = DepartCreateQuery;
                DepartCreateCmd.ExecuteNonQuery();
                DesignCreateCmd = conn.CreateCommand();
                string DesignCreateQuery = "CREATE TABLE IF NOT EXISTS Designation(Id INTEGER PRIMARY KEY,Name TEXT);";
                DesignCreateCmd.CommandText = DesignCreateQuery;
                DesignCreateCmd.ExecuteNonQuery();
                PeopleCreateCmd = conn.CreateCommand();
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
            }
        }
        public void InsertDepartment()
        {
            List<Department> departments = new List<Department>();
            departments.Add( new Department() { Id = 15, Name = "AppX-Windows-Cliq" });
            departments.Add( new Department() { Id = 16, Name = "Appx-Windows-Mail" });
            foreach(Department department in departments)
            {
                InsertDepartmentData(department);
            }
            //insertDepartmentData(appx);
            //insertDepartmentData(mail);
        }
        public void InsertDesign()
        {
            List<Designation> designations = new List<Designation>();
            designations.Add( new Designation() { Id = 1020, Name = "Project Trainee" });
            designations.Add( new Designation() { Id = 123, Name = "Member Technical Staff" });
            designations.Add( new Designation() { Id = 186, Name = "Project Lead" });
            foreach (Designation designation in designations)
            {
                InsertDesignData(designation);
            }
            //insertDesignData(pt);
            //insertDesignData(mts);
            //insertDesignData(lead);
        }
        public void InsertPeople()
        {
            Department appx = GetDepartmentObj(15);
            Department mail = GetDepartmentObj(16);
            Designation pt = GetDesignObj(1020);
            Designation mts = GetDesignObj(123);
            Designation lead = GetDesignObj(186);
            People Ram =new People() { Employee_id = "1344", Id = 123402, Firstname = "Ram", Lastname = "Sekar", CheckinStatus_Text = "Away", Mobile = 9832391383, Zoid = 149367, Organization_id = 1333, Email_id = "ramsekar.zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Ram Sekar", Checkin_status = true, DisplayName = "Ram", Name = "Ram Sekar", ImageUrl = "Assets/MaleUser.png", Country = "India", ReportingTo = null, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Away, Design = lead, Depart = mail };
            People Rahul = new People() { Employee_id = "1290", Id = 129434, Firstname = "Rahul", Lastname = "Takur", CheckinStatus_Text = "Away", Mobile = 9832391383, Zoid = 149367, Organization_id = 1333, Email_id = "rahultakur.zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Rahul Takur", Checkin_status = true, DisplayName = "Rahul", Name = "Rahul", ImageUrl = "Assets/MaleUser.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Away, Design = lead, Depart = appx };
            People me = new People() { Employee_id = "PT2339", Id = 235667, Firstname = "Deepikha", Lastname = "Thanu", CheckinStatus_Text = "Office in", Mobile = 7839201283, Zoid = 1920403, Organization_id = 12933, Email_id = "deepikha.thanu@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Deepikha T", Checkin_status = true, DisplayName = "Deepi", Name = "Deepikha", ImageUrl = "Assets/WomenUser.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = pt, Depart = appx };
            People pratiksha = new People() { Employee_id = "PT4893", Id = 975483, Firstname = "Partiksha", Lastname = "Arun", CheckinStatus_Text = "Office in", Mobile = 94438294313, Zoid = 1223443, Organization_id = 24433, Email_id = "pratiksha.arun@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Pratiksha Arun", Checkin_status = true, DisplayName = "Prati", Name = "Pratiksha", ImageUrl = "Assets/WomenUser.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = pt, Depart = appx };
            People srimathi = new People() { Employee_id = "2839", Id = 37989, Firstname = "Srimathi", Lastname = "Selvam", CheckinStatus_Text = "Office in", Mobile = 9372937429, Zoid = 1297853, Organization_id = 16729, Email_id = "srimathi.selvam@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Srimathi", Checkin_status = true, DisplayName = "Sri", Name = "Srimathi", ImageUrl = "Assets/WomenUser.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = mts, Depart = mail };
            People rajesh = new People() { Employee_id = "2390", Id = 159332, Firstname = "Rajesh", Lastname = "Kumar", CheckinStatus_Text = "Office in", Mobile = 9883749222, Zoid = 1454903, Organization_id = 12315, Email_id = "rajesh.kumar@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Rajesh Kumar", Checkin_status = true, DisplayName = "Rajesh", Name = "Rajesh", ImageUrl = "Assets/MaleUser.png", Country = "India", ReportingTo = Rahul, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = mts, Depart = appx };
            People priya = new People() { Employee_id = "13567", Id = 28903, Firstname = "Priya", Lastname = "Dhasan", CheckinStatus_Text = "Away", Mobile = 94530235532, Zoid = 653232, Organization_id = 17890, Email_id = "priyadhasan@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Priya Dhasan", Checkin_status = true, DisplayName = "Priya Dhasan", Name = "Priya Dhasan", ImageUrl = "Assets/WomenUser.png", Country = "India", ReportingTo = Rahul, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = mts, Depart = appx };
            InsertPeopleData(Ram);
            InsertPeopleData(Rahul);
            InsertPeopleData(me);
            InsertPeopleData(pratiksha);
            InsertPeopleData(srimathi);
            InsertPeopleData(rajesh);
            InsertPeopleData(priya);
        }
        //public async void createDBFile(string dbName)
        //{
        //    StorageFolder dbFolder = ApplicationData.Current.LocalFolder;
        //    if (await dbFolder.TryGetItemAsync(dbName)==null)
        //    {
        //        StorageFile dbFile = await dbFolder.CreateFileAsync(dbName);
        //        insertDepartment();
        //        insertDesign();
        //        insertPeople();
        //        //conn = new SqliteConnection($"FileName={connectionString}");

        //    }
        //    else
        //    {
        //        //conn = new SqliteConnection($"FileName={connectionString}");
        //        //conn.Open();
        //        return;
        //    }
        //}
        //public void createPeopleTable()
        //{
           
        //    SqliteCommand DepartCreateCmd;
        //    SqliteCommand DesignCreateCmd;
        //    SqliteCommand PeopleCreateCmd;
        //    DepartCreateCmd = conn.CreateCommand();
        //    string DepartCreateQuery = "CREATE TABLE IF NOT EXISTS Department(Id INTEGER PRIMARY KEY,Name TEXT);";
        //    DepartCreateCmd.CommandText = DepartCreateQuery;
        //    DepartCreateCmd.ExecuteNonQuery();
        //    DesignCreateCmd = conn.CreateCommand();
        //    string DesignCreateQuery = "CREATE TABLE IF NOT EXISTS Designation(Id INTEGER PRIMARY KEY,Name TEXT);";
        //    DesignCreateCmd.CommandText = DesignCreateQuery;
        //    DesignCreateCmd.ExecuteNonQuery();
        //    PeopleCreateCmd = conn.CreateCommand();
        //    string PeoplecreateQuery = "CREATE TABLE IF NOT EXISTS People(Id INTEGER PRIMARY KEY," +
        //        "Employee_Id VARCHAR(20)," +
        //        "FirstName TEXT," +
        //        "LastName TEXT," +
        //        "ReportingToId INTEGER," +
        //        "CheckinStatusText TEXT," +
        //        "Mobile INTEGER," +
        //        "EmpType TEXT," +
        //        "Zoid INTEGER," +
        //        "OrgId INTEGER," +
        //        "EmailId TEXT," +
        //        "DateTimeOffset TEXT," +
        //        "Language TEXT," +
        //        "Status TEXT," +
        //        "DepartmentId INTEGER," +
        //        "DesignationId INTEGER," +
        //        "Fullname TEXT," +
        //        "CheckinStatus TEXT," +
        //        "ImageUrl TEXT," +
        //        "DisplayName TEXT," +
        //        "Name TEXT," +
        //        "Country TEXT);";
        //    PeopleCreateCmd.CommandText = PeoplecreateQuery;
        //    PeopleCreateCmd.ExecuteNonQuery();
        //}
        public void InsertDepartmentData(Department depart)
        {
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "EmployeeDatabase.db");
            using (SqliteConnection conn = new SqliteConnection($"FileName={dbPath}"))
            {
                conn.Open();
                SqliteCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = $"INSERT OR IGNORE INTO Department(Id,Name) VALUES('{ depart.Id}','{depart.Name}');";
                insertCommand.ExecuteNonQuery();
            }

        }
        public void InsertDesignData(Designation design)
        {
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "EmployeeDatabase.db");
            using (SqliteConnection conn = new SqliteConnection($"FileName={dbPath}"))
            {
                conn.Open();
                SqliteCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = "INSERT OR IGNORE INTO Designation(Id,Name) VALUES(" + design.Id + ",'" + design.Name + "');";
                insertCommand.ExecuteNonQuery();
            }
        }
        public void InsertPeopleData(People people)
        {
            if(people.ReportingTo==null)
            {
                people.ReportingTo = new People();
                people.ReportingTo.Id = 0;
                people.ReportingTo.Name = null;
            }
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "EmployeeDatabase.db");
            using (SqliteConnection conn = new SqliteConnection($"FileName={dbPath}"))
            {
                conn.Open();
                SqliteCommand InsertCommand;
                string InsertQuery = "INSERT OR IGNORE INTO People(Id,Employee_Id,FirstName,LastName,ReportingToId,CheckinStatusText,Mobile,EmpType," +
                    "Zoid,OrgId,EmailId,DateTimeOffset,Language,Status,DepartmentId,DesignationId,Fullname,CheckinStatus,ImageUrl,DisplayName," +
                    "Name,Country) VALUES(" + people.Id + ",'" + people.Employee_id + "','" + people.Firstname + "','" + people.Lastname + "'," + people.ReportingTo.Id + ",'" + people.CheckinStatus_Text + "'," + people.Mobile + ",'" + people.Type.ToString() + "'," + people.Zoid + "," + people.Organization_id + ",'" + people.Email_id + "','" + people.TimeOffset.ToString() + "','" + people.Lang.ToString() + "','" + people.Stat.ToString() + "'," + people.Depart.Id + "," + people.Design.Id + ",'" + people.Fullname + "','" + people.Checkin_status.ToString() + "','" + people.ImageUrl + "','" + people.DisplayName + "','" + people.Name + "','" + people.Country + "');";
                InsertCommand = conn.CreateCommand();
                InsertCommand.CommandText = InsertQuery;
                InsertCommand.ExecuteNonQuery();
            }

        }
        public List<People> ReadData()
        {
            List<People> toReturn=new List<People>();
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "EmployeeDatabase.db");
            using (SqliteConnection conn = new SqliteConnection($"FileName={dbPath}"))
            {
                conn.Open();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = conn.CreateCommand();
                readCommand.CommandText = "SELECT * FROM People;";
                dataReader = readCommand.ExecuteReader();
                for (int i = 0; dataReader.Read(); i++)
                {
                    toReturn.Add(new People()
                    {
                        Id = dataReader.GetInt32(0),
                        Employee_id = dataReader.GetString(1),
                        Firstname = dataReader.GetString(2),
                        Lastname = dataReader.GetString(3),
                        ReportingTo = dataReader.IsDBNull(4) ? null : GetPeopleObj(dataReader.GetInt32(4)),
                        CheckinStatus_Text = dataReader.GetString(5),
                        Mobile = dataReader.GetInt64(6),
                        Type = (Emp_type)Enum.Parse(typeof(Emp_type), dataReader.GetString(7)),
                        Zoid = dataReader.GetInt64(8),
                        Organization_id = dataReader.GetInt32(9),
                        Email_id = dataReader.GetString(10),
                        TimeOffset = DateTimeOffset.Parse(dataReader.GetString(11)),
                        Lang = (Language)Enum.Parse(typeof(Language), dataReader.GetString(12)),
                        Stat = (Status)Enum.Parse(typeof(Status), dataReader.GetString(13)),
                        Depart = GetDepartmentObj(dataReader.GetInt32(14)),
                        Design = GetDesignObj(dataReader.GetInt32(15)),
                        Fullname = dataReader.GetString(16),
                        Checkin_status = Convert.ToBoolean(dataReader.GetString(17)),
                        ImageUrl = dataReader.GetString(18),
                        DisplayName = dataReader.GetString(19),
                        Name = dataReader.GetString(20),
                        Country = dataReader.GetString(21)
                    });
                }
            }
            return toReturn;
        }
        public People GetPeopleObj(int id)
        {
            if(id==0)
            {
                return null;
            }
            People toReturn = new People();
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "EmployeeDatabase.db");
            using (SqliteConnection conn = new SqliteConnection($"FileName={dbPath}"))
            {
                conn.Open();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = conn.CreateCommand();
                readCommand.CommandText = "SELECT * FROM People WHERE Id='" + id.ToString() + "';";
                dataReader = readCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    toReturn = new People()
                    {
                        Id = dataReader.GetInt32(0),
                        Employee_id = dataReader.GetString(1),
                        Firstname = dataReader.GetString(2),
                        Lastname = dataReader.GetString(3),
                        ReportingTo = dataReader.IsDBNull(4) ? null : GetPeopleObj(dataReader.GetInt32(4)),
                        CheckinStatus_Text = dataReader.GetString(5),
                        Mobile = dataReader.GetInt64(6),
                        Type = (Emp_type)Enum.Parse(typeof(Emp_type), dataReader.GetString(7)),
                        Zoid = dataReader.GetInt64(8),
                        Organization_id = dataReader.GetInt32(9),
                        Email_id = dataReader.GetString(10),
                        TimeOffset = DateTimeOffset.Parse(dataReader.GetString(11)),
                        Lang = (Language)Enum.Parse(typeof(Language), dataReader.GetString(12)),
                        Stat = (Status)Enum.Parse(typeof(Status), dataReader.GetString(13)),
                        Depart = GetDepartmentObj(dataReader.GetInt32(14)),
                        Design = GetDesignObj(dataReader.GetInt32(15)),
                        Fullname = dataReader.GetString(16),
                        Checkin_status = Convert.ToBoolean(dataReader.GetString(17)),
                        ImageUrl = dataReader.GetString(18),
                        DisplayName = dataReader.GetString(19),
                        Name = dataReader.GetString(20),
                        Country = dataReader.GetString(21)
                    };
                }
            }
            return toReturn;
        }
        public Department GetDepartmentObj(int id)
        {
            Department toReturn = new Department();
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "EmployeeDatabase.db");
            using (SqliteConnection conn = new SqliteConnection($"FileName={dbPath}"))
            {
                conn.Open();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = conn.CreateCommand();
                readCommand.CommandText = "SELECT * FROM Department WHERE Id=" + id.ToString() + ";";
                dataReader = readCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    toReturn.Id = dataReader.GetInt32(0);
                    toReturn.Name = dataReader.GetString(1);
                }
                return toReturn;
            }
        }
        public Designation GetDesignObj(int id)
        {
            Designation toReturn=new Designation();
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "EmployeeDatabase.db");
            using (SqliteConnection conn = new SqliteConnection($"FileName={dbPath}"))
            {
                conn.Open();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = conn.CreateCommand();
                readCommand.CommandText = "SELECT * FROM Designation WHERE Id=" + id.ToString() + ";";
                dataReader = readCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    toReturn.Id = dataReader.GetInt32(0);
                    toReturn.Name = dataReader.GetString(1);
                }
                return toReturn;
            }
        }
        //public void DeleteTableData()
        //{
        //    SqliteCommand delPeoplecmd=conn.CreateCommand();
        //    delPeoplecmd.CommandText = "DELETE FROM People;";
        //    delPeoplecmd.ExecuteNonQuery();
        //    SqliteCommand delDepartmentcmd = conn.CreateCommand();
        //    delDepartmentcmd.CommandText = "DELETE FROM Department;";
        //    delDepartmentcmd.ExecuteNonQuery();
        //    SqliteCommand delDesigncmd = conn.CreateCommand();
        //    delDesigncmd.CommandText = "DELETE FROM Designation;";
        //    delDesigncmd.ExecuteNonQuery();
        //}
        //public void CloseConnecton()
        //{
        //    conn.Close();
        //}
    }
}
