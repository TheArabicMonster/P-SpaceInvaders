using Model;

namespace Display
{
    public class Playground
    {
        public const int SCREEN_HEIGHT = 40;
        public const int SCREEN_WIDTH = 150;

        public static string[] AlienSprit =
        {
            @" /-~-\",
            @"|- # -|",
            @" \―v―/ ",
        };
        public static string[] JoueurSprit =
        {
            @" _/-\_ ",
            @"|#####|",
        };
        public static string Explosion = "";
        public static string MissileJoueurSprit0 = "";
        public static string MissileJoueurSprit1 = "‖";
        public static string MissileJoueurSprit2 = "║";
        public static string MissileJoueurSprit3 = "▲";
        public static string MissileJoueurSprit4 = "ꜛ";
        public static string MissileJoueurSprit5 = "◊";
        public static void Initalisation()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            //Console.SetWindowSize(100, 100);
        }

        public static void DessinerAlien(Alien alien)
        {
            // modifer le boom par un ascii art d'explosion
            if (!alien.AlienEstMort)
            {
                if (alien == null) return;
                for (int i = 0; i < AlienSprit.Length; i++)
                {
                    Console.SetCursorPosition(alien.AlienX, alien.AlienY + i);
                    Console.WriteLine(AlienSprit[i]);
                }
            }
        }
        public static void DessinerAlienMort(Alien alien)
        {
            if (alien.AlienEstMort)
            {
                for (int i = 0; i < AlienSprit.Length; i++)
                {
                    Console.SetCursorPosition(alien.AlienX, alien.AlienY + i);
                    Console.WriteLine(Explosion[i]);
                }
            }
        }

        public static void DessinerJoueur(Joueur joueur)
        {
            for (int j = 0; j < JoueurSprit.Length; j++)
            {
                Console.SetCursorPosition(joueur.JoueurX, joueur.JoueurY + j);
                Console.WriteLine(JoueurSprit[j]);
            }
        }
        public static void DessinerJoueurMort(Joueur joueur)
        {
            if (joueur.JoueurEstMort)
            {
                for (int j = 0; j < JoueurSprit.Length; j++)
                {
                    Console.SetCursorPosition(joueur.JoueurX, joueur.JoueurY + j);
                    Console.WriteLine(Explosion[j]);
                }
            }
        }

        public static void DessinerMissileDeclancher(MissileJoueur missile)
        {
            if (missile.MissileLancer)
            {
                if (missile == null)
                {
                    return;
                }
                Console.SetCursorPosition(missile.MissileX, missile.MissileY);
                Console.Write(MissileJoueurSprit0);
            }
        }
        public static void DessinerMissileAlien(MissileAlien missileAlien)
        {
            if (missileAlien.MissileLancer)
            {
                if (missileAlien == null)
                {
                    return;
                }
                Console.SetCursorPosition(missileAlien.MissileX + 3, missileAlien.MissileY);
                Console.Write("█");
            }
        }
    }
}