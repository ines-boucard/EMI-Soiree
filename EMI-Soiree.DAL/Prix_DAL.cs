using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree.DAL
{
    public class Prix_DAL
    {
        public int Montant { get; set; }
        public int IdParticipants { get; set; }
        public int IdSoiree { get; set; }

        public Prix_DAL(int idSoiree, int idParticipants, int montant)
            => (IdSoiree, IdParticipants, Montant) = (idSoiree, idParticipants, montant);

    }
}
