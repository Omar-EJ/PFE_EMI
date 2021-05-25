
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_EMI.Models
{
    
    public class Professeur
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // email du prof (avant @) exemple
        // [ mkabbaj@emi.ac.ma => id = mkabbaj ]
        [Key]
        public string ID_prof { get; set; } 

        // nom du professeur
        public string Fname { get; set; }

        // prénom du professeur
        public string Lname { get; set; }
        /**
         * Disponible = 1       le professeur accepte les demandes de PFE
         * Disponible = 0       le professeure n'accepte plus les demandes de PFE
         */
        public int Disponible { get; set; }


        public ICollection<RemarqueProf> RemarquesProf { get; set; }
        public ICollection<DemandeEncadrements> DemandesEncadrements { get; set; }
        public ICollection<PFE> PFE { get; set; }
        public ICollection<ProfessorDepartment> ProfessorDepartments { get; set; }


    }
}