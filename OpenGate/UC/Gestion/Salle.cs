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
    public partial class Salle : UserControl
    {
        SqlConnection _conn;
        public Salle(string lettreBat, string salle, SqlConnection _conn)
        {
            InitializeComponent();
            Lab_SalleNum.Text = "Salle " + salle;

            string query = "select count(position) from [PTUT].[dbo].[OGA_Portes] where batiment = '" + lettreBat + "' and numero = '" + salle + "';";
            // la commande nous rend un nombre, on le met dans une var

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                int nombrePortes = (int)command.ExecuteScalar();
                if (nombrePortes == 1) 
                {
                    UC.Gestion.Porte newPorte = new UC.Gestion.Porte(lettreBat, salle, "Unique", _conn);
                    Panel_Portes.Controls.Add(newPorte);
                } 
                else 
                {
                    foreach (string position in (string[])["AV", "AR"])
                    {
                        UC.Gestion.Porte newPorte = new UC.Gestion.Porte(lettreBat, salle, position, _conn);
                        Panel_Portes.Controls.Add(newPorte);
                    }
                }
            }
        }
    }
}
