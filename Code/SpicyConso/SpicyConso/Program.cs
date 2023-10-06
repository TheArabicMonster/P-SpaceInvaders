using Model;
using Display;
using System.Numerics;
using Storage;

bool ChoixJeux = true;
int ChoixMenu = 0;

List<MissileJoueur> ListeMissiles = new();
List<MissileAlien> ListeMissileAlien = new();
List<Alien> ListeAlien = new();
Menu menu = new();
Joueur joueur = new(Console.WindowWidth / 2, Console.WindowHeight - 3);
Playground.Initalisation();

for (int i = 0; i < 10; i++)
{
    ListeAlien.Add(new Alien(10 + i * 10, 3, 15));
}

menu.DessinerMenuTitre();
menu.DessinerMenuJouer();
menu.DessinerMenuOption();
menu.DessinerMenuScore();
do
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
    if(ChoixMenu == 1){
        Console.Clear();
        menu.DessinerMenuTitre();

        Console.ForegroundColor = ConsoleColor.Cyan;
        menu.DessinerMenuJouer();
        Console.ForegroundColor = ConsoleColor.White;

        menu.DessinerMenuOption();
        menu.DessinerMenuScore();
    }
    else if(ChoixMenu == 2){
        Console.Clear();
        menu.DessinerMenuTitre();
        menu.DessinerMenuJouer();

        Console.ForegroundColor = ConsoleColor.Cyan;
        menu.DessinerMenuOption();
        Console.ForegroundColor = ConsoleColor.White;

        menu.DessinerMenuScore();
    }
    else if(ChoixMenu == 3){
        Console.Clear();
        menu.DessinerMenuTitre();
        menu.DessinerMenuJouer();
        menu.DessinerMenuOption();

        Console.ForegroundColor = ConsoleColor.Cyan;
        menu.DessinerMenuScore();
        Console.ForegroundColor = ConsoleColor.White;
    }
} while (ChoixJeux);


if (ChoixMenu == 1) // Boucle pour afficher le jeu lui-même
{
    ConsoleKeyInfo keyPressed;
    while (!ChoixJeux)
    {
        // Mettez à jour la logique du jeu ici
        // Par exemple, déplacez les aliens, vérifiez les collisions, etc.

        Console.Clear();

        // Affichez les éléments du jeu ici, y compris les aliens
        foreach (Alien alien in ListeAlien)
        {
            alien.DeplacementDroiteAlien();
            Playground.DessinerAlien(alien);
            // Affichez chaque alien à sa position actuelle (alien.X, alien.Y)
        }

        // Gérez l'entrée utilisateur ici (déplacement du joueur, tir, etc.)
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

                    break;
            }
        }

        Playground.DessinerJoueur(joueur);
        Thread.Sleep(100);
    }
}

if (ChoixMenu == 2)
{

}while (!ChoixJeux);

if (ChoixMenu == 3)
{

}while(!ChoixJeux);




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