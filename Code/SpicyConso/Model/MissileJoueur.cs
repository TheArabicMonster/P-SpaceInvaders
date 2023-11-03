namespace Model
{
    /// <summary>
    /// la classe MissileJoueur contient les caractéristiques basique du missiles joueur, ainsi que sa méthode de déplacement, et sa méthode pour savoir si le missile joueur touche un alien
    /// </summary>
    public class MissileJoueur : Missile
    {
        /// <summary>
        /// Initialise un nouveau missile joueur en fonction de la position du joueur.
        /// </summary>
        /// <param name="joueur">le joueur qui vas tirer un missile</param>
        public MissileJoueur(Joueur joueur, int MissileDMG)
        {
            this.MissileX = joueur.JoueurX + 3; //ajouter 3 au X du missile pour qu'il se lance au millieu du joueur
            this.MissileY = joueur.JoueurY; //ajouter 2 pour que le missile ne se lance pas dans le joueur
            this.MissileDMG = MissileDMG;
        }
        /// <summary>
        /// augemante de 1 le Y du missile joueur si il est lancer
        /// </summary>
        public void ActualiserMissile()
        {
            if (this.MissileY == 1)
            {
                this.MissileLancer = false;
            }
            if (MissileLancer) { this.MissileY -= 1; }
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