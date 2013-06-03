using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trainee_Consultant.Models;

using Trainee_Consultant.ServiceReference1;

namespace Trainee_Consultant.Controllers
{
    public class HomePageController : Controller
    {
        Guid sessionId;
        UserRepository user;

        public ActionResult Index(Guid sessionId)
        {
            //HomeController home = new HomeController();
            //home.Logon(LogonModel m)
            //user = new UserRepository(sessionId);
            //ViewBag.Message = "Welcome to the FDM Job Posting System";
                      
            return View();
        }

        public ActionResult Account_Managers()
        {
            return View();
        }

        public ActionResult Favourites()
        {
            return View();
        }

        public string Profile()
        {
            DbUser currentUser = user.ShowProfile(sessionId);
            return HttpUtility.HtmlEncode(currentUser.FirstName);
        }

        public ActionResult Recent_Jobs()
        {
            return View();
        }

        public ActionResult Search_Jobs()
        {
            return View();
        }
        
        public ActionResult Logoff()
        {
            
            return View();
        }
    }
}
