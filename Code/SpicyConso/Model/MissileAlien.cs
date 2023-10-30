using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
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
        /// <summary>
        /// Vérifie si un missile du joueur entre en collision avec un alien
        /// </summary>
        /// <param name="missile">Le missile du joueur à vérifier</param>
        /// <param name="alien">L'alien avec lequel vérifier la collision</param>
        /// <returns>True si une collision est détectée, sinon False</returns>
        public static bool CollisionMissileJoueurDansAlien(MissileJoueur missile, Alien alien)
        {
            if (missile.MissileX >= alien.AlienX && missile.MissileX <= alien.AlienX + 7 && missile.MissileY >= alien.AlienY && missile.MissileY <= alien.AlienY + 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}