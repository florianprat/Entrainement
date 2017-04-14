using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComptageVoyellesConsonnes
{
    class Program
    {
        //
        // Ce programme compte les voyelles et les consonnes contenues dans un mot
        //

        static void Main(string[] args)
        {
            int nbVoyelles, nbConsonnes;    // Nombres de voyelles et de consonnes

            Console.WriteLine("Veuillez saisir un mot :");
            string motSaisi = Console.ReadLine().ToLower();
            CompterVoyellesConsonnes(motSaisi, out nbVoyelles, out nbConsonnes);

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
            foreach (var c in s)
                if (voyelle.Contains(c)) nbVoy++;
            nbCons = s.Length - nbVoy;
        }
    }
}
