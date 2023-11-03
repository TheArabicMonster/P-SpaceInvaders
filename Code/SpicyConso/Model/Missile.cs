using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// la classe Missile contient les caractéristiques de base du missile pour les hériters au autres missiles
    /// </summary>
    public class Missile
    {
        public int MissileX;
        public int MissileY;
        public int MissileDMG;
        public bool MissileLancer = true;
        public bool MissileToucher = false;
        /// <summary>
        /// Constructeur de la classe Missile
        /// </summary>
        public Missile()
        {
            this.MissileDMG = MissileDMG;
        }
    }
}