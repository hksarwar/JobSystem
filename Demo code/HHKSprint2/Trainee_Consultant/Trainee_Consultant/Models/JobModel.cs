using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;



namespace Trainee_Consultant.Models
{
    public class JobModel
    {
        [Required]
        [Display(Name = "Job ID")]
        public int JobId { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public int userId { get; set; }

        [Required]
        [Display(Name = "Stream")]
        public string stream { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string status { get; set; }

        [Required]
        [Display(Name = "Discription")]
        public string discription { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Date Posted")]
        public DateTime datePosted { get; set; }

        [Required]
        [Display(Name = "Deadline")]
        public DateTime deadline { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string company { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string location { get; set; }

    }

    public class RecentJobsModel
    {
        [Required]
        [Display(Name = "Stream")]
        public string stream { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string status { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Date Posted")]
        public DateTime datePosted { get; set; }

        [Required]
        [Display(Name = "Deadline")]
        public DateTime deadline { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string company { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string location { get; set; }
    }
}