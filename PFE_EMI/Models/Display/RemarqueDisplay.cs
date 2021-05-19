using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models.Display
{
    public class RemarqueDisplay
    {
        public string prof { get; set; }
        public string titrePFE { get; set; }
        public ICollection<RemarqueProf> listeRemarques { get; set; }
    }
}
