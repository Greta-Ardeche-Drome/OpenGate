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

            string query = "select count(position) from [PTUT].[dbo].[OGA_Portes] where batiment = 'A' and numero = '101';";
            // la commande nous rend un nombre, on le met dans une var
            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                int nombrePortes = (int)command.ExecuteScalar();
                if (nombrePortes == 1) 
                {
                    UC.Gestion.Porte newPorte = new UC.Gestion.Porte(lettreBat, salle, "Unique");
                    Panel_Portes.Controls.Add(newPorte);
                } 
                else 
                {
                    foreach (string a in (string[])["Avant", "Arrière"])
                    {
                        UC.Gestion.Porte newPorte = new UC.Gestion.Porte(lettreBat, salle, a);
                        Panel_Portes.Controls.Add(newPorte);
                    }
                }
            }
        }
    }
}
