using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace OpenGate.UC
{
    public partial class Login : UserControl
    {
        private SqlConnection _conn;

        public Login(SqlConnection conn)
        {
            InitializeComponent();
            _conn = conn;
        }

        private void But_Login_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim(); // .Trim() pour éviter les espaces accidentels
            string passwd = Passwd.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(passwd))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            string sql = "SELECT passwd FROM [PTUT].[dbo].[OGA_Users] WHERE username = @user";
            string token = "none";
            try
            {
                if (_conn.State != ConnectionState.Open) _conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string dbHash = result.ToString();

                        // Vérification du mot de passe avec ton utilitaire BCrypt
                        if (Utils.HashUtils.verifyPASSWD(passwd, dbHash))
                        {
                            // Si "Rester connecté" est coché, on récupère le token
                            if (StayLogin.Checked)
                            {
                                token = SaveUserToken(username);
                            }

                            // Redirection vers le StartUp de la fenêtre Main
                            if (this.FindForm() is Main maFenetre)
                            {
                                maFenetre.StartUp(token);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mot de passe incorrect !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Utilisateur introuvable !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }
        }

        public string SaveUserToken(string user)
        {
            string sqlToken = "SELECT token FROM [PTUT].[dbo].[OGA_Users] WHERE username = @username";

            using (SqlCommand cmdToken = new SqlCommand(sqlToken, _conn))
            {
                cmdToken.Parameters.AddWithValue("@username", user);
                object tokenResult = cmdToken.ExecuteScalar();

                if (tokenResult != null)
                {
                    Properties.Settings.Default.UserToken = tokenResult.ToString();
                    Properties.Settings.Default.Save();

                    return tokenResult.ToString();
                }
            }

            return string.Empty;
        }
    }
}