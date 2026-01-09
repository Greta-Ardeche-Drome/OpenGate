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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            Panel_Portes = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // pictureBox1
            // 
            pictureBox1.Image = Res.Img.images.Open;
            pictureBox1.Location = new Point(133, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(15, 15);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(154, 13);
            label1.Name = "label1";
            label1.Size = new Size(209, 21);
            label1.TabIndex = 3;
            label1.Text = "Ouvert à 15:15 par XXXXXXX";
            // 
            // Panel_Portes
            // 
            Panel_Portes.Dock = DockStyle.Bottom;
            Panel_Portes.Location = new Point(0, 43);
            Panel_Portes.Name = "Panel_Portes";
            Panel_Portes.Size = new Size(1234, 106);
            Panel_Portes.TabIndex = 4;
            // 
            // Salle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(Panel_Portes);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(Lab_SalleNum);
            Name = "Salle";
            Size = new Size(1234, 149);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lab_SalleNum;
        private PictureBox pictureBox1;
        private Label label1;
        private FlowLayoutPanel Panel_Portes;
    }
}
