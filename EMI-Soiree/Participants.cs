using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree
{
    public class Participants
    {
        public int ID { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int IdSoiree { get; set; }

        public Participants(String nom, String prenom, int idSoiree)
            => (Nom, Prenom, IdSoiree) = (nom, prenom, idSoiree);
        public Participants(int id, String nom, String prenom, int idSoiree)
            => (ID, Nom, Prenom, IdSoiree) = (id, nom, prenom, idSoiree);
    }
}
