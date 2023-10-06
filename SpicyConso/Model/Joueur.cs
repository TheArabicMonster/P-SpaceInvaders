using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Joueur
    {
        List<MissileJoueur> ListeMissileJoueur = new List<MissileJoueur>();
        public int JoueurX;
        public int JoueurY;
        public bool JoueurEstMort;
        public Joueur(int JoueurX, int JoueurY)
        {
            this.JoueurX = JoueurX;
            this.JoueurY = JoueurY;
            this.JoueurEstMort = false;
        }
        public void DeplacementJoueurDroite()
        {
            JoueurX += 1;
            if (JoueurX == Console.WindowWidth - 3)
            {
                JoueurX = 0;
            }
        }
        public void DeplacementJoueurGauche()
        {
            JoueurX -= 1;
            if (JoueurX == 3)
            {
                JoueurX = 0;
            }
        }
        public void ChargementMissileJoueur(MissileJoueur missileJoueur)
        {
            this.ListeMissileJoueur.Add(missileJoueur);
        }
    }
}
