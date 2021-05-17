using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Models
{
    public class Reformatter
    {
        public static string reformatState(int state)
        {
            switch (state)
            {
                case 0:
                    return "En Attente";
                case 1:
                    return "Accepté";
                case -1:
                    return "Annulée";
                case -2:
                    return "Rejeté";
                default:
                    return "";
            }
        }
    }
}
