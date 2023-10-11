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
        public int MissileDMG;
        public bool MissileLancer = true;
        public bool MissileToucher = false;
        public Missile()
        {
            this.MissileDMG = MissileDMG;
            this.MissileX = MissileX;
            this.MissileY = MissileY;
            this.MissileLancer = MissileLancer;
        }
    }
}