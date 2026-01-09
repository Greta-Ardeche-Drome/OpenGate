namespace OpenGate.UC
{
    partial class Login
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
            Lab_Username = new Label();
            Lab_Passwd = new Label();
            Username = new TextBox();
            Passwd = new TextBox();
            MainTitle = new Label();
            But_Login = new Button();
            StayLogin = new CheckBox();
            SuspendLayout();
            // 
            // Lab_Username
            // 
            Lab_Username.AutoSize = true;
            Lab_Username.ForeColor = Color.FromArgb(170, 175, 190);
            Lab_Username.Location = new Point(14, 58);
            Lab_Username.Name = "Lab_Username";
            Lab_Username.Size = new Size(99, 15);
            Lab_Username.TabIndex = 0;
            Lab_Username.Text = "Nom d'utilisateur";
            // 
            // Lab_Passwd
            // 
            Lab_Passwd.AutoSize = true;
            Lab_Passwd.ForeColor = Color.FromArgb(170, 175, 190);
            Lab_Passwd.Location = new Point(14, 88);
            Lab_Passwd.Name = "Lab_Passwd";
            Lab_Passwd.Size = new Size(77, 15);
            Lab_Passwd.TabIndex = 1;
            Lab_Passwd.Text = "Mot de passe";
            // 
            // Username
            // 
            Username.BackColor = Color.FromArgb(30, 33, 45);
            Username.BorderStyle = BorderStyle.FixedSingle;
            Username.ForeColor = SystemColors.ButtonFace;
            Username.Location = new Point(119, 55);
            Username.Name = "Username";
            Username.PlaceholderText = "Username";
            Username.Size = new Size(169, 23);
            Username.TabIndex = 2;
            // 
            // Passwd
            // 
            Passwd.BackColor = Color.FromArgb(30, 33, 45);
            Passwd.BorderStyle = BorderStyle.FixedSingle;
            Passwd.ForeColor = SystemColors.ButtonFace;
            Passwd.Location = new Point(119, 88);
            Passwd.Name = "Passwd";
            Passwd.PasswordChar = '*';
            Passwd.PlaceholderText = "Password";
            Passwd.Size = new Size(169, 23);
            Passwd.TabIndex = 3;
            // 
            // MainTitle
            // 
            MainTitle.AutoSize = true;
            MainTitle.BackColor = Color.Transparent;
            MainTitle.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainTitle.ForeColor = Color.White;
            MainTitle.Location = new Point(95, 11);
            MainTitle.Name = "MainTitle";
            MainTitle.Size = new Size(110, 30);
            MainTitle.TabIndex = 4;
            MainTitle.Text = "OpenGate";
            // 
            // But_Login
            // 
            But_Login.BackColor = Color.FromArgb(52, 152, 219);
            But_Login.FlatAppearance.BorderSize = 0;
            But_Login.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            But_Login.FlatStyle = FlatStyle.Flat;
            But_Login.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            But_Login.ForeColor = Color.White;
            But_Login.Location = new Point(134, 122);
            But_Login.Name = "But_Login";
            But_Login.Size = new Size(160, 34);
            But_Login.TabIndex = 5;
            But_Login.Text = "Connexion";
            But_Login.UseVisualStyleBackColor = false;
            But_Login.Click += But_Login_Click;
            // 
            // StayLogin
            // 
            StayLogin.AutoSize = true;
            StayLogin.FlatStyle = FlatStyle.Flat;
            StayLogin.ForeColor = Color.FromArgb(170, 175, 190);
            StayLogin.Location = new Point(14, 129);
            StayLogin.Name = "StayLogin";
            StayLogin.Size = new Size(111, 19);
            StayLogin.TabIndex = 12;
            StayLogin.Text = "Rester connecter";
            StayLogin.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 46, 62);
            Controls.Add(StayLogin);
            Controls.Add(But_Login);
            Controls.Add(MainTitle);
            Controls.Add(Passwd);
            Controls.Add(Username);
            Controls.Add(Lab_Passwd);
            Controls.Add(Lab_Username);
            Name = "Login";
            Size = new Size(310, 167);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lab_Username;
        private Label Lab_Passwd;
        private TextBox Username;
        private TextBox Passwd;
        private Label MainTitle;
        private Button But_Login;
        private CheckBox StayLogin;
    }
}
