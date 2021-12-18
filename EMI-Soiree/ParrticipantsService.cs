using EMI_Soiree.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree
{
    public class ParticipantsService : IParticipantsService
    {
        private Participants_Depot_DAL depot = new Participants_Depot_DAL();
        public List<Participants> GetAll()
        {
            var participant = depot.GetAll()
                .Select(p => new Participants(p.ID,
                                        p.Nom,
                                        p.Prenom,
                                        p.IdSoiree
                                        ))
                .ToList();

            return participant;
        }
        public Participants GetByID(int idParticipants)
        {
            var p = depot.GetByID(idParticipants);

            return new Participants(p.ID,
                               p.Nom,
                               p.Prenom,
                               p.IdSoiree
                              );

        }

        public  List<Participants> GetByIdSoiree(int idSoiree)
        {
            var participant = depot.GetByIdSoiree(idSoiree)
                .Select(p => new Participants(p.ID,
                                        p.Nom,
                                        p.Prenom,
                                        p.IdSoiree
                                        ))
                .ToList();

            return participant;
        }

        public Participants Insert(Participants p)
        {
            var participants = new Participants_DAL(p.ID,
                               p.Nom,
                               p.Prenom,
                               p.IdSoiree);
            depot.Insert(participants);
            p.ID = participants.ID;

            return p;
        }
        public Participants Update(Participants p)
        {
            var participants = new Participants_DAL(p.ID,
                               p.Nom,
                               p.Prenom,
                               p.IdSoiree);
            depot.Update(participants);

            return p;
        }
        public void Delete(Participants p)
        {
            var participants = new Participants_DAL(p.ID,
                               p.Nom,
                               p.Prenom,
                               p.IdSoiree);
            depot.Delete(participants);
        }
    }
}
