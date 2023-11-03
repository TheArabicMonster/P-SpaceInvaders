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
        public const int SCREEN_WIDTH = 150;
        /// <summary>
        /// constructeur de la classe Alien
        /// </summary>
        /// <param name="AlienX">Position X de l'alien sur l'écran</param>
        /// <param name="AlienY">Position Y de l'alien sur l'écran</param>
        /// <param name="AlienHP">Points de vie de l'alien</param>
        public Alien(int AlienX, int AlienY, int AlienHP)
        {
            this.AlienX = AlienX;
            this.AlienY = AlienY;
            this.AlienHP = AlienHP;
            this.AlienEstMort = false;
        }
        /// <summary>
        /// modifie le X de l'alien
        /// </summary>
        public void DeplacementDroiteAlien()
        {
            if (this.AlienDirection)
            {
                AlienX += 2;
                if (AlienX == SCREEN_WIDTH - 6)
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
                this.AlienX -= 2;
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
