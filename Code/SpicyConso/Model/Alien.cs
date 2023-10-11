using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Alien
    {
        List<MissileAlien> MissileAlienChargement = new List<MissileAlien>();
        public int AlienX;
        public int AlienY;
        public int AlienHP;
        public bool AlienEstMort = false;
        public bool AlienDirection = true;
        public Alien(int AlienX, int AlienY, int AlienHP)
        {
            this.AlienX = AlienX;
            this.AlienY = AlienY;
            this.AlienHP = AlienHP;
            this.AlienEstMort = false;
        }
        public void DeplacementDroiteAlien()
        {
            if (this.AlienDirection)
            {
                AlienX += 1;
                if (AlienX == Console.WindowWidth - 6)
                {
                    this.AlienDirection = false;
                    this.AlienY += 5;
                }
            }
        }
        public void DeplacementGaucheAlien()
        {
            if (!this.AlienDirection)
            {
                this.AlienX -= 1;
                if (this.AlienX <= 2)
                {
                    this.AlienDirection = true;
                    this.AlienY += 5;
                }
            }
        }
        /// <summary>
        /// ajouter missile dans liste missileAlien
        /// </summary>
        /// <param name="missileAlien"></param>
        public void ChargementMissileAlien(MissileAlien missileAlien)
        {
            this.MissileAlienChargement.Add(missileAlien);
        }
    }
}
