using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriTableau
{
    class Program
    {
        //
        // Ce programme permet de trier un tableau de mots par ordre alphabétique selon la méthode du tri à bulle.
        //

        static void Main(string[] args)
        {
            // Tableau de mots à trier
            string[] tableau = new string[] { "vert", "orange", "mauve", "gris", "violet", "bleu" };

            // Affichage des mots avant le tri
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Liste des mots avant le tri :\n");
            Console.ResetColor();
            Console.WriteLine(AfficherTableau(tableau));

            // Affichage des mots après le tri
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nListe des mots après le tri :\n");
            Console.ResetColor();
            string[] tabTrié = TrierTableau(tableau);
            Console.WriteLine(AfficherTableau(tabTrié));

            // On affiche de nouveau le tableau d'origine, pour vérifier qu'il n'a pas été modifié par la fonction de tri.
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nOù on vérifie que le tableau d'origine n'a pas été modifié par la fonction de tri ...\n");
            Console.ResetColor();
            Console.WriteLine(AfficherTableau(tableau));

            Console.ReadKey();
        }

        // Affichage du contenu d'un tableau sur une seule ligne
        // La méthode renvoie une chaîne de caractères contenant les mots du tableau.
        static string AfficherTableau(string[] tab)
        {
            string listMots = string.Empty;                             // Chaîne de caractères à renvoyer
            foreach (var s in tab)
                listMots += s + ", ";                                   // Concaténation des mots sur une seule ligne
            listMots = listMots.Substring(0, listMots.Length - 2);      // On enlève la dernière virgule pour faire plus propre.
            return listMots;
        }

        // Tri d'un tableau de mots en comparant ses éléments deux à deux et en les permutant.
        // Le tri se termine lorsque le tableau peut être parcouru sans faire aucune permutation.
        static string[] TrierTableau(string[] tab)
        {
            // On crée une copie du tableau passé en paramètre, afin de ne pas modifier ses éléments.
            // Les tableaux sont des types référence, donc rien n'empêche de modifier les éléments du tableau dans la méthode.
            string[] copie = new string[tab.Length];
            tab.CopyTo(copie, 0);

            int cptPermut = 1;  // Compteur de permutation

            // On sort du processus de tri lorsque le tableau peut être parcouru sans permutation (cptPermut = 0).
            while (cptPermut > 0)
            {
                cptPermut = 0;
                for (int i = 0; i < copie.Length - 1; i++)
                {
                    if (copie[i].CompareTo(copie[i + 1]) > 0)
                    {
                        // On se sert d'une variable intermédiaire pour faire la permutation.
                        // Elle permet de stocker la variable tab[i], et donc ne pas perdre cette dernière lors de la permuation.
                        string temp = copie[i];
                        copie[i] = copie[i + 1];
                        copie[i + 1] = temp;
                        cptPermut++;    // On incrémente de 1 le compteur de permutation.
                    }
                }
            }
            return copie;
        }
    }
}
