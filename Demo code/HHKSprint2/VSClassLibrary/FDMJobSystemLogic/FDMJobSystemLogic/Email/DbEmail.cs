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
    public class DbEmail
    {
        private string _sender;
        private string _recipient;
        private string _subject;
        private string _body;
        private List<string> _cc;
        private List<string> _attachments;
           
        [DataMember]
        public string Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }

        [DataMember]
        public string Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }

        [DataMember]
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        [DataMember]
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        [DataMember]
        public List<string> CC
        {
            get { return _cc; }
            set { _cc = value; }
        }

        [DataMember]
        public List<string> Attachments
        {
            get { return _attachments; }
            set { _attachments = value; }
        }
    }
}
