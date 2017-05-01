using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorateurFichiers
{
    /********************************************************************************************************************
     * Ce programme permet d'analyser les fichiers d'un dossier dont le chemin est saisi par l'utilisateur.
     * Il permet par exemple d'afficher :
     *      - le nombre total de fichiers
     *      - la liste des noms des fichiers d'un type donné
     *      - ...
     ********************************************************************************************************************/


    class Program
    {
        static void Main(string[] args)
        {
            // Saisie du chemin du dossier à analyser
            // L'invite de saisie est répétée tant que le chemin saisi n'est pas valide.
            string dossierSaisi = string.Empty;

            while (dossierSaisi == string.Empty)
            {
                Console.WriteLine("Saisissez le chemin du dossier à explorer :");
                dossierSaisi = Console.ReadLine();

                // On vérifie que le chemin saisi correspond à un dossier existant.
                if (!Directory.Exists(dossierSaisi))
                {
                    Console.WriteLine("Ce dossier n'existe pas.");
                    dossierSaisi = string.Empty;
                }
                Console.WriteLine();
            }

            // Analyse du dossier
            var ana = new Analyseur();
            ana.AnalyserDossier(dossierSaisi);

            // Affichage des résultats de l'analyse du dossier
            Console.WriteLine("{0} fichiers, dont {1} fichiers .cs", ana.NbTotalFichiers, ana.NbFichiersCs);
            Console.WriteLine("Nom de fichier le plus long : {0}", ana.NomLePlusLong);
            Console.WriteLine();
            Console.WriteLine("Fichiers projets C# :");
            foreach (var s in ana.listFichiersProjet)
                Console.WriteLine(s);

            Console.ReadKey();
        }
    }
}
