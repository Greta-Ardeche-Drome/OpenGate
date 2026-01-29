
namespace OpenGate.UC.LDAP
{
    partial class GestionLDAP
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
            grpConnection = new GroupBox();
            SrvPort = new Label();
            txtPort = new TextBox();
            txtServer = new TextBox();
            SrvLDAP = new Label();
            grpBind = new GroupBox();
            txtMDP = new TextBox();
            BindMDP = new Label();
            txtDN = new TextBox();
            BindDN = new Label();
            grpOption = new GroupBox();
            btnSave = new Button();
            btnTest = new Button();
            stateLDAP = new CheckBox();
            userFilter = new Label();
            txtUserFilter = new TextBox();
            grpConnection.SuspendLayout();
            grpBind.SuspendLayout();
            grpOption.SuspendLayout();
            SuspendLayout();
            // 
            // grpConnection
            // 
            grpConnection.Controls.Add(SrvPort);
            grpConnection.Controls.Add(txtPort);
            grpConnection.Controls.Add(txtServer);
            grpConnection.Controls.Add(SrvLDAP);
            grpConnection.Location = new Point(3, 3);
            grpConnection.Name = "grpConnection";
            grpConnection.Size = new Size(967, 88);
            grpConnection.TabIndex = 1;
            grpConnection.TabStop = false;
            // 
            // SrvPort
            // 
            SrvPort.AutoSize = true;
            SrvPort.Location = new Point(291, 19);
            SrvPort.Name = "SrvPort";
            SrvPort.Size = new Size(29, 15);
            SrvPort.TabIndex = 6;
            SrvPort.Text = "Port";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(292, 37);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(200, 23);
            txtPort.TabIndex = 5;
            txtPort.Text = "389";
            txtPort.TextChanged += textBox1_TextChanged;
            // 
            // txtServer
            // 
            txtServer.Location = new Point(6, 37);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(200, 23);
            txtServer.TabIndex = 3;
            // 
            // SrvLDAP
            // 
            SrvLDAP.AutoSize = true;
            SrvLDAP.Location = new Point(6, 19);
            SrvLDAP.Name = "SrvLDAP";
            SrvLDAP.Size = new Size(78, 15);
            SrvLDAP.TabIndex = 2;
            SrvLDAP.Text = "Serveur LDAP";
            // 
            // grpBind
            // 
            grpBind.Controls.Add(txtMDP);
            grpBind.Controls.Add(BindMDP);
            grpBind.Controls.Add(txtDN);
            grpBind.Controls.Add(BindDN);
            grpBind.Location = new Point(3, 123);
            grpBind.Name = "grpBind";
            grpBind.Size = new Size(970, 86);
            grpBind.TabIndex = 6;
            grpBind.TabStop = false;
            // 
            // txtMDP
            // 
            txtMDP.Location = new Point(292, 37);
            txtMDP.Name = "txtMDP";
            txtMDP.Size = new Size(200, 23);
            txtMDP.TabIndex = 5;
            txtMDP.UseSystemPasswordChar = true;
            // 
            // BindMDP
            // 
            BindMDP.AutoSize = true;
            BindMDP.Location = new Point(292, 19);
            BindMDP.Name = "BindMDP";
            BindMDP.Size = new Size(77, 15);
            BindMDP.TabIndex = 4;
            BindMDP.Text = "Mot de Passe";
            // 
            // txtDN
            // 
            txtDN.Location = new Point(6, 37);
            txtDN.Name = "txtDN";
            txtDN.Size = new Size(200, 23);
            txtDN.TabIndex = 3;
            // 
            // BindDN
            // 
            BindDN.AutoSize = true;
            BindDN.Location = new Point(6, 19);
            BindDN.Name = "BindDN";
            BindDN.Size = new Size(60, 15);
            BindDN.TabIndex = 2;
            BindDN.Text = "Utilisateur";
            // 
            // grpOption
            // 
            grpOption.Controls.Add(txtUserFilter);
            grpOption.Controls.Add(userFilter);
            grpOption.Controls.Add(stateLDAP);
            grpOption.Location = new Point(1, 229);
            grpOption.Name = "grpOption";
            grpOption.Size = new Size(970, 86);
            grpOption.TabIndex = 7;
            grpOption.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(756, 452);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Enregistrer";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(9, 452);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(124, 23);
            btnTest.TabIndex = 0;
            btnTest.Text = "Tester la connexion";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // stateLDAP
            // 
            stateLDAP.AutoSize = true;
            stateLDAP.Location = new Point(57, 40);
            stateLDAP.Name = "stateLDAP";
            stateLDAP.Size = new Size(95, 19);
            stateLDAP.TabIndex = 0;
            stateLDAP.Text = "Activer LDAP";
            stateLDAP.UseVisualStyleBackColor = true;
            // 
            // userFilter
            // 
            userFilter.AutoSize = true;
            userFilter.Location = new Point(374, 30);
            userFilter.Name = "userFilter";
            userFilter.Size = new Size(94, 15);
            userFilter.TabIndex = 5;
            userFilter.Text = "Filtre Utilisateurs";
            // 
            // txtUserFilter
            // 
            txtUserFilter.Location = new Point(374, 48);
            txtUserFilter.Name = "txtUserFilter";
            txtUserFilter.Size = new Size(200, 23);
            txtUserFilter.TabIndex = 6;
            // 
            // GestionLDAP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 38, 52);
            Controls.Add(btnSave);
            Controls.Add(grpOption);
            Controls.Add(btnTest);
            Controls.Add(grpBind);
            Controls.Add(grpConnection);
            Name = "GestionLDAP";
            Size = new Size(973, 544);
            grpConnection.ResumeLayout(false);
            grpConnection.PerformLayout();
            grpBind.ResumeLayout(false);
            grpBind.PerformLayout();
            grpOption.ResumeLayout(false);
            grpOption.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox grpConnection;
        private Label SrvLDAP;
        private TextBox txtServer;
        private TextBox txtPort;
        private GroupBox grpBind;
        private TextBox txtMDP;
        private Label BindMDP;
        private TextBox txtDN;
        private Label BindDN;
        private Label SrvPort;
        private GroupBox grpOption;
        private Button btnSave;
        private Button btnTest;
        private TextBox txtUserFilter;
        private Label userFilter;
        private CheckBox stateLDAP;
    }
}
