using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Net;
using System.Runtime.Serialization;

namespace FDMJobSystemLogic
{
    public class User
    {
        private int _userId;
        private string _username;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _loc;
        private int _typeId;


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
    }
}
