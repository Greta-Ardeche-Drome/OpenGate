namespace OpenGate.UC
{
    partial class GestionBat
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
            Panel_BatListe = new FlowLayoutPanel();
            batiment1 = new OpenGate.UC.Gestion.Batiment();
            batiment2 = new OpenGate.UC.Gestion.Batiment();
            batiment4 = new OpenGate.UC.Gestion.Batiment();
            batiment3 = new OpenGate.UC.Gestion.Batiment();
            Panel_BatListe.SuspendLayout();
            SuspendLayout();
            // 
            // Panel_BatListe
            // 
            Panel_BatListe.BorderStyle = BorderStyle.FixedSingle;
            Panel_BatListe.Controls.Add(batiment1);
            Panel_BatListe.Controls.Add(batiment2);
            Panel_BatListe.Controls.Add(batiment4);
            Panel_BatListe.Controls.Add(batiment3);
            Panel_BatListe.Dock = DockStyle.Fill;
            Panel_BatListe.FlowDirection = FlowDirection.TopDown;
            Panel_BatListe.Location = new Point(0, 0);
            Panel_BatListe.Name = "Panel_BatListe";
            Panel_BatListe.Size = new Size(1268, 1454);
            Panel_BatListe.TabIndex = 0;
            Panel_BatListe.WrapContents = false;
            // 
            // batiment1
            // 
            batiment1.Location = new Point(3, 3);
            batiment1.Name = "batiment1";
            batiment1.Size = new Size(1260, 357);
            batiment1.TabIndex = 0;
            // 
            // batiment2
            // 
            batiment2.AutoSize = true;
            batiment2.Location = new Point(3, 366);
            batiment2.Name = "batiment2";
            batiment2.Size = new Size(1260, 357);
            batiment2.TabIndex = 1;
            // 
            // batiment4
            // 
            batiment4.AutoSize = true;
            batiment4.Location = new Point(3, 729);
            batiment4.Name = "batiment4";
            batiment4.Size = new Size(1260, 357);
            batiment4.TabIndex = 3;
            // 
            // batiment3
            // 
            batiment3.AutoSize = true;
            batiment3.Location = new Point(3, 1092);
            batiment3.Name = "batiment3";
            batiment3.Size = new Size(1260, 357);
            batiment3.TabIndex = 2;
            // 
            // GestionBat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(Panel_BatListe);
            Name = "GestionBat";
            Size = new Size(1268, 1454);
            Panel_BatListe.ResumeLayout(false);
            Panel_BatListe.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel Panel_BatListe;
        private Gestion.Batiment batiment1;
        private Gestion.Batiment batiment2;
        private Gestion.Batiment batiment3;
        private Gestion.Batiment batiment4;
    }
}
