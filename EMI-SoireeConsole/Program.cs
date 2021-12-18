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
            
            static void Menu()
            {
                Console.WriteLine("\n Bienvenu dans EMI-Soiree !");
                Console.WriteLine("\n Que souhaitez-vous faire ? \n 1 - Voir les soirees " +
                    "                                            \n 2 - Rentrer une nouvelle soiree " +
                    "                                            \n 3 - Quitter l'application");
                int choix1 = Int32.Parse(Console.ReadLine());
                if (choix1 == 1)
                {
                    Console.WriteLine("Voici la liste de vos soiree enregistrees :");
                    GestionSoiree.ListeDeSoirees();
                    Console.WriteLine("\n Choisisser la soiree a laquelle vous souhaiter acceder \n ou bien taper 0 pour revenir au menu");
                    int choix2 = Int32.Parse(Console.ReadLine());
                    if (choix2 == 0)
                    {
                        Menu();
                    }
                    else
                    {
                        GestionSoiree.AccederAuneSoiree(choix2);
                    }

                }
                else if (choix1 == 2)
                {
                    GestionSoiree.AjoutSoiree();
                }
                else if (choix1 == 3)
                {
                    Environment.Exit(0);
                }
                Menu();
            }

            Menu();



            }
        
    }
}
