using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace authenticate.cdsonline.co.za.Entities
{
    public class ClientUsers
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string ClientId { get; set; }
        [Required]
        [MaxLength(128)]
        public string UserId { get; set; }
    }
}