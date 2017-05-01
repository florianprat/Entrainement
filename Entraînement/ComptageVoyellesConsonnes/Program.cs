using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComptageVoyellesConsonnes
{
    class Program
    {
        /************************************************************************************************************
         * Ce programme compte les voyelles et les consonnes contenues dans un mot saisi par l'utilisateur.
         ************************************************************************************************************/

        static void Main(string[] args)
        {
            int nbVoyelles, nbConsonnes;    // Nombres de voyelles et de consonnes

            // Saisie d'un mot (on ne fait pas de vérification de la saisie.)
            Console.WriteLine("Veuillez saisir un mot :");
            string motSaisi = Console.ReadLine().ToLower();     // On met le mot en minuscule (sinon il faut traiter les cas majuscule et minuscule).

            // Comptage
            CompterVoyellesConsonnes(motSaisi, out nbVoyelles, out nbConsonnes);

            // On distingue dans l'affichage les cas singulier/pluriel des mots "voyelle(s)" et "consonne(s)".
            Console.WriteLine("\n\"{0}\" comprend {1} {2} et {3} {4}.", motSaisi,
                               nbVoyelles, nbVoyelles > 1 ? "voyelles" : "voyelle",
                               nbConsonnes, nbConsonnes > 1 ? "consonnes" : "consonne");

            Console.ReadKey();
        }

        // Comptage des voyelles et des consonnes contenues dans le mot saisi.
        // Les nombres de voyelles et de consonnes sont renvoyés en paramètres out.
        static void CompterVoyellesConsonnes(string s, out int nbVoy, out int nbCons)
        {
            nbVoy = 0;
            char[] voyelle = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };   // Création d'un tableau contenant les voyelles de l'alphabet

            // On regarde si chaque caractère du mot saisi appartient au tableau des voyelles.
            // Si c'est le cas, on incrémente de 1 le nombre de voyelles.
            foreach (var c in s)
                if (voyelle.Contains(c)) nbVoy++;

            // Le nombre de consonnes est déduit à partir du nombre de voyelles et du nombre de caractères du mot saisi.
            nbCons = s.Length - nbVoy;
        }
    }
}
