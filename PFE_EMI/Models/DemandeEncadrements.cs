using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_EMI.Models
{
   
    public class DemandeEncadrements
    {
        
        [Key]
        public int ID { get; set; }
        [ForeignKey("ID")]
        public int ID_Etudiant { get; set; }
        [ForeignKey("ID_prof")]
        public string ID_Prof { get; set; }
        public string liens_complementaires { get; set; }
        public string SujetPFE { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy\nHH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date d'envoie")]
        public DateTime date_depot { get; set; }
        /*
         * Les valeurs possibles sont:
         *  -2 : refusée
         *  -1 : annulé
         *   0 : en attente
         *   1 : accepté
         *
         */
        
        public int ETAT { get  ; set; }
        public Etudiant Etudiant { get; set; }
        public Professeur Professeur { get; set; }

        public string reformatState()
        {
            switch (ETAT)
            {
                case 0:
                    return "En Attente";
                case 1:
                    return "Accepté";
                case -1:
                    return "Annulée";
                case -2:
                    return "Rejeté";
                default:
                    return "";
            }
        }
    }
}