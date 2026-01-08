using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OpenGate.UC
{
    public partial class Register : UserControl
    {
        private SqlConnection _conn;

        // Constructeur vide obligatoire pour que le Designer de Visual Studio affiche l'UC
        public Register()
        {
            InitializeComponent();
        }

        // Ton constructeur utilisé pour passer la connexion
        public Register(SqlConnection conn) : this()
        {
            _conn = conn;
        }

        private void AddNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FindForm() is Main maFenetre)
            {
                maFenetre.ClearPanel();
                maFenetre.Resize_Window("Login");
                maFenetre.PannelLogin.Controls.Add(new Login(_conn));
            }
        }

        private void But_Register_Click(object sender, EventArgs e)
        {
            // 1. Vérification des mots de passe
            if (Passwd.Text != Passwd_Conf.Text)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas !");
                return;
            }

            // 2. Vérification si l'utilisateur existe
            if (CheckUserAlrExist(Username.Text))
            {
                MessageBox.Show("Le nom d'utilisateur existe déjà !");
                return;
            }

            try
            {
                string token = Utils.HashUtils.HashTOKEN(Username.Text, Passwd.Text);
                string hashedpasswd = Utils.HashUtils.HashPASSWD(Passwd.Text);

                // 3. Utilisation de paramètres pour l'INSERT
                string sql_res = "INSERT INTO PTUT.dbo.OGA_Users (username, passwd, token) VALUES (@user, @pass, @token)";

                if (_conn.State != ConnectionState.Open) _conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql_res, _conn))
                {
                    cmd.Parameters.AddWithValue("@user", Username.Text);
                    cmd.Parameters.AddWithValue("@pass", hashedpasswd);
                    cmd.Parameters.AddWithValue("@token", token);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Compte créé avec succès !");
                if (this.FindForm() is Main maFenetre)
                {
                    maFenetre.HomePage();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'inscription : " + ex.Message);
            }
        }

        private bool CheckUserAlrExist(string username)
        {
            // Utilisation de paramètres pour le SELECT également
            string sql_res = "SELECT COUNT(*) FROM [PTUT].[dbo].[OGA_Users] WHERE username = @user";

            try
            {
                if (_conn.State != ConnectionState.Open) _conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql_res, _conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}