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
        }
        public void MissileActualise()
        {
            MissileY += 1;
            if (MissileY == Console.WindowHeight)
            {
                MissileLancer = false;
            }
        }
    }
}