using Microsoft.Data.SqlClient;

namespace OpenGate
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Afficher le Splash Screen de manière non-bloquante
            FormSplash splash = new FormSplash();
            splash.Show();
            splash.Refresh(); // Force l'affichage immédiat du texte

            string connectionString = "Data Source=172.26.0.1;Initial Catalog=PTUT;User ID=test;Password=test;Encrypt=False;TrustServerCertificate=False;";
            SqlConnection dbConnection = new SqlConnection(connectionString);

            try
            {
                // 2. Tenter l'ouverture de la DB
                dbConnection.Open();

                // Petit délai optionnel pour que l'utilisateur voit le message (ex: 1 sec)
                // System.Threading.Thread.Sleep(1000); 

                // 3. Fermer le splash et lancer le formulaire principal
                splash.Close();
                Application.Run(new Form1(dbConnection));
            }
            catch (Exception ex)
            {
                splash.Close();
                MessageBox.Show("Impossible de se connecter à la base de données :\n" + ex.Message,
                                "Erreur Critique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // L'application s'arrêtera ici car Application.Run n'est pas appelé
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open)
                    dbConnection.Close();
            }
        }
    }
}