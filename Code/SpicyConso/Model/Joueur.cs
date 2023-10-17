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
        public int JoueurHP;
        public bool JoueurEstMort;
        int largeurJoueur = 7;
        int hauteurJoueur = 2;
        public Joueur(int JoueurX, int JoueurY)
        {
            this.JoueurX = JoueurX;
            this.JoueurY = JoueurY;
            this.JoueurEstMort = false;
            this.JoueurHP = 20;
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
        public bool CollisionMissileAlien(MissileAlien missileAlien)
        {
            if (missileAlien.MissileX >= JoueurX && missileAlien.MissileX <= JoueurX + largeurJoueur && missileAlien.MissileY >= JoueurY && missileAlien.MissileY <= JoueurY + hauteurJoueur)
            {
                return true;
            }
            return false;
        }
        public void PrendreDegats(int degats)
        {
            JoueurHP -= degats;
            if (JoueurHP <= 0)
            {
                JoueurEstMort = true;
            }
        }
    }
}
