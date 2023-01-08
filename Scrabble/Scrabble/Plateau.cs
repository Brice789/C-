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
    public class Plateau
    {
        #region Attributs
        private const char Joker = '*';

        char[,] tab = new char[15, 15];
        string[] tab1;
        #endregion

        #region Constructeurs
        public Plateau(string path)
        {
            //this.tab1 = ptab1;
            this.tab = GetPlateauFile(path);
        }
        #endregion

        public static void Maine()
        {
            string path = "MyTest.txt";
             string[] createText = { "Hello", "And", "Welcome" }; // texte à enregistrer
                string createText2 = "H" ; // texte à enregistrer

                //File.WriteAllLines(path, createText); // écriture dans le fichier
                File.AppendAllText(path, createText2);
            
        }

        #region Fonctions et methodes
        public char[,] GetPlateauFile(string path)
        {
            string ln;
            char[,] tab = new char[15, 15];
            StreamReader fileScanner = new StreamReader(path);
            int ligne = 0;
            while ((ln = fileScanner.ReadLine()) != null)
            {
                //Console.WriteLine(ln);
                //char[] lnTableauChar = n  ew char[15];
                char[] lnTableauChar = ln.Replace(";", "").ToCharArray();
                /*/
                string affichage = "";
                for (int i = 0; i < lnTableauChar.Length; i++)
                {
                    affichage += lnTableauChar[i].ToString();
                }
                */
                /*foreach(string charachter in lnTableauString)
                {
                    lnTableauChar.Append(Convert.ToChar(charachter));
                    Console.WriteLine(lnTableauChar.ToString());
                }*/

                for (int colonne = 0; colonne < lnTableauChar.Length; colonne++)
                {
                    tab[ligne, colonne] = lnTableauChar[colonne];
                }

                ligne++;


            }
            return tab;
        }


         
        

        public char[,] Test_Plateau2(string mot, int ligne, int colonne, int direction) //qui teste si le mot passé en paramètre est un mot éligible aux positions ligne et colonne et dans la direction indiquée
        {

           // char[] WordArray = mot.ToCharArray();


            for (int i = 0; i < mot.Length; i++)
            {
                if (direction == 0)
                {
                    tab[ligne, colonne + i] = mot[i];
                }
                else if (direction == 1)
                {
                    tab[ligne + i, colonne] = mot[i];
                }

            }
            //ecrire le tab
            return tab;
        }


        public int nb_lettre(string lettre, string[] tab) // fontion auxiliaire à Test_Plateau, et permet de compter le nombre de fois qu'apparait une certaine lettre sur le plateau de jeu
        {
            int compteur = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                if (lettre == tab[i])
                {
                    compteur = compteur + 1;
                }
            }
            return compteur;
        }


        public List<int> emplacement(string lettre, string[] tab) // fontion auxiliaire à Test_Plateau, et permet de déterminer les positions où apparait une certaine lettre sur le plateau de jeu
        {
            List<int> listemplacement = new List<int>();
            for (int i = 0; i < tab.Length; i++)
            {
                if (lettre == tab[i])
                {
                    listemplacement.Add(i);
                }
            }
            return listemplacement;
        }


        public override string ToString() //qui retourne une chaîne de caractères qui décrit le plateau.
        {
            return "j";
        }

        public static bool taillemot(string mot)
        {
            if (mot.Length < 1 || mot.Length > 15)
            {
                if (mot.Length < 1)
                {
                    Console.WriteLine("Le mot est trop petit");

                }
                else
                {
                    Console.WriteLine("Le mot est trop grand");

                }
                return false;
            }

            else
            {
                return true;
            }
        }

        public char[,] Test_Plateau232(string mot, int ligne, int colonne, int direction) //qui teste si le mot passé en paramètre est un mot éligible aux positions ligne et colonne et dans la direction indiquée
        {
            char[,] matrice = new char[15, 15];
            int WordSize = mot.Length;

            char[] WordArray = mot.ToCharArray();


            for (int i = 0; i < WordSize; i++)
            {
                if (direction == 0)
                {
                    tab[ligne, colonne + i] = WordArray[i];
                }
                else if (direction == 1)
                {
                    tab[ligne + i, colonne] = WordArray[i];
                }

            }
            return matrice;
        }

        public bool Test_Plateau(string mot, int ligne, int colonne, char direction) //qui teste si le mot passé en paramètre est un mot éligible aux positions ligne et colonne et dans la direction indiquée
        {
            return true;
        }

        public char[,] GetPlateau(string path)
        {
            string ln;
            char[,] tab = new char[15, 15];
            StreamReader fileScanner = new StreamReader(path);
            int ligne = 0;
            while ((ln = fileScanner.ReadLine()) != null)
            {

                //Console.WriteLine(ln);
                //char[] lnTableauChar = n  ew char[15];
                char[] lnTableauChar = ln.Replace(";", "").ToCharArray();
                //fileScanner.Write("jkfdnjf");
                //write.Close();
                /*/
                string affichage = "";
                for (int i = 0; i < lnTableauChar.Length; i++)
                {
                    affichage += lnTableauChar[i].ToString();
                }
                */
                /*foreach(string charachter in lnTableauString)
                {
                    lnTableauChar.Append(Convert.ToChar(charachter));
                    Console.WriteLine(lnTableauChar.ToString());
                }*/

                for (int colonne = 0; colonne < lnTableauChar.Length; colonne++)
                {
                    tab[ligne, colonne] = lnTableauChar[colonne];
                }

                ligne++;


            }
            return tab;
        }

        /*
        public bool Test_Plateau(string mot, int ligne, int colonne, char direction, List<string>) //qui teste si le mot passé en paramètre est un mot éligible aux positions ligne et colonne et dans la direction indiquée
        {
            int taille_mot = mot.Length;
            List<int[]> liste_emplacement = new List<int[]>();
            int[] emplacement = new int[2];
            for (int i = 0; i < taille_mot; i++)
            {
                if (direction == 'h')
                {
                    emplacement[0] = ligne;
                    emplacement[1] = colonne + i;
                    liste_emplacement.Add(emplacement);
                }
                else if (direction == 'v')
                {
                    emplacement[0] = ligne + i;
                    emplacement[1] = colonne;
                    liste_emplacement.Add(emplacement);

                }
                return true;
            }
            return true;

        }

        */
        #endregion

        #region Getters Setters

        #region Getters

        public char[,] getTab()
        {
            return this.tab;
        }

        #endregion
        #region Setters

        public void setTab(int x, int y, char value)
        {
            this.tab[x, y] = value;
        }
        #endregion
        #endregion

    }
}







/*
    Une instance de plateau est définie par une matrice 15x15. Deux cas doivent être pris en
considération :
 initialement vide avec les poids associés.
 Qui s’initialise avec une instance de plateau définie à partir d’un fichier (exemple
joint en annexe Plateau.txt)
Vous créerez les propriétés en fonction des besoins de votre programme
Les méthodes sont imposées : (les signatures peuvent être ajustées en fonction de votre code)

Un mot est éligible si
1. Il peut être placé sur le plateau en vertical ou horizontal
2. Il appartient au dictionnaire
3. Les lettres de la main utiles au mot appartiennent bien à la main
4. Tous les mots qui se croisent sont éligibles
Si le mot est éligible alors il faut calculer le score associé. Il faut préciser que
les mots ou lettres double ou triple ne sont valables que la première fois.
Vous pouvez évidemment vous inspirer du TD6 avec le labyrinthe pour concevoir votre
plateau 

   */