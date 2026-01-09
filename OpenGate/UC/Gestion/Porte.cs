using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenGate.UC.Gestion
{
    public partial class Porte : UserControl
    {
        public Porte(string lettreBat, string salle, string label)
        {
            InitializeComponent();

            Lab_PorteType.Text = "Porte " + label;
        }
    }
}
