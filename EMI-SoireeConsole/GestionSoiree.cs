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
            Console.WriteLine("\n Souhaitez vous : \n 1-voir les participants \n 2-ajouter un participant \n 3-modifier la soiree");
            
        }
    }
}
