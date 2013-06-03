using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic.Email
{
    public class ApplyForJob
    {
        public DbEmail Execute(Guid sessionID, string recipientEmail, DbJob job)
        {
            // Get userEmail
            string qry = "SELECT email FROM FDMUSER JOIN SESSIONS ON FDMUSER.user_id = SESSIONS.user_id WHERE session_guid = '" + sessionID.ToString() + "'";
            ReadOneCommand cmd = new ReadOneCommand();
            string userEmail = cmd.Execute(qry);

            DbEmail email = new DbEmail();
            email.Sender = userEmail;
            email.Recipient = recipientEmail;
            email.Subject = "Application for " + job.Title + " at " + job.Location;
            email.Body = "Hi ";

            return email;
        }
    }
}
