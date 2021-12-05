using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree.DAL
{
    public abstract class Soirees_Depot_DAL : Depot_DAL<Soirees_DAL>
    {
        public Soirees_Depot_DAL()
           : base()
        {

        }

        public override List<Soirees_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, lieu, date from soirees";
            //pour lire les lignes une par une
            var reader = commande.ExecuteReader();

            var listeDeSoirees = new List<Soirees_DAL>();

            while (reader.Read())
            {
                //dans reader.GetInt32 on met la colonne que l'on souhaite récupérer ici 0 = idFournisseurs, 1 = societe...
                var soirees = new Soirees_DAL(reader.GetInt32(0),
                                                        reader.GetString(1),
                                                        reader.GetSqlDateTime(2).IsNull ? null : reader.GetDateTime(2));


                listeDeSoirees.Add(soirees);
            }

            DetruireConnexionEtCommande();

            return listeDeSoirees;
        }

        public override Soirees_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, lieu, date from soirees where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            var listeDeFournisseurs = new List<Soirees_DAL>();

            Soirees_DAL fournisseur;
            if (reader.Read())
            {
                fournisseur = new Soirees_DAL(reader.GetInt32(0),
                                                        reader.GetString(1),
                                                        reader.GetSqlDateTime(2).IsNull ? null : reader.GetDateTime(2));
            }
            else
                throw new Exception($"Pas de soiree dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return fournisseur;
        }

        public override Soirees_DAL Insert(Soirees_DAL soirees)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into soirees (lieu, date)"
                                    + " values (@lieu, getDate()); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@lieu", soirees.Lieu));
   

            var id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            soirees.ID = id;

            DetruireConnexionEtCommande();

            return soirees;
        }


    }
}
