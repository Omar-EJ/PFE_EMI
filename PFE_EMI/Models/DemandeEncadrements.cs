using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_EMI.Models
{
    public class DemandeEncadrements
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ID { get; set; }
        [ForeignKey("ID")]
        public int ID_Etudiant { get; set; }
        [ForeignKey("ID_prof")]
        public int ID_Prof { get; set; }
        public string liens_complémentaires { get; set; }
        public Etudiant Etudiant { get; set; }
        public Professeur Professeur { get; set; }

    }
}