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

        public static void CalculerRemboursement(int choixSoiree)
        {

            var prix = new PrixService();
            var participant = new ParticipantsService();
            double montantGlobal = 0;
            var DoitRembourser = new List<Prix>();
            var DoitEtreRembourser = new List<Prix>();

            if (participant.GetByIdSoiree(choixSoiree).Count() <2)
            {
                Console.WriteLine("Cette soirée ne contient pas assez de participants pour faire le calcul");
            }
            else
            {
                for (int i = 0; i < prix.GetByIdSoiree(choixSoiree).Count; i++)
                {
                    montantGlobal = montantGlobal + prix.GetByIdSoiree(choixSoiree)[i].Montant;
                }

                double montantMoyenneParPersonne = montantGlobal / prix.GetByIdSoiree(choixSoiree).Count;

                for (int i = 0; i < prix.GetByIdSoiree(choixSoiree).Count; i++)
                {

                    if (prix.GetByIdSoiree(choixSoiree)[i].Montant <= montantMoyenneParPersonne)
                    {
                        DoitRembourser.Add(prix.GetByIdSoiree(choixSoiree)[i]);
                    }
                    else
                    {
                        DoitEtreRembourser.Add(prix.GetByIdSoiree(choixSoiree)[i]);
                    }
                }

                for (int i = 0; i < DoitEtreRembourser.Count; i++)
                {

                    var personneDoitEtreRembourser = DoitEtreRembourser[i];
                    // on calcul le montant dont la personne doit être remboursée 
                    double montantReceveur = personneDoitEtreRembourser.Montant - montantMoyenneParPersonne;
  
                    // Si cette personne a déja été remboursé elle n'a pas besoin d'etre remboursée 
                    if (personneDoitEtreRembourser.Montant == montantMoyenneParPersonne)
                    {
                        Console.WriteLine("Cette personne a le bon compte");
                    }
                    else
                    {

                        for (int j = 0; j < DoitRembourser.Count; j++)
                        {
                            var personneDoitRembourser = DoitRembourser[j];
                            // on calcul le montant que la personne doit donner 
                            double montantDonneur = montantMoyenneParPersonne - personneDoitRembourser.Montant;

                            // Si cette personne a déja été remboursé elle n'a pas besoin d'etre remboursée 
                            if (personneDoitRembourser.Montant == montantMoyenneParPersonne)
                            {
                                Console.WriteLine("Cette personne a le bon compte");
                            }
                            else
                            {
                                // Le cas où le montant que la personne doit payer est plus petit que celui qu'elle doit donner
                                // ex donneur doit donner 5 euros mais le receveur doit recevoir 10 euros
                                if (montantReceveur > montantDonneur)
                                {

                                    personneDoitEtreRembourser.Montant = personneDoitEtreRembourser.Montant - montantDonneur;
                                    personneDoitRembourser.Montant = personneDoitRembourser.Montant + montantDonneur;
                                    Console.WriteLine(participant.GetByID(personneDoitRembourser.IdParticipants).Prenom + " doit " + String.Format("{0:0.00}", montantDonneur) + " a " + participant.GetByID(personneDoitEtreRembourser.IdParticipants).Prenom);
                                    montantReceveur = personneDoitEtreRembourser.Montant - montantMoyenneParPersonne;
                                    montantDonneur = montantMoyenneParPersonne - personneDoitRembourser.Montant;

                                }
                                // Le cas où le montant que la personne doit payer est plus grand que celui qu'elle doit donner
                                // ex donneur doit donner 10 euros mais le receveur doit recevoir 5 euros

                                if (montantReceveur < montantDonneur)
                                {


                                    personneDoitEtreRembourser.Montant = personneDoitEtreRembourser.Montant - montantReceveur;
                                    personneDoitRembourser.Montant = personneDoitRembourser.Montant + montantReceveur;
                                    Console.WriteLine(participant.GetByID(personneDoitRembourser.IdParticipants).Prenom + " doit " + String.Format("{0:0.00}", montantReceveur) + " a " + participant.GetByID(personneDoitEtreRembourser.IdParticipants).Prenom);
                                    montantReceveur = personneDoitEtreRembourser.Montant - montantMoyenneParPersonne;
                                    montantDonneur = montantMoyenneParPersonne - personneDoitRembourser.Montant;
                                }
                                // Le cas où le montant que la personne doit payer est plus égale à celui qu'elle doit donner
                                // ex donneur doit donner 10 euros mais le receveur doit recevoir 10 euros
                                if (montantReceveur == montantDonneur)
                                {

                                    personneDoitEtreRembourser.Montant = personneDoitEtreRembourser.Montant - montantReceveur;
                                    personneDoitRembourser.Montant = personneDoitRembourser.Montant + montantReceveur;
                                    Console.WriteLine(participant.GetByID(personneDoitRembourser.IdParticipants).Prenom + " doit " + String.Format("{0:0.00}", montantReceveur) + " a " + participant.GetByID(personneDoitEtreRembourser.IdParticipants).Prenom);
                                    montantReceveur = personneDoitEtreRembourser.Montant - montantMoyenneParPersonne;
                                    montantDonneur = montantMoyenneParPersonne - personneDoitRembourser.Montant;
                                }

                            }

                        }

                    }

                }
            }


            
        }

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
