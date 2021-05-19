using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_EMI.Models
{
    public class RemarqueProf
    {
        [Key]
        public int id_remarque { get; set; }
        [ForeignKey("ID_prof")]
        public string id_prof { get; set; }
        [ForeignKey("ID")]
        public int id_student { get; set; }
        public string remarque { get; set; }
        public string liens_complementaires { get; set; }
        public Boolean seen { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy\nHH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime date_remarque { get; set; }
        public Professeur Professeur { get; set; }
        public Etudiant Etudiant { get; set; }

    }
}