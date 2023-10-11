using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MissileJoueur : Missile
    {
        public MissileJoueur(Joueur joueur)
        {
            this.MissileX = joueur.JoueurX + 3; //ajouter 3 au X du missile pour qu'il se lance au millieu du joueur
            this.MissileY = joueur.JoueurY;
            this.MissileLancer = MissileLancer;
            this.MissileDMG = 5;
        }
        public void ActualiserMissile()
        {
            this.MissileY -= 1;
            if(this.MissileY < 0)
            {
                this.MissileLancer = false;
            }
        }
    }
}