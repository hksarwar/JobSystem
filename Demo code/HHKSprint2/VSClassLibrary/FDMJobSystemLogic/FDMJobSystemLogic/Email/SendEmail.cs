using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;

namespace FDMJobSystemLogic
{
    public class SendEmail //: ISendEmail
    {
        // Uses SMTP directly
        public bool Execute(Guid sessionID, string subject, string body, string recipientEmail, List<string> cc, string file)
        {
            // Sender
            // Get userEmail
            string qry = "SELECT email FROM FDMUSER JOIN SESSIONS ON FDMUSER.user_id = SESSIONS.user_id WHERE session_guid = '" + sessionID.ToString() + "'";
            ReadOneCommand cmd = new ReadOneCommand();
            string userEmail = cmd.Execute(qry);

            // Create message
            MailMessage message = new MailMessage();
            message.From = new MailAddress(userEmail);

            // Recipient
            message.To.Add(new MailAddress(recipientEmail));

            // CC
            if (cc.Count() > 0)
            {
                for (int i = 0; i < cc.Count(); i++)
                {
                    message.CC.Add(new MailAddress(cc[i]));
                }
            }

            // Subject
            message.Subject = subject;

            // Attachment
            if (file != "")
            {
                Attachment attachment = new Attachment(file, "my attachment");
                message.Attachments.Add(attachment);
            }

            // Body
            message.Body = body;

            try
            {
                SmtpClient client = new SmtpClient("localhost");
                client.SendAsync(message, message);
                //client.Send(message);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
