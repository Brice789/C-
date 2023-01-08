#region using
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
#endregion

namespace Scrabble
{
    public class Sac_Jetons
    {
        #region Attributs
        private Dictionary<Jeton, int> sac = new Dictionary<Jeton, int>();
        private string chemin;
        #endregion


        #region Constructeurs
        public Sac_Jetons(string pchemin)
        {
            this.chemin = pchemin;
            
            RemplirSacJeton();

        }
        #endregion

        #region Fonctions

        #endregion

        #region Methodes

        #region RemplirSac

        public void RemplirSacJeton()
        {
            StreamReader fileScanner = new StreamReader(this.chemin);
            int count = 0;
            string ln;

            while((ln = fileScanner.ReadLine()) != null)
            {
                string[]lnTableau = ln.Split(';');
                Jeton jetonSac = new Jeton(Convert.ToChar(lnTableau[0]), Convert.ToInt32(lnTableau[1]));

                this.sac.Add(jetonSac, Convert.ToInt32(lnTableau[2]));
            }
        }

        #endregion

        

        public Jeton Retire_Jeton(Random r) // cette fonction permet de tirer au hasard un jeton parmi les possibles.
        {
            // - utiliser le random
            // - this.sac

            int rand = r.Next(0, 26);
            while (this.sac.ElementAt(rand).Value == 0 )
            {
                rand = r.Next(0, 26);
            }
            this.sac[this.sac.Keys.ElementAt(rand)] = this.sac.ElementAt(rand).Value - 1;
            return this.sac.Keys.ElementAt(rand);
        }

        public override string ToString() //qui retourne une chaîne de caractères qui décrit en synthèse le contenu du Sac_Jetons.
        {
            string res = " ";
            string descriptionSac = "Le sac contient : ";
            foreach (KeyValuePair<Jeton, int> element in this.sac)
            {
                res = "\nLettre : " + element.Key.getLettre().ToString() + " Score : " + element.Key.getScore().ToString() + " Quantité : " + element.Value.ToString();
                descriptionSac += res;
            }
            return descriptionSac;
        }


    }
}



/*
Le sac de jetons est composé de l’ensemble des jetons (26 lettres de l’alphabet plus le joker *) et
initialisé par la lecture du fichier Jetons.txt au départ du jeu ou bien par un fichier en cours de partie
qui aura la même structure.
Une ligne du fichier caractérise une lettre, un score et le nombre de jetons identiques.
Exemple E, 1,15 la lettre E a un score de 1 et est dupliqué 15 fois.
Vous créerez les propriétés en fonction des besoins de votre programme
Les méthodes suivantes sont imposées : (les signatures peuvent être ajustées en fonction de votre
code)

*/
#endregion