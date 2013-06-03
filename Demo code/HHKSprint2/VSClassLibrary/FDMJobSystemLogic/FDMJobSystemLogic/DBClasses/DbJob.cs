using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Net;
using System.Runtime.Serialization;

namespace FDMJobSystemLogic
{
    [DataContract]
    public class DbJob
    {
        private int _jobId;
        private int _userId;
        private string _stream;
        private string _status;
        private string _description;
        private string _title;
        private DateTime _datePosted;
        private DateTime _deadline;
        private string _company;
        private string _location;
        private List<string> _skills;

        [DataMember]
        public int JobId 
        {
            get { return _jobId;}
            set { _jobId = value;} 
        }

        [DataMember]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        [DataMember]
        public string Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        [DataMember]
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [DataMember]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        [DataMember]
        public DateTime DatePosted
        {
            get { return _datePosted; }
            set { _datePosted = value; }
        }

        [DataMember]
        public DateTime Deadline
        {
            get { return _deadline; }
            set { _deadline = value; }
        }

        [DataMember]
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        [DataMember]
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        [DataMember]
        public List<string> Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }
    }
}
