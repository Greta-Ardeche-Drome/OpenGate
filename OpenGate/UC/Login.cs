using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OpenGate.UC
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AddNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Main maFenetre = (Main)this.FindForm();
            maFenetre.ClearPanel();
            maFenetre.Resize_Window("Register");
            maFenetre.PannelLogin.Controls.Add(new Register());
        }
    }
}
