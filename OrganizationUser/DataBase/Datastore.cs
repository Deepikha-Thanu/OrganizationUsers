using Microsoft.Data.Sqlite;
using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.DataBase
{
    class Datastore
    {
        SqliteConnection conn;
        string connectionString;
        public Datastore()
        {
            connectionString = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path , "EmployeeDatabase.db");
            conn = new SqliteConnection($"FileName={connectionString}");
            conn.Open();
        }
        public Boolean checkFileExists()
        {
            bool check= File.Exists(connectionString);
            //File.Create(connectionString);
            return check;
        }
        //public void createPeopleTable()
        //{
        //    SqliteCommand DepartCreateCmd;
        //    SqliteCommand DesignCreateCmd;
        //    SqliteCommand PeopleCreateCmd;
        //    DepartCreateCmd = conn.CreateCommand();
        //    string DepartCreateQuery = "CREATE TABLE Department(Id INTEGER PRIMARY KEY,Name TEXT);";
        //    DepartCreateCmd.CommandText = DepartCreateQuery;
        //    DepartCreateCmd.ExecuteNonQuery();
        //    DesignCreateCmd = conn.CreateCommand();
        //    string DesignCreateQuery = "CREATE TABLE Designation(Id INTEGER PRIMARY KEY,Name TEXT);";
        //    DesignCreateCmd.CommandText = DesignCreateQuery;
        //    DesignCreateCmd.ExecuteNonQuery();
        //    PeopleCreateCmd = conn.CreateCommand();
        //    string PeoplecreateQuery = "CREATE TABLE People(Id INTEGER PRIMARY KEY," +
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
        //public void insertDepartmentData(Department depart)
        //{
        //    SqliteCommand insertCommand= conn.CreateCommand();
        //    insertCommand.CommandText = "INSERT INTO Department(Id,Name) VALUES("+depart.Id+",'"+depart.Name+"');";
        //    insertCommand.ExecuteNonQuery();
        //}
        //public void insertDesignData(Designation design)
        //{
        //    SqliteCommand insertCommand = conn.CreateCommand();
        //    insertCommand.CommandText = "INSERT INTO Designation(Id,Name) VALUES(" + design.Id + ",'" + design.Name + "');";
        //    insertCommand.ExecuteNonQuery();
        //}
        //public void insertPeopleData(People people)
        //{
        //    SqliteCommand InsertCommand;
        //    string InsertQuery = "INSERT INTO People(Id,Employee_Id,FirstName,LastName,ReportingToId,CheckinStatusText,Mobile,EmpType," +
        //        "Zoid,OrgId,EmailId,DateTimeOffset,TimeZoneInfo,Language,Status,DepartmentId,DesignationId,Fullname,CheckinStatus,ImageUrl,DisplayName," +
        //        "Name,Country) VALUES(" + people.Id + "," + people.Employee_id +",'"+people.Firstname+"','"+people.Lastname+"',"+people.ReportingTo.Id+",'"+people.CheckinStatus_Text+"',"+people.Mobile+",'"+people.Type.ToString()+"',"+people.Zoid+","+people.Organization_id+",'"+people.Email_id+"','"+people.TimeOffset.ToString()+"','"+people.Lang.ToString()+"','"+people.Stat.ToString()+"',"+people.Depart.Id+","+people.Design.Id+",'"+people.Fullname+"','"+people.Checkin_status.ToString()+"','"+"','"+people.ImageUrl+"','"+people.DisplayName+"','"+people.Name+"','"+people.Country+"';";
        //    InsertCommand = conn.CreateCommand();
        //    InsertCommand.CommandText = InsertQuery;
        //    InsertCommand.ExecuteNonQuery();
        //}
        public List<People> ReadData()
        {
            List<People> toReturn=new List<People>();
            SqliteDataReader dataReader;
            SqliteCommand readCommand=conn.CreateCommand();
            readCommand.CommandText = "SELECT * FROM People;";
            dataReader = readCommand.ExecuteReader();
            for(int i=0; dataReader.Read();i++)
            {
                toReturn.Add(new People() { 
                    Id=dataReader.GetInt32(0),
                    Employee_id=dataReader.GetString(1), 
                    Firstname = dataReader.GetString(2), 
                    Lastname = dataReader.GetString(3), 
                    ReportingTo =dataReader.IsDBNull(4)? null : getPeopleObj(dataReader.GetString(4)), 
                    CheckinStatus_Text = dataReader.GetString(5), 
                    Mobile = dataReader.GetInt64(6), 
                    Type = (Emp_type)Enum.Parse(typeof(Emp_type),dataReader.GetString(7)),
                    Zoid = dataReader.GetInt64(8), 
                    Organization_id = dataReader.GetInt32(9), 
                    Email_id = dataReader.GetString(10), 
                    TimeOffset = DateTimeOffset.Parse(dataReader.GetString(11)),
                    Lang = (Language)Enum.Parse(typeof(Language), dataReader.GetString(12)),
                    Stat = (Status)Enum.Parse(typeof(Status), dataReader.GetString(13)),
                    Depart = getDepartmentObj(dataReader.GetInt32(14)),
                    Design = getDesignObj(dataReader.GetInt32(15)),
                    Fullname = dataReader.GetString(16),
                    Checkin_status = Convert.ToBoolean(dataReader.GetString(17)),
                    ImageUrl = dataReader.GetString(18),
                    DisplayName = dataReader.GetString(19),
                    Name = dataReader.GetString(20),
                    Country = dataReader.GetString(21)
                });
            }

            return toReturn;
        }
        public People getPeopleObj(string empid)
        {
            if(empid==null)
                return null;
            People toReturn = new People();
            SqliteDataReader dataReader;
            SqliteCommand readCommand = conn.CreateCommand();
            readCommand.CommandText = "SELECT * FROM People WHERE Employee_Id='"+empid+"';";
            dataReader = readCommand.ExecuteReader();
            if(dataReader.Read())
            {
                toReturn = new People() {
                    Id = dataReader.GetInt32(0),
                    Employee_id = dataReader.GetString(1),
                    Firstname = dataReader.GetString(2),
                    Lastname = dataReader.GetString(3),
                    ReportingTo = dataReader.IsDBNull(4) ? null: getPeopleObj(dataReader.GetString(4)),
                    CheckinStatus_Text = dataReader.GetString(5),
                    Mobile = dataReader.GetInt64(6),
                    Type = (Emp_type)Enum.Parse(typeof(Emp_type),dataReader.GetString(7)),
                    Zoid = dataReader.GetInt64(8),
                    Organization_id = dataReader.GetInt32(9),
                    Email_id = dataReader.GetString(10),
                    TimeOffset = DateTimeOffset.Parse(dataReader.GetString(11)),
                    Lang = (Language)Enum.Parse(typeof(Language), dataReader.GetString(12)),
                    Stat = (Status)Enum.Parse(typeof(Status), dataReader.GetString(13)),
                    Depart = getDepartmentObj(dataReader.GetInt32(14)),
                    Design = getDesignObj(dataReader.GetInt32(15)),
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
        public Department getDepartmentObj(int id)
        {
            Department toReturn = new Department();
            SqliteDataReader dataReader;
            SqliteCommand readCommand = conn.CreateCommand();
            readCommand.CommandText = "SELECT * FROM Department WHERE Id=" + id.ToString()+";";
            dataReader = readCommand.ExecuteReader();
            if(dataReader.Read())
            { 
                toReturn.Id = dataReader.GetInt32(0);
                toReturn.Name = dataReader.GetString(1);
            }
            return toReturn;
        }
        public Designation getDesignObj(int id)
        {
            Designation toReturn=new Designation();
            SqliteDataReader dataReader;
            SqliteCommand readCommand = conn.CreateCommand();
            readCommand.CommandText = "SELECT * FROM Designation WHERE Id=" + id.ToString()+";";
            dataReader = readCommand.ExecuteReader();
            if(dataReader.Read())
            { 
                toReturn.Id= dataReader.GetInt32(0);
                toReturn.Name= dataReader.GetString(1);
            }
            return toReturn;
        }
        public void CloseConnecton()
        {
            conn.Close();
        }
    }
}
