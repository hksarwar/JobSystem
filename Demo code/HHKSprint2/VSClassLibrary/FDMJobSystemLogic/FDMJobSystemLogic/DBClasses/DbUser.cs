using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace FDMJobSystemLogic
{
    [DataContract]
    public class DbUser
    {
        private int _userId;
        private string _username;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _loc;
        private int _typeId;
        private string _tStatus;
        private string _degree;
        private string _modules;
        private string _stream;
        private List<string> _skills;
        private string _name;

        [DataMember]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        [DataMember]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [DataMember]
        public string Location
        {
            get { return _loc; }
            set { _loc = value; }
        }

        [DataMember]
        public int TypeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }

        [DataMember]
        public string TStatus
        {
            get { return _tStatus; }
            set { _tStatus = value; }
        }

        [DataMember]
        public string Degree
        {
            get { return _degree; }
            set { _degree = value; }
        }

        [DataMember]
        public string Modules
        {
            get { return _modules; }
            set { _modules = value; }
        }

        [DataMember]
        public string Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        [DataMember]
        public List<string> Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
