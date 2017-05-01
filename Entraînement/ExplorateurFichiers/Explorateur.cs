using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorateurFichiers
{
    // Déclaration d'un type de délégué pour l'analyse des dossiers
    public delegate void DelegueExplorateur(FileInfo fichier);

    class Explorateur
    {
        // Parcours du dossier dont le chemin est spécifié en paramètre
        // Pour chaque fichier rencontré, le délégué entré en paramètre est exécuté.
        public static void Explorer(string chemin, DelegueExplorateur explore)
        {
            var dir = new DirectoryInfo(chemin);

            foreach (var fi in dir.EnumerateFiles("*", SearchOption.AllDirectories))    // Les sous-dossiers sont également parcourus.
            {
                explore(fi);
            }
        }
    }
}
