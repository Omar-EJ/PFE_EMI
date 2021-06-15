using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models.Display
{


    public class RemarqueDisplayProf
    {
        public int id_Etudiant { get; set; }
        public string etudiant { get; set; }
        public string titrePFE { get; set; }
        public string lienPFE { get; set; }
        public string remarque { get; set; }
        public ICollection<RemarqueProf> listeRemarques { get; set; }
    }
}
