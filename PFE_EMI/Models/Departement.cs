using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_EMI.Models
{
    public class Departement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string code_ID { get; set; }
        public string nom { get; set; }

        // id du chef de département
        public string ID_chef { get; set; }

        public ICollection<Etudiant> Etudiants { get; set; }
        public ICollection<Specialty> Specialty { get; set; }

    }
}