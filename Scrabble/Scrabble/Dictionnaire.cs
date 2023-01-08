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
    public class Dictionnaire
    {

        #region Attributs
        private string langue;
        private string chemin;
        public  Dictionary<int, List<string>> motdico = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> dico = new Dictionary<int, List<string>>();

        #endregion


        #region Constructeurs
        //Une instance de dictionnaire associe un ensemble de mots avec une longueur déterminée ainsi qu’une langue.
        public Dictionnaire(string plangue, string pchemin)
        {
            this.langue = plangue;
            this.chemin = pchemin;
            initalisationDico();
            
            
        }
        #endregion
        public void initalisationDico()
        {
            string ln;
            StreamReader file = new StreamReader(this.chemin);
            int resultParse;
            int numberParsed = 0;
            bool isParsed;

            while ((ln = file.ReadLine()) != null)
            {
                isParsed = int.TryParse(ln, out resultParse);
                if (isParsed)
                {
                    //this.motdico.Add(numberParsed, new string[0]);
                    numberParsed = resultParse;
                    this.motdico[numberParsed] = new List<string>();
                }
                else
                {
                    this.motdico[numberParsed].AddRange(ln.Split(' '));
                }

            }
        }

       

        public bool RechercheDichoRecussif(Dictionary<int, List<string>>  dico, string mot )
        {
            bool result = false;
            int taille = mot.Length;
            if (this.motdico.Keys.ElementAt(taille) != 0)
            {
                List<string> court = new List<string>(dico[taille]);

                int size = court.Count ;
                int i = 0;
                while(size>i && court[i] != mot )
                {
                    i++;
                }
                if (size > i)
                {
                    result = true;
                }
            }
            return result;
        }
       

        
        //recherche dico recusive
        /*
        public bool Affiche()

        {
            foreach (int key in motdico.Keys)
            {
                foreach (string val in motdico[key])
                {
                    Console.WriteLival);
                }
            }
            return true;
        }



        public bool Afficheettrouve(string mot)

        {
            foreach (int key in motdico.Keys)
            {
                foreach (string val in motdico[key])
                {
                    if(val == mot)
                    {
                        string res = " ";
                        res  = "le mot trouvé est" + mot ;
                        Console.WriteLine(  res);
                    }
                }
            }
            return true;
        }


*/





        public override string ToString() //qui retourne une chaîne de caractères qui décrit le dictionnaire à savoir ici le nombre de mots par longueur et la langue
        {
            int nbmots = 0;
            string result = "";

            foreach (KeyValuePair<int, List<string>> element in motdico)
            {
                result += "\nNombre de mots pour la longuer " + element.Key + " : " + element.Value.Count;
                nbmots += element.Value.Count;
            }
            return "Ce dictionnaire comprend " + nbmots + " mots" + result + "\net la langue est " + this.langue;
        }


    }




        #region TODO

        

        


        /*/
        public string InfoDico2()
        {


            string s = "";
            for (int j = 2; j < 16; j++)
            {
                int compteur = 0;
                for (int i = 0; i < touslesmots.Count; i++)
                {
                    if (touslesmots[i].Length == j)
                    {
                        compteur++;
                    }

                }
                s = s + "il y a" + compteur + "mots de " + j + "lettres" + '\n';
            }
            return s;

        }

        public string InfoDico()
        {
            string[] ensemblemots = File.ReadAllLines("//Users//bricelewis//Desktop//Francais.csv");
            string s = "";
            //int countWords = ensemblemots.Split(' ').Length;

            for (int j = 2; j < 16; j++)
            {
                int compteur = 0;
                for (int i = 0; i < ensemblemots.Length; i++)
                {
                    if (ensemblemots[i] == " " )
                    {
                        compteur++;
                    }

                }
                s = s + "il y a" + compteur + "mots de " + j + "lettres" + '\n';
            }
            return s;

        }
        */
        #endregion
    /*
        public bool Comparaison(string mot1, string mot2)
        {
            bool res = false;
            if(mot1.ToUpper() == mot2.ToUpper())
            {
                res = true;
            }
            return res;
        }
    */

        /*
        public bool RechDichoRecursif(int debut, int fin, string mot) // qui teste que le mot appartient bien au dictionnaire
        {
            if (debut == fin)
            {
                if (ensemblemots[debut] == mot)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else if (mot.Length > ensemblemots[(debut + fin) / 2].Length || (mot.Length == ensemblemots[(debut + fin) / 2].Length) )
            {
                return RechDichoRecursif(((debut + fin) / 2), fin, mot);

            }
            else
            {
                return RechDichoRecursif(((debut + fin) / 2), fin, mot);

            }

        }*/



        /*
        public static string[] separation(string dico)
        {
            var words = new List<string>();
            int position = 0;
            int start = 0;
            do
            {
                position = dico.IndexOf(' ', start);
                if (position >= 0)
                {
                    words.Add(dico.Substring(start, position - start + 1).Trim());
                    start = position + 1;
                }
            } while (position > 0);

            //on creer notre tableau a partir de notre liste que lon vient de creer


            string[] tableau = new String[words.Count];
            for (int i = 0; i < tableau.Length; i++)
            {
                tableau[i] = words[i];
            }
            return tableau;

        } */

        /*

        public bool RechDichoRecursif(int debut, int fin, string mot, string[] tableau) // qui teste que le mot appartient bien au dictionnaire
        {

            if (debut == fin)
            {
                if (tableau[debut] == mot)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (mot.Length > tableau[(debut + fin) / 2].Length || (mot.Length.tableau[(debut + fin) / 2].Length && string.Compare(mot, tableau[(debut + fin) / 2].Length);
        }
        */
        /*
        public void dico()
        {
            string s = "BONJOUR";
            string[] lines = File.ReadAllLines("Francais.txt");
            Dictionnaire longeur2 = new Dictionnaire(lines[1].Split(' '), 2, "Français");
            Dictionnaire longeur3 = new Dictionnaire(lines[3].Split(' '), 3, "Français");

            Dictionnaire[] mondico = { longeur2, longeur3 };

        }
        */
        /*
        public bool RechDichoRecursif(int debut, int fin, string mot)
        {
            int milieu = (fin + debut) / 2;
            string find = dico[milieu];
        }

        public static int RechercheDichoRecursif(int debut, int fin, string[] t, int mot)
        {
            int milieu = (debut + fin) / 2;
            if (debut > fin || t == null || t.Length == 0) return -1;
            else
                if (mot == t[milieu])
                return milieu;
            else
                    if (mot > t[milieu])
                return RechercheDichoRecursif(milieu + 1, fin, t, Elt);
            else
                return RechercheDichoRecursif(debut, milieu - 1, t, Elt);


        }


        */



        



    
}
