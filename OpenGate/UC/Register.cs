using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenGate.UC
{
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void AddNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Main maFenetre = (Main)this.FindForm();
            maFenetre.ClearPanel();
            maFenetre.Resize_Window("Login");
            maFenetre.PannelLogin.Controls.Add(new Login());
        }
    }
}
