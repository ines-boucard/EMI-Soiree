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

    }
}
