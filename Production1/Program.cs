using System;

namespace Production1 {
    class Program {
        static void Main(string[] args) {

            //Explication des règles à l'utilisateur
            Console.WriteLine("Bienvenue dans le jeu du Mastermind.");
            Console.WriteLine("L'ordinateur va générer un code de quatre couleurs à partir de 8 couleurs disponibles.");
            Console.WriteLine("Votre but est de deviner ce code. Bonne chance !\n");

            //Génération du masterCode (Code à deviner)
            Code masterCode = new Code();
            masterCode.GenererCode();

            #region DEBUG
            //DEBUG Affichage du MasterCode
            //for (int i = 0; i < masterCode.ListCouleurs.Count; i++) {

            //    Console.WriteLine($"{masterCode.ListCouleurs[i]}");

            //}
            #endregion

            int nbEssais = 1;
            Code userCode = new Code();
            userCode.InitialiserCouleurs();
            string indice = "";

            do {

                //Une fois le premier essai terminé, faire ceci :
                if (nbEssais > 1) {

                    Console.WriteLine(indice);//Affichage de l'indice
                    userCode.AfficherListeCouleurs();//Affichage du dernier essai
                    userCode.ReinitialiserCouleurs();//Réinitialisation du userCode

                }

                //Affichage des couleurs disponibles
                masterCode.AfficherCouleursDisponibles();

                //Lecture des entrées utilisateur
                Console.WriteLine($"Essai numéro {nbEssais} :\n");
                userCode.ObtenirCouleur();

                nbEssais++;
                //Console.Clear();
                                
            } while (!(userCode.CorrectionReponse(masterCode, out indice)));//Tant que le userCode est différent du masterCode

            Console.WriteLine(indice);//Affichage de la félicitation
            Console.WriteLine($"Vous avez trouvé le Master Code en {nbEssais} essais !");//Affichage du nombre d'essais
            Console.ReadLine();//Permet d'avoir une pause avant que le programme se ferme

        }


        
    }


}
