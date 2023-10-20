using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display
{
    public class Menu
    {
        /// <summary>
        /// tableau pour afficher le titre du menu
        /// </summary>
        public string[] MenuTitre =
        {
            @" _____ ______   ___   _____  _____   _____  _   _  _   _   ___  ______  _____ ______ ",
            @"/  ___|| ___ \ / _ \ /  __ \|  ___| |_   _|| \ | || | | | / _ \ |  _  \|  ___|| ___ \",
            @"\ `--. | |_/ // /_\ \| /  \/| |__     | |  |  \| || | | |/ /_\ \| | | || |__  | |_/ /",
            @" `--. \|  __/ |  _  || |    |  __|    | |  | . ` || | | ||  _  || | | ||  __| |    / ",
            @"/\__/ /| |    | | | || \__/\| |___   _| |_ | |\  |\ \_/ /| | | || |/ / | |___ | |\ \ ",
            @"\____/ \_|    \_| |_/ \____/\____/   \___/ \_| \_/ \___/ \_| |_/|___/  \____/ \_| \_|",
        };
        /// <summary>
        /// tableau pour afficher le boutton "jouer" du menu
        /// </summary>
        public string[] MenuJouer =
        {
            @"   ___  _____  _   _  _____ ______ ",
            @"  |_  ||  _  || | | ||  ___|| ___ \",
            @"    | || | | || | | || |__  | |_/ /",
            @"    | || | | || | | ||  __| |    / ",
            @"/\__/ /\ \_/ /| |_| || |___ | |\ \ ",
            @"\____/  \___/  \___/ \____/ \_| \_|",
        };
        /// <summary>
        /// tableau pour afficher le boutton "option" du menu
        /// </summary>
        public string[] MenuOption =
        {
            @" _____ ______  _____  _____  _____  _   _ ",
            @"|  _  || ___ \|_   _||_   _||  _  || \ | |",
            @"| | | || |_/ /  | |    | |  | | | ||  \| |",
            @"| | | ||  __/   | |    | |  | | | || . ` |",
            @"\ \_/ /| |      | |   _| |_ \ \_/ /| |\  |",
            @" \___/ \_|      \_/   \___/  \___/ \_| \_/"
        };
        /// <summary>
        /// tableau pour afficher le boutton "score" du menu
        /// </summary>
        public string[] MenuScore =
        {
            @" _____  _____  _____ ______  _____ ",
            @"/  ___|/  __ \|  _  || ___ \|  ___|",
            @"\ `--. | /  \/| | | || |_/ /| |__  ",
            @" `--. \| |    | | | ||    / |  __| ",
            @"/\__/ /| \__/\\ \_/ /| |\ \ | |___ ",
            @"\____/  \____/ \___/ \_| \_|\____/ ",
        };
        /// <summary>
        /// tableau pour afficher "GameOver" en ascii art 
        /// </summary>
        public string[] GameOver =
        {
            @" _____                        _____                ",
            @"|  __ \                      |  _  |               ",
            @"| |  \/ __ _ _ __ ___   ___  | | | |_   _____ _ __ ",
            @"| | __ / _` | '_ ` _ \ / _ \ | | | \ \ / / _ \ '__|",
            @"| |_\ \ (_| | | | | | |  __/ \ \_/ /\ V /  __/ |   ",
            @" \____/\__,_|_| |_| |_|\___|  \___/  \_/ \___|_|   ",
        };
        /// <summary>
        /// tableau pour afficher "GameWin" en ascii art 
        /// </summary>
        public string[] GameWin =
        {
            @" _____                        _    _ _       ",
            @"|  __ \                      | |  | (_)      ",
            @"| |  \/ __ _ _ __ ___   ___  | |  | |_ _ __  ",
            @"| | __ / _` | '_ ` _ \ / _ \ | |/\| | | '_ \ ",
            @"| |_\ \ (_| | | | | | |  __/ \  /\  / | | | |",
            @" \____/\__,_|_| |_| |_|\___|  \/  \/|_|_| |_|",
        };

        public int MenuCount = 0;
        /// <summary>
        /// constructeur de la classe "Menu"
        /// </summary>
        public Menu()
        {
            this.MenuCount = 0;
        }
        /// <summary>
        /// dessine le titre du menu, en parcourant le tableau "MenuTitre" et affiche chaqu'une de ses lignes
        /// </summary>
        public void DessinerMenuTitre()
        {
            for (int i = 0; i < MenuTitre.Length; i++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 41, 2 + i);
                Console.WriteLine(MenuTitre[i]);
            }
        }
        /// <summary>
        /// dessine le boutton "jouer" du menu, en parcourant le tableau "MenuJouer" et affiche chaqu'une de ses lignes
        /// </summary>
        public void DessinerMenuJouer()
        {
            for (int j = 0; j < MenuJouer.Length; j++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 17, 12 + j);
                Console.WriteLine(MenuJouer[j]);
            }
        }
        /// <summary>
        /// dessine le boutton "option" du menu, en parcourant le tableau "MenuOption" et affiche chaqu'une de ses lignes
        /// </summary>
        public void DessinerMenuOption()
        {
            for (int k = 0; k < MenuOption.Length; k++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 19, 18 + k);
                Console.WriteLine(MenuOption[k]);
            }
        }
        /// <summary>
        /// dessine le boutton "score" du menu, en parcourant le tableau "MenuScore" et affiche chaqu'une de ses lignes
        /// </summary>
        public void DessinerMenuScore()
        {
            for (int o = 0; o < MenuScore.Length; o++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 16, 24 + o);
                Console.WriteLine(MenuScore[o]);
            }
        }
        /// <summary>
        /// 1. clear la console
        /// 2. dessine l'écran de victoire au milleu de l'écran, en parcourant le tableau "GameWin" et affiche chaqu'une de ses lignes
        /// </summary>
        public void DessinerGameWin()
        {
            Console.Clear();
            for(int i = 0; i < GameWin.Length; i++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 22, Playground.SCREEN_HEIGHT / 2 + i - 4);
                Console.WriteLine(GameWin[i]);
            }
        }
        /// <summary>
        /// 1. clear la console
        /// 2. dessine l'écran de défaite au milleu de l'écran, en parcourant le tableau "GameOver" et affiche chaqu'une de ses lignes
        /// </summary>
        public void DessinerGameOver()
        {
            Console.Clear();
            for (int i = 0; i < GameOver.Length; i++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 25, Playground.SCREEN_HEIGHT / 2 + i - 4);
                Console.WriteLine(GameOver[i]);
            }
        }
    }
}
