using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EMI_Soiree.DAL
{
    public class Participants_DAL
    {
        public int ID { get; set; }
        public List<Participants_DAL> Participants { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int IdSoiree { get; set; }

        public Participants_DAL(String nom, String prenom, int idSoiree)
            => (Nom, Prenom, IdSoiree) = (nom, prenom, idSoiree);
        public Participants_DAL(int id, String nom, String prenom, int idSoiree)
            => (ID, Nom, Prenom, IdSoiree) = (id, nom, prenom, idSoiree);
        
    }
}

