using System.Data; // Nécessaire pour DataTable
using Microsoft.Data.SqlClient;

namespace OpenGate
{
    public partial class Form1 : Form
    {
        private readonly SqlConnection _connection;

        public Form1(SqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;

            // On charge les données dès l'ouverture
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            string sql = "SELECT * FROM PTUT.dbo.users;";

            try
            {
                // On s'assure que la connexion est ouverte
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                // Le SqlDataAdapter fait le pont entre la DB et la DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection))
                {
                    DataTable dataTable = new DataTable();

                    // Remplit la DataTable avec les résultats de la requête
                    adapter.Fill(dataTable);

                    // Lie la DataTable au DataGridView (le tableau s'affiche magiquement)
                    dataGridViewUsers.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du tableau : " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase(); // Permet de rafraîchir le tableau
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RefreshDisplay(string title, string sqlQuery)
        {
            try
            {
                // 2. On charge les données
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, _connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // 3. On lie au tableau
                dataGridViewUsers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        // BOUTON DASHBOARD (Vue d'ensemble)
        private void but_dashboard_Click(object sender, EventArgs e)
        {
            // Ici on peut afficher un résumé, ou juste la table des dernières activités
            RefreshDisplay("TABLEAU DE BORD", "SELECT TOP 10 * FROM PTUT.dbo.users ORDER BY id DESC");
        }

        // BOUTON UTILISATEURS
        private void but_users_Click(object sender, EventArgs e)
        {
            RefreshDisplay("GESTION DES UTILISATEURS", "SELECT User_ID, Name, Surname, Card_ID, Type, Actif FROM PTUT.dbo.users");
        }

        // BOUTON SALLES
        private void but_rooms_Click(object sender, EventArgs e)
        {
            RefreshDisplay("INVENTAIRE DES SALLES", "SELECT nom_salle AS 'Nom', etage AS 'Étage', type_salle AS 'Type' FROM dbo.salles");
        }

        // BOUTON AUTORISATIONS
        private void but_auth_Click(object sender, EventArgs e)
        {
            // Requête avec JOIN pour afficher les NOMS au lieu des IDs
            string sql = @"SELECT u.Name AS 'Utilisateur', s.nom_salle AS 'Salle', a.niveau_acces AS 'Niveau', a.date_expiration AS 'Expire le'
                   FROM dbo.authorisations a 

                   JOIN dbo.users u ON a.id_user = u.User_ID 
                   JOIN dbo.salles s ON a.id_salle = s.id_salle";

            RefreshDisplay("AUTORISATIONS D'ACCÈS", sql);
        }

        private void TableMenuAjouter_Click(object sender, EventArgs e)
        {
            
        }

        private void TableMenuSupp_Click(object sender, EventArgs e)
        {
            var test = dataGridViewUsers.SelectedRows;

            if (test != null)
            {
                foreach (var a in test)
                {
                    MessageBox.Show(a.ToString());
                    //String User = dataGridViewUsers[0, 0].Value.ToString();
                }
            }
        }

        private void TableMenuMod_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}