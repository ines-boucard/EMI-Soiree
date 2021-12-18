using EMI_Soiree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_SoireeConsole
{
    class GestionRemboursements
    {
        public static void AjoutPrix(int idSoiree, int idParticipant)
        {
            Console.WriteLine("Combien a t-il dépensé ?");
            int montant = Int32.Parse(Console.ReadLine());
            var prix = new Prix(idSoiree, idParticipant , montant);
            var prixServices = new PrixService();
            prixServices.Insert(prix);
        }

        public static void ModifierPrix(int idSoiree, int idParticipant)
        {
            Console.WriteLine("Combien as-tu donc dépensé ?");
            int montant = Int32.Parse(Console.ReadLine());
            var prix = new Prix(idSoiree, idParticipant, montant);
            var prixServices = new PrixService();
            prixServices.Update(prix);
        }


    }
}
