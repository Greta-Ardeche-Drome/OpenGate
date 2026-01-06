namespace OpenGate
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            PAN_Gauche = new Panel();
            PAN_Droite = new Panel();
            PAN_DroitBas = new Panel();
            Pannel_SalleFermee = new Panel();
            PanelSalleFermeeContainer = new Panel();
            ExemplePannelSalleFermee = new Panel();
            ExempleLabel_FermeLeDate = new Label();
            ExempleLabel_FermeLe = new Label();
            ExempleLabel_FermeParNom = new Label();
            ExempleLabel_FermePar = new Label();
            ExempleLabel_FermeNum = new Label();
            PanelSalleFermeeTitre = new Panel();
            PanelSalleFermeeTitreLabel = new Label();
            Pannel_SalleOuverte = new Panel();
            PanelSalleOuverteContainer = new Panel();
            ExemplePannelSalleOuverte = new Panel();
            ExempleLabel_OuvertLeDate = new Label();
            ExempleLabel_OuvertLe = new Label();
            ExempleLabel_OuvertParNom = new Label();
            ExempleLabel_OuvertPart = new Label();
            ExempleLabel_OuvertNum = new Label();
            PanelSalleOuverteTitre = new Panel();
            PanelSalleOuverteTitreLabel = new Label();
            PAN_DroitHaut = new Panel();
            DashB_Label = new Label();
            PAN_Droite.SuspendLayout();
            PAN_DroitBas.SuspendLayout();
            Pannel_SalleFermee.SuspendLayout();
            PanelSalleFermeeContainer.SuspendLayout();
            ExemplePannelSalleFermee.SuspendLayout();
            PanelSalleFermeeTitre.SuspendLayout();
            Pannel_SalleOuverte.SuspendLayout();
            PanelSalleOuverteContainer.SuspendLayout();
            ExemplePannelSalleOuverte.SuspendLayout();
            PanelSalleOuverteTitre.SuspendLayout();
            PAN_DroitHaut.SuspendLayout();
            SuspendLayout();
            // 
            // PAN_Gauche
            // 
            PAN_Gauche.BorderStyle = BorderStyle.FixedSingle;
            PAN_Gauche.Dock = DockStyle.Left;
            PAN_Gauche.Location = new Point(0, 0);
            PAN_Gauche.Name = "PAN_Gauche";
            PAN_Gauche.Size = new Size(200, 581);
            PAN_Gauche.TabIndex = 0;
            // 
            // PAN_Droite
            // 
            PAN_Droite.Controls.Add(PAN_DroitBas);
            PAN_Droite.Controls.Add(PAN_DroitHaut);
            PAN_Droite.Dock = DockStyle.Fill;
            PAN_Droite.Location = new Point(200, 0);
            PAN_Droite.Name = "PAN_Droite";
            PAN_Droite.Size = new Size(884, 581);
            PAN_Droite.TabIndex = 1;
            // 
            // PAN_DroitBas
            // 
            PAN_DroitBas.BorderStyle = BorderStyle.FixedSingle;
            PAN_DroitBas.Controls.Add(Pannel_SalleFermee);
            PAN_DroitBas.Controls.Add(Pannel_SalleOuverte);
            PAN_DroitBas.Dock = DockStyle.Fill;
            PAN_DroitBas.Font = new Font("Stencil", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PAN_DroitBas.Location = new Point(0, 55);
            PAN_DroitBas.Name = "PAN_DroitBas";
            PAN_DroitBas.Size = new Size(884, 526);
            PAN_DroitBas.TabIndex = 1;
            // 
            // Pannel_SalleFermee
            // 
            Pannel_SalleFermee.BorderStyle = BorderStyle.FixedSingle;
            Pannel_SalleFermee.Controls.Add(PanelSalleFermeeContainer);
            Pannel_SalleFermee.Controls.Add(PanelSalleFermeeTitre);
            Pannel_SalleFermee.Location = new Point(-1, 197);
            Pannel_SalleFermee.Name = "Pannel_SalleFermee";
            Pannel_SalleFermee.Size = new Size(884, 120);
            Pannel_SalleFermee.TabIndex = 7;
            // 
            // PanelSalleFermeeContainer
            // 
            PanelSalleFermeeContainer.Controls.Add(ExemplePannelSalleFermee);
            PanelSalleFermeeContainer.Dock = DockStyle.Fill;
            PanelSalleFermeeContainer.Location = new Point(0, 25);
            PanelSalleFermeeContainer.Name = "PanelSalleFermeeContainer";
            PanelSalleFermeeContainer.Size = new Size(882, 93);
            PanelSalleFermeeContainer.TabIndex = 8;
            // 
            // ExemplePannelSalleFermee
            // 
            ExemplePannelSalleFermee.BorderStyle = BorderStyle.FixedSingle;
            ExemplePannelSalleFermee.Controls.Add(ExempleLabel_FermeLeDate);
            ExemplePannelSalleFermee.Controls.Add(ExempleLabel_FermeLe);
            ExemplePannelSalleFermee.Controls.Add(ExempleLabel_FermeParNom);
            ExemplePannelSalleFermee.Controls.Add(ExempleLabel_FermePar);
            ExemplePannelSalleFermee.Controls.Add(ExempleLabel_FermeNum);
            ExemplePannelSalleFermee.Location = new Point(-1, 6);
            ExemplePannelSalleFermee.Name = "ExemplePannelSalleFermee";
            ExemplePannelSalleFermee.Size = new Size(181, 84);
            ExemplePannelSalleFermee.TabIndex = 4;
            // 
            // ExempleLabel_FermeLeDate
            // 
            ExempleLabel_FermeLeDate.AutoSize = true;
            ExempleLabel_FermeLeDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExempleLabel_FermeLeDate.Location = new Point(77, 53);
            ExempleLabel_FermeLeDate.Name = "ExempleLabel_FermeLeDate";
            ExempleLabel_FermeLeDate.Size = new Size(82, 17);
            ExempleLabel_FermeLeDate.TabIndex = 4;
            ExempleLabel_FermeLeDate.Text = "OpenedDate";
            // 
            // ExempleLabel_FermeLe
            // 
            ExempleLabel_FermeLe.AutoSize = true;
            ExempleLabel_FermeLe.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExempleLabel_FermeLe.Location = new Point(2, 53);
            ExempleLabel_FermeLe.Name = "ExempleLabel_FermeLe";
            ExempleLabel_FermeLe.Size = new Size(79, 17);
            ExempleLabel_FermeLe.TabIndex = 3;
            ExempleLabel_FermeLe.Text = "Ouverte le : ";
            // 
            // ExempleLabel_FermeParNom
            // 
            ExempleLabel_FermeParNom.AutoSize = true;
            ExempleLabel_FermeParNom.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExempleLabel_FermeParNom.Location = new Point(86, 25);
            ExempleLabel_FermeParNom.Name = "ExempleLabel_FermeParNom";
            ExempleLabel_FermeParNom.Size = new Size(87, 17);
            ExempleLabel_FermeParNom.TabIndex = 2;
            ExempleLabel_FermeParNom.Text = "OpenerName";
            // 
            // ExempleLabel_FermePar
            // 
            ExempleLabel_FermePar.AutoSize = true;
            ExempleLabel_FermePar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExempleLabel_FermePar.Location = new Point(2, 25);
            ExempleLabel_FermePar.Name = "ExempleLabel_FermePar";
            ExempleLabel_FermePar.Size = new Size(89, 17);
            ExempleLabel_FermePar.TabIndex = 1;
            ExempleLabel_FermePar.Text = "Ouverte par : ";
            // 
            // ExempleLabel_FermeNum
            // 
            ExempleLabel_FermeNum.AutoSize = true;
            ExempleLabel_FermeNum.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExempleLabel_FermeNum.Location = new Point(2, 2);
            ExempleLabel_FermeNum.Name = "ExempleLabel_FermeNum";
            ExempleLabel_FermeNum.Size = new Size(68, 17);
            ExempleLabel_FermeNum.TabIndex = 0;
            ExempleLabel_FermeNum.Text = "Salle XXX";
            // 
            // PanelSalleFermeeTitre
            // 
            PanelSalleFermeeTitre.Controls.Add(PanelSalleFermeeTitreLabel);
            PanelSalleFermeeTitre.Dock = DockStyle.Top;
            PanelSalleFermeeTitre.Location = new Point(0, 0);
            PanelSalleFermeeTitre.Name = "PanelSalleFermeeTitre";
            PanelSalleFermeeTitre.Size = new Size(882, 25);
            PanelSalleFermeeTitre.TabIndex = 5;
            // 
            // PanelSalleFermeeTitreLabel
            // 
            PanelSalleFermeeTitreLabel.AutoSize = true;
            PanelSalleFermeeTitreLabel.Dock = DockStyle.Fill;
            PanelSalleFermeeTitreLabel.Font = new Font("Segoe UI", 12.75F);
            PanelSalleFermeeTitreLabel.Location = new Point(0, 0);
            PanelSalleFermeeTitreLabel.Name = "PanelSalleFermeeTitreLabel";
            PanelSalleFermeeTitreLabel.Size = new Size(117, 23);
            PanelSalleFermeeTitreLabel.TabIndex = 3;
            PanelSalleFermeeTitreLabel.Text = "Salles fermées";
            // 
            // Pannel_SalleOuverte
            // 
            Pannel_SalleOuverte.BorderStyle = BorderStyle.FixedSingle;
            Pannel_SalleOuverte.Controls.Add(PanelSalleOuverteContainer);
            Pannel_SalleOuverte.Controls.Add(PanelSalleOuverteTitre);
            Pannel_SalleOuverte.Location = new Point(-1, 30);
            Pannel_SalleOuverte.Name = "Pannel_SalleOuverte";
            Pannel_SalleOuverte.Size = new Size(884, 125);
            Pannel_SalleOuverte.TabIndex = 7;
            // 
            // PanelSalleOuverteContainer
            // 
            PanelSalleOuverteContainer.Controls.Add(ExemplePannelSalleOuverte);
            PanelSalleOuverteContainer.Dock = DockStyle.Fill;
            PanelSalleOuverteContainer.Location = new Point(0, 24);
            PanelSalleOuverteContainer.Name = "PanelSalleOuverteContainer";
            PanelSalleOuverteContainer.Size = new Size(882, 99);
            PanelSalleOuverteContainer.TabIndex = 6;
            // 
            // ExemplePannelSalleOuverte
            // 
            ExemplePannelSalleOuverte.BorderStyle = BorderStyle.FixedSingle;
            ExemplePannelSalleOuverte.Controls.Add(ExempleLabel_OuvertLeDate);
            ExemplePannelSalleOuverte.Controls.Add(ExempleLabel_OuvertLe);
            ExemplePannelSalleOuverte.Controls.Add(ExempleLabel_OuvertParNom);
            ExemplePannelSalleOuverte.Controls.Add(ExempleLabel_OuvertPart);
            ExemplePannelSalleOuverte.Controls.Add(ExempleLabel_OuvertNum);
            ExemplePannelSalleOuverte.Location = new Point(-1, 6);
            ExemplePannelSalleOuverte.Name = "ExemplePannelSalleOuverte";
            ExemplePannelSalleOuverte.Size = new Size(181, 84);
            ExemplePannelSalleOuverte.TabIndex = 4;
            // 
            // ExempleLabel_OuvertLeDate
            // 
            ExempleLabel_OuvertLeDate.AutoSize = true;
            ExempleLabel_OuvertLeDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExempleLabel_OuvertLeDate.Location = new Point(77, 53);
            ExempleLabel_OuvertLeDate.Name = "ExempleLabel_OuvertLeDate";
            ExempleLabel_OuvertLeDate.Size = new Size(82, 17);
            ExempleLabel_OuvertLeDate.TabIndex = 4;
            ExempleLabel_OuvertLeDate.Text = "OpenedDate";
            // 
            // ExempleLabel_OuvertLe
            // 
            ExempleLabel_OuvertLe.AutoSize = true;
            ExempleLabel_OuvertLe.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExempleLabel_OuvertLe.Location = new Point(2, 53);
            ExempleLabel_OuvertLe.Name = "ExempleLabel_OuvertLe";
            ExempleLabel_OuvertLe.Size = new Size(79, 17);
            ExempleLabel_OuvertLe.TabIndex = 3;
            ExempleLabel_OuvertLe.Text = "Ouverte le : ";
            // 
            // ExempleLabel_OuvertParNom
            // 
            ExempleLabel_OuvertParNom.AutoSize = true;
            ExempleLabel_OuvertParNom.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExempleLabel_OuvertParNom.Location = new Point(86, 25);
            ExempleLabel_OuvertParNom.Name = "ExempleLabel_OuvertParNom";
            ExempleLabel_OuvertParNom.Size = new Size(87, 17);
            ExempleLabel_OuvertParNom.TabIndex = 2;
            ExempleLabel_OuvertParNom.Text = "OpenerName";
            // 
            // ExempleLabel_OuvertPart
            // 
            ExempleLabel_OuvertPart.AutoSize = true;
            ExempleLabel_OuvertPart.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExempleLabel_OuvertPart.Location = new Point(2, 25);
            ExempleLabel_OuvertPart.Name = "ExempleLabel_OuvertPart";
            ExempleLabel_OuvertPart.Size = new Size(89, 17);
            ExempleLabel_OuvertPart.TabIndex = 1;
            ExempleLabel_OuvertPart.Text = "Ouverte par : ";
            // 
            // ExempleLabel_OuvertNum
            // 
            ExempleLabel_OuvertNum.AutoSize = true;
            ExempleLabel_OuvertNum.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExempleLabel_OuvertNum.Location = new Point(2, 2);
            ExempleLabel_OuvertNum.Name = "ExempleLabel_OuvertNum";
            ExempleLabel_OuvertNum.Size = new Size(68, 17);
            ExempleLabel_OuvertNum.TabIndex = 0;
            ExempleLabel_OuvertNum.Text = "Salle XXX";
            // 
            // PanelSalleOuverteTitre
            // 
            PanelSalleOuverteTitre.Controls.Add(PanelSalleOuverteTitreLabel);
            PanelSalleOuverteTitre.Dock = DockStyle.Top;
            PanelSalleOuverteTitre.Location = new Point(0, 0);
            PanelSalleOuverteTitre.Name = "PanelSalleOuverteTitre";
            PanelSalleOuverteTitre.Size = new Size(882, 24);
            PanelSalleOuverteTitre.TabIndex = 5;
            // 
            // PanelSalleOuverteTitreLabel
            // 
            PanelSalleOuverteTitreLabel.AutoSize = true;
            PanelSalleOuverteTitreLabel.Dock = DockStyle.Fill;
            PanelSalleOuverteTitreLabel.Font = new Font("Segoe UI", 12.75F);
            PanelSalleOuverteTitreLabel.Location = new Point(0, 0);
            PanelSalleOuverteTitreLabel.Name = "PanelSalleOuverteTitreLabel";
            PanelSalleOuverteTitreLabel.Size = new Size(118, 23);
            PanelSalleOuverteTitreLabel.TabIndex = 3;
            PanelSalleOuverteTitreLabel.Text = "Salles Ouverte";
            PanelSalleOuverteTitreLabel.Click += label12_Click;
            // 
            // PAN_DroitHaut
            // 
            PAN_DroitHaut.BorderStyle = BorderStyle.FixedSingle;
            PAN_DroitHaut.Controls.Add(DashB_Label);
            PAN_DroitHaut.Dock = DockStyle.Top;
            PAN_DroitHaut.Location = new Point(0, 0);
            PAN_DroitHaut.Name = "PAN_DroitHaut";
            PAN_DroitHaut.Size = new Size(884, 55);
            PAN_DroitHaut.TabIndex = 0;
            // 
            // DashB_Label
            // 
            DashB_Label.AutoSize = true;
            DashB_Label.Font = new Font("Segoe UI", 21.75F);
            DashB_Label.Location = new Point(6, 9);
            DashB_Label.Name = "DashB_Label";
            DashB_Label.Size = new Size(156, 40);
            DashB_Label.TabIndex = 1;
            DashB_Label.Text = "Dashboard";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 581);
            Controls.Add(PAN_Droite);
            Controls.Add(PAN_Gauche);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Dashboard";
            Text = "Admin Pannel ";
            PAN_Droite.ResumeLayout(false);
            PAN_DroitBas.ResumeLayout(false);
            Pannel_SalleFermee.ResumeLayout(false);
            PanelSalleFermeeContainer.ResumeLayout(false);
            ExemplePannelSalleFermee.ResumeLayout(false);
            ExemplePannelSalleFermee.PerformLayout();
            PanelSalleFermeeTitre.ResumeLayout(false);
            PanelSalleFermeeTitre.PerformLayout();
            Pannel_SalleOuverte.ResumeLayout(false);
            PanelSalleOuverteContainer.ResumeLayout(false);
            ExemplePannelSalleOuverte.ResumeLayout(false);
            ExemplePannelSalleOuverte.PerformLayout();
            PanelSalleOuverteTitre.ResumeLayout(false);
            PanelSalleOuverteTitre.PerformLayout();
            PAN_DroitHaut.ResumeLayout(false);
            PAN_DroitHaut.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PAN_Gauche;
        private Panel PAN_Droite;
        private Panel PAN_DroitHaut;
        private Panel PAN_DroitBas;
        private Label DashB_Label;
        private Panel Pannel_SalleOuverte;
        private Panel PanelSalleOuverteTitre;
        private Label PanelSalleOuverteTitreLabel;
        private Panel ExemplePannelSalleOuverte;
        private Label ExempleLabel_OuvertLeDate;
        private Label ExempleLabel_OuvertLe;
        private Label ExempleLabel_OuvertParNom;
        private Label ExempleLabel_OuvertPart;
        private Label ExempleLabel_OuvertNum;
        private Panel Pannel_SalleFermee;
        private Panel PanelSalleFermeeTitre;
        private Label PanelSalleFermeeTitreLabel;
        private Panel ExemplePannelSalleFermee;
        private Label ExempleLabel_FermeLeDate;
        private Label ExempleLabel_FermeLe;
        private Label ExempleLabel_FermeParNom;
        private Label ExempleLabel_FermePar;
        private Label ExempleLabel_FermeNum;
        private Panel PanelSalleOuverteContainer;
        private Panel PanelSalleFermeeContainer;
    }
}