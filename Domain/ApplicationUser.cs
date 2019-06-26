using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "Tech")]
        public string Tech { get; set; }

        [Display(Name = "Advisor")]
        public string Advisor { get; set; }

        [Display(Name = "Parts")]
        public string Parts { get; set; }

        [Display(Name = "Manager")]
        public string Manager { get; set; }

        [Display(Name = "Customer")]
        public string Customer { get; set; }

        [NotMapped]
        public bool isSuperAdmin { get; set; }

    }
}
