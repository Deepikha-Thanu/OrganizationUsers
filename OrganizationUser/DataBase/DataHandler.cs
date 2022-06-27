using Microsoft.Data.Sqlite;
using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OrganizationUser.DataBase
{
    class DataHandler
    {
        IDataAdapter dataAdapter;
        SqliteConnection conn;
        public DataHandler()
        {
            ServiceProvider provider = DependencyInitializer.IntializeDependencies();
            IDataAdapter adapter = provider.GetService(typeof(IDataAdapter)) as IDataAdapter;
            dataAdapter = adapter;
            conn=dataAdapter.GetConnection();
            CreateTable();
            InsertDepartment();
            InsertDesign();
            InsertPeople();
        }
        public void CreateTable()
        {
            try
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
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
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
        public void InsertDesign()
        {
            List<Designation> designations = new List<Designation>();
            designations.Add(new Designation() { Id = 1020, Name = "Project Trainee" });
            designations.Add(new Designation() { Id = 123, Name = "Member Technical Staff" });
            designations.Add(new Designation() { Id = 186, Name = "Project Lead" });
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
            try
            {
                conn.Open();
                Department appx = GetDepartmentObj(15);
                Department mail = GetDepartmentObj(16);
                Designation pt = GetDesignObj(1020);
                Designation mts = GetDesignObj(123);
                Designation lead = GetDesignObj(186);
                People Ram = new People() { Employee_id = "1344", Id = 123402, Firstname = "Ram", Lastname = "Sekar", CheckinStatus_Text = "Away", Mobile = 9832391383, Zoid = 149367, Organization_id = 1333, Email_id = "ramsekar.zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Ram Sekar", Checkin_status = true, DisplayName = "Ram", Name = "Ram Sekar", ImageUrl = "Assets/MaleUser.png", Country = "India", ReportingTo = null, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Away, Design = lead, Depart = mail };
                People Rahul = new People() { Employee_id = "1290", Id = 129434, Firstname = "Rahul", Lastname = "Takur", CheckinStatus_Text = "Away", Mobile = 9832391383, Zoid = 149367, Organization_id = 1333, Email_id = "rahultakur.zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Rahul Takur", Checkin_status = true, DisplayName = "Rahul", Name = "Rahul", ImageUrl = "Assets/MaleUser1.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Away, Design = lead, Depart = appx };
                People me = new People() { Employee_id = "PT2339", Id = 235667, Firstname = "Deepikha", Lastname = "Thanu", CheckinStatus_Text = "Office in", Mobile = 7839201283, Zoid = 1920403, Organization_id = 12933, Email_id = "deepikha.thanu@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Deepikha T", Checkin_status = true, DisplayName = "Deepi", Name = "Deepikha", ImageUrl = "Assets/WomenUser.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = pt, Depart = appx };
                People pratiksha = new People() { Employee_id = "PT4893", Id = 975483, Firstname = "Partiksha", Lastname = "Arun", CheckinStatus_Text = "Office in", Mobile = 94438294313, Zoid = 1223443, Organization_id = 24433, Email_id = "pratiksha.arun@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Pratiksha Arun", Checkin_status = true, DisplayName = "Prati", Name = "Pratiksha", ImageUrl = "Assets/WomenUser1.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = pt, Depart = appx };
                People srimathi = new People() { Employee_id = "2839", Id = 37989, Firstname = "Srimathi", Lastname = "Selvam", CheckinStatus_Text = "Office in", Mobile = 9372937429, Zoid = 1297853, Organization_id = 16729, Email_id = "srimathi.selvam@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Srimathi", Checkin_status = true, DisplayName = "Sri", Name = "Srimathi", ImageUrl = "Assets/WomenUser2.png", Country = "India", ReportingTo = Ram, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = mts, Depart = mail };
                People rajesh = new People() { Employee_id = "2390", Id = 159332, Firstname = "Rajesh", Lastname = "Kumar", CheckinStatus_Text = "Office in", Mobile = 9883749222, Zoid = 1454903, Organization_id = 12315, Email_id = "rajesh.kumar@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Rajesh Kumar", Checkin_status = true, DisplayName = "Rajesh", Name = "Rajesh", ImageUrl = "Assets/MaleUser2.png", Country = "India", ReportingTo = Rahul, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = mts, Depart = appx };
                People priya = new People() { Employee_id = "13567", Id = 28903, Firstname = "Priya", Lastname = "Dhasan", CheckinStatus_Text = "Away", Mobile = 94530235532, Zoid = 653232, Organization_id = 17890, Email_id = "priyadhasan@zohocorp.com", TimeOffset = DateTime.Now, Fullname = "Priya Dhasan", Checkin_status = true, DisplayName = "Priya Dhasan", Name = "Priya Dhasan", ImageUrl = "Assets/WomenUser3.png", Country = "India", ReportingTo = Rahul, Type = Emp_type.Paid, Lang = Language.English, Stat = Status.Officein, Design = mts, Depart = appx };
                InsertPeopleData(Ram);
                InsertPeopleData(Rahul);
                InsertPeopleData(me);
                InsertPeopleData(pratiksha);
                InsertPeopleData(srimathi);
                InsertPeopleData(rajesh);
                InsertPeopleData(priya);
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }
        public void InsertDepartmentData(Department depart)
        {
            try
            {
                conn.Open();
                SqliteCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = $"INSERT OR IGNORE INTO Department(Id,Name) VALUES('{ depart.Id}','{depart.Name}');";
                insertCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }
        public void InsertDesignData(Designation design)
        {
            try
            {
                conn.Open();
                SqliteCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = "INSERT OR IGNORE INTO Designation(Id,Name) VALUES(" + design.Id + ",'" + design.Name + "');";
                insertCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }
        public void InsertPeopleData(People people)
        {
            try { 
            if (people.ReportingTo == null)
            {
                people.ReportingTo = new People();
                people.ReportingTo.Id = 0;
                people.ReportingTo.Name = null;
            }
            conn.Open();
            SqliteCommand InsertCommand;
            string InsertQuery = "INSERT OR IGNORE INTO People(Id,Employee_Id,FirstName,LastName,ReportingToId,CheckinStatusText,Mobile,EmpType," +
                "Zoid,OrgId,EmailId,DateTimeOffset,Language,Status,DepartmentId,DesignationId,Fullname,CheckinStatus,ImageUrl,DisplayName," +
                "Name,Country) VALUES(" + people.Id + ",'" + people.Employee_id + "','" + people.Firstname + "','" + people.Lastname + "'," + people.ReportingTo.Id + ",'" + people.CheckinStatus_Text + "'," + people.Mobile + ",'" + people.Type.ToString() + "'," + people.Zoid + "," + people.Organization_id + ",'" + people.Email_id + "','" + people.TimeOffset.ToString() + "','" + people.Lang.ToString() + "','" + people.Stat.ToString() + "'," + people.Depart.Id + "," + people.Design.Id + ",'" + people.Fullname + "','" + people.Checkin_status.ToString() + "','" + people.ImageUrl + "','" + people.DisplayName + "','" + people.Name + "','" + people.Country + "');";
            InsertCommand = conn.CreateCommand();
            InsertCommand.CommandText = InsertQuery;
            InsertCommand.ExecuteNonQuery();
            conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
            }
        }
        public List<People> ReadData()
        {
            try
            {
                conn.Open();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = conn.CreateCommand();
                readCommand.CommandText = "SELECT * FROM People;";
                dataReader = readCommand.ExecuteReader();
                 List<People> toReturn = new List<People>();
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
                    }
                    );
                }
                conn.Close();
                return toReturn;
            }
            catch(Exception ex)
            {
                conn.Close();
                return null;
            }
        }

        public List<People> ReadDepartmentData(int departId)
        {
            try
            {
                conn.Open();
                SqliteDataReader dataReader;
                SqliteCommand readCommand = conn.CreateCommand();
                readCommand.CommandText = $"SELECT * FROM People WHERE DepartmentId ={departId}";
                dataReader = readCommand.ExecuteReader();
                List<People> toReturn = new List<People>();
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
                conn.Close();
                return toReturn;
            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
        }

        public People GetPeopleObj(int id)
        {
            try
            {
                if (id == 0)
                {
                    return null;
                }
                People toReturn = new People();
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
                return toReturn;
            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
        }
        public Department GetDepartmentObj(int id)
        {
            try
            {
                Department toReturn = new Department();
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
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
        }
        public Designation GetDesignObj(int id)
        {
            try
            {
                Designation toReturn = new Designation();
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
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
        }
    }
}
