using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MissileAlien : Missile
    {
        public MissileAlien(Alien alien)
        {
            this.MissileY = alien.AlienY;
            this.MissileX = alien.AlienX;
            this.MissileLancer = MissileLancer;
            this.MissileDMG = 5;
        }
        public void MissileActualiseAlien(MissileAlien missileAlien)
        {
            this.MissileY += 1;
            if (this.MissileY == 40)//40 = console screen height
            {
                this.MissileLancer = false;
            }
        }
        public static bool CollisionMissileJoueurDansAlien(MissileJoueur missile, Alien alien)
        {
            if (missile.MissileX + 1 >= alien.AlienX && missile.MissileX <= alien.AlienX + 6 && missile.MissileY <= alien.AlienY + 2)
            {
                return true;
            }
            return false;
        }
    }
}