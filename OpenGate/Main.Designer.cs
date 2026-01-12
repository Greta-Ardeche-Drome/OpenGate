namespace OpenGate
{
    partial class Main
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
            PannelLogin = new Panel();
            PannelTopBar = new Panel();
            Panel_MenuTop = new FlowLayoutPanel();
            But_Gestion = new Button();
            But_Home = new Button();
            PanelProfile = new Panel();
            But_Profile = new Button();
            Label_UserName = new Label();
            But_Logoff = new Button();
            PannelOptions = new FlowLayoutPanel();
            But_NewUser = new Button();
            PannelMain = new Panel();
            PannelTopBar.SuspendLayout();
            Panel_MenuTop.SuspendLayout();
            PanelProfile.SuspendLayout();
            PannelOptions.SuspendLayout();
            SuspendLayout();
            // 
            // PannelLogin
            // 
            PannelLogin.BackColor = Color.Transparent;
            PannelLogin.Location = new Point(0, 0);
            PannelLogin.Name = "PannelLogin";
            PannelLogin.Size = new Size(10, 10);
            PannelLogin.TabIndex = 1;
            // 
            // PannelTopBar
            // 
            PannelTopBar.BackColor = Color.FromArgb(24, 26, 36);
            PannelTopBar.Controls.Add(Panel_MenuTop);
            PannelTopBar.Controls.Add(But_Home);
            PannelTopBar.Controls.Add(PanelProfile);
            PannelTopBar.Dock = DockStyle.Top;
            PannelTopBar.Location = new Point(0, 0);
            PannelTopBar.Name = "PannelTopBar";
            PannelTopBar.Size = new Size(1248, 59);
            PannelTopBar.TabIndex = 0;
            // 
            // Panel_MenuTop
            // 
            Panel_MenuTop.BackColor = Color.Transparent;
            Panel_MenuTop.Controls.Add(But_Gestion);
            Panel_MenuTop.Location = new Point(62, 6);
            Panel_MenuTop.Name = "Panel_MenuTop";
            Panel_MenuTop.Size = new Size(996, 45);
            Panel_MenuTop.TabIndex = 8;
            // 
            // But_Gestion
            // 
            But_Gestion.BackColor = Color.FromArgb(35, 38, 52);
            But_Gestion.FlatAppearance.BorderSize = 0;
            But_Gestion.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            But_Gestion.FlatStyle = FlatStyle.Flat;
            But_Gestion.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            But_Gestion.ForeColor = SystemColors.ButtonFace;
            But_Gestion.Location = new Point(3, 3);
            But_Gestion.Name = "But_Gestion";
            But_Gestion.Size = new Size(112, 40);
            But_Gestion.TabIndex = 6;
            But_Gestion.Text = "Salles";
            But_Gestion.UseVisualStyleBackColor = false;
            But_Gestion.Click += ManagePage;
            // 
            // But_Home
            // 
            But_Home.BackColor = Color.Transparent;
            But_Home.BackgroundImage = Res.Img.images.Home;
            But_Home.BackgroundImageLayout = ImageLayout.Zoom;
            But_Home.FlatAppearance.BorderSize = 0;
            But_Home.Location = new Point(9, 8);
            But_Home.Name = "But_Home";
            But_Home.Size = new Size(40, 40);
            But_Home.TabIndex = 5;
            But_Home.UseVisualStyleBackColor = false;
            But_Home.Click += But_Home_Click;
            // 
            // PanelProfile
            // 
            PanelProfile.Controls.Add(But_Profile);
            PanelProfile.Controls.Add(Label_UserName);
            PanelProfile.Location = new Point(1064, 8);
            PanelProfile.Name = "PanelProfile";
            PanelProfile.Size = new Size(179, 40);
            PanelProfile.TabIndex = 4;
            // 
            // But_Profile
            // 
            But_Profile.BackColor = Color.Transparent;
            But_Profile.BackgroundImage = Res.Img.images.Logo;
            But_Profile.BackgroundImageLayout = ImageLayout.Zoom;
            But_Profile.FlatAppearance.BorderSize = 0;
            But_Profile.Location = new Point(136, 1);
            But_Profile.Name = "But_Profile";
            But_Profile.Size = new Size(40, 40);
            But_Profile.TabIndex = 4;
            But_Profile.UseVisualStyleBackColor = false;
            But_Profile.Click += But_Profile_Click;
            // 
            // Label_UserName
            // 
            Label_UserName.AutoSize = true;
            Label_UserName.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            Label_UserName.ForeColor = Color.White;
            Label_UserName.Location = new Point(-4, 5);
            Label_UserName.Name = "Label_UserName";
            Label_UserName.Size = new Size(139, 32);
            Label_UserName.TabIndex = 4;
            Label_UserName.Text = "USERNAME";
            // 
            // But_Logoff
            // 
            But_Logoff.BackColor = Color.FromArgb(42, 46, 62);
            But_Logoff.FlatAppearance.BorderSize = 0;
            But_Logoff.FlatStyle = FlatStyle.Flat;
            But_Logoff.ForeColor = Color.FromArgb(255, 118, 117);
            But_Logoff.Location = new Point(3, 45);
            But_Logoff.Name = "But_Logoff";
            But_Logoff.Size = new Size(194, 36);
            But_Logoff.TabIndex = 3;
            But_Logoff.Text = "Déconnexion";
            But_Logoff.UseVisualStyleBackColor = false;
            But_Logoff.Click += But_Logoff_Click;
            // 
            // PannelOptions
            // 
            PannelOptions.BackColor = Color.FromArgb(35, 38, 52);
            PannelOptions.BorderStyle = BorderStyle.FixedSingle;
            PannelOptions.Controls.Add(But_NewUser);
            PannelOptions.Controls.Add(But_Logoff);
            PannelOptions.Location = new Point(1025, 49);
            PannelOptions.Name = "PannelOptions";
            PannelOptions.Size = new Size(200, 88);
            PannelOptions.TabIndex = 3;
            PannelOptions.Visible = false;
            // 
            // But_NewUser
            // 
            But_NewUser.BackColor = Color.FromArgb(42, 46, 62);
            But_NewUser.FlatAppearance.BorderSize = 0;
            But_NewUser.FlatStyle = FlatStyle.Flat;
            But_NewUser.ForeColor = Color.FromArgb(220, 221, 225);
            But_NewUser.Location = new Point(3, 3);
            But_NewUser.Name = "But_NewUser";
            But_NewUser.Size = new Size(194, 36);
            But_NewUser.TabIndex = 4;
            But_NewUser.Text = "Ajouter un compte admin";
            But_NewUser.UseVisualStyleBackColor = false;
            But_NewUser.Click += But_NewUser_Click;
            // 
            // PannelMain
            // 
            PannelMain.BackColor = Color.FromArgb(30, 33, 45);
            PannelMain.Dock = DockStyle.Fill;
            PannelMain.Location = new Point(0, 59);
            PannelMain.Name = "PannelMain";
            PannelMain.Size = new Size(1248, 622);
            PannelMain.TabIndex = 4;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 33, 45);
            ClientSize = new Size(1248, 681);
            Controls.Add(PannelOptions);
            Controls.Add(PannelLogin);
            Controls.Add(PannelMain);
            Controls.Add(PannelTopBar);
            ForeColor = Color.White;
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Open Gate Admin";
            PannelTopBar.ResumeLayout(false);
            Panel_MenuTop.ResumeLayout(false);
            PanelProfile.ResumeLayout(false);
            PanelProfile.PerformLayout();
            PannelOptions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public Panel PannelLogin;
        private Panel PannelTopBar;
        private Button But_Logoff;
        private Panel PanelProfile;
        private Label Label_UserName;
        private FlowLayoutPanel PannelOptions;
        private Button But_Profile;
        private Button But_NewUser;
        private Panel PannelMain;
        private Button But_Home;
        private Button But_Gestion;
        private FlowLayoutPanel Panel_MenuTop;
    }
}