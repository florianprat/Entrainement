using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCD
{
    class Program
    {
        /******************************************************************************************************************
         * Ce programme permet de calculer le plus grand dénominateur commun (PGCD) de deux nombres entiers non nuls.
         ******************************************************************************************************************/

        static void Main(string[] args)
        {
            ConsoleKeyInfo touche = new ConsoleKeyInfo();
            do
            {
                // Affichage en couleur d'une brève description du programme
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Calcul du PGCD de deux nombres entiers non nuls");
                Console.ResetColor();

                // Saisie du premier nombre entier
                // La validité de la saisie est testée, puis l'entrée est convertie en entier.
                // Si la saisie est invalide, une nouvelle saisie est demandée.
                bool testSaisie = false;
                string s = string.Empty;

                // On test la validité de la saisie avant sa conversion en un entier.
                while (!testSaisie)
                {
                    Console.WriteLine("\nEntrez le premier nombre :");
                    s = Console.ReadLine();
                    testSaisie = ValiderSaisie(s);
                }
                int val1 = int.Parse(s);

                // Saisie du deuxième nombre entier, selon les mêmes modalités que la première saisie.
                testSaisie = false;
                while (!testSaisie)
                {
                    Console.WriteLine("\nEntrez le deuxième nombre :");
                    s = Console.ReadLine();
                    testSaisie = ValiderSaisie(s);
                }
                int val2 = int.Parse(s);

                // Calcul du PGCD et affichage du résultat
                int res = CalculerPGCD(val1, val2);
                Console.WriteLine("\nLe PGCD de {0} et {1} est : {2}", val1, val2, res);

                // Choix entre faire un nouveau calcul (touche Espace) ou sortir de l'application (touche Echap)
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nAppuyer sur Espace pour lancer un nouveau calcul\nOu Echap pour quitter l'application.");
                Console.ResetColor();
                // L'appui sur d'autres touches ne fait rien.
                do
                {
                    touche = Console.ReadKey(true);
                }
                while (touche.Key != ConsoleKey.Spacebar && touche.Key != ConsoleKey.Escape);

                Console.Clear();
            }
            while (touche.Key != ConsoleKey.Escape);        // La touche Echap permet de sortir du programme.
        }

        // Vérification de la validité de la saisie des nombres
        // La méthode renvoie un booléen (true si valide).
        static bool ValiderSaisie(string s)
        {
            try
            {
                int valeur = int.Parse(s);
                if (valeur > 0) return true;
                else throw new ArgumentException();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nLe nombre saisi doit être un entier positif non nul.");
                Console.ResetColor();
                return false;
            }
        }

        // Calcul et renvoi du PGCD 
        static int CalculerPGCD(int p, int q)
        {
            while (p != q)
            {
                if (p > q) p = p - q;
                else q = q - p;
            }
            return p;
        }
    }
}
