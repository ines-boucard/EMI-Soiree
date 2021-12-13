using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree.DAL
{
    public class Participants_Depot_DAL : Depot_DAL<Participants_DAL>
    {
        public Participants_Depot_DAL()
            : base()
        {

        }
        public override List<Participants_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, prenom, idSoiree from participants";
            //pour lire les lignes une par une
            var reader = commande.ExecuteReader();

            var listeDeParticipants = new List<Participants_DAL>();

            while (reader.Read())
            {
                //dans reader.GetInt32 on met la colonne que l'on souhaite récupérer ici 0 = ID, 1 = Societe...
                var participants = new Participants_DAL(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(1));

                listeDeParticipants.Add(participants);
            }

            DetruireConnexionEtCommande();

            return listeDeParticipants;
        }
        public override Participants_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande(); 

            commande.CommandText = "select id, nom, CiviliteContact, prenom, idSoiree from participants";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            var listeDeFournisseurs = new List<Participants_DAL>();

            Participants_DAL participants;
            if (reader.Read())
            {
                participants = new Participants_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetInt32(2));
            }
            else
                throw new Exception($"Pas de participant dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return participants;
            }
        public override Participants_DAL Insert(Participants_DAL participants)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into participants (nom, prenom, idSoiree)"
                                    + " values (@nom, @prenom, @idSoiree); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@nom", participants.Nom));
            commande.Parameters.Add(new SqlParameter("@prenom", participants.Prenom));
            commande.Parameters.Add(new SqlParameter("@idSoiree", participants.IdSoiree));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            participants.ID = ID;

            DetruireConnexionEtCommande();

            return participants;
        }
        public override Participants_DAL Update(Participants_DAL participants)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update participants set id = @id, nom = @nom, prenom = @prenom, idSoiree = @idSoiree )"
                                    + " where idFournisseurs=@idFournisseurs";
            commande.Parameters.Add(new SqlParameter("@id", participants.ID));
            commande.Parameters.Add(new SqlParameter("@nom", participants.Nom));
            commande.Parameters.Add(new SqlParameter("@prenom", participants.Prenom));
            commande.Parameters.Add(new SqlParameter("@idSoiree", participants.IdSoiree));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le participants avec l'ID  {participants.ID}");
            }

            DetruireConnexionEtCommande();

            return participants;
        }
        public override void Delete(Participants_DAL participants)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from participants where id = @id";
            commande.Parameters.Add(new SqlParameter("@id", participants.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le participants avec l'ID {participants.ID}");
            }

            DetruireConnexionEtCommande();
        }



    }
}
