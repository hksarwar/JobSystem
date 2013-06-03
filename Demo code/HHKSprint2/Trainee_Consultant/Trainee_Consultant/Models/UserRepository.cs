using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Trainee_Consultant.ServiceReference1;

namespace Trainee_Consultant
{
    public class UserRepository
    {
        IJSService service = new JSServiceClient();
        Guid sessionId;

        public UserRepository(Guid sessionId)
        {
            this.sessionId = sessionId;
        }

        public DbUser ShowProfile(Guid sessionid)
        {
            return service.DisplayProfile(this.sessionId);
        }
    }
}