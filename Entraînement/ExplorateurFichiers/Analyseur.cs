using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorateurFichiers
{
    public class Analyseur
    {
        #region Propriétés
        public int NbTotalFichiers { get; private set; }
        public int NbFichiersCs { get; private set; }
        public string NomLePlusLong { get; private set; }
        public List<string> listFichiersProjet { get; private set; }
        #endregion

        #region Constructeur
        public Analyseur()
        {
            listFichiersProjet = new List<string>();
        }
        #endregion

        #region Méthode publique
        // Analyse des fichiers parcourus par l'explorateur
        public void AnalyserDossier(string chemin)
        {
            // RAZ des propriétés utiles à l'analyse
            NbTotalFichiers = 0;
            NbFichiersCs = 0;
            NomLePlusLong = string.Empty;
            listFichiersProjet.Clear();

            // Déclaration d'un délégué et branchement des méthodes nécessaires à l'analyse
            DelegueExplorateur delegExplo = null;
            delegExplo += CompterFichiers;
            delegExplo += AnalyserNom;
            delegExplo += FiltrerProjet;

            Explorateur.Explorer(chemin, delegExplo);
        }
        #endregion

        #region Méthodes privées
        // Compte le nombre total de fichiers et le nombre de fichiers cs
        private void CompterFichiers(FileInfo fichier)
        {
            NbTotalFichiers++;
            if (fichier.Extension.ToLower() == ".cs")
                NbFichiersCs++;
        }

        // Analyse les noms des fichiers et récupère le nom le plus long
        private void AnalyserNom(FileInfo fichier)
        {
            if (fichier.Name.Length > NomLePlusLong.Length)
                NomLePlusLong = fichier.Name;
        }

        // Filtre les fichiers .csproj et mémorise leur nom dans une liste
        private void FiltrerProjet(FileInfo fichier)
        {
            if (fichier.Extension.ToLower() == ".csproj")
                listFichiersProjet.Add(Path.GetFileNameWithoutExtension(fichier.Name));
        } 
        #endregion
    }
}
