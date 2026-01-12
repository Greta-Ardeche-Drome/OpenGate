using Microsoft.Data.SqlClient;
using OpenGate.UC;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OpenGate
{
    public partial class Main : Form
    {
        private SqlConnection _conn;

        public Main(SqlConnection conn)
        {
            InitializeComponent();
            // On stocke la connexion dans la variable de classe pour la réutiliser partout
            _conn = conn;

            // Logique de démarrage : si le token existe, on va au Dashboard, sinon au Login
            if (isAlrLogin())
            {
                StartUp("none");
            }
            else
            {
                showLogin(_conn);
            }
        }

        private bool isAlrLogin()
        {
            // Renvoie true seulement si le token N'EST PAS vide
            return !string.IsNullOrWhiteSpace(Properties.Settings.Default.UserToken);
        }

        public void LockWindow()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        public void DelockWindow()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
        }

        public void showLogin(SqlConnection connectionPartagee)
        {
            LockWindow();
            Resize_Window("Login");

            PannelLogin.Visible = true;
            // Taille fixe pour le formulaire de login
            PannelLogin.Size = new Size(400, 300);

            Login monUC = new Login(connectionPartagee);
            monUC.Dock = DockStyle.Fill;

            ClearPanel();
            PannelLogin.Controls.Add(monUC);
        }

        public void ClearPanel()
        {
            PannelLogin.Controls.Clear();
        }

        public void Resize_Window(string Type)
        {
            try
            {
                string S = OpenGate.Res.Sizes.ResourceManager.GetString(Type)!;
                string[] parts = S.Split(',');

                int x = int.Parse(parts[0]);
                int y = int.Parse(parts[1]);

                this.Size = new Size(x, y);
                this.CenterToScreen(); // Plus simple que le calcul manuel de Point
            }
            catch { /* Gérer l'erreur si la ressource 'Type' n'existe pas */ }
        }

        public void StartUp(string token)
        {
            DelockWindow();
            PannelOptions.Visible = false;
            PannelLogin.Visible = false;
            ClearPanel();
            Resize_Window("Default");


            // Récupération du nom d'utilisateur via le Token
            string sql = "SELECT username FROM [PTUT].[dbo].[OGA_Users] WHERE token = @token";

            try
            {
                if (_conn.State != ConnectionState.Open) _conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    if (token == "none")
                    {
                        token = Properties.Settings.Default.UserToken;
                    }

                    cmd.Parameters.AddWithValue("@token", token);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        Label_UserName.Text = result.ToString();
                    }
                    else
                    {
                        // Si le token est invalide en BDD, on déconnecte
                        LogOut();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SQL StartUp : " + ex.Message);
            }
        }

        public void HomePage()
        {
            PannelMain.Controls.Clear();
        }

        private void RegisterPage()
        {
            PannelMain.Controls.Clear();
            Register reg = new Register(_conn);
            reg.Location = new Point(469, 175);
            reg.BorderStyle = BorderStyle.FixedSingle;
            PannelMain.Controls.Add(reg);
        }

        private void LogOut()
        {
            Properties.Settings.Default.UserToken = "";
            Properties.Settings.Default.Save();
            showLogin(_conn);
        }

        private void But_Logoff_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void But_Profile_Click(object sender, EventArgs e)
        {
            PannelOptions.Visible = !PannelOptions.Visible;
        }

        private void But_Home_Click(object sender, EventArgs e)
        {
            HomePage();
        }

        private void But_NewUser_Click(object sender, EventArgs e)
        {
            RegisterPage();
        }

        private void ManagePage(object sender, EventArgs e)
        {
            PannelMain.Controls.Clear();
            UC.GestionBat contentUC = new UC.GestionBat(_conn);
            PannelMain.Controls.Add(contentUC);
            PannelMain.HorizontalScroll.Visible = false;
            PannelMain.VerticalScroll.Visible = false;
        }
    }
}