using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NombresPremiers
{
    class Program
    {
        /*****************************************************************************************
         * Ce programme permet de calculer et afficher les N premiers nombres premiers.
         *****************************************************************************************/

        static void Main(string[] args)
        {
            // Saisie du nombre N de nombres premiers à afficher
            // On ne fait pas de vérification de la saisie.
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ce programme permet de calculer et afficher les N premiers nombres premiers");
            Console.ResetColor();
            Console.WriteLine("\nSaisissez le nombre N de nombres premiers à afficher :");

            // Calcul et affichage des nombres premiers
            int N = int.Parse(Console.ReadLine());  // Nombre de premiers à afficher
            Console.WriteLine("\nLes {0} premiers nombres premiers sont :", N);
            Console.WriteLine(CalculerPremier(N));

            Console.ReadKey();
        }

        // Calcul des N premiers nombres premiers.
        // La liste des nombres premiers est renvoyée sous la forme d'une chaîne de caractères.
        static string CalculerPremier(int nbr)
        {
            int compteur = 1;            // Compteur indiquant le nombre de premiers calculés
            int nbrTesté = 3;            // Nombre testé
            int diviseur;                // Nombre par lequel le nombre testé est divisé
            bool estPremier;             // Indique si le nombre est premier (true) ou non (false)
            string res = "\n - 2";       // Chaîne concaténant les nombres premiers

            while (compteur < nbr)
            {
                diviseur = 3;
                estPremier = true;

                while (diviseur < nbrTesté / 2 && estPremier)
                {
                    // Si le reste de la division (nbrTesté / diviseur) est nul, alors nbrTesté est un multiple de diviseur.
                    // Dans ce cas, nbrTesté n'est pas un nombre premier.
                    if (nbrTesté % diviseur == 0) estPremier = false;
                    else diviseur += 2;     // On ne considère que les nombres impairs.
                }

                // Si le nombre est premier, on l'ajoute dans la chaîne de caractères qui sera retournée et
                // on incrémente de 1 le compteur.
                if (estPremier)
                {
                    res += "\n - " + nbrTesté;
                    compteur++;
                }

                nbrTesté += 2;      // On ne teste que les nombres impairs (un nombre pair est divisible par 2).
            }

            return res;
        }
    }
}
