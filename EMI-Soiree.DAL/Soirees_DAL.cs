using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree.DAL
{
    public class Soirees_DAL
    {
        public int ID { get; set; }
        public List<Soirees_DAL> Soirees { get; set; }
        public String Lieu { get; set; }
        public DateTime? Date { get; set; }
        public Soirees_DAL( String lieu)
            => (Lieu) = (lieu);
        public Soirees_DAL(int id, String lieu, DateTime? date)
            => (ID, Lieu, Date) = (id, lieu, date);
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

                    commande.CommandText = "insert into soirees (lieu, date) values (@lieu, getDate()); select scope_identity()";
                    commande.Parameters.Add(new SqlParameter("@lieu", Lieu));
                    ID = (int)commande.ExecuteScalar();


                }


                //fermer la connexion
                connexion.Close();
            }

        }

    }
}
