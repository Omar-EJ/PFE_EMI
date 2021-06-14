using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models.Display
{
    public class DemandeEtudiants
    {
        public int ID { get; set; }
        public int ID_Etudiant { get; set; }
        public string ID_Prof { get; set; }
        public string PFE { get; set; }
        public string liens { get; set; }
        public int etat { get; set; }


    }
}
