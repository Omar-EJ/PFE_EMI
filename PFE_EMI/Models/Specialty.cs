using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_EMI.Models
{
    public class Specialty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public string ID_specialty { get; set; }
        public string name { get; set; }
        public string code_dept { get; set; }

        public Departement Departement { get; set; }

    }
}