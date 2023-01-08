using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scrabble
{
    /* Ces jetons seront initialisés à partir du sac de jetons.
    Vous créerez les propriétés en fonction des besoins de votre programme
    Les méthodes suivantes sont imposées : (les signatures peuvent être ajustées en fonction de votre
    code) */
    public class Jeton
    {
        #region Attributs
        private char Lettre;
        private int Score;
        #endregion

        #region Constructeurs
        public Jeton(char pLettre, int pScore)
        {
            this.Lettre = pLettre;
            this.Score = pScore;
        }
        #endregion

        #region Getters Setters

        #region Lettre
        public char getLettre()
        {
            return this.Lettre;
        }
        #endregion

        #region Score
        public int getScore()
        {
            return this.Score;
        }
        #endregion

        #endregion

        #region Fonctions

        #region ToString
        public override string ToString() //qui retourne une chaîne de caractères qui décrit un jeton.
        {
            return "&&";
        }
        #endregion

        #endregion

        #region Méthodes

        #endregion
    }


}