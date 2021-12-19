using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree
{
    public class Prix
    {
        public double Montant { get; set; }
        public int IdParticipants { get; set; }
        public int IdSoiree { get; set; }

        public Prix(int idSoiree, int idParticipants, double montant)
            => (IdSoiree, IdParticipants, Montant) = (idSoiree, idParticipants, montant);
    }
}
