using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PFE_EMI.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Fname { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Lname { get; set; }

        [PersonalData]
        public string Genie { get; set; }

    }
}
