using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree
{
    public interface ISoireesService
    {
        public List<Soirees> GetAll();
        public Soirees GetByID(int ID);
        public Soirees Insert(Soirees s);
        public Soirees Update(Soirees s);
        public void Delete(Soirees s);

    }
}
