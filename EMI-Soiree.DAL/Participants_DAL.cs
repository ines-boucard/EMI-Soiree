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

        public Participants_DAL(int id, String nom, String prenom, int idSoiree)
            => (ID, Nom, Prenom, IdSoiree) = (id, nom, prenom, idSoiree);
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

                    commande.CommandText = "insert into participants (nom, prenom, idSoiree) values (@nom, @prenom, @idSoiree); select scope_identity()";
                    commande.Parameters.Add(new SqlParameter("@nom", Nom));
                    commande.Parameters.Add(new SqlParameter("@prenom", Prenom));
                    commande.Parameters.Add(new SqlParameter("@idFournisseurs", IdSoiree));
                    ID = (int)commande.ExecuteScalar();


                }


                //fermer la connexion
                connexion.Close();
            }

        }
    }
}

