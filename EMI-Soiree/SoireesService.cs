using EMI_Soiree.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree
{
    public class SoireesService : ISoireesService
    {
        private Soirees_Depot_DAL depot = new Soirees_Depot_DAL();
        public List<Soirees> GetAll()
        {
            var soirees = depot.GetAll()
                .Select(s => new Soirees(s.ID,
                                        s.Lieu,
                                        s.Date
                                        ))
                .ToList();

            return soirees;
        }
        public Soirees GetByID(int idsoiree)
        {
            var s = depot.GetByID(idsoiree);

            return new Soirees(s.ID,
                               s.Lieu,
                               s.Date
                              );

        }
        public Soirees Insert(Soirees s)
        {
            var soirees = new Soirees_DAL(s.ID,
                                          s.Lieu,
                                          s.Date);
            depot.Insert(soirees);
            s.ID = soirees.ID;

            return s;
        }
        public Soirees Update(Soirees s)
        {
            var soirees = new Soirees_DAL(s.ID,
                                    s.Lieu,
                                    s.Date);
            depot.Update(soirees);

            return s;
        }
        public void Delete(Soirees s)
        {
            var soirees = new Soirees_DAL(s.ID,
                                          s.Lieu,
                                          s.Date);
            depot.Delete(soirees);
        }
    }
}
