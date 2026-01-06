using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OpenGate
{
    public partial class Dashboard : Form
    {
        private readonly SqlConnection _connection;

        public Dashboard(SqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;

            // Au démarrage, on génère l'affichage complet
            RefreshDashboard();
        }

        /// <summary>
        /// Vide les panels et recrée les cartes de salles à partir de la base de données
        /// </summary>
        private void RefreshDashboard()
        {
            PanelSalleOuverteContainer.Controls.Clear();
            PanelSalleFermeeContainer.Controls.Clear();

            // Variables pour gérer le décalage (évite la superposition)
            int xOffsetOuvert = 5;
            int xOffsetFerme = 5;

            string sql = @"
        SELECT s.batiment, s.numero_salle, u.Surname, c.access_ts
        FROM dbo.salles s
        LEFT JOIN dbo.Cur_access c ON s.id_salle = c.id_room AND c.is_initiator = 1
        LEFT JOIN dbo.users u ON c.id_user = u.User_ID";

            try
            {
                if (_connection.State != ConnectionState.Open) _connection.Open();

                using (SqlCommand cmd = new SqlCommand(sql, _connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string num = $"{reader["batiment"]}-{reader["numero_salle"]}";
                        string user = reader["Surname"]?.ToString();

                        if (!string.IsNullOrEmpty(user))
                        {
                            string date = Convert.ToDateTime(reader["access_ts"]).ToShortTimeString();
                            Panel card = CreateRoomCard(num, user, date, true);

                            // FIX : On définit manuellement la position X pour ne pas superposer
                            card.Location = new Point(xOffsetOuvert, 5);
                            PanelSalleOuverteContainer.Controls.Add(card);

                            // On décale la position pour la PROCHAINE carte (largeur 181 + 10 de marge)
                            xOffsetOuvert += 191;
                        }
                        else
                        {
                            Panel card = CreateRoomCard(num, null, null, false);

                            // FIX : Même chose pour les salles fermées
                            card.Location = new Point(xOffsetFerme, 5);
                            PanelSalleFermeeContainer.Controls.Add(card);

                            xOffsetFerme += 191;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Crée dynamiquement un panel correspondant à ton design "Exemple"
        /// </summary>
        private Panel CreateRoomCard(string numSalle, string user, string date, bool isOpen)
        {
            // Container principal de la carte
            Panel p = new Panel
            {
                Size = new Size(181, 84),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                BackColor = isOpen ? Color.White : Color.FromArgb(245, 245, 245)
            };

            // Label : Salle XXX
            p.Controls.Add(new Label
            {
                Text = "Salle " + numSalle,
                Font = new Font("Segoe UI", 9.75F, FontStyle.Bold),
                Location = new Point(2, 2),
                AutoSize = true
            });

            if (isOpen)
            {
                // Infos d'ouverture
                p.Controls.Add(new Label { Text = "Ouverte par : ", Font = new Font("Segoe UI", 9.75F), Location = new Point(2, 25), AutoSize = true });
                p.Controls.Add(new Label { Text = user, Font = new Font("Segoe UI", 9.75F), Location = new Point(86, 25), AutoSize = true, ForeColor = Color.Blue });

                p.Controls.Add(new Label { Text = "Ouverte le : ", Font = new Font("Segoe UI", 9.75F), Location = new Point(2, 53), AutoSize = true });
                p.Controls.Add(new Label { Text = date, Font = new Font("Segoe UI", 9.75F), Location = new Point(77, 53), AutoSize = true });
            }
            else
            {
                // Statut fermé
                p.Controls.Add(new Label
                {
                    Text = "( Salle vide )",
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Location = new Point(2, 35),
                    AutoSize = true
                });
            }

            return p;
        }

        /// <summary>
        /// Utilitaire pour vider un panel en gardant son titre
        /// </summary>
        private void PreparePanel(Panel targetPanel, Panel titleToKeep)
        {
            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(titleToKeep);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            // Rafraîchir manuellement si on clique sur le titre par exemple
            RefreshDashboard();
        }
    }
}