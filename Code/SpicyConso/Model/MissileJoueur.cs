using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MissileJoueur : Missile
    {
        /// <summary>
        /// Initialise un nouveau missile joueur en fonction de la position du joueur.
        /// </summary>
        /// <param name="joueur">le joueur qui vas tirer un missile</param>
        public MissileJoueur(Joueur joueur, int MissileDMG)
        {
            this.MissileX = joueur.JoueurX + 3; //ajouter 3 au X du missile pour qu'il se lance au millieu du joueur
            this.MissileY = joueur.JoueurY; //ajouter 2 pour que le missile ne se lance pas dans le joueur
            this.MissileDMG = MissileDMG;
        }
        /// <summary>
        /// augemante de 1 le Y du missile joueur si il est lancer
        /// </summary>
        public void ActualiserMissile()
        {
            if (this.MissileY == 1)
            {
                this.MissileLancer = false;
            }
            if (MissileLancer) { this.MissileY -= 1; }
        }
    }
}