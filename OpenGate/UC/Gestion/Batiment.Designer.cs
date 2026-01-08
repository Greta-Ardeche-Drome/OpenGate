namespace OpenGate.UC.Gestion
{
    partial class Batiment
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            Panel_BatimentListe = new FlowLayoutPanel();
            salle2 = new Salle();
            Lab_BatimentNom = new Label();
            salle1 = new Salle();
            Panel_BatimentListe.SuspendLayout();
            SuspendLayout();
            // 
            // Panel_BatimentListe
            // 
            Panel_BatimentListe.AutoSize = true;
            Panel_BatimentListe.Controls.Add(salle2);
            Panel_BatimentListe.Controls.Add(salle1);
            Panel_BatimentListe.FlowDirection = FlowDirection.TopDown;
            Panel_BatimentListe.Location = new Point(3, 44);
            Panel_BatimentListe.Name = "Panel_BatimentListe";
            Panel_BatimentListe.Size = new Size(1254, 310);
            Panel_BatimentListe.TabIndex = 0;
            // 
            // salle2
            // 
            salle2.BorderStyle = BorderStyle.FixedSingle;
            salle2.Location = new Point(3, 3);
            salle2.Name = "salle2";
            salle2.Size = new Size(1248, 149);
            salle2.TabIndex = 1;
            // 
            // Lab_BatimentNom
            // 
            Lab_BatimentNom.AutoSize = true;
            Lab_BatimentNom.Font = new Font("Segoe UI", 22F);
            Lab_BatimentNom.Location = new Point(0, 0);
            Lab_BatimentNom.Name = "Lab_BatimentNom";
            Lab_BatimentNom.Size = new Size(163, 41);
            Lab_BatimentNom.TabIndex = 2;
            Lab_BatimentNom.Text = "Bâtiment A";
            // 
            // salle1
            // 
            salle1.BorderStyle = BorderStyle.FixedSingle;
            salle1.Location = new Point(3, 158);
            salle1.Name = "salle1";
            salle1.Size = new Size(1248, 149);
            salle1.TabIndex = 2;
            // 
            // Batiment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(Lab_BatimentNom);
            Controls.Add(Panel_BatimentListe);
            Name = "Batiment";
            Size = new Size(1260, 357);
            Panel_BatimentListe.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel Panel_BatimentListe;
        private Label Lab_BatimentNom;
        private Salle salle2;
        private Salle salle1;
    }
}
