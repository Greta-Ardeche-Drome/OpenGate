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
            Lab_PorteType = new Label();
            But_Open = new Button();
            But_Verouiller = new Button();
            SuspendLayout();
            // 
            // Lab_PorteType
            // 
            Lab_PorteType.AutoSize = true;
            Lab_PorteType.Font = new Font("Segoe UI", 22F);
            Lab_PorteType.Location = new Point(0, 0);
            Lab_PorteType.Name = "Lab_PorteType";
            Lab_PorteType.Size = new Size(188, 41);
            Lab_PorteType.TabIndex = 2;
            Lab_PorteType.Text = "Porte unique";
            // 
            // But_Open
            // 
            But_Open.BackColor = Color.FromArgb(39, 174, 96);
            But_Open.Location = new Point(914, 3);
            But_Open.Name = "But_Open";
            But_Open.Size = new Size(150, 42);
            But_Open.TabIndex = 3;
            But_Open.Text = "Ouvrir";
            But_Open.UseVisualStyleBackColor = false;
            // 
            // But_Verouiller
            // 
            But_Verouiller.BackColor = Color.FromArgb(192, 57, 43);
            But_Verouiller.ForeColor = SystemColors.Desktop;
            But_Verouiller.Location = new Point(1070, 3);
            But_Verouiller.Name = "But_Verouiller";
            But_Verouiller.Size = new Size(150, 42);
            But_Verouiller.TabIndex = 4;
            But_Verouiller.Text = "Verouiller";
            But_Verouiller.UseVisualStyleBackColor = false;
            // 
            // Porte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(But_Verouiller);
            Controls.Add(But_Open);
            Controls.Add(Lab_PorteType);
            Name = "Porte";
            Size = new Size(1223, 48);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lab_PorteType;
        private Button But_Open;
        private Button But_Verouiller;
    }
}
