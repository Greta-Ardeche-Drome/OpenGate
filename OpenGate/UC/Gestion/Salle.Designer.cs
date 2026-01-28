namespace OpenGate.UC.Gestion
{
    partial class Salle
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
            Lab_SalleNum = new Label();
            Img_Status = new PictureBox();
            Label_WhoWhen = new Label();
            Panel_Portes = new FlowLayoutPanel();
            But_Verouiller = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)Img_Status).BeginInit();
            SuspendLayout();
            // 
            // Lab_SalleNum
            // 
            Lab_SalleNum.AutoSize = true;
            Lab_SalleNum.Font = new Font("Segoe UI", 22F);
            Lab_SalleNum.Location = new Point(0, 0);
            Lab_SalleNum.Name = "Lab_SalleNum";
            Lab_SalleNum.Size = new Size(135, 41);
            Lab_SalleNum.TabIndex = 1;
            Lab_SalleNum.Text = "Salle 101";
            // 
            // Img_Status
            // 
            Img_Status.Image = Res.Img.images.Open;
            Img_Status.Location = new Point(133, 16);
            Img_Status.Name = "Img_Status";
            Img_Status.Size = new Size(15, 15);
            Img_Status.SizeMode = PictureBoxSizeMode.Zoom;
            Img_Status.TabIndex = 2;
            Img_Status.TabStop = false;
            // 
            // Label_WhoWhen
            // 
            Label_WhoWhen.AutoSize = true;
            Label_WhoWhen.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Label_WhoWhen.Location = new Point(154, 13);
            Label_WhoWhen.Name = "Label_WhoWhen";
            Label_WhoWhen.Size = new Size(209, 21);
            Label_WhoWhen.TabIndex = 3;
            Label_WhoWhen.Text = "Ouvert à 15:15 par XXXXXXX";
            // 
            // Panel_Portes
            // 
            Panel_Portes.AutoSize = true;
            Panel_Portes.FlowDirection = FlowDirection.TopDown;
            Panel_Portes.Location = new Point(0, 43);
            Panel_Portes.Name = "Panel_Portes";
            Panel_Portes.Padding = new Padding(0, 0, 3, 0);
            Panel_Portes.Size = new Size(1202, 10);
            Panel_Portes.TabIndex = 4;
            // 
            // But_Verouiller
            // 
            But_Verouiller.BackColor = Color.FromArgb(192, 57, 43);
            But_Verouiller.ForeColor = SystemColors.Desktop;
            But_Verouiller.Location = new Point(1053, 7);
            But_Verouiller.Name = "But_Verouiller";
            But_Verouiller.Size = new Size(110, 30);
            But_Verouiller.TabIndex = 5;
            But_Verouiller.Tag = "Ver";
            But_Verouiller.Text = "Déverouiller tout";
            But_Verouiller.UseVisualStyleBackColor = false;
            But_Verouiller.Click += But_Verouiller_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1169, 7);
            button1.Name = "button1";
            button1.Size = new Size(30, 30);
            button1.TabIndex = 8;
            button1.Tag = "Ver";
            button1.Text = "V";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Salle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(button1);
            Controls.Add(But_Verouiller);
            Controls.Add(Panel_Portes);
            Controls.Add(Label_WhoWhen);
            Controls.Add(Img_Status);
            Controls.Add(Lab_SalleNum);
            Margin = new Padding(5);
            Name = "Salle";
            Size = new Size(1205, 56);
            ((System.ComponentModel.ISupportInitialize)Img_Status).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lab_SalleNum;
        private PictureBox Img_Status;
        private Label Label_WhoWhen;
        private FlowLayoutPanel Panel_Portes;
        private Button But_Verouiller;
        private Button button1;
    }
}
