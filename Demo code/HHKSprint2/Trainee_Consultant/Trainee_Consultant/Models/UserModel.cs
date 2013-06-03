using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Trainee_Consultant.Models
{
    public class UserModel
    {

        [Required]
        [Display(Name = "User ID")]
        public int userId { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Type Id")]
        public int typeId { get; set; }

        [Required]
        [Display(Name = "Trainee Status")]
        public string tStatus { get; set; }

        [Required]
        [Display(Name = "Degree")]
        public string degree { get; set; }

        [Required]
        [Display(Name = "Modules")]
        public string modules { get; set; }

        [Required]
        [Display(Name = "Stream")]
        public string stream { get; set; }
    }


}