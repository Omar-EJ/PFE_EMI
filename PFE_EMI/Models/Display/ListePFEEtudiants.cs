using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models
{
    public class ListePFEEtudiants
    {
        public int IdEtudiant { get; set; }
        public string nameEtudiant { get; set; }
        public string nomPFE { get; set; }
        public int taches { get; set; }
        public int tacheFaites { get; set; }
        public DateTime dateDernireTache { get; set; }

    }
}
