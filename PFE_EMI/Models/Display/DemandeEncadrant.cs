using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models.Display
{

    


    public class DemandeEncadrant
    {
        public int ID { get; set; }
        public int ID_Etudiant { get; set; }
        public string ID_Prof { get; set; }
        public List<Prof> nomProfs { get; set; }
        public string liens_complementaires { get; set; } = "";
        public string SujetPFE { get; set; } = "";
        public String professeurChoisis { get; set; }
    }
}
