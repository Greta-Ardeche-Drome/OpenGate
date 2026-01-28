using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OpenGate.UC.Gestion
{
    public partial class Salle : UserControl
    {
        SqlConnection _conn;
        List<Porte> maListePortes = new List<Porte>();
        private Batiment _parentBat;
        bool shrink;
        public Salle(string lettreBat, string salle, SqlConnection conn, Batiment parent)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            shrink = false;

            // 1. ASSIGNATION PRIORITAIRE
            // On remplit les variables de classe AVANT de lancer les requêtes SQL
            this._conn = conn;
            this._parentBat = parent;

            // Mise à jour visuelle du titre
            Lab_SalleNum.Text = "Salle " + salle;

            // 2. RÉCUPÉRATION DU NOMBRE DE PORTES
            // Utilisation de paramètres @ pour éviter les crashs et injections
            string queryCount = "SELECT COUNT(position) FROM [PTUT].[dbo].[OGA_Portes] WHERE batiment = @bat AND numero = @num;";

            int nombrePortes = 0;
            try
            {
                // Vérification de sécurité sur la connexion
                if (_conn.State != ConnectionState.Open) _conn.Open();

                using (SqlCommand command = new SqlCommand(queryCount, _conn))
                {
                    command.Parameters.AddWithValue("@bat", lettreBat);
                    command.Parameters.AddWithValue("@num", salle);

                    // L'exécution se fait maintenant sur une connexion bien assignée
                    nombrePortes = (int)command.ExecuteScalar();
                }

                // 3. CRÉATION DES PORTES (Logique de l'UC)
                if (nombrePortes == 1)
                {
                    // Note : on passe "this" pour que la porte puisse notifier cette salle
                    Porte newPorte = new Porte(lettreBat, salle, "Unique", _conn, this);
                    Panel_Portes.Controls.Add(newPorte);
                    maListePortes.Add(newPorte); // Indispensable pour HasUnLocked()
                }
                else
                {
                    // On crée les deux portes AV et AR
                    string[] positions = { "AV", "AR" };
                    foreach (string pos in positions)
                    {
                        Porte newPorte = new Porte(lettreBat, salle, pos, _conn, this);
                        Panel_Portes.Controls.Add(newPorte);
                        maListePortes.Add(newPorte);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'initialisation de la salle : " + ex.Message);
            }

            // 4. On regarde si la salle est occupée ou non

            // On réinitialise le label avant de commencer la vérification
            Label_WhoWhen.Text = "Salle vide";
            Img_Status.Image = Res.Img.images.Close;

            foreach (Porte p in maListePortes)
            {
                // On utilise une jointure pour avoir l'accès et le nom de l'utilisateur
                string query = @"
                    SELECT TOP 1 A.time_entree, U.SAM 
                    FROM [PTUT].[dbo].[OGA_Access] A
                    INNER JOIN [PTUT].[dbo].[AD_Users] U ON A.id_user = U.id_user
                    WHERE A.time_sortie IS NULL AND A.id_porte = @IDPorte
                    ORDER BY A.time_entree DESC"; // On prend le dernier entré si plusieurs

                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    command.Parameters.AddWithValue("@IDPorte", p.bdd_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Une personne est trouvée !
                            DateTime timeEntree = Convert.ToDateTime(reader["time_entree"]);
                            string nameOpener = reader["SAM"].ToString()!;

                            string jour = timeEntree.ToString("dd/MM");
                            string heure = timeEntree.ToString("HH:mm");

                            Label_WhoWhen.Text = $"Ouverte par {nameOpener} (Le {jour} à {heure})";
                            Img_Status.Image = Res.Img.images.Open;

                            // Si on a trouvé quelqu'un, on peut arrêter de chercher pour les autres portes de cette salle
                            break;
                        }
                    }
                }
            }

            // 4. MISE À JOUR DU BOUTON GLOBAL DE LA SALLE
            // Maintenant que maListePortes est remplie, on peut calculer l'état du bouton
            UpdateBut();
        }

        private void But_Verouiller_Click(object sender, EventArgs e)
        {
            // 1. On calcule l'action UNIQUE pour toute la salle AVANT la boucle
            // Si au moins une porte est ouverte (UNLOCKED), on veut TOUT fermer (true)
            bool actionLock = HasUnLocked();

            // 2. On applique cet état à chaque porte
            foreach (Porte _porte in maListePortes)
            {
                _porte.SetLockState(actionLock);
            }

            // 3. On rafraîchit le bouton de la salle après avoir fini
            UpdateBut();
        }

        public bool HasUnLocked()
        {
            foreach (Porte _porte in maListePortes)
            {
                // On vérifie le Tag du BOUTON à l'intérieur de l'UC Porte
                // Si le Tag est "UNLOCKED", la porte est ouverte.
                if (_porte.But_Verouiller.Tag!.ToString() == "UNLOCKED")
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateBut() // Changé en public
        {
            if (HasUnLocked())
            {
                But_Verouiller.Text = "Verrouiller salle"; // Texte corrigé pour l'action
                But_Verouiller.BackColor = Color.FromArgb(192, 57, 43);
            }
            else
            {
                But_Verouiller.Text = "Déverrouiller salle"; // Texte corrigé pour l'action
                But_Verouiller.BackColor = Color.FromArgb(39, 174, 96);
            }
            But_Verouiller.ForeColor = Color.White;
        }

        public void SetAllLockState(bool lockIt)
        {
            foreach (Porte p in maListePortes)
            {
                p.SetLockState(lockIt);
            }
            UpdateBut(); // Met à jour le bouton de la salle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuspendLayout();

            shrink = !shrink;

            foreach (Porte p in maListePortes)
            {
                p.Visible = !shrink;
            }
            ResumeLayout();
        }
    }
}
