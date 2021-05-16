using System.Collections;
using System.Collections.Generic;

namespace PFE_EMI.Models
{
    public class Departement
    {
        public string code { get; set; }
        public string nom { get; set; }

        // id du chef de département
        public string ID { get; set; }

        public ICollection<Etudiant> Etudiants { get; set; }
        public ICollection<Specialty> Specialty { get; set; }

    }
}