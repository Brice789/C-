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
    class MainClass
    {
        static Dictionnaire mondico;
        static Dictionnaire dico;
       
        public static void Main(string[] args)
        {
            string[,] matrice = new string[15, 15];

            
            //AfficherMatrice(matrice);

            Plateau plt = new Plateau("InstancePlateau.txt");
            DateTime dt2 = new DateTime(0);

            DateTime date1 = new DateTime(1, 1, 1, 0, 0, 1);

            TestTime(DateTime.Now, date1, 1);


            //Plateau.Maine();
            //Sac_Jetons sac = new Sac_Jetons("Jetons.txt");
            //Console.WriteLine(sac.ToString());

            mondico = new Dictionnaire("Français", "Francais.txt");
            //Console.WriteLine(mondico.ToString());

            dico = new Dictionnaire("Français", "Francais.txt");


            Console.WriteLine(dico.RechercheDichoRecussif(dico.motdico, "BATEAU" ));


            //Console.WriteLine(mondico.Affiche());

            /*
            //string contenu = File.ReadAllText("//Users//bricelewis//Desktop//Jetons.csv");
            string[] contenu = File.ReadAllLines("//Users//bricelewis//Desktop//Francais.csv");
            foreach (string line in contenu)
            Console.WriteLine(line);

            //Console.WriteLine("parite" + contenu[25]);

            string ad = "My name is ABC XYZ";

            int l = ad.Length; //18 chars;

            int w = ad.Split(' ').Count(); //5 words 

            //Console.WriteLine(w);
            int[] s = { 1, 2, 1, 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int[] s11 = null;
            int[] s21 = null;


            //Console.WriteLine(InfoDico());

            //Dictionnaire mondico = new Dictionnaire();


            //Console.WriteLine(Dictionnaire.InfoDico());


            melangepile(s1, s2);

              Stack<int> s1 = new Stack<int>(10);
                for (int i = 1; i < 4; i++) s1.Push(i);
               Stack<int> s2 = new Stack<int>(10);
               for (int i = 11; i < 14; i++) s2.Push(i);
               Stack<int> s3 = melange(s1, s2);

               for (int i = 0; i < s3.Count; i++)
               Console.WriteLine(s3.ElementAt<int>(i));

               s1.Clear();
               if (s1 == null) Console.WriteLine("ok"); else Console.WriteLine("nok");

            */

            //AfficherMatrice(plt.getTab());
            TestTime(DateTime.Now, dt2, 0.1);
            Console.ReadKey();
        }

        static void AfficherMatrice(char[,] matrice)
        {
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    Console.Write(matrice[i, j]);
                }
                Console.WriteLine();
            }
        }
        //Melange qui prend en arguments 2 piles et qui mélange leurs éléments dans une 3 ème pile de la façon suivante : tant qu’une pile au moins n’est pas
        //vide, on retire aléatoirement unélément au sommet d’une des 2 piles et on l’empile sur la pile résultat.


        //ici on veut une fonction que prend 1 pile et on rajoute un élément dans au moins 2 autres piles (idealement, on veut determiner le nombre de pile à l'avance...

        static Stack<int> melange(Stack<int> s1, Stack<int> s2)
        {
            Stack<int> s = new Stack<int>();

            Random r = new Random();

            Stack<int> st = null;

            while (s1.Count != 0 || s2.Count != 0)
            {
                int n = r.Next(1, 3);
                if (n == 1) st = s1; else st = s2;
                if (s1.Count == 0) s.Push(s2.Pop());
                else
                    if (s2.Count == 0) s.Push(s1.Pop());
                else s.Push(st.Pop());
            }
            return s;

        }
        //empiler un élément : void tas.Push (char item)

        //dépiler et renvoyer l’élément du dessus de la pile : char tas.Pop ( ) 

        static Stack<int> melangepile(Stack<int> s1  , Stack<int> s2 )
        {
            Stack<int> s = new Stack<int>();
            
            Random r = new Random();

            int nbmelange = 4;

            while(s.Count != 0)
            {
                int n = r.Next(1,nbmelange);

                for(int i = 0; i < nbmelange; i ++)
                {
                    if (i == 0) s = s1;
                    if (i == 1) s = s2;
                    if (i == 2) s = s1;
                    if (i == 3) s = s2;

                    if (s1.Count < 7) s.Push(s1.Pop());
                    else
                        if (s2.Count <7) s.Push(s2.Pop());

                }

            }

            Console.WriteLine("la pile 1 est " + s1);
            Console.WriteLine("la pile 2 est " + s2);
            return s;

        }


        static void AfficherMatriceCaractere(char[,] matrice)
        {
            if(matrice == null)
            {
                Console.WriteLine("matrice null)");

            }
            else
            {
                int dim1 = matrice.GetLength(0);
                int dim2 = matrice.GetLength(1);
                if(dim1 == 0 || dim2 == 0)
                {
                    Console.WriteLine("matrice vide");
                }
                else
                {
                    int b = 0;
                    int c = 0;
                    while(c<dim2 && b<dim1)
                    {
                        while (c<dim2)
                        {
                            Console.WriteLine(matrice[b,c]);
                            Console.WriteLine(" ");
                            c += 1;
                        }
                        Console.WriteLine(" ");
                        b += 1;
                        c = 0;
                    }
                }
            }
        }

        static bool TestTime(DateTime Date1, DateTime Date2, double max)
        {
            TimeSpan interval = Date2 - Date1;

            if (interval.Minutes > max)
            {
                return false;
            }
            return true;
        }

        




    }
}



/*

La classe Jeu possède 3 attributs : Un tableau de Dictionnaire ‘’mondico’’ , un plateau ‘’monplateau’’
et un sac de jetons ‘’monsac_jetons’’
 ‘’mondico’’ sera instancié par la lecture du fichier donné en pièce jointe : Francais.txt. Prenez
le temps d’analyser la construction de ce fichier 


 ‘’monplateau’’ sera instancié en fonction
 ‘’monsac_jetons‘’ instancié à partir d’un fichier initial ou d’une partie en cours
Le programme principal Main va donc à tour de rôle donner la main à un joueur puis à un autre
pendant un laps de temps à définir (6mn par exemple). A chaque tour, les joueurs complètent leur
main de telle manière à avoir toujours 7 jetons.
Chaque joueur a X minutes (voir la classe DateTime et TimeSpan) pour trouver un mot à partir de sa
main. X étant à définir au début du jeu.
A la fin du temps imparti, le joueur suivant prend la main.
Le jeu est terminé quand il n’y a plus de jetons dans le sac. Vous affichez alors le score définitif et
désigner le vainqueur
Vous pouvez arrêter le jeu au bout d’un laps de temps et sauvegarder l’instance du jeu dans des
fichiers selon les critères proposés en mode lecture. Vous affichez les scores temporaires de chacun
des joueurs. 
   */


//Lire un fichier et le transposer en tableau
//LE FICHER FRANCAIS A 28 LIGNES ET LE DOSSSIER JETONS EN A 27
//