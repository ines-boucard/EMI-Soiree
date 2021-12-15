using System;
using System.Linq;
using EMI_Soiree;
using EMI_Soiree.DAL;

namespace EMI_SoireeConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            void ListeDeSoirees()
        {
            var soireesService = new SoireesService();
            Console.WriteLine("Participants");
            Console.WriteLine("Lieu      Date");
            for (int i = 0; i < soireesService.GetAll().Count(); i++)
            {

                Console.WriteLine("| " + soireesService.GetAll()[i].Lieu + "  |   " + soireesService.GetAll()[i].Date);

            }

        }
            void ListeDeParticipants()
            {
                var participantsService = new SParticipantsService();
                Console.WriteLine("Soirees");
                Console.WriteLine("Nom      Prenom      Numero de soiree");
                for (int i = 0; i < participantsService.GetAll().Count(); i++)
                {

                    Console.WriteLine("| " + participantsService.GetAll()[i].Nom + "  |   " + participantsService.GetAll()[i].Prenom + "  |  " + participantsService.GetAll()[i].IdSoiree);

                }

            }
            void RentrerSoirees()
            {
                Console.WriteLine("Rentrez le lieu de la soiree");
                string Lieu = Console.ReadLine();
                var soiree = new Soirees(Lieu);

                var soireesService = new SoireesService();
                Console.WriteLine("\nChoissiez un nombre : \n 1 - ajouter un participant \n 2 - retour au menu");
                int rentrerUnParticipants = Int32.Parse(Console.ReadLine());

                soireesService.Insert(soiree);
                
                if (rentrerUnParticipants == 1)
                {
                    var participantsService = new SParticipantsService();
                    Console.WriteLine("Quel est votre prenom ?");
                    string prenom = Console.ReadLine();
                    Console.WriteLine("Quel est votre nom ?");
                    var nom = Console.ReadLine();
                    Console.WriteLine("Quel est le numero de la soiree à laquelle vous avez participé ?");
                    int numeroSoiree = Int32.Parse(Console.ReadLine());
                    var participant = new Participants(nom, prenom, numeroSoiree);
                    participantsService.Insert(participant);
                    Console.WriteLine("Combien avez vous dépensé ?");
                    int montant = Int32.Parse(Console.ReadLine());
                    var prix = new Prix(soiree.ID, participant.ID, montant);
                    var prixServices = new PrixService();
                    prixServices.Insert(prix);


                }
                if(rentrerUnParticipants == 2)
                {
                    Menu();
                }
                


            }
            void Menu()
            {
                Console.WriteLine("\nChoissiez un nombre : \n 1 - voir les participants\n 2 - voir les soirees\n 3 - rentrer une soiree" );
                int choix1 = Int32.Parse(Console.ReadLine());
                 if(choix1 == 1)
                {
                    ListeDeParticipants();
                    Menu();
                }
                 if(choix1 == 2)
                {
                    ListeDeSoirees();
                    Menu();
                }
                 if(choix1 == 3)
                {
                    RentrerSoirees();
                    Menu();
                }



            }
            void helllo()
            {
                Console.WriteLine("Hello World!");
            }
            helllo();
            Menu();

            /*var s1DAL = new Soirees_DAL("warehouse");
            var s = new Soirees_Depot_DAL();
            s.Insert(s1DAL);
            var p1DAL = new Participants_DAL("eline", "malherbe", 1);*/
            //var p = new Participants_Depot_DAL();

            // p.Insert(p1DAL);

            // p.Insert(p1);
           // ListeDeParticipants();
           

        }
    }
}
