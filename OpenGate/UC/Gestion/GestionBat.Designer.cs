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
            Panel_Menu = new Panel();
            But_Reload = new Button();
            Panel_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // Panel_BatListe
            // 
            Panel_BatListe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel_BatListe.AutoScroll = true;
            Panel_BatListe.BackColor = Color.Transparent;
            Panel_BatListe.BorderStyle = BorderStyle.FixedSingle;
            Panel_BatListe.FlowDirection = FlowDirection.TopDown;
            Panel_BatListe.Location = new Point(0, 45);
            Panel_BatListe.Name = "Panel_BatListe";
            Panel_BatListe.Size = new Size(835, 577);
            Panel_BatListe.TabIndex = 0;
            Panel_BatListe.WrapContents = false;
            Panel_BatListe.SizeChanged += ChangingSize;
            // 
            // Panel_Menu
            // 
            Panel_Menu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Panel_Menu.Controls.Add(But_Reload);
            Panel_Menu.Location = new Point(0, 0);
            Panel_Menu.Name = "Panel_Menu";
            Panel_Menu.Size = new Size(835, 43);
            Panel_Menu.TabIndex = 1;
            // 
            // But_Reload
            // 
            But_Reload.BackColor = Color.FromArgb(35, 38, 52);
            But_Reload.FlatAppearance.BorderSize = 0;
            But_Reload.FlatStyle = FlatStyle.Flat;
            But_Reload.Font = new Font("Segoe UI", 13.5F);
            But_Reload.ForeColor = SystemColors.ButtonFace;
            But_Reload.Location = new Point(3, 5);
            But_Reload.Name = "But_Reload";
            But_Reload.Size = new Size(75, 34);
            But_Reload.TabIndex = 0;
            But_Reload.Text = "Reload";
            But_Reload.UseVisualStyleBackColor = false;
            But_Reload.Click += Update_Button;
            // 
            // GestionBat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(Panel_BatListe);
            Controls.Add(Panel_Menu);
            Name = "GestionBat";
            RightToLeft = RightToLeft.No;
            Size = new Size(836, 625);
            Panel_Menu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel Panel_BatListe;
        private Panel Panel_Menu;
        private Button But_Reload;
    }
}
