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
            Panel_SalleListe = new FlowLayoutPanel();
            Lab_BatimentNom = new Label();
            But_Verouiller = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // Panel_SalleListe
            // 
            Panel_SalleListe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Panel_SalleListe.AutoSize = true;
            Panel_SalleListe.FlowDirection = FlowDirection.TopDown;
            Panel_SalleListe.Location = new Point(3, 44);
            Panel_SalleListe.Name = "Panel_SalleListe";
            Panel_SalleListe.Size = new Size(1064, 10);
            Panel_SalleListe.TabIndex = 0;
            // 
            // Lab_BatimentNom
            // 
            Lab_BatimentNom.AutoSize = true;
            Lab_BatimentNom.Font = new Font("Segoe UI", 22F);
            Lab_BatimentNom.Location = new Point(0, 0);
            Lab_BatimentNom.Name = "Lab_BatimentNom";
            Lab_BatimentNom.Size = new Size(162, 41);
            Lab_BatimentNom.TabIndex = 2;
            Lab_BatimentNom.Text = "Bâtiment X";
            // 
            // But_Verouiller
            // 
            But_Verouiller.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            But_Verouiller.BackColor = Color.FromArgb(192, 57, 43);
            But_Verouiller.ForeColor = SystemColors.Desktop;
            But_Verouiller.Location = new Point(893, 3);
            But_Verouiller.Name = "But_Verouiller";
            But_Verouiller.Size = new Size(137, 30);
            But_Verouiller.TabIndex = 6;
            But_Verouiller.Tag = "Ver";
            But_Verouiller.Text = "Déverouiller batiment";
            But_Verouiller.UseVisualStyleBackColor = false;
            But_Verouiller.Click += But_Verouiller_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1037, 3);
            button1.Name = "button1";
            button1.Size = new Size(30, 30);
            button1.TabIndex = 7;
            button1.Tag = "Ver";
            button1.Text = "V";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Batiment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(button1);
            Controls.Add(But_Verouiller);
            Controls.Add(Lab_BatimentNom);
            Controls.Add(Panel_SalleListe);
            Name = "Batiment";
            Size = new Size(1070, 57);
            StyleChanged += ChangingSize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel Panel_SalleListe;
        private Label Lab_BatimentNom;
        private Button But_Verouiller;
        private Button button1;
    }
}
