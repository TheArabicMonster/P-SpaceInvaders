using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Missile
    {
        public int MissileX;
        public int MissileY;
        public bool MissileLancer = true;
        public bool MissileToucher = false;
        public Missile()
        {
            this.MissileX = MissileX;
            this.MissileY = MissileY;
            this.MissileLancer = MissileLancer;
        }
    }
}
