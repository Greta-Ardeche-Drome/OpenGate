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
            Lab_BatimentNom = new Label();
            SuspendLayout();
            // 
            // Panel_BatimentListe
            // 
            Panel_BatimentListe.AutoSize = true;
            Panel_BatimentListe.FlowDirection = FlowDirection.TopDown;
            Panel_BatimentListe.Location = new Point(3, 44);
            Panel_BatimentListe.Name = "Panel_BatimentListe";
            Panel_BatimentListe.Size = new Size(1173, 310);
            Panel_BatimentListe.TabIndex = 0;
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
            // Batiment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(Lab_BatimentNom);
            Controls.Add(Panel_BatimentListe);
            Name = "Batiment";
            Size = new Size(1179, 357);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel Panel_BatimentListe;
        private Label Lab_BatimentNom;
    }
}
