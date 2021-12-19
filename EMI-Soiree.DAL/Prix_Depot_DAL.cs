using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree.DAL
{
    public class Prix_Depot_DAL : Depot_DAL<Prix_DAL>
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
                var prix = new Prix_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));

                listeDePrix.Add(prix);
            }

            DetruireConnexionEtCommande();

            return listeDePrix;
        }
        public override Prix_DAL Insert(Prix_DAL prix)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into prix (idSoiree, idParticipants, montant)"
                                    + " values (@idSoiree, @idParticipants, @montant)";
            commande.Parameters.Add(new SqlParameter("@idParticipants", prix.IdParticipants));
            commande.Parameters.Add(new SqlParameter("@idSoiree", prix.IdSoiree));
            commande.Parameters.Add(new SqlParameter("@montant", prix.Montant));

            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();

            return prix;
        }
        public List<Prix_DAL> GetByIdSoiree(int idSoiree)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idSoiree, idParticipants, montant from prix where idSoiree=@idSoiree ";
            commande.Parameters.Add(new SqlParameter("@idSoiree", idSoiree));
            var reader = commande.ExecuteReader();

            var listeDePrix = new List<Prix_DAL>();


            while (reader.Read())
            {
                //dans reader.GetInt32 on met la colonne que l'on souhaite récupérer ici 0 = ID, 1 = Societe...
                var p = new Prix_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));

                listeDePrix.Add(p);
            }
       
            /*if (reader.Read() == false)
            {
                throw new Exception($"Pas prix dans la BDD avec l'ID soiree  {idSoiree}");

            }*/
          

            return listeDePrix; 
            
        }
        public List<Prix_DAL> GetByIdParticipants(int idParticipants)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idSoiree, idParticipants, montant from prix where idParticipants=@idParticipants ";
            commande.Parameters.Add(new SqlParameter("@idParticipants", idParticipants));
            var reader = commande.ExecuteReader();

            var listeDePrix = new List<Prix_DAL>();

            
            while(reader.Read())
            {
                //dans reader.GetInt32 on met la colonne que l'on souhaite récupérer ici 0 = ID, 1 = Societe...
                var p = new Prix_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));

                listeDePrix.Add(p);
            }
            /*
            else
                throw new Exception($"Pas prix dans la BDD avec l'ID participant  {idParticipants}");

            DetruireConnexionEtCommande();*/

            return listeDePrix;
        }
        // pas de méthode update 
        public override void Delete(Prix_DAL item)
        {
            throw new NotImplementedException();
        }

        public override Prix_DAL GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public override Prix_DAL Update(Prix_DAL prix)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update prix set montant=@montant where idParticipants=@idParticipants and idSoiree=@idSoiree";
            commande.Parameters.Add(new SqlParameter("@idParticipants", prix.IdParticipants));
            commande.Parameters.Add(new SqlParameter("@idSoiree", prix.IdSoiree));
            commande.Parameters.Add(new SqlParameter("@montant", prix.Montant));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour le prix correspondant a la soire {prix.IdSoiree} et au participant {prix.IdParticipants} ");
            }

            prix.Montant = GetByID(prix.IdParticipants).Montant;

            DetruireConnexionEtCommande();

            return prix;
        }
    }

}
