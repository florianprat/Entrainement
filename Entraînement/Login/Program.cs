using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Program
    {
        //
        // Ce programme permet de saisir un login et un mot de passe lors de la création d'un compte.
        //

        static void Main(string[] args)
        {
            // Saisie du login et vérification de sa validité
            bool loginValide = false;
            string saisieLogin = string.Empty;

            while (!loginValide)
            {
                Console.WriteLine("Veuillez saisir un identifiant :");
                try
                {
                    saisieLogin = Console.ReadLine();
                    ValiderLogin(saisieLogin);
                    loginValide = true;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n" + e.Message);
                    Console.ResetColor();
                }
            }

            // Saisie du mot de passe et vérification de sa validité
            bool mdpValide = false;
            string saisieMdp = string.Empty;
            ConsoleKeyInfo touche;

            Console.WriteLine();

            while (!mdpValide)
            {
                Console.WriteLine("Veuillez saisir un mot de passe :");

                // On fait en sorte que la saisie soit sécurisée (on ne voit pas ce que tape l'utilisateur).
                do
                {
                    touche = Console.ReadKey(true);
                    saisieMdp += touche.KeyChar;
                    Console.Write("*");
                }
                while (touche.Key != ConsoleKey.Enter);

                try
                {
                    ValiderMdp(saisieMdp);
                    mdpValide = true;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n" + e.Message);
                    Console.ResetColor();
                }
            }

            // Message de création du compte
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nVotre compte a bien été créé. Un message vient de vous être envoyé.");
            Console.ResetColor();

            // Affichage des saisies pour vérification
            Console.WriteLine("\nPetite vérification pour voir si tout s'est bien passé.");
            Console.WriteLine(" - login saisi : " + saisieLogin);
            Console.WriteLine(" - mdp saisi : " + saisieMdp);

            Console.ReadKey();
        }

        // Test de la validité du login saisi
        // Le login doit comporter au moins 5 caractères.
        // Si ce n'est pas le cas, on lève une exception du type FormatException avec une description explicite.
        static void ValiderLogin(string log)
        {
            if (log.Length < 5)
                throw new FormatException("L'identifiant doit comporter au moins 5 caractères.");
        }

        // Test de la validité du mot de passe saisi
        // Le mot de passe doit comporter au moins 6 caractères, dont au moins 1 lettre et 1 chiffre.
        // Si une des conditions n'est pas remplie, on lève une exception du type FormatException avec une description explicite.
        static void ValiderMdp(string mdp)
        {
            // On gère les conditions au moins 1 lettre et au moins 1 chiffre avec des booléens.
            bool auMoinsUneLettre = false;
            bool auMoinsUnChiffre = false;

            // Le mot de passe doit comporter au moins 6 caractères.
            if (mdp.Length < 6)
                throw new FormatException("Le mot de passe doit comporter au moins 6 caractères, dont au moins 1 lettre et 1 chiffre.");

            foreach (var c in mdp)
            {
                // On accède au code ASCII du caractère courant.
                UInt16 codeASCII = Convert.ToUInt16(c);

                // Si le caractère courant est un chiffre, auMoinsUnChiffre passe true.
                if (codeASCII > 48 && codeASCII < 57) auMoinsUnChiffre = true;

                // Si le caractère courant est une lettre, auMoinsUneLettre passe true.
                if ((codeASCII > 65 && codeASCII < 90) || (codeASCII > 97 && codeASCII < 122)) auMoinsUneLettre = true;
            }

            // Levée d'une exception si pas au moins 1 chiffre ou au moins 1 lettre
            if (!(auMoinsUneLettre && auMoinsUnChiffre))
                throw new FormatException("\nLe mot de passe doit comporter au moins 6 caractères, dont au moins 1 lettre et 1 chiffre.");
        }
    }
}
