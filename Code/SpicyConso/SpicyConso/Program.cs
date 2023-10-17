using Display;
using Model;

bool ChoixJeux = true;
int ChoixMenu = 0;
bool GameOver = false;
bool GameWin = false;

Playground.Initalisation();
List<MissileJoueur> ListeMissilesJoueur = new();
List<MissileAlien> ListeMissileAlien = new();
List<Alien> ListeAlien = new();
Menu menu = new();
List<MissileJoueur> MissilesASupprimer = new();
List<MissileAlien> MissileAlienASupprimer = new();
Random random = new Random();
Joueur joueur = new(Console.WindowWidth / 2, Console.WindowHeight - 10);

for (int i = 0; i < 10; i++)
{
    ListeAlien.Add(new Alien(10 + i * 10, 3, 15));
}

do
{
    if (ChoixMenu == 0)
    {
        menu.DessinerMenuTitre();
        menu.DessinerMenuJouer();
        menu.DessinerMenuOption();
        menu.DessinerMenuScore();
        do //boucle pour gerer le choix du menu du joueur
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch (keyPressed.Key)
            {
                case ConsoleKey.UpArrow:
                    if (ChoixMenu > 1)
                    {
                        ChoixMenu--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (ChoixMenu < 3)
                    {
                        ChoixMenu++;
                    }
                    break;
                case ConsoleKey.Enter:
                    ChoixJeux = false;//pour sortir de la boucle do while
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White; //afficher la couleur d'affiche de base
            if (ChoixMenu == 1)
            {
                Console.Clear();
                menu.DessinerMenuTitre();

                Console.ForegroundColor = ConsoleColor.Cyan;
                menu.DessinerMenuJouer();
                Console.ForegroundColor = ConsoleColor.White;

                menu.DessinerMenuOption();
                menu.DessinerMenuScore();
            }
            else if (ChoixMenu == 2)
            {
                Console.Clear();
                menu.DessinerMenuTitre();
                menu.DessinerMenuJouer();

                Console.ForegroundColor = ConsoleColor.Cyan;
                menu.DessinerMenuOption();
                Console.ForegroundColor = ConsoleColor.White;

                menu.DessinerMenuScore();
            }
            else if (ChoixMenu == 3)
            {
                Console.Clear();
                menu.DessinerMenuTitre();
                menu.DessinerMenuJouer();
                menu.DessinerMenuOption();

                Console.ForegroundColor = ConsoleColor.Cyan;
                menu.DessinerMenuScore();
                Console.ForegroundColor = ConsoleColor.White;
            }
        } while (ChoixJeux);
    }

    if (ChoixMenu == 1) // Boucle pour afficher le jeu lui-même
    {
        ConsoleKeyInfo keyPressed;
        while (!GameOver || !GameWin)
        {
            Console.Clear();

            foreach (MissileJoueur missile in ListeMissilesJoueur)
            {
                Playground.DessinerMissileDeclancher(missile);
            }
            foreach(MissileAlien missileAlien in ListeMissileAlien)
            {
                Playground.DessinerMissileAlien(missileAlien);
            }
            foreach (Alien alien in ListeAlien)
            {
                //Dessine tout les aliens dans la liste ListeAlien
                Playground.DessinerAlien(alien);
            }
            Playground.DessinerJoueur(joueur);

            if (Console.KeyAvailable)
            {
                keyPressed = Console.ReadKey(true);
                switch (keyPressed.Key)
                {
                    case ConsoleKey.RightArrow:
                        joueur.DeplacementJoueurDroite();
                        break;
                    case ConsoleKey.LeftArrow:
                        joueur.DeplacementJoueurGauche();
                        break;
                    case ConsoleKey.Spacebar:
                        MissileJoueur nouveauMissile = new MissileJoueur(joueur);
                        ListeMissilesJoueur.Add(nouveauMissile);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }

            foreach (MissileJoueur missile in ListeMissilesJoueur)
            {
                missile.ActualiserMissile();

                foreach (Alien alien in ListeAlien)
                {
                    if (MissileAlien.CollisionMissileJoueurDansAlien(missile, alien))
                    {
                        if (MissilesASupprimer.Contains(missile))
                        {
                            missile.MissileDMG = 0;
                        }
                        alien.AlienHP -= missile.MissileDMG;
                        if (alien.AlienHP <= 0)
                        {
                            alien.AlienEstMort = true;
                        }
                        MissilesASupprimer.Add(missile);
                    }
                }
            }
            ListeAlien.RemoveAll(alien => alien.AlienHP <= 0); //chatgpt m'a aider avec ca
            foreach (MissileJoueur missile in MissilesASupprimer)
            {
                ListeMissilesJoueur.Remove(missile);
            }

            foreach(MissileAlien missileAlien in ListeMissileAlien)
            {
                missileAlien.MissileActualiseAlien(missileAlien);
                if (joueur.CollisionMissileAlien(missileAlien))
                {
                    joueur.PrendreDegats(missileAlien.MissileDMG);
                    MissileAlienASupprimer.Add(missileAlien);
                }
            }
            foreach(MissileAlien missile in MissileAlienASupprimer)//supprimer les missiles qui ont toucher le joueur
            {
                ListeMissileAlien.Remove(missile);
            }

            foreach (Alien alien in ListeAlien)
            {
                alien.DeplacementDroiteAlien();
                alien.DeplacementGaucheAlien();

                int RandomNb = random.Next(1, 50);
                if(RandomNb == 1)
                {
                    MissileAlien nouveauMissilleAlien = new MissileAlien(alien);
                    ListeMissileAlien.Add(nouveauMissilleAlien);
                }
            }
            if (ListeAlien.Count == 0)
            {
                GameWin = true;
            }
            if (joueur.JoueurEstMort)
            {
                GameOver = true;
            }
            Thread.Sleep(100);

            if (GameOver || GameWin)
            {
                break;
            }
        }
    }
    if (GameWin)
    {
        menu.DessinerGameWin();
    }
    if (GameOver)
    {
        menu.DessinerGameOver();
    }

    if (ChoixMenu == 2)//afficher les options du jeux
    {

    } while (!ChoixJeux) ;
    if (ChoixMenu == 3)//afficher le menu score
    {

    } while (!ChoixJeux) ;

} while (true);

/*uint frameNumber=0; // count the number of frames displayed

Alien alain = new Alien(0,0);

Playground.Initalisation();

while (true)
{
    // Actions de l'utilisateur
    if (Console.KeyAvailable) // L'utilisateur a pressé une touche
    {
        ConsoleKeyInfo keyPressed = Console.ReadKey(false);
        switch (keyPressed.Key)
        {
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }

    // Déplacement au niveau du modèle (état)
    alain.Move();

    // Affichage
    Playground.Clear();
    Playground.DrawAlien(alain);
    frameNumber++;

    // Autosave
    if (frameNumber % 1000 == 0 )
    {
        Store.StoreAlien(alain);
    }

    // Timing
    Thread.Sleep(100);
}*/