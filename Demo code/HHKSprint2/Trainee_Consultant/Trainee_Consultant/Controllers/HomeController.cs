using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trainee_Consultant.Models;

using Trainee_Consultant.ServiceReference1;

namespace Trainee_Consultant.Controllers
{
    public class HomeController : Controller
    {
        IJSService service = new JSServiceClient();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(LogOnModel m)
        //public Guid Logon(LogOnModel m)
        {
            if (ModelState.IsValid)
            {
                //string s = m.Username.ToString();

                if ((m.Username.ToString() != null) && (m.Password.ToString() != null))
                {
                    Guid sessionId = service.Login2(m.Username.ToString(), m.Username.ToString(), "Trainer", "Consultant");

                    if (sessionId == Guid.Empty)
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        RedirectToAction("Favourites", "HomePage");
                    }
                    else
                    {
                        Session["sessionId"] = sessionId;
                        return RedirectToAction("Index", "HomePage");
                        //return sessionId;
                    }

                }

                //if (s.Equals("Katie"))
                //{
                //    return RedirectToAction("Index", "HomePage");
                //}
                //else 
                //{
                //    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                //}
            }
            return View(m);
            //return sessionId;
            //return Guid.Empty;
            
        }
    }
}
