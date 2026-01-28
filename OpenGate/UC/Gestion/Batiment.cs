using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OpenGate.UC.Gestion
{
    public partial class Batiment : UserControl
    {
        SqlConnection _conn;
        // On stocke la liste des salles pour les commandes groupées
        List<Salle> maListeSalles = new List<Salle>();
        bool shrink;
        public Batiment(string lettreBat, SqlConnection conn)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            _conn = conn;
            shrink = false;

            if (_conn == null)
            {
                MessageBox.Show("Erreur : La connexion SQL est nulle dans Batiment.cs");
                return;
            }

            Lab_BatimentNom.Text = "Bâtiment " + lettreBat;

            if (_conn.State != ConnectionState.Open) _conn.Open();

            string query = "SELECT DISTINCT numero FROM [PTUT].[dbo].[OGA_Portes] WHERE batiment = @bat;";
            List<string> ListeSalles = new List<string>();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@bat", lettreBat);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) { ListeSalles.Add(reader[0].ToString()!); }
                }
            }

            foreach (string salle in ListeSalles)
            {
                // Note : On passe "this" pour que la salle puisse notifier le bâtiment
                UC.Gestion.Salle newSalle = new UC.Gestion.Salle(lettreBat, salle, _conn, this);
                newSalle.Padding = new Padding(0, 0, 0, 3);
                Panel_SalleListe.Controls.Add(newSalle);
                maListeSalles.Add(newSalle);
            }

            UpdateBut();
        }

        // Vérifie si au moins une salle dans tout le bâtiment a une porte ouverte
        public bool HasUnLocked()
        {
            foreach (Salle s in maListeSalles)
            {
                if (s.HasUnLocked()) return true;
            }
            return false;
        }

        public void UpdateBut()
        {
            if (HasUnLocked())
            {
                But_Verouiller.Text = "Verrouiller bâtiment";
                But_Verouiller.BackColor = Color.FromArgb(150, 40, 27); // Rouge
            }
            else
            {
                But_Verouiller.Text = "Déverrouiller bâtiment";
                But_Verouiller.BackColor = Color.FromArgb(30, 132, 73); // Vert
            }
            But_Verouiller.ForeColor = Color.White;
        }

        private void But_Verouiller_Click(object sender, EventArgs e)
        {
            bool actionLock = HasUnLocked();

            foreach (Salle s in maListeSalles)
            {
                // On demande à chaque salle de traiter ses portes
                // On crée une méthode SetAllLockState dans Salle.cs
                s.SetAllLockState(actionLock);
            }
            UpdateBut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuspendLayout();

            shrink = !shrink;

            foreach (Salle s in maListeSalles)
            {
                s.Visible = !shrink;
            }
            ResumeLayout();
        }

        private void ChangingSize(object sender, EventArgs e)
        {
            foreach (Salle s in maListeSalles)
            {
                s.Width = Panel_SalleListe.ClientSize.Width - s.Margin.Left - s.Margin.Right;
            }
        }
    }
}