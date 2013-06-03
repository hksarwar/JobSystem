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
    public class DbRecommendation
    {
        private int _recId;
        private string _recommender;
        private string _recommended;
        private string _job;
        private int _jobID;
        private string _reason;

        [DataMember]
        public int RecID
        {
            get { return _recId; }
            set { _recId = value; }
        }

        [DataMember]
        public string  Recommender
        {
            get { return _recommender; }
            set { _recommender = value; }
        }

        [DataMember]
        public string Recommended
        {
            get { return _recommended; }
            set { _recommended = value; }
        }

        [DataMember]
        public string JobTitle
        {
            get { return _job; }
            set { _job = value; }
        }

        [DataMember]
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        [DataMember]
        public int JobID
        {
            get { return _jobID; }
            set { _jobID = value; }
        }
    }
}
