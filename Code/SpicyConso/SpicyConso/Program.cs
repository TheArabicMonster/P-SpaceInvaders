using Display;
using Model;

int ChoixMenu = 0;
int CptAlien = 0;
bool ChoixJeux = true;
bool GameOver = false;
bool GameWin = false;
bool Recommencer = true;
ConsoleKeyInfo keyPressed;
ConsoleKeyInfo response;

Playground.Initalisation();
List<MissileAlien> MissileAlienASupprimer = new();
List<MissileJoueur> ListeMissilesJoueur = new();
List<MissileJoueur> MissilesASupprimer = new();
List<MissileAlien> ListeMissileAlien = new();
List<Alien> ListeAlien = new();

Menu menu = new();
Random random = new Random();


do
{
    Joueur joueur = new(Console.WindowWidth / 2, Console.WindowHeight - 10);
    for (CptAlien = 0; CptAlien < 10; CptAlien++)
    {
        ListeAlien.Add(new Alien(10 + CptAlien * 10, 3, 20));
    }

    if (ChoixMenu == 0)
    {
        Console.Clear();
        menu.DessinerMenuTitre();
        menu.DessinerMenuJouer();
        menu.DessinerMenuOption();
        menu.DessinerMenuScore();

        do
        {
            if (ChoixMenu == 1)
            {
                menu.DessinerMenuTitre();

                Console.ForegroundColor = ConsoleColor.Cyan;
                menu.DessinerMenuJouer();
                Console.ForegroundColor = ConsoleColor.White;

                menu.DessinerMenuOption();
                menu.DessinerMenuScore();
            }
            else if (ChoixMenu == 2)
            {
                menu.DessinerMenuTitre();
                menu.DessinerMenuJouer();

                Console.ForegroundColor = ConsoleColor.Cyan;
                menu.DessinerMenuOption();
                Console.ForegroundColor = ConsoleColor.White;

                menu.DessinerMenuScore();
            }
            else if (ChoixMenu == 3)
            {
                menu.DessinerMenuTitre();
                menu.DessinerMenuJouer();
                menu.DessinerMenuOption();

                Console.ForegroundColor = ConsoleColor.Cyan;
                menu.DessinerMenuScore();
                Console.ForegroundColor = ConsoleColor.White;
            }
            keyPressed = Console.ReadKey(true);

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
                case ConsoleKey.Spacebar:
                    MissileJoueur nouveauMissile = new MissileJoueur(joueur, 5);
                    ListeMissilesJoueur.Add(nouveauMissile);
                    break;
                case ConsoleKey.Enter:
                    if (ChoixMenu >= 1 && ChoixMenu <= 3)
                    {
                        ChoixJeux = false;
                    }
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Touche non valide. Utilisez les touches fléchées, Espace ou Échap.");
                    break;

            }
        } while (ChoixJeux);
    }

    if (ChoixMenu == 1) // Boucle pour afficher le jeu lui-même
    {
        ConsoleKeyInfo keyPressedGame;
        while (!GameOver && !GameWin)
        {
            Console.Clear();

            foreach (MissileJoueur missile in ListeMissilesJoueur)
            {
                //dessine tout les missiles du joueur contenu dans ListeMissilesJoueur
                Playground.DessinerMissileDeclancher(missile);
            }
            foreach (MissileAlien missileAlien in ListeMissileAlien)
            {
                //dessine tout les missiles aliens contenu dans ListeMissileAlien
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
                keyPressedGame = Console.ReadKey(true);
                switch (keyPressedGame.Key)
                {
                    case ConsoleKey.RightArrow:
                        joueur.DeplacementJoueurDroite();
                        break;
                    case ConsoleKey.LeftArrow:
                        joueur.DeplacementJoueurGauche();
                        break;
                    case ConsoleKey.Spacebar:
                        MissileJoueur nouveauMissile = new MissileJoueur(joueur, 5);
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

            foreach (MissileAlien missileAlien in ListeMissileAlien)
            {
                missileAlien.MissileActualiseAlien(missileAlien);
                if (joueur.CollisionMissileAlien(missileAlien))
                {
                    joueur.PrendreDegats(missileAlien.MissileDMG);
                    MissileAlienASupprimer.Add(missileAlien);
                }
            }

            foreach (MissileAlien missile in MissileAlienASupprimer)//supprimer les missiles qui ont toucher le joueur
            {
                ListeMissileAlien.Remove(missile);
            }

            foreach (Alien alien in ListeAlien)
            {
                alien.DeplacementDroiteAlien();
                alien.DeplacementGaucheAlien();

                int RandomNb = random.Next(1, 50);
                if (RandomNb == 1)
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
            Thread.Sleep(10);
            if (GameOver || GameWin)
            {
                if (GameWin)
                {
                    menu.DessinerGameWin();
                }
                if (GameOver)
                {
                    menu.DessinerGameOver();
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Voulez-vous rejouer ? (Appuyez sur 'y' pour Oui, ou 'N' pour Non)");
            }
        }
        do
        {
            response = Console.ReadKey();
            if (response.Key == ConsoleKey.Y)
            {
                ListeMissilesJoueur.Clear();
                ListeMissileAlien.Clear();
                ListeAlien.Clear();
                MissileAlienASupprimer.Clear();
                MissilesASupprimer.Clear();
                ChoixMenu = 0;
                ChoixJeux = true;
                GameOver = false;//set des 2 bool "game" en true pour ne pas re entrer dans la boucle du jeux en lui même
                GameWin = false;
                joueur.JoueurEstMort = false;
                Recommencer = false;
                break;
            }
            else if (response.Key == ConsoleKey.N)
            {
                Environment.Exit(0);
            }
        } while (Recommencer);
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