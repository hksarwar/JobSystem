using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Trainee_Consultant.ServiceReference1;

namespace Trainee_Consultant.Models
{
    public class LoginRepository
    {
        IJSService service = new JSServiceClient();

        public Guid VerifyDetails(string username, string password)
        {
            Guid sessionid = service.Login2(username, password, "Trainer", "Consultant");
            return sessionid;
        }
    }
}