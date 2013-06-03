using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trainee_Consultant.Models;

using Trainee_Consultant.ServiceReference1;

namespace Trainee_Consultant.Controllers
{
    public class RecentJobsController : Controller
    {

        private IJSService service = new JSServiceClient();
        //
        // GET: /RecentJobs/

        public ActionResult Index()
        {
            List<RecentJobsModel> recentJobsM = new List<RecentJobsModel>();
            List<Trainee_Consultant.ServiceReference1.DbJob> recentjobs = new List<DbJob>();
            recentjobs = service.RecentJobs().ToList();

            for (int i = 0; i < recentjobs.Count; i++)
            {
                for (int j = 0; j < recentjobs.Count; j++)
                {
                    recentJobsM[i].stream = recentjobs[j].Stream;
                    recentJobsM[i].status = recentjobs[j].Status;
                    recentJobsM[i].title = recentjobs[j].Title;
                    recentJobsM[i].datePosted = recentjobs[j].DatePosted;
                    recentJobsM[i].deadline = recentjobs[j].Deadline;
                    recentJobsM[i].location = recentjobs[j].Location;
                    recentJobsM[i].company = recentjobs[j].Company;
                }
            }
            return View(recentJobsM);

        }

    }
}
