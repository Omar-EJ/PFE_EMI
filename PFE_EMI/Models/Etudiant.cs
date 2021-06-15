using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models
{
    public class Etudiant
    {


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // Matricule de l'étudiant
        public int ID { get; set; }

        // nom de l'étudaint
        public string Fname { get; set; }
        
        // prénom de l'étudiant
        public string Lname { get; set; }

        // email de l'étudiant
        public string Email { get; set; }

        // génie (département)
        [ForeignKey("code_ID")]
        public string Branch { get; set; }

        // spécialité
        [ForeignKey("ID_specialty")]
        public string Specialty { get; set; }

        public ICollection<DemandeEncadrements> DemandesEncadrement { get; set; }
        public ICollection<RemarqueProf> RemarquesProf { get; set; }

        internal Etudiant FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public PFE PFE { get; set; }
        public Departement Departement { get; set; }
        public Specialty SPES { get; set; }

    }
}
