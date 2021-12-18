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
        public static void Rembourser(int choixSoiree)
        {

            var prixServices = new PrixService();
            int montantGlobale = 0;
            var DoisRembourser = new List<Prix>();
            var DoisEtreRembourser = new List<Prix>();

            for (int i = 0; i < prixServices.GetByIdSoiree(choixSoiree).Count; i++)
            {
                montantGlobale = montantGlobale + prixServices.GetByIdSoiree(choixSoiree)[i].Montant;
            }

            int montantMoyenneParPersonne = montantGlobale / prixServices.GetByIdSoiree(choixSoiree).Count;
            
            for (int i = 0; i < prixServices.GetByIdSoiree(choixSoiree).Count; i++)
            {

                if (prixServices.GetByIdSoiree(choixSoiree)[i].Montant <= montantMoyenneParPersonne)
                {
                    DoisRembourser.Add(prixServices.GetByIdSoiree(choixSoiree)[i]);
                }
                else
                {
                    DoisEtreRembourser.Add(prixServices.GetByIdSoiree(choixSoiree)[i]);
                }
            }

            for (int i = 0; i < DoisEtreRembourser.Count; i++)
            {

                var personneDoitEtreRemourser = DoisEtreRembourser[i];
                // on calcul le montant dont la personne doit être remboursée 
                int montantReceveur = personneDoitEtreRemourser.Montant - montantMoyenneParPersonne;
                Console.WriteLine("le participant" + personneDoitEtreRemourser.IdParticipants + "doit etre rembourser de " + montantReceveur);

                // Si cette personne a déja été remboursé elle n'a pas besoin d'etre remboursée 
                if (personneDoitEtreRemourser.Montant == montantMoyenneParPersonne)
                {
                    Console.WriteLine("Cette personne a le bon compte");
                }
                else
                {

                    for (int j = 0; j < DoisRembourser.Count; j++)
                    {
                        var personneDoisRemourser = DoisRembourser[j];
                        // on calcul le montant que la personne doit donner 
                        int montantDonneur = montantMoyenneParPersonne - personneDoisRemourser.Montant;
                       
                        // Si cette personne a déja été remboursé elle n'a pas besoin d'etre remboursée 
                        if (personneDoisRemourser.Montant == montantMoyenneParPersonne)
                        {
                            Console.WriteLine("Cette personne a le bon compte");
                        }
                        else
                        {

                            int remboursementFait;
                            // Le cas où le montant que la personne doit payer est plus petit que celui qu'elle doit donner
                            // ex donneur doit donner 5 euros mais le receveur doit recevoir 10 euros
                            if (montantReceveur > montantDonneur)
                            {

                                personneDoitEtreRemourser.Montant = personneDoitEtreRemourser.Montant - montantDonneur;
                                personneDoisRemourser.Montant = personneDoisRemourser.Montant + montantDonneur;
                                Console.WriteLine("le participants " + personneDoisRemourser.IdParticipants + " dois " + montantDonneur + " au participants" + personneDoitEtreRemourser.IdParticipants);
                                montantReceveur = personneDoitEtreRemourser.Montant - montantMoyenneParPersonne;
                                montantDonneur = montantMoyenneParPersonne - personneDoisRemourser.Montant;

                            }
                            // Le cas où le montant que la personne doit payer est plus grand que celui qu'elle doit donner
                            // ex donneur doit donner 10 euros mais le receveur doit recevoir 5 euros

                            if (montantReceveur < montantDonneur)
                            {


                                personneDoitEtreRemourser.Montant = personneDoitEtreRemourser.Montant - montantReceveur;
                                personneDoisRemourser.Montant = personneDoisRemourser.Montant + montantReceveur;
                                Console.WriteLine("le participants " + personneDoisRemourser.IdParticipants + " dois " + montantReceveur + " au participants" + personneDoitEtreRemourser.IdParticipants);
                                montantReceveur = personneDoitEtreRemourser.Montant - montantMoyenneParPersonne;
                                montantDonneur = montantMoyenneParPersonne - personneDoisRemourser.Montant;
                            }
                            // Le cas où le montant que la personne doit payer est plus égale à celui qu'elle doit donner
                            // ex donneur doit donner 10 euros mais le receveur doit recevoir 10 euros
                            if (montantReceveur == montantDonneur)
                            {

                                personneDoitEtreRemourser.Montant = personneDoitEtreRemourser.Montant - montantReceveur;
                                personneDoisRemourser.Montant = personneDoisRemourser.Montant + montantReceveur;
                                Console.WriteLine("le participants " + personneDoisRemourser.IdParticipants + " dois " + montantReceveur + " au participants" + personneDoitEtreRemourser.IdParticipants);
                                montantReceveur = personneDoitEtreRemourser.Montant - montantMoyenneParPersonne;
                                montantDonneur = montantMoyenneParPersonne - personneDoisRemourser.Montant;
                            }




                        }

                    }

                }

            }
            for (int i = 0; i < DoisEtreRembourser.Count; i++)
            {
                Console.WriteLine("partcipant" + DoisEtreRembourser[i].IdParticipants + " montant " + DoisEtreRembourser[i].Montant);
            }
            for (int i = 0; i < DoisRembourser.Count; i++)
            {
                Console.WriteLine("partcipant" + DoisRembourser[i].IdParticipants + " montant " + DoisRembourser[i].Montant);
            }

        }
    }
}
