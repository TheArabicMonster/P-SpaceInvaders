using Model;

namespace Display
{
    public class Playground
    {
        /// <summary>
        /// constante qui contient la hauteur de l'écran
        /// </summary>
        public const int SCREEN_HEIGHT = 40;
        /// <summary>
        /// constante qui contient la largeur de l'écran
        /// </summary>
        public const int SCREEN_WIDTH = 150;
        /// <summary>
        /// sprite pour les aliens
        /// </summary>
        public static string[] AlienSprit =
        {
            @" /-~-\ ",
            @"|- # -|",
            @" \―v―/ ",
        };
        /// <summary>
        /// sprite du joueur
        /// </summary>
        public static string[] JoueurSprit =
        {
            @" _/-\_ ",
            @"|#####|",
        };

        //chaînes de caractères pour missiles du joueur et des aliens
        public static string MissileJoueurSprit1 = "‖";
        public static string MissileJoueurSprit2 = "║";
        public static string MissileAlienSprit1 = "█";
        //public static string MissileJoueurSprit3 = "▲";
        //public static string MissileJoueurSprit4 = "ꜛ";
        //public static string MissileJoueurSprit5 = "◊";

        /// <summary>
        /// 1. masque le curseur dans la console
        /// 2. définis la taille de la console en utilisant des constantes, si l'OS est Windows
        /// </summary>
        public static void Initalisation()
        {
            Console.CursorVisible = false;
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            }
        }
        /// <summary>
        /// 1. desinne un alien, si il est vivant, en fonction de ses coordonnées
        ///     si hp alien = 15, l'alien sera dessiner en vert
        ///     si hp alien = 10, l'alien sera dessiner en jaune foncé
        ///     si hp alien = 5, l'alien sera dessiner en rouge     
        /// 2. réinitialise la couleur de console
        /// </summary>
        /// <param name="alien"></param>
        public static void DessinerAlien(Alien alien)
        {
            //change la couleur de la console en fonction des hp des l'alien
            if (alien.AlienHP == 15) { Console.ForegroundColor = ConsoleColor.Green; }
            if (alien.AlienHP == 10) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
            if (alien.AlienHP == 5) { Console.ForegroundColor = ConsoleColor.Red; }

            if (!alien.AlienEstMort)//vérifie si l'alien est vivant
            {
                for (int i = 0; i < AlienSprit.Length; i++)
                {
                    //positionne le curseur en fonction du Y et du X de l'alien
                    Console.SetCursorPosition(alien.AlienX, alien.AlienY + i);
                    Console.WriteLine(AlienSprit[i]);
                }
            }
            //réinitialise la couleur de console
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// dessine le joueur en fonction de son X et son Y, en parcourant toute les lignes de son sprite
        /// </summary>
        /// <param name="joueur"></param>
        public static void DessinerJoueur(Joueur joueur)
        {
            if (joueur.JoueurHP == 15) { Console.ForegroundColor = ConsoleColor.Green; }
            if (joueur.JoueurHP == 10) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
            if (joueur.JoueurHP == 5) { Console.ForegroundColor = ConsoleColor.Red; }

            for (int j = 0; j < JoueurSprit.Length; j++)
            {
                Console.SetCursorPosition(joueur.JoueurX, joueur.JoueurY + j);
                Console.WriteLine(JoueurSprit[j]);
            }

            //réinitialise la couleur de console
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// dessine le missile du joueur en fonction de son X et de son Y
        /// </summary>
        /// <param name="missile"></param>
        public static void DessinerMissileDeclancher(MissileJoueur missile)
        {
            if (missile.MissileLancer)
            {
                Console.SetCursorPosition(missile.MissileX, missile.MissileY);
                Console.Write(MissileJoueurSprit2);
            }
        }
        /// <summary>
        /// dessine le missile des aliens en fonction de son X et de son Y
        /// </summary>
        /// <param name="missileAlien"></param>
        public static void DessinerMissileAlien(MissileAlien missileAlien)
        {
            if (missileAlien.MissileLancer)
            {
                Console.SetCursorPosition(missileAlien.MissileX, missileAlien.MissileY);
                Console.Write(MissileAlienSprit1);
            }
        }
    }
}