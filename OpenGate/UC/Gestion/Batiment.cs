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
    public partial class Batiment : UserControl
    {
        SqlConnection _conn;
        public Batiment(string lettreBat, SqlConnection conn)
        {
            InitializeComponent();
            _conn = conn;

            Lab_BatimentNom.Text = "Bâtiment " + lettreBat;

            string query = "select distinct numero from [PTUT].[dbo].[OGA_Portes] where batiment = '" + lettreBat + "';";
            List<string> ListeSalles = new List<string>();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) { ListeSalles.Add(reader[0].ToString()); }
                }
            }

            foreach (string salle in ListeSalles)
            {
                UC.Gestion.Salle newSalle = new UC.Gestion.Salle(lettreBat, salle, _conn);
                newSalle.Padding = new Padding(0, 0, 0, 3);
                Panel_BatimentListe.Controls.Add(newSalle);
            }
        }
    }
}
