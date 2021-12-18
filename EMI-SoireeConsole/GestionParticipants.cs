using EMI_Soiree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_SoireeConsole
{
    public static class GestionParticipants
    {
        public static void VoirParticipantsSoiree(int choixSoiree)
        {
            var participant = new ParticipantsService();
            Console.WriteLine(participant.GetByIdSoiree(choixSoiree).Count());
            for (int i = 0; i < participant.GetByIdSoiree(choixSoiree).Count(); i++)
            {
                Console.WriteLine("| " + participant.GetByIdSoiree(choixSoiree)[i].ID + "| " + participant.GetByIdSoiree(choixSoiree)[i].Nom + "  |   " + participant.GetByIdSoiree(choixSoiree)[i].Prenom);
            }
            Console.WriteLine("\n Souhaitez vous : \n 1-modifier un participants " +
                "                                  \n 2-supprimer un participant " +
                "                                  \n 3-modifier le montant d'un participant" +
                "                                  \n 0-revenir au menu");
            int choix1 = Int32.Parse(Console.ReadLine());
            if (choix1 == 1)
            {
                Console.WriteLine("\n Quel Participant souhaitez-vous modifier ? ");
                int choixParticipant = Int32.Parse(Console.ReadLine());
                ModifierParticipant(choixParticipant);
                //ModifierParticipantDuneSoiree(choixSoiree);
            }
            else if (choix1 == 2)
            {
                Console.WriteLine("\n Quel Participant souhaitez-vous supprimer ? ");
                int choixParticipant = Int32.Parse(Console.ReadLine());
                SupprimerParticipantDuneSoiree(choixSoiree);
            }
            else if (choix1 == 3)
            {
                Console.WriteLine("\n A quel Participant souhaitez-vous modifier le montant ? ");
                int choixParticipant = Int32.Parse(Console.ReadLine());
                GestionRemboursements.ModifierPrix(choixSoiree, choixParticipant);
            }
            
        }


        public static void AjoutParticipant(int idSoiree)
        {
            var participantsService = new ParticipantsService();
            Console.WriteLine("Quel est son prenom ?");
            string prenom = Console.ReadLine();
            Console.WriteLine("Quel est son nom ?");
            string nom = Console.ReadLine();

            var participant = new Participants(nom, prenom, idSoiree);
            participantsService.Insert(participant);

            GestionRemboursements.AjoutPrix(idSoiree, participant.ID);
        }

        public static void SupprimerParticipantDuneSoiree(int choixParticipant)
        {
            var depot = new ParticipantsService();
            var participant = new Participants(depot.GetByID(choixParticipant).ID, depot.GetByID(choixParticipant).Nom, depot.GetByID(choixParticipant).Prenom, depot.GetByID(choixParticipant).IdSoiree);
            Console.WriteLine("\n Etes vous sur de vouloir supprimer " + participant.Nom + "?"
                                + "\n (O) Oui  -  (n) Non");
            string choix = Console.ReadLine();
            if (choix == "O")
            {
                depot.Delete(participant);
            }
        }

        public static void ModifierParticipant(int idParticipant)
        {
            var depot = new ParticipantsService();
            
            Console.WriteLine("\n Vous avez choisit " + depot.GetByID(idParticipant).Prenom + depot.GetByID(idParticipant).Nom);
           
            Console.WriteLine("\n Souhaiter vous changer :" +
                "              \n 1- son nom" +
                "              \n 2- son premom");
            int choix = Int32.Parse(Console.ReadLine());
            if (choix == 1)
            {
                Console.WriteLine("\n Quel est son nom ?");
                string nom = Console.ReadLine();
                var participant = new Participants(depot.GetByID(idParticipant).ID, nom , depot.GetByID(idParticipant).Prenom, depot.GetByID(idParticipant).IdSoiree);
                depot.Update(participant);
            }
            else if (choix == 2)
            {
                Console.WriteLine("\n Quel est son prenom ?");
                string prenom = Console.ReadLine();
                var participant = new Participants(depot.GetByID(idParticipant).ID, depot.GetByID(idParticipant).Nom, prenom, depot.GetByID(idParticipant).IdSoiree);
                depot.Update(participant);
            }

            
       
        }

        
        
    }
}
