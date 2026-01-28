using Microsoft.Data.SqlClient;
using OpenGate.UC.Gestion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenGate.UC
{
    public partial class GestionBat : UserControl
    {
        SqlConnection _conn;
        List<Batiment> ListeBatiment = new List<Batiment>();
        public GestionBat(SqlConnection conn)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            _conn = conn;

            UpdateList();
        }

        private void Update_Button(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            Panel_BatListe.Controls.Clear();

            string query = "select DISTINCT [batiment] from PTUT.dbo.OGA_Portes;";
            List<string> ListeBatiments = new List<string>();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) { ListeBatiments.Add(reader[0].ToString()!); }
                }
            }

            foreach (string bat in ListeBatiments)
            {
                UC.Gestion.Batiment newBat = new UC.Gestion.Batiment(bat, _conn);
                newBat.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                Panel_BatListe.Controls.Add(newBat);
                ListeBatiment.Add(newBat);
            }
        }

        private void ChangingSize(object sender, EventArgs e)
        {
            foreach (Batiment b in ListeBatiment)
            {
                b.Width = Panel_BatListe.ClientSize.Width - b.Margin.Left - b.Margin.Right;
            }
        }
    }
}
