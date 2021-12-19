using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMI_Soiree.DAL;
using EMI_Soiree;

namespace EMI_SoireeConsole
{
    public static class GestionSoiree
    {
        public static void ListeDeSoirees()
        {
            var soireesService = new SoireesService();
            Console.WriteLine("Participants");
            Console.WriteLine("ID    Lieu      Date");
            for (int i = 0; i < soireesService.GetAll().Count(); i++)
            {
                Console.WriteLine("| " + soireesService.GetAll()[i].ID + "| " + soireesService.GetAll()[i].Lieu + "  |   " + soireesService.GetAll()[i].Date);
            }
        }

        public static void AccederAuneSoiree(int choixSoiree)
        {
            var soiree = new SoireesService();
            Console.WriteLine("\n Vous avez choisi la soiree n° " + soiree.GetByID(choixSoiree).ID + " a " + soiree.GetByID(choixSoiree).Lieu + ", le " + soiree.GetByID(choixSoiree).Date);
            Console.WriteLine("\n Souhaitez vous : \n 1-calculer les remboursements de la soirée " +
                "                                  \n 2-voir les participants " +
                "                                  \n 3-ajouter un participant " +
                "                                  \n 4-modifier la soiree " +
                "                                  \n 5-supprimer la soiree  " +
                "                                  \n 0-revenir au menu ");
            int choix1 = Int32.Parse(Console.ReadLine());
            if (choix1 == 1)
            {
                GestionRemboursements.CalculerRemboursement(choixSoiree);
            }
            else if (choix1 == 2)
            {
                GestionParticipants.VoirParticipantsSoiree(choixSoiree);
            }
            else if (choix1 == 3)
            {
                GestionParticipants.AjoutParticipant(choixSoiree);
            }
            else if (choix1 == 4)
            {
                ModifierSoiree(choixSoiree);
            }
            else if (choix1 == 4)
            {
                SupprimerSoiree(choixSoiree);
            }
        }

        public static void AjoutSoiree()
        {
            Console.WriteLine("Rentrez le lieu de la soiree :");
            string Lieu = Console.ReadLine();
            var soiree = new Soirees(Lieu);

            var soireesService = new SoireesService();
            soireesService.Insert(soiree);
        }

        public static void ModifierSoiree(int choixSoiree)
        {
            Console.WriteLine("Rentrez le nouveau lieu de la soiree :");
            string Lieu = Console.ReadLine();
            var depot = new SoireesService();
            var soiree = new Soirees(depot.GetByID(choixSoiree).ID, Lieu, depot.GetByID(choixSoiree).Date);

            var soireesService = new SoireesService();
            soireesService.Update(soiree);
        }

        public static void SupprimerSoiree(int choixSoiree)
        {
            var depot = new SoireesService();
            var soiree = new Soirees(depot.GetByID(choixSoiree).ID, depot.GetByID(choixSoiree).Lieu, depot.GetByID(choixSoiree).Date);
            Console.WriteLine("\n Etes vous sur de vouloir supprimer la soirée n° " + soiree.ID + " qui se deroulait à " + soiree.Lieu
                                + "\n (O) Oui  -  (n) Non");
            string choix = Console.ReadLine();
            if (choix == "O")
            {
                depot.Delete(soiree);
            }
        }

    }
}
