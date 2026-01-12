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
            button1 = new Button();
            Panel_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // Panel_BatListe
            // 
            Panel_BatListe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel_BatListe.AutoScroll = true;
            Panel_BatListe.BackColor = SystemColors.Control;
            Panel_BatListe.BorderStyle = BorderStyle.FixedSingle;
            Panel_BatListe.FlowDirection = FlowDirection.TopDown;
            Panel_BatListe.Location = new Point(0, 51);
            Panel_BatListe.Name = "Panel_BatListe";
            Panel_BatListe.Size = new Size(1247, 572);
            Panel_BatListe.TabIndex = 0;
            Panel_BatListe.WrapContents = false;
            // 
            // Panel_Menu
            // 
            Panel_Menu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Panel_Menu.Controls.Add(button1);
            Panel_Menu.Location = new Point(0, 0);
            Panel_Menu.Name = "Panel_Menu";
            Panel_Menu.Size = new Size(1247, 52);
            Panel_Menu.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(11, 9);
            button1.Name = "button1";
            button1.Size = new Size(38, 34);
            button1.TabIndex = 0;
            button1.Text = "O";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Update_Button;
            // 
            // GestionBat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(Panel_BatListe);
            Controls.Add(Panel_Menu);
            Name = "GestionBat";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1248, 622);
            Panel_Menu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel Panel_BatListe;
        private Panel Panel_Menu;
        private Button button1;
    }
}
