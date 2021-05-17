using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_EMI.Models
{
    public class PFE
    {
        public int ID { get; set; }
        [ForeignKey("ID")]
        public int id_student { get; set; }
        public Etudiant Etudiant { get; set; }

        [ForeignKey("ID_prof")]
        public string id_prof { get; set; }
        public Professeur Professeur { get; set; }

        public string lien_PFE { get; set; }

    }
}