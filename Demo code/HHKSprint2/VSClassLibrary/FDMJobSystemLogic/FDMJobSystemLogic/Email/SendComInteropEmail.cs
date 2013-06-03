using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;     // to use Missing.Value 
using Microsoft.Office;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace FDMJobSystemLogic
{
    public class SendComInteropEmail : ISendEmail
    {
        public bool SendMail(DbEmail email)
        {
            Outlook.Attachment oAttach;
            try
            {
                // Create the Outlook application by using inline initialization. 
                Outlook.Application oApp = new Outlook.Application();

                //Create the new message by using the simplest approach. 
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                //Add a recipient
                Outlook.Recipient oRecip = (Outlook.Recipient)oMsg.Recipients.Add(email.Recipient);
                oRecip.Resolve();

                //Set the basic properties. 
                oMsg.Subject = email.Subject;
                oMsg.Body = email.Body;

                //Add an attachment

                //if (email.Attachments.Count > 0)
                //{
                //    for (int i = 0; i < email.Attachments.Count(); i++)
                //    {
                //        String sSource = email.Attachments[i];
                //        String sDisplayName = email.Subject;
                //        int iPosition = (int)oMsg.Body.Length + 1;
                //        int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                //        oAttach = oMsg.Attachments.Add(sSource, iAttachType, iPosition, sDisplayName);
                //    }
                //}


                // If you want to, display the message. 
                // oMsg.Display(true);  //modal 

                //Send the message. 
                oMsg.Save();
                //(oMsg as _Outlook.MailItem).Send();
                //Outlook.Account account = oApp.Session.Accounts[email.Sender];
                //oMsg.SendUsingAccount = account;
                ((Outlook._MailItem)oMsg).Send();


                //Explicitly release objects. 
                oRecip = null;
                oAttach = null; 
                oMsg = null;
                oApp = null;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Label1.Text = ex.Message + ex.StackTrace;
                return false;
            }

        }

    }
}
