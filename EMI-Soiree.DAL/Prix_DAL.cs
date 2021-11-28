using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree.DAL
{
    class Prix_DAL
    {
        public int Montant { get; set; }
        public int IdParticipants { get; set; }
        public int IdSoiree { get; set; }

        public Prix_DAL(int idSoiree, int idParticipants, int montant)
            => (IdSoiree, IdParticipants, Montant) = (idSoiree, idParticipants, montant);

        public void Insert()
        {
            var chaineConnexion = "Data Source=localhost;Initial Catalog=EMI-Soiree;Integrated Security=True";

            //Créer une connexion
            using (var connexion = new SqlConnection(chaineConnexion))
            {
                //ouvrir la connexion
                connexion.Open();

                //créer une commande pour l'instruction SQL à executer
                using (var commande = new SqlCommand())
                {
                    //définir la connexion à utiliser
                    commande.Connection = connexion;

                    //définir l'instruction SQL
                    //avec des paramètres si besoin
                    //SELECT SCOPE_IDENTITY() va renvoyer l'ID créé

                    commande.CommandText = "insert into prix (idSoiree, idParticipants, montant) values (@idSoiree, @idParticipants, @montant)";
                    commande.Parameters.Add(new SqlParameter("@idSoiree", IdSoiree));
                    commande.Parameters.Add(new SqlParameter("@idParticipants", IdParticipants));
                    commande.Parameters.Add(new SqlParameter("@montant", Montant));

                }
                //fermer la connexion
                connexion.Close();
            }
        }
    }
}
