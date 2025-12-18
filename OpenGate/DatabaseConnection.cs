using System;
using MySql.Data.MySqlClient;

public class DatabaseConnection
{
    private string server;
    private string database;
    private string uid;
    private string password;

    // Constructeur
    public DatabaseConnection()
    {
        server = "172.23.200.245"; // Adresse IP de ton serveur MySQL
        database = "ptut"; // Remplace par le nom de ta base
        uid = "ptut"; // Utilisateur MySQL
        password = "ptut"; // Mot de passe MySQL
    }

    // Méthode pour obtenir une connexion ouverte
    public MySqlConnection GetConnection()
    {
        MySqlConnection connection = null;
        try
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connexion à la base de données réussie !");
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erreur de connexion : {ex.Message}");
            connection = null;
        }
        return connection;
    }

    // Méthode pour fermer la connexion
    public void CloseConnection(MySqlConnection connection)
    {
        if (connection != null)
        {
            connection.Close();
            Console.WriteLine("Connexion fermée.");
        }
    }
}
