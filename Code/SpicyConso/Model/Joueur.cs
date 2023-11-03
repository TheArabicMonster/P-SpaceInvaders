namespace Model
{
    public class Joueur
    {
        List<MissileJoueur> ListeMissileJoueur = new List<MissileJoueur>();
        public int JoueurX;
        public int JoueurY;
        public int JoueurHP;
        public bool JoueurEstMort;
        int largeurJoueur = 7;
        int hauteurJoueur = 2;
        public const int SCREEN_WIDTH = 150;
        public const int SCREEN_HEIGHT = 40;
        /// <summary>
        /// Constructeur de la classe Joueur
        /// </summary>
        /// <param name="JoueurX">Position X du joueur</param>
        /// <param name="JoueurY">Position Y du joueur</param>
        /// <param name="JoueurHP">Points de vie du joueur</param>
        public Joueur(int JoueurX, int JoueurY)
        {
            this.JoueurX = JoueurX;
            this.JoueurY = JoueurY;
            this.JoueurEstMort = false;
            this.JoueurHP = 20;
        }
        /// <summary>
        /// augmente de 4 le X du joueur, si il n'est pas coller au bord de la console
        /// </summary>
        public void DeplacementJoueurDroite()
        {
            JoueurX += 4;
            if(JoueurX + 7 > SCREEN_WIDTH) { JoueurX = SCREEN_WIDTH - largeurJoueur; }
        }
        /// <summary>
        /// baisse de 4 le X du joueur, si il n'est pas coller au bord de la console
        /// </summary>
        public void DeplacementJoueurGauche()
        {
            JoueurX -= 4;
            if (JoueurX < 0) { JoueurX = 0; }
        }
        /// <summary>
        /// Ajoute un missile à la liste des missiles du joueur
        /// </summary>
        /// <param name="missileJoueur"></param>
        public void ChargementMissileJoueur(MissileJoueur missileJoueur)
        {
            this.ListeMissileJoueur.Add(missileJoueur);
        }
        /// <summary>
        /// Vérifie s'il y a une collision entre un missile alien et le joueur
        /// </summary>
        /// <param name="missileAlien"></param>
        /// <returns>True s'il y a collision, sinon False</returns>
        public bool CollisionMissileAlien(MissileAlien missileAlien)
        {
            if (missileAlien.MissileX >= JoueurX && missileAlien.MissileX <= JoueurX + largeurJoueur && missileAlien.MissileY >= JoueurY && missileAlien.MissileY <= JoueurY + hauteurJoueur)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Applique des dégâts au joueur et vérifie s'il est mort
        /// </summary>
        /// <param name="degats">dégats du missile qui a toucher le joueur</param>
        public void PrendreDegats(int degats)
        {
            JoueurHP -= degats;
            if (JoueurHP <= 0)
            {
                JoueurEstMort = true;
            }
        }
    }
}
