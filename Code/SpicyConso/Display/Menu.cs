using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display
{
    public class Menu
    {
        public string[] MenuTitre =
        {
            @" _____ ______   ___   _____  _____   _____  _   _  _   _   ___  ______  _____ ______ ",
            @"/  ___|| ___ \ / _ \ /  __ \|  ___| |_   _|| \ | || | | | / _ \ |  _  \|  ___|| ___ \",
            @"\ `--. | |_/ // /_\ \| /  \/| |__     | |  |  \| || | | |/ /_\ \| | | || |__  | |_/ /",
            @" `--. \|  __/ |  _  || |    |  __|    | |  | . ` || | | ||  _  || | | ||  __| |    / ",
            @"/\__/ /| |    | | | || \__/\| |___   _| |_ | |\  |\ \_/ /| | | || |/ / | |___ | |\ \ ",
            @"\____/ \_|    \_| |_/ \____/\____/   \___/ \_| \_/ \___/ \_| |_/|___/  \____/ \_| \_|",
        };
        public string[] MenuJouer =
        {
            @"   ___  _____  _   _  _____ ______ ",
            @"  |_  ||  _  || | | ||  ___|| ___ \",
            @"    | || | | || | | || |__  | |_/ /",
            @"    | || | | || | | ||  __| |    / ",
            @"/\__/ /\ \_/ /| |_| || |___ | |\ \ ",
            @"\____/  \___/  \___/ \____/ \_| \_|",
        };
        public string[] MenuOption =
        {
            @" _____ ______  _____  _____  _____  _   _ ",
            @"|  _  || ___ \|_   _||_   _||  _  || \ | |",
            @"| | | || |_/ /  | |    | |  | | | ||  \| |",
            @"| | | ||  __/   | |    | |  | | | || . ` |",
            @"\ \_/ /| |      | |   _| |_ \ \_/ /| |\  |",
            @" \___/ \_|      \_/   \___/  \___/ \_| \_/"
        };
        public string[] MenuScore =
        {
            @" _____  _____  _____ ______  _____ ",
            @"/  ___|/  __ \|  _  || ___ \|  ___|",
            @"\ `--. | /  \/| | | || |_/ /| |__  ",
            @" `--. \| |    | | | ||    / |  __| ",
            @"/\__/ /| \__/\\ \_/ /| |\ \ | |___ ",
            @"\____/  \____/ \___/ \_| \_|\____/ ",
        };
        public int MenuCount = 0;
        public Menu()
        {
            this.MenuCount = 0;
        }
        public void DessinerMenuTitre()
        {
            for (int i = 0; i < MenuTitre.Length; i++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 41, 2 + i);
                Console.WriteLine(MenuTitre[i]);
            }
        }
        public void DessinerMenuJouer()
        {
            for (int j = 0; j < MenuJouer.Length; j++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 17, 12 + j);
                Console.WriteLine(MenuJouer[j]);
            }
        }
        public void DessinerMenuOption()
        {
            for (int k = 0; k < MenuOption.Length; k++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 19, 18 + k);
                Console.WriteLine(MenuOption[k]);
            }
        }
        public void DessinerMenuScore()
        {
            for (int o = 0; o < MenuScore.Length; o++)
            {
                Console.SetCursorPosition(Playground.SCREEN_WIDTH / 2 - 16, 24 + o);
                Console.WriteLine(MenuScore[o]);
            }
        }
    }
}
