
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
using System.Drawing.Text;

namespace OpenGate.UC.LDAP
{
    public partial class GestionLDAP : UserControl
    {
        public GestionLDAP()
        {
            InitializeComponent();

            // État initial : tout désactivé
            SetControlsEnabled(stateLDAP.Checked);

            // Ajouter l’événement
            stateLDAP.CheckedChanged += (sender, e) =>
            {
                SetControlsEnabled(stateLDAP.Checked);
            };
        }

        // Modèle de configuration
        private class LdapConfig
        {
            public required string Server { get; set; }
            public required int Port { get; set; }
            public required string BindDn { get; set; }
            public string BaseDn { get; set; }
            public required string Password { get; set; }
            public string? UserFilter { get; set; }
            public bool UseSSL { get; set; }
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
                UserFilter = string.IsNullOrWhiteSpace(txtUserFilter.Text) ? "(objectClass=*)" : txtUserFilter.Text.Trim(), // Valeur par défault
                BaseDn = txtBaseDN.Text.Trim(),
                UseSSL = stateSSL.Checked
            };
        }

        private void SetControlsEnabled(bool enabled)
        {
            // Groupe Connexion LDAP
            txtServer.Enabled = enabled;
            txtPort.Enabled = enabled;
            txtBaseDN.Enabled = enabled;
            stateSSL.Enabled = enabled;

            // Groupe Bind
            txtDN.Enabled = enabled;
            txtMDP.Enabled = enabled;

            // Groupe Option
            txtUserFilter.Enabled = enabled;

            // Boutons
            btnTest.Enabled = enabled;
            btnSave.Enabled = enabled;
        }

        // Test connexion LDAP
        private void TestLdap(LdapConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.Server))
                throw new Exception("Le Server doit être renseigné pour la connexion.");

            var identifier = new LdapDirectoryIdentifier(
                config.Server,
                config.Port
            );

            LdapConnection connection;

            if (string.IsNullOrWhiteSpace(config.BindDn) || string.IsNullOrWhiteSpace(config.Password))
                throw new Exception("L'Utilisateur et son MDP doit être renseignés pour la connexion.");
            
            var credential = new NetworkCredential(config.BindDn, config.Password);
            connection = new LdapConnection(identifier, credential);

            // ✅ Activer SSL si demandé
            if (config.UseSSL)
            {
                connection.SessionOptions.SecureSocketLayer = true;
                connection.SessionOptions.VerifyServerCertificate += (conn, cert) => true; // Accepter tous les certificats
            }

            connection.Bind();

            var request = new SearchRequest(
                config.BaseDn,
                config.UserFilter,
                SearchScope.Base
            );

            var response = (SearchResponse)connection.SendRequest(request);
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
    }
}
