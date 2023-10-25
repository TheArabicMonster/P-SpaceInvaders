using Model;
using MySqlConnector;
using System.Diagnostics;

namespace Storage
{
    public class Store
    {
        //String pour se connecter au serveur 
        public static string dbConnexion = "Server=localhost;Port=8888;Database=db_space_invaders;User=root;Password=root;";
        //Commande MySQL pour savoir les top 5 meilleurs joueurs
        public static string commandeSQLTopJoueur = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
        //Commande MySQL pour ajouter le score et le pseudo du joueur dans la base de données
        public static string commandeSQLInsertScoreJoueur = "INSERT INTO t_joueur (jouNom, jouNombrePoints) VALUES (@jouPseudo, @scoreJoueur)";
        public static void StoreAlien(Alien alain)
        {
            Debug.WriteLine("C'est dans la db que je mets " + alain.ToString());
        }
        /// <summary>
        /// affiche les 5 meilleurs joueurs de la base de données
        /// </summary>
        public static void Afficher5TopJoueurs()
        {
            using (MySqlConnection connexion = new MySqlConnection(dbConnexion))
            {
                connexion.Open();

                using (MySqlCommand cmd = new MySqlCommand(commandeSQLTopJoueur, connexion))
                {

                    using (MySqlDataReader select = cmd.ExecuteReader())
                    {
                        while (select.Read())//Boucle pour afficher les meilleures joueurs 
                        {
                            int id = select.GetInt32("jouID");
                            string nom = select.GetString("jouNom");
                            int score = select.GetInt32("jouNombrePoints");
                            Console.WriteLine($"ID: {id}, Nom: {nom}, Points: {score}");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Méthode pour sauvgarder dans la base de données le score d'un joueur
        /// </summary>
        /// <param name="scoreJoueur">le score du joueur que l'ont vas sauvgarder</param>
        /// <param name="jouPseudo">le pseudo du joueur que l'ont vas sauvgarder</param>
        public static void SauvgarderScore(int scoreJoueur, string jouPseudo)
        {
            using (MySqlConnection connexion = new MySqlConnection(dbConnexion))
            {
                connexion.Open();//Se connecter à la base de données 

                using (MySqlCommand cmd = new MySqlCommand(commandeSQLInsertScoreJoueur, connexion))
                {
                    cmd.Parameters.AddWithValue("@pseudo", jouPseudo);
                    cmd.Parameters.AddWithValue("@score", scoreJoueur);
                    cmd.ExecuteNonQuery();

                    Console.SetCursorPosition(5, 0);
                    Console.WriteLine($"{jouPseudo} à sauvergder un score de : {scoreJoueur}.");
                }
            }
        }
    }
}