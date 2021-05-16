using System.ComponentModel.DataAnnotations;

namespace PFE_EMI.Models
{
    public class RemarqueProf
    {

        [Key]
        public int id_remarque { get; set; }
        public int id_prof { get; set; }
        public int id_student { get; set; }
        public string remarque { get; set; }
        public string liens_complementaires { get; set; }

        public Professeur Professeur { get; set; }
        public Etudiant Etudiant { get; set; }

    }
}