using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenGate.UC.Gestion
{
    public partial class Porte : UserControl
    {
        private SqlConnection _connection;
        private string _lettreBat;
        private string _salle;
        private string _position;
        private Salle _parentSalle;
        public int bdd_id;
        public Porte(string lettreBat, string salle, string position, SqlConnection conn, Salle parent)
        {
            InitializeComponent();

            // --- Optimisation Anti-Clignotement ---
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            _connection = conn;
            _lettreBat = lettreBat;
            _salle = salle;
            _position = position;
            _parentSalle = parent;

            string pos = (position == "AV") ? "Avant" : (position == "AR") ? "Arrière" : position;
            Lab_PorteName.Text = lettreBat + salle + " " + pos;

            LoadPorteData();
        }

        private void LoadPorteData()
        {
            string query = "SELECT [id], [is_locked] FROM [PTUT].[dbo].[OGA_Portes] " +
                           "WHERE batiment = @bat AND numero = @num AND position = @pos;";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@bat", _lettreBat);
                    command.Parameters.AddWithValue("@num", _salle);
                    command.Parameters.AddWithValue("@pos", _position);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isLocked = Convert.ToBoolean(reader["is_locked"]);
                            bdd_id = Convert.ToInt32(reader["id"]);
                            // On appelle la fonction de design unique
                            UpdateVisualState(isLocked);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur chargement porte: " + ex.Message);
            }
        }

        // Cette méthode sert maintenant de "passerelle" pour garder ton appel original
        private void UpdateUI(bool isLocked)
        {
            UpdateVisualState(isLocked);
        }

        private void But_Verouiller_Click(object sender, EventArgs e)
        {
            bool currentlyLocked = (But_Verouiller.Tag!.ToString() == "LOCKED");
            bool nextState = !currentlyLocked;

            string query = "UPDATE [PTUT].[dbo].[OGA_Portes] SET is_locked = @state " +
                           "WHERE batiment = @bat AND numero = @num AND position = @pos;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@state", nextState ? 1 : 0);
                    cmd.Parameters.AddWithValue("@bat", _lettreBat);
                    cmd.Parameters.AddWithValue("@num", _salle);
                    cmd.Parameters.AddWithValue("@pos", _position);

                    cmd.ExecuteNonQuery();

                    // Mise à jour visuelle (Bouton + Label)
                    UpdateVisualState(nextState);

                    // Mise à jour des parents (Salle puis Bâtiment en cascade)
                    if (_parentSalle != null)
                    {
                        _parentSalle.UpdateBut();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour : " + ex.Message);
            }
        }

        public void SetLockState(bool shouldLock)
        {
            string query = "UPDATE [PTUT].[dbo].[OGA_Portes] SET is_locked = @state " +
                           "WHERE batiment = @bat AND numero = @num AND position = @pos;";

            try
            {
                if (_connection.State != ConnectionState.Open) _connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@state", shouldLock ? 1 : 0);
                    cmd.Parameters.AddWithValue("@bat", _lettreBat);
                    cmd.Parameters.AddWithValue("@num", _salle);
                    cmd.Parameters.AddWithValue("@pos", _position);

                    cmd.ExecuteNonQuery();
                    UpdateVisualState(shouldLock);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SetLockState : " + ex.Message);
            }
        }

        private void UpdateVisualState(bool isLocked)
        {
            // On fige le layout du contrôle pour éviter le scintillement des textes
            this.SuspendLayout();

            if (isLocked)
            {
                // État : Verrouillé -> Action : Déverrouiller
                But_Verouiller.Text = "Déverouiller";
                But_Verouiller.Tag = "LOCKED";
                But_Verouiller.BackColor = Color.FromArgb(46, 204, 113); // Vert

                Lab_PorteStatus.Text = "Verrouillée";
                Lab_PorteStatus.ForeColor = Color.FromArgb(231, 76, 60); // Rouge pour le texte
            }
            else
            {
                // État : Déverrouillé -> Action : Verrouiller
                But_Verouiller.Text = "Verouiller";
                But_Verouiller.Tag = "UNLOCKED";
                But_Verouiller.BackColor = Color.FromArgb(231, 76, 60); // Rouge

                Lab_PorteStatus.Text = "Déverrouillée";
                Lab_PorteStatus.ForeColor = Color.FromArgb(46, 204, 113); // Vert pour le texte
            }

            But_Verouiller.ForeColor = Color.White;
            this.ResumeLayout();
        }
    }
}