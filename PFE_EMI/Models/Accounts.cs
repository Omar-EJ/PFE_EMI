using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models
{
    public enum TypeAccount
    {
        STUDENT, PROFESSOR
    }
    public class Accounts
    {
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        public string login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public TypeAccount type { get; set; }
       
    }
}
