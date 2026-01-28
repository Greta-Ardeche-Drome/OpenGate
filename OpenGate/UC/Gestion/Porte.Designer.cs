namespace OpenGate.UC.Gestion
{
    partial class Porte
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
            Lab_PorteStatus = new Label();
            But_Open = new Button();
            But_Verouiller = new Button();
            Lab_PorteName = new Label();
            SuspendLayout();
            // 
            // Lab_PorteStatus
            // 
            Lab_PorteStatus.AutoSize = true;
            Lab_PorteStatus.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Lab_PorteStatus.Location = new Point(187, 13);
            Lab_PorteStatus.Name = "Lab_PorteStatus";
            Lab_PorteStatus.Size = new Size(99, 21);
            Lab_PorteStatus.TabIndex = 2;
            Lab_PorteStatus.Text = "Porte unique";
            // 
            // But_Open
            // 
            But_Open.BackColor = Color.FromArgb(39, 174, 96);
            But_Open.Location = new Point(1021, 3);
            But_Open.Name = "But_Open";
            But_Open.Size = new Size(75, 42);
            But_Open.TabIndex = 3;
            But_Open.Text = "Ouvrir";
            But_Open.UseVisualStyleBackColor = false;
            // 
            // But_Verouiller
            // 
            But_Verouiller.BackColor = Color.FromArgb(192, 57, 43);
            But_Verouiller.ForeColor = SystemColors.Desktop;
            But_Verouiller.Location = new Point(1102, 3);
            But_Verouiller.Name = "But_Verouiller";
            But_Verouiller.Size = new Size(82, 42);
            But_Verouiller.TabIndex = 4;
            But_Verouiller.Tag = "Ver";
            But_Verouiller.Text = "Verouiller";
            But_Verouiller.UseVisualStyleBackColor = false;
            But_Verouiller.Click += But_Verouiller_Click;
            // 
            // Lab_PorteName
            // 
            Lab_PorteName.AutoSize = true;
            Lab_PorteName.Font = new Font("Segoe UI", 22F);
            Lab_PorteName.Location = new Point(3, 0);
            Lab_PorteName.Name = "Lab_PorteName";
            Lab_PorteName.Size = new Size(188, 41);
            Lab_PorteName.TabIndex = 5;
            Lab_PorteName.Text = "Porte unique";
            // 
            // Porte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(Lab_PorteName);
            Controls.Add(But_Verouiller);
            Controls.Add(But_Open);
            Controls.Add(Lab_PorteStatus);
            Name = "Porte";
            Size = new Size(1187, 48);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lab_PorteStatus;
        private Button But_Open;
        private Label Lab_PorteName;
        public Button But_Verouiller;
    }
}
