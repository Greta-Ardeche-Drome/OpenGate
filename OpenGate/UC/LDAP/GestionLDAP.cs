
using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.DirectoryServices.Protocols;

namespace OpenGate.UC.LDAP
{
    public partial class GestionLDAP : UserControl
    {
        public GestionLDAP()
        {
            InitializeComponent();
        }

        // Modèle de configuration
        private class LdapConfig
        {
            public string Server { get; set; }
            public int Port { get; set; }
            public string BindDn { get; set; }
            public string Password { get; set; }
            public string UserFilter { get; set; }
            public bool Enabled { get; set; }
        }

        // Lecture UI
        private LdapConfig ReadForm()
        {
            return new LdapConfig
            {
                Server = txtServer.Text.Trim(),
                Port = int.Parse(txtPort.Text),
                BindDn = txtDN.Text.Trim(),
                Password = txtMDP.Text,
                UserFilter = txtUserFilter.Text.Trim(),
                Enabled = stateLDAP.Checked
            };
        }

        // Test connexion LDAP
        // ======================
        private void TestLdap(LdapConfig config)
        {
            var identifier = new LdapDirectoryIdentifier(
                config.Server,
                config.Port
            );

            var credential = new NetworkCredential(
                config.BindDn,
                config.Password
            );

            using var connection = new LdapConnection(identifier, credential);
            connection.Bind(); // exception si erreur
        }

        // Bouton TEST
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                var config = ReadForm();
                TestLdap(config);

                MessageBox.Show(
                    "Connexion LDAP OK ✅",
                    "LDAP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Connexion LDAP échouée ❌\n" + ex.Message,
                    "LDAP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Bouton SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var config = ReadForm();

                var json = JsonSerializer.Serialize(
                    config,
                    new JsonSerializerOptions { WriteIndented = true }
                );

                File.WriteAllText("ldap-config.json", json);

                MessageBox.Show(
                    "Configuration LDAP enregistrée 💾",
                    "LDAP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur sauvegarde ❌\n" + ex.Message,
                    "LDAP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
