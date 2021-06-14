using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models.Display
{
    public class DemandePourProfesseur
    {
        public int ID_ETUDIANT { get; set; }
        public string nomEtudiant { get; set; }
        public string sujet { get; set; }
        public string liens { get; set; }
        public int ETAT { get; set; }
        public string branche { get; set; }
        public string specialty { get; set; }

        public DateTime date_depot { get; set; }

    }
}
