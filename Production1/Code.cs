using System;
using System.Collections.Generic;

namespace Production1 {
    public struct Code {

        public List<Couleurs> ListCouleurs;

        /// <summary>
        /// Génération d'un code à 4 couleurs non identiques (pas de doublons)
        /// </summary>
        public void GenererCode() {

            int randomObtenu;
            ListCouleurs = new List<Couleurs>();
            Random randomNumber;

            while (ListCouleurs.Count < 4) {    //Tant que la liste contient moins de 4 éléments

                randomNumber = new Random();
                randomObtenu = randomNumber.Next(0, 8); //Obtention d'un nombre entre 0 et 7
                Couleurs nouvCouleur = (Couleurs)Enum.Parse(typeof(Couleurs), randomObtenu.ToString()); //Sauvegarde de la couleur correspondant au nombre aléatoire reçu

                if (!ListCouleurs.Contains(nouvCouleur)) {  //SI la nouvelle couleur n'est pas dans le tableau

                    ListCouleurs.Add(nouvCouleur);

                }

            }

        }

        /// <summary>
        /// Affichage des couleurs disponibles dans l'enum Couleurs
        /// </summary>
        public void AfficherCouleursDisponibles() {

            string message = "Couleurs disponibles : ";

            for (int i = 0; i < 8; i++) {
                message += $"{(Couleurs)Enum.Parse(typeof(Couleurs), i.ToString())} ";
            }

            Console.WriteLine(message);
        }

        /// <summary>
        /// Vérifie que la couleur choisie soit dans l'enum Couleurs et l'ajoute au code si c'est le cas. Sinon, renvoie un message explicatif.
        /// </summary>
        /// <param name="index">Numéro de la couleur (Index de la list ListCouleurs)</param>
        /// <returns></returns>
        public bool VerifierInput(string color) {

            //Vérifier si la couleur entrée est dans la liste
            //Si elle est dans la liste,
                //S'il ne l'a pas encore entré, je l'ajoute au code utilisateur et je renvoie un bool positif
                //Sinon, je renvoie un bool négatif, avec un message
            //Sinon, je renvoie un bool négatif

            if (Enum.TryParse<Couleurs>(color, out Couleurs couleurRecue)) {

                if (ListCouleurs.Contains(couleurRecue) && ListCouleurs.Count > 0) {

                    Console.WriteLine("Cette couleur est déjà sélectionnée. Essayez une autre couleur...");
                    return false;

                } else {

                    ListCouleurs.Add(couleurRecue);
                    Console.WriteLine("Couleur sélectionnée avec succès !");
                    return true;

                }

            } else {

                Console.WriteLine("Cette couleur n'est pas disponible...");
                return false;

            }

        }

        /// <summary>
        /// Récupère les couleurs entrées par l'utilisateur pour les rajouter à la liste de couleurs
        /// </summary>
        public void ObtenirCouleur() {

            string couleurLue;

            for (int i = 0; i < 4; i++) {//Tant que le code n'a pas 4 couleurs, en pratique.
                                
                do {//Faire

                    Console.WriteLine($"Couleur {i + 1} : ");//Couleur numéro : 
                    couleurLue = Console.ReadLine();//Obtenir couleur

                } while (!VerifierInput(couleurLue));//Tant que la couleur est incorrecte

            }

        }

        /// <summary>
        /// Crée la liste de couleurs
        /// </summary>
        public void InitialiserCouleurs() {

            ListCouleurs = new List<Couleurs>();

        }

        /// <summary>
        /// Réinitialise la liste de couleurs
        /// </summary>
        public void ReinitialiserCouleurs() {

            ListCouleurs.Clear();

        }

        /// <summary>
        /// Vérifie la réponse du userCode en le comparant au masterCode. Renvoie true si c'est correct, false si c'est incorrect. Accompage le bool par un message correspondant avec soit un indice, soit une félicitation!
        /// </summary>
        /// <param name="masterCode">masterCode à deviner</param>
        /// <param name="message">Message accompagnant le booléen. Indice si bool == false, Félicitation si bool == true</param>
        /// <returns></returns>
        public bool CorrectionReponse(Code masterCode, out string message) {

            int nbBonEndroit = 0;
            int nbMauvaisEndroit = 0;
            int i = 0;

            //Comparer le code à deviner par rapport au code utilisateur (Case 1 Utilisateur vs les 4 du MasterCode)
            //Si case 1 User == case 1 Master --> nbBonEndroit++
            //SINON SI case 2 User == case 1 Master --> nbMauvaisEndroit++

            foreach (Couleurs c in ListCouleurs) {

                if (c == masterCode.ListCouleurs[i]) {  //case {i} de userCode et case {i} de masterCode

                    nbBonEndroit++;

                } else if (masterCode.ListCouleurs.Contains(c)) {//Si c est dans le MasterCode, mais pas au bon endroit. Si on rentre ici, c'est que c est présent dans la liste, mais pas au bon endroit...

                    nbMauvaisEndroit++;

                }


                i++;

            }
            //Si nbBonEndroit == 4, alors, le code est correct !
            //Sinon, Montrer l'indice...

            if (nbBonEndroit == 4) {

                message = "Le code est correct! Bien joué !";
                return true; //Le code est correct, je renvoie une réponse positive !

            } else {

                message = $"Indices : {nbBonEndroit} couleur(s) au bon endroit, {nbMauvaisEndroit} couleur(s) au mauvais endroit...";
                return false; //Le code n'est pas correct, je renvoie une réponse négative...

            }

        }

        /// <summary>
        /// Affiche le contenu actuel du userCode
        /// </summary>
        public void AfficherListeCouleurs() {

            Console.Write("Essai Précédent : ");

            foreach (Couleurs couleurs in ListCouleurs) {

                Console.Write($"{couleurs} ");

            }
                Console.WriteLine();

        }

    }

    public enum Couleurs {
        Rouge = 0,
        Blanc = 1,
        Jaune = 2,
        Bleu = 3,
        Noir = 4,
        Vert = 5,
        Orange = 6,
        Brun = 7
    }
}
