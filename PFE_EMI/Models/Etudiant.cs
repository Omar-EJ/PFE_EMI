﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models
{
    public class Etudiant
    {
       

        // Matricule de l'étudiant
        public int ID { get; set; }

        // nom de l'étudaint
        public string Fname { get; set; }
        
        // prénom de l'étudiant
        public string Lname { get; set; }

        // email de l'étudiant
        public string Email { get; set; }

        // génie (département)
        public string Branch { get; set; }

        // spécialité
        public string ID_specialty { get; set; }

        public ICollection<DemandeEncadrements> DemandesEncadrement { get; set; }
        public ICollection<RemarqueProf> RemarquesProf { get; set; }
        public ICollection<PFE> PFE { get; set; }


        public Departement Departement { get; set; }

        public Specialty Specialty { get; set; }

    }
}