namespace OpenGate
{
    partial class Loading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Titre = new Label();
            SousTitre = new Label();
            SuspendLayout();
            // 
            // Titre
            // 
            Titre.AutoSize = true;
            Titre.Location = new Point(149, 86);
            Titre.Name = "Titre";
            Titre.Size = new Size(69, 15);
            Titre.TabIndex = 0;
            Titre.Text = "OPEN GATE";
            // 
            // SousTitre
            // 
            SousTitre.AutoSize = true;
            SousTitre.Location = new Point(98, 101);
            SousTitre.Name = "SousTitre";
            SousTitre.Size = new Size(185, 15);
            SousTitre.TabIndex = 1;
            SousTitre.Text = "Connexion à la base de données...";
            // 
            // FormSplash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(SousTitre);
            Controls.Add(Titre);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSplash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Titre;
        private Label SousTitre;
    }
}