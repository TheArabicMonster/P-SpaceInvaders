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
            this.MissileX = joueur.JoueurX;
            this.MissileY = joueur.JoueurY;
            this.MissileLancer = MissileLancer;
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