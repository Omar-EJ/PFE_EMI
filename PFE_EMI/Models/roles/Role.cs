using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models.roles
{
    public class Role
    {
        public int ID { get; set; }
        [Required]
        public string roleName { get; set; }
    }
}
