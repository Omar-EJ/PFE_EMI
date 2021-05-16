using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_EMI.Models
{
    public class ProfessorDepartment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string ID_prof { get; set; }
        public string ID_departement { get; set; }

        public Departement Departement { get; set; }
        public Professeur Professeur { get; set; }

    }
}