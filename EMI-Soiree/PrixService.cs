using EMI_Soiree.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree
{
    public class PrixService : IPrixService
    {
        private Prix_Depot_DAL depot = new Prix_Depot_DAL();
        public List<Prix> GetAll()
        {
            var prix = depot.GetAll()
                .Select(p => new Prix(p.IdSoiree,
                                      p.IdParticipants,
                                      p.Montant
                                        ))
                .ToList();

            return prix;
        }
        public Prix GetByIdSoiree(int idsoiree)
        {
            var p = depot.GetByID(idsoiree);

            return new Prix(p.IdSoiree,
                            p.IdParticipants,
                            p.Montant
                              );

        }
        public Prix GetByIdParticipants(int idParticipant)
        {
            var p = depot.GetByID(idParticipant);

            return new Prix(p.IdSoiree,
                            p.IdParticipants,
                            p.Montant
                              );

        }
        
        public Prix Insert(Prix p)
        {
            var prix = new Prix_DAL(p.IdSoiree,
                            p.IdParticipants,
                            p.Montant
                              ); ;
            depot.Insert(prix);

            return p;
        }
        
    }
}
