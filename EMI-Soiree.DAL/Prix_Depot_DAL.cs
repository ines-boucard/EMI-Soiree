using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree.DAL
{
    public abstract class Prix_Depot_DAL : Depot_DAL<Prix_DAL>
    {
        public Prix_Depot_DAL()
           : base()
        {

        }
        public override List<Prix_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idSoiree, idParticipants, montant from prix";
            //pour lire les lignes une par une
            var reader = commande.ExecuteReader();

            var listeDePrix = new List<Prix_DAL>();

            while (reader.Read())
            {
                //dans reader.GetInt32 on met la colonne que l'on souhaite récupérer ici 0 = ID, 1 = Societe...
                var prix = new Prix_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(3));

                listeDePrix.Add(prix);
            }

            DetruireConnexionEtCommande();

            return listeDePrix;
        }
        public override Prix_DAL Insert(Prix_DAL participants)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into prix (idSoiree, idParticipants, montant)"
                                    + " values (@idSoiree, @idParticipants, @montant)";
            commande.Parameters.Add(new SqlParameter("@idParticipants", participants.IdParticipants));
            commande.Parameters.Add(new SqlParameter("@idSoiree", participants.IdSoiree));
            commande.Parameters.Add(new SqlParameter("@montant", participants.Montant));


            DetruireConnexionEtCommande();

            return participants;
        }

        // pas de méthode update 
    }
}
