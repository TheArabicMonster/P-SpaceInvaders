using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// la classe MissileAlien contient les caractéristiques basique du missiles alien, ainsi que sa méthode de déplacement
    /// </summary>
    public class MissileAlien : Missile
    {
        /// <summary>
        /// Initialise un nouveau missile alien en fonction de la position de l'alien
        /// </summary>
        /// <param name="alien">L'alien qui vas tirer un missile</param>
        /// <param name="MissileDMG">Dégats du missile que l'alien vas tirer</param>
        public MissileAlien(Alien alien)
        {
            this.MissileY = alien.AlienY + 3; //ajout de 3 pour que le missile se lance au milleu de l'alien
            this.MissileX = alien.AlienX + 3; //ajout de 3 pour que le missile ne se lance pas en l'alien
            this.MissileDMG = 5;
        }
        /// <summary>
        /// augemente de 1 la position du missile alien
        /// </summary>
        /// <param name="missileAlien"></param>
        public void MissileActualiseAlien(MissileAlien missileAlien)
        {
            //si le missile atteint les limites de la console, il n'est pas lancer
            if (this.MissileY == 39) //40 = console screen height
            {
                this.MissileLancer = false;
            }
            else if (this.MissileY < 39)
            {
                this.MissileY += 1;
            }
        }
    }
}