using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CDS.C2A.Auth.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(200)]
        [Display(Name = "Connection String")]
        public string ConnectionString { get; set; }

        [MaxLength(50)] 
        [Display(Name = "Company Name")]
        public string Company { get; set; }

        [MaxLength(50)] 
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
    }
}