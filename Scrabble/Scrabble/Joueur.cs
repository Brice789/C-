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
    public class Joueur
    {

        #region Attributs
        private int score;
        private List<string> mots = new List<string>();
        private string nom;
        private List<Jeton> main = new List<Jeton>();

        #endregion


        #region Constructeur
        public Joueur(string pnom)
        {
            this.score = 0;
            this.nom = pnom;


        }
        #endregion

        /*
        public bool Contain(string mot) //Verifie si le mot est présent dans la liste de mot stocké
        {
            mot = mot.ToUpper();
            
            for (int i = 0; i < mots.Length; i++)
            {
                if (mot == mots[i])
                {
                    r true;
                }
            }
            
            
            return false;
            
             
        }

         */

        public void Add_Mot(string mot) // ajoute le mot dans la liste, utilisation de append
        {
            this.mots.Append(mot);
        }

        public void Add_Score(int val)
        {
            this.score += val;
        }

        public override string ToString() //qui retourne une chaîne de caractères qui décrit un joueur.
        {
                string listetexte = "";
                for (int i = 0; i < mots.Count; i++) listetexte += mots[i] + " ";
                return ("Pour le moment, " + this.nom + " a un score de " + this.score + " points grâce à la liste de mots trouvés suivante : " + listetexte);
        }

        

            public void Add_Main_Courante(Jeton monjeton)//qui ajoute un jeton à la main courante
            {
            this.main.Append(monjeton); 
            }

            public void Remove_Main_Courante(Jeton monjeton)//public void Remove_Main_Courante(Jeton monjeton)
            {
            this.main.Remove(monjeton);
            }

        

          


           
            
    }
}





/*

-Un joueur est caractérisé par son nom, son score et par les mots trouvés au cours de la partie

La création d’un joueur n’est possible que si celui-ci a un nom au départ du jeu. Le score et les mots
trouvés sont respectivement égal à 0 et null au départ du jeu.

Un autre constructeur permettra de prendre en entrée un fichier pour simuler une partie en cours
(exemple joueur.txt)

Vous créerez les propriétés en fonction des besoins de votre programme
Les méthodes suivantes sont imposées : (les signatures peuvent être ajustées en fonction de votre code)

    */