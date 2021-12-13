using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree
{
    public interface IPrixService
    {
        public List<Prix> GetAll();
        public Prix GetByIdSoiree(int IdSoiree);
        public Prix GetByIdParticipants(int IdParticipants);
        public Prix Insert(Prix p);
        

    }
}
