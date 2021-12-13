using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree
{
    public interface IParticipantsService
    {
        public List<Participants> GetAll();
        public Participants GetByID(int ID);
        public Participants Insert(Participants p);
        public Participants Update(Participants p);
        public void Delete(Participants p);


    }
}
