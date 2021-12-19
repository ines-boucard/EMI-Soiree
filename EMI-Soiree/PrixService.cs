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
        public List<Prix> GetByIdSoiree(int idsoiree)
        {

            var prix = depot.GetByIdSoiree(idsoiree)
                .Select(p => new Prix(p.IdSoiree,
                                      p.IdParticipants,
                                      p.Montant
                                        ))
                .ToList();
            return prix;
            

        }
        public List<Prix> GetByIdParticipants(int idParticipant)
        {
            var p = depot.GetByIdParticipants(idParticipant);

            var prix = depot.GetByIdParticipants(idParticipant)
                .Select(p => new Prix(p.IdSoiree,
                                      p.IdParticipants,
                                      p.Montant
                                        ))
                .ToList();
            return prix;

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

        public Prix Update(Prix p)
        {
            var prix = new Prix_DAL(p.IdParticipants,
                                    p.IdSoiree,
                                    p.Montant);
            depot.Update(prix);

            return p;
        }

    }
}
