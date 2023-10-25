using Display;
using Model;
using Storage;

string jouPseudo = string.Empty;
int ChoixMenu = 0;
int CptAlien = 0;
int ChanceAlienTirer = 0;
int frameNumber = 0;
int scoreJoueur = 0;
bool ChoixJeux = true;
bool GameOver = false;
bool GameWin = false;
bool Recommencer = true;
bool quitter = false;
ConsoleKeyInfo keyPressed;
ConsoleKeyInfo response;
ConsoleKeyInfo key;

Playground.Initalisation();//Initialise la fenêtre de la console
List<MissileAlien> MissileAlienASupprimer = new();//Liste pour stocker les missiles aliens à supprimer
List<MissileJoueur> ListeMissilesJoueur = new();//Liste pour stocker les missiles du joueur
List<MissileJoueur> MissilesASupprimer = new();//Liste pour stocker les missiles du joueur à supprimer
List<MissileAlien> ListeMissileAlien = new();//Liste pour stocker les missiles aliens
List<Alien> ListeAlien = new();//Liste pour stocker les aliens

Menu menu = new();//Crée un nouvel objet Menu
Random random = new Random();


do
{
    quitter = false;
    jouPseudo = "";
    scoreJoueur = 0;
    Recommencer = true;
    Joueur joueur = new(Console.WindowWidth / 2, Console.WindowHeight - 10);//Crée un joueur au centre de la fenêtre
    //création de 10 aliens
    for (CptAlien = 0; CptAlien < 10; CptAlien++)
    {
        ListeAlien.Add(new Alien(10 + CptAlien * 10, 3, 20));
    }

    if (ChoixMenu == 0)//si ChoixMenu = 0, affichage du menu prinpiale
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

            if (frameNumber % 4 == 0)
            {
                Console.Clear();

                foreach (Alien alien in ListeAlien)
                {
                    //Dessine tout les aliens dans la liste ListeAlien
                    Playground.DessinerAlien(alien);
                }
                Playground.DessinerJoueur(joueur);
                foreach (MissileAlien missileAlien in ListeMissileAlien)
                {
                    //dessine tout les missiles aliens contenu dans ListeMissileAlien
                    Playground.DessinerMissileAlien(missileAlien);
                }
                foreach (MissileJoueur missile in ListeMissilesJoueur)
                {
                    //dessine tout les missiles du joueur contenu dans ListeMissilesJoueur
                    Playground.DessinerMissileDeclancher(missile);
                }
            }
            frameNumber++;

            if (Console.KeyAvailable)
            {
                keyPressedGame = Console.ReadKey(true);
                switch (keyPressedGame.Key) //switch pour savoir les interactions du joueur
                {
                    case ConsoleKey.RightArrow: //si flèche de droite, joueur se déplace à droite
                        joueur.DeplacementJoueurDroite();
                        break;
                    case ConsoleKey.LeftArrow: //si flèche de gauche, joueur se déplace à gauche
                        joueur.DeplacementJoueurGauche();
                        break;
                    case ConsoleKey.Spacebar: //si barre éspace, tire un missile
                        MissileJoueur nouveauMissile = new MissileJoueur(joueur, 5);
                        ListeMissilesJoueur.Add(nouveauMissile);
                        break;
                    case ConsoleKey.Escape: //si echap, quitte le programme
                        Environment.Exit(0);
                        break;
                }
            }

            if (frameNumber % 1 == 0)
            {
                foreach (MissileJoueur missile in ListeMissilesJoueur)
                {
                    missile.ActualiserMissile();

                    foreach (Alien alien in ListeAlien)
                    {
                        //si le missile du joueur touche un alien -> entre dans la boucle
                        if (MissileAlien.CollisionMissileJoueurDansAlien(missile, alien))
                        {
                            //soustrais des HP de l'aliens égale au dégats du MissileJoueur
                            alien.AlienHP -= missile.MissileDMG;
                            //si les HP de l'alien sont = 0, il est considérer comme mort
                            if (alien.AlienHP <= 0)
                            {
                                alien.AlienEstMort = true;
                                scoreJoueur += 25;
                            }
                            //ajout du missile qui a toucher l'alien dans la liste des missiles qui vont se faire supprimer
                            MissilesASupprimer.Add(missile);
                        }
                    }
                }
            }

            //Supprime tout les aliens qui ont des hp égale à 0
            ListeAlien.RemoveAll(alien => alien.AlienHP <= 0); //chatgpt m'a aider avec ca
            foreach (MissileJoueur missile in MissilesASupprimer)
            {
                //supprimer les missiles qui ont déjà toucher un alien
                ListeMissilesJoueur.Remove(missile);
            }

            if (frameNumber % 2 == 0)
            {
                foreach (MissileAlien missileAlien in ListeMissileAlien)
                {
                    missileAlien.MissileActualiseAlien(missileAlien);
                    //si le missile de l'alien touche le joueur il entre dans la boucle
                    if (joueur.CollisionMissileAlien(missileAlien))
                    {
                        //le missile de l'alien qui infliger des DMG au joueur
                        joueur.PrendreDegats(missileAlien.MissileDMG);
                        //ajout du missile alien à la liste des missiles aliens à supprimer
                        MissileAlienASupprimer.Add(missileAlien);
                    }
                }
            }
            //supprimer les missiles qui ont toucher le joueur
            foreach (MissileAlien missile in MissileAlienASupprimer)
            {
                ListeMissileAlien.Remove(missile);
            }
            if (frameNumber % 2 == 0)
            {
                foreach (Alien alien in ListeAlien)
                {
                    //bouge les aliens de droite à gauche dans la console
                    alien.DeplacementDroiteAlien();
                    alien.DeplacementGaucheAlien();
                }
            }

            if (frameNumber % 5 == 0)
            {
                foreach (Alien alien in ListeAlien)
                {
                    ChanceAlienTirer = random.Next(1, 51); //génère un nombre entre 1 et 50
                                                           //si le nombre crée est 1, l'alien tire
                    if (ChanceAlienTirer == 1)
                    {
                        MissileAlien nouveauMissilleAlien = new MissileAlien(alien);
                        ListeMissileAlien.Add(nouveauMissilleAlien);
                    }
                }
            }


            //si la joueur a tuer tout les aliens, le jeux deviens gaganer
            if (ListeAlien.Count == 0)
            {
                GameWin = true;
            }
            //si le joueur s'est fait toucher par trop de missiles enemis, le jeux deviens perdu
            if (joueur.JoueurEstMort)
            {
                GameOver = true;
            }

            Thread.Sleep(3); //timing
            //si le jeux est gagner ou perdu, il entre dans la boucle
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
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Appuyez sur echap pour passer ou entrer votre pseudo pour save votre score : ");

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Escape)//Si echap est appuyer, passe la boucle
                        {
                            quitter = true;
                        }
                        else if (key.Key == ConsoleKey.Enter)//Si enter est appuyer, soit score est save, soit si le pseudo n'est pas valide affiche un message d'erreur
                        {
                            if (!string.IsNullOrEmpty(jouPseudo))
                            {
                                Store.SauvgarderScore(scoreJoueur, jouPseudo);
                                quitter = false;
                            }
                            else
                            {
                                Console.SetCursorPosition(0, 2);
                                Console.WriteLine("Le pseudo ne doit pas être null");
                            }
                        }
                        else if (key.Key == ConsoleKey.Backspace)
                        {
                            //Retirer un caractère si Backspace est pressé
                            if (jouPseudo.Length > 0)
                            {
                                jouPseudo = jouPseudo.Substring(0, jouPseudo.Length - 1);
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.Write(new string(' ', Console.WindowWidth - 1));
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.Write(jouPseudo);
                            }
                        }
                        else
                        {
                            //Ajouter le caractère saisi au pseudo
                            jouPseudo += key.KeyChar;
                            Console.SetCursorPosition(20, 0);
                            Console.Write(key.KeyChar);
                        }
                    }
                    if (quitter) break;
                }
            }
        }
        do
        {
            Console.SetCursorPosition(0, 3);
            //Demande au joueur si il veux recommencer une partie ou quitter le programme
            Console.WriteLine("Voulez-vous rejouer ? (Appuyez sur 'y' pour Oui, ou 'N' pour Non)");
            response = Console.ReadKey();
            //si le joueur à appuyer sur "Y" il réinitialise les variable et clear les listes pour recommencer une partie
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
                quitter = false;
                jouPseudo = string.Empty;
                break;
            }
            //sinon, si il a appuyer sur "N" il quitte le programme
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
        Store.Afficher5TopJoueurs();
        Console.WriteLine("Appuyer sur échap pour revenir au menu principale");
        while (true)//si utilisateur appuie sur echap, 
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    ChoixJeux = true;
                    break; // Sort de la boucle lorsque Échap est pressé
                }
            }
        }
    } while (!ChoixJeux) ;

} while (true);