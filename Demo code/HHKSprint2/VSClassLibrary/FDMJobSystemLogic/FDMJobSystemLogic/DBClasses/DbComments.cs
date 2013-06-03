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
    public class DbComments
    {
        private int _commentId;
        private int _jobId;
        private string _username;
        private string _text;
        private DateTime _dateAdded;

        [DataMember]
        public int CommentId
        {
            get { return _commentId; }
            set { _commentId = value; }
        }

        [DataMember]
        public int JobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }

        [DataMember]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        [DataMember]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        [DataMember]
        public DateTime DateAdded
        {
            get { return _dateAdded; }
            set { _dateAdded = value; }
        }
    }
}
