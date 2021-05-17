using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_EMI.Models
{
    public class RemarqueProf
    {

        [Key]
        public int id_remarque { get; set; }
        [ForeignKey("ID_prof")]
        public int id_prof { get; set; }
        [ForeignKey("ID")]
        public int id_student { get; set; }
        public string remarque { get; set; }
        public string liens_complementaires { get; set; }

        public Professeur Professeur { get; set; }
        public Etudiant Etudiant { get; set; }

    }
}