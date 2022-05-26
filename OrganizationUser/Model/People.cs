using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace OrganizationUser.Model
{
    enum Emp_type
    {
        Paid, Unpaid, Contract
    }

    enum Language
    {
        English, French
    }

    enum Status
    {
        Away,
        Officein,
        Out
    }
    
    public class People
    {
        long _Id;
        string _Employee_id;
        string _Firstname;
        string _Lastname;
        People _ReportingTo;
        string _CheckinStatus_Text;
        long _Mobile;
        Emp_type _Type;
        long _Zoid;
        long _Organization_id;
        string _Email_id;
        DateTimeOffset _TimeOffset;
        Language _Lang;
        Status _Stat;
        Department _Depart;
        Designation _Design;
        string _Fullname;
        bool _Checkin_status;
        string _ImageUrl;
        string _DisplayName;
        string _Name;
        string _Country;
       // Windows.UI.Xaml.Media.Brush _DisplayColor;
        public string Employee_id { get => _Employee_id; set => _Employee_id = value; }
        public string Firstname { get => _Firstname; set => _Firstname = value; }
        public string Lastname { get => _Lastname; set => _Lastname = value; }
        public string CheckinStatus_Text { get => _CheckinStatus_Text; set => _CheckinStatus_Text = value; }
        public long Mobile { get => _Mobile; set => _Mobile = value; }
        public long Zoid { get => _Zoid; set => _Zoid = value; }
        public long Organization_id { get => _Organization_id; set => _Organization_id = value; }
        public string Email_id { get => _Email_id; set => _Email_id = value; }
        public long Id { get => _Id; set => _Id = value; }
        public DateTimeOffset TimeOffset { get => _TimeOffset; set => _TimeOffset = value; }
        public string Fullname { get => _Fullname; set => _Fullname = value; }
        public bool Checkin_status { get => _Checkin_status; set => _Checkin_status = value; }
        public string DisplayName { get => _DisplayName; set => _DisplayName = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string ImageUrl { get => _ImageUrl; set => _ImageUrl = value; }
        public string Country { get => _Country; set => _Country = value; }
        internal People ReportingTo { get => _ReportingTo; set => _ReportingTo = value; }
        internal Emp_type Type { get => _Type; set => _Type = value; }
        internal Language Lang { get => _Lang; set => _Lang = value; }
        internal Status Stat { get => _Stat; set => _Stat = value; }
        internal Department Depart { get => _Depart; set => _Depart = value; }
        internal Designation Design { get => _Design; set => _Design = value; }


    }
}
