using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OpenGate.UC.Gestion
{
    public partial class Porte : UserControl
    {
        public Porte(string lettreBat, string salle, string position, SqlConnection _conn)
        {
            InitializeComponent();

            string pos = (position == "AV") ? "Avant" : "Arrière";

            Lab_PorteType.Text = "Porte " + position;

            string query = "SELECT [porte] FROM [PTUT].[dbo].[OGA_Portes] WHERE batiment = '" + lettreBat + "' and numero = '" + salle + "' and position = '" + position + "';";
            // la commande nous rend un nombre, on le met dans une var

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                string nomPorte = (string)command.ExecuteScalar();
                Lab_PorteName.Text = nomPorte;
            }
        }
    }
}
