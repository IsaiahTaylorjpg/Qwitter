using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MockWebApp.Models
{
    public class StatusMod
    {
        public string UserId { get; set; }
        [Display(Name = "Write A Post")]
        [Required(ErrorMessage = "You must write something")]
        [StringLength(500)]
        public string Status { get; set; }

    }
}