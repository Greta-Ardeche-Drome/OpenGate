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
            label2 = new Label();
            But_Open = new Button();
            But_Verouiller = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22F);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(188, 41);
            label2.TabIndex = 2;
            label2.Text = "Porte unique";
            // 
            // But_Open
            // 
            But_Open.BackColor = Color.FromArgb(39, 174, 96);
            But_Open.Location = new Point(876, 3);
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
            But_Verouiller.Location = new Point(1032, 3);
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
            Controls.Add(label2);
            Name = "Porte";
            Size = new Size(1188, 48);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button But_Open;
        private Button But_Verouiller;
    }
}
