
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
            SrvDN = new Label();
            txtBaseDN = new TextBox();
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
            txtUserFilter = new TextBox();
            userFilter = new Label();
            stateLDAP = new CheckBox();
            btnSave = new Button();
            btnTest = new Button();
            stateSSL = new CheckBox();
            grpConnection.SuspendLayout();
            grpBind.SuspendLayout();
            grpOption.SuspendLayout();
            SuspendLayout();
            // 
            // grpConnection
            // 
            grpConnection.Controls.Add(stateSSL);
            grpConnection.Controls.Add(SrvDN);
            grpConnection.Controls.Add(txtBaseDN);
            grpConnection.Controls.Add(SrvPort);
            grpConnection.Controls.Add(txtPort);
            grpConnection.Controls.Add(txtServer);
            grpConnection.Controls.Add(SrvLDAP);
            grpConnection.Location = new Point(0, 26);
            grpConnection.Name = "grpConnection";
            grpConnection.Size = new Size(973, 88);
            grpConnection.TabIndex = 1;
            grpConnection.TabStop = false;
            // 
            // SrvDN
            // 
            SrvDN.AutoSize = true;
            SrvDN.Location = new Point(427, 19);
            SrvDN.Name = "SrvDN";
            SrvDN.Size = new Size(51, 15);
            SrvDN.TabIndex = 8;
            SrvDN.Text = "Base DN";
            // 
            // txtBaseDN
            // 
            txtBaseDN.Location = new Point(428, 37);
            txtBaseDN.Name = "txtBaseDN";
            txtBaseDN.PlaceholderText = "DC=domain,DC=local";
            txtBaseDN.Size = new Size(200, 23);
            txtBaseDN.TabIndex = 7;
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
            txtPort.Size = new Size(39, 23);
            txtPort.TabIndex = 5;
            txtPort.Text = "389";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(6, 37);
            txtServer.Name = "txtServer";
            txtServer.PlaceholderText = "srv-ad.domain.local";
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
            grpBind.Location = new Point(0, 120);
            grpBind.Name = "grpBind";
            grpBind.Size = new Size(973, 97);
            grpBind.TabIndex = 6;
            grpBind.TabStop = false;
            // 
            // txtMDP
            // 
            txtMDP.Location = new Point(350, 39);
            txtMDP.Name = "txtMDP";
            txtMDP.Size = new Size(200, 23);
            txtMDP.TabIndex = 5;
            txtMDP.UseSystemPasswordChar = true;
            // 
            // BindMDP
            // 
            BindMDP.AutoSize = true;
            BindMDP.Location = new Point(350, 21);
            BindMDP.Name = "BindMDP";
            BindMDP.Size = new Size(77, 15);
            BindMDP.TabIndex = 4;
            BindMDP.Text = "Mot de Passe";
            // 
            // txtDN
            // 
            txtDN.Location = new Point(6, 39);
            txtDN.Name = "txtDN";
            txtDN.PlaceholderText = "user@domain.local";
            txtDN.Size = new Size(282, 23);
            txtDN.TabIndex = 3;
            // 
            // BindDN
            // 
            BindDN.AutoSize = true;
            BindDN.Location = new Point(6, 21);
            BindDN.Name = "BindDN";
            BindDN.Size = new Size(60, 15);
            BindDN.TabIndex = 2;
            BindDN.Text = "Utilisateur";
            // 
            // grpOption
            // 
            grpOption.Controls.Add(txtUserFilter);
            grpOption.Controls.Add(userFilter);
            grpOption.Location = new Point(0, 223);
            grpOption.Name = "grpOption";
            grpOption.Size = new Size(973, 86);
            grpOption.TabIndex = 7;
            grpOption.TabStop = false;
            // 
            // txtUserFilter
            // 
            txtUserFilter.Location = new Point(9, 37);
            txtUserFilter.Name = "txtUserFilter";
            txtUserFilter.PlaceholderText = "(&(objectClass=user)(memberOf=CN=NomDuGroupe,OU=Groupes,DC=domain,DC=local))";
            txtUserFilter.Size = new Size(541, 23);
            txtUserFilter.TabIndex = 6;
            // 
            // userFilter
            // 
            userFilter.AutoSize = true;
            userFilter.Location = new Point(9, 19);
            userFilter.Name = "userFilter";
            userFilter.Size = new Size(94, 15);
            userFilter.TabIndex = 5;
            userFilter.Text = "Filtre Utilisateurs";
            // 
            // stateLDAP
            // 
            stateLDAP.AutoSize = true;
            stateLDAP.Location = new Point(0, 3);
            stateLDAP.Name = "stateLDAP";
            stateLDAP.Size = new Size(95, 19);
            stateLDAP.TabIndex = 0;
            stateLDAP.Text = "Activer LDAP";
            stateLDAP.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(797, 430);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Enregistrer";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(9, 430);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(124, 23);
            btnTest.TabIndex = 0;
            btnTest.Text = "Tester la connexion";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // stateSSL
            // 
            stateSSL.AutoSize = true;
            stateSSL.Location = new Point(688, 41);
            stateSSL.Name = "stateSSL";
            stateSSL.Size = new Size(44, 19);
            stateSSL.TabIndex = 9;
            stateSSL.Text = "SSL";
            stateSSL.UseVisualStyleBackColor = true;
            // 
            // GestionLDAP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 38, 52);
            Controls.Add(btnSave);
            Controls.Add(grpOption);
            Controls.Add(stateLDAP);
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
            PerformLayout();
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
        private Label SrvDN;
        private TextBox txtBaseDN;
        private CheckBox stateSSL;
    }
}
