using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree
{
    public class Soirees
    {
        public int ID { get; set; }
        public String Lieu { get; set; }
        public DateTime? Date { get; set; }

        public Soirees(String lieu)
            => (Lieu) = (lieu);
        public Soirees(int id, String lieu, DateTime? date)
            => (ID, Lieu, Date) = (id, lieu, date);
    }
}
