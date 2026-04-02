using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.DirectoryServices.Protocols;

namespace OpenGate.UC
{
    public partial class Login : UserControl
    {
        private SqlConnection _conn;

        public Login(SqlConnection conn)
        {
            InitializeComponent();
            _conn = conn;

            AuthMode.SelectedItem = "BDD";
        }

        private void But_Login_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string passwd = Passwd.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(passwd))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            string authMode = AuthMode.SelectedItem?.ToString() ?? "BDD";

            try
            {
                if (authMode == "BDD")
                {
                    AuthBDD(username, passwd);
                }
                else if (authMode == "LDAP")
                {
                    AuthLDAP(username, passwd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }
        }
        private void AuthBDD(string username, string passwd) 
        {
            string sql = "SELECT passwd FROM [PTUT].[dbo].[OGA_Users] WHERE username = @user";
            
            try
            {
                if (_conn.State != ConnectionState.Open) _conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string dbHash = result as string ?? "";

                        // Vérification du mot de passe avec ton utilitaire BCrypt
                        if (Utils.HashUtils.verifyPASSWD(passwd, dbHash))
                        {

                            // Redirection vers le StartUp de la fenêtre Main
                            if (this.FindForm() is Main maFenetre)
                            {
                                maFenetre.StartUp(username);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mot de passe incorrect !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Utilisateur introuvable !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }
        }

        private void AuthLDAP(string username, string passwd)
        {
            string ldapServer = Properties.Settings.Default.LdapServer;
            int ldapPort = Properties.Settings.Default.LdapPort;
            string ldapBindDn = Properties.Settings.Default.LdapBindDn;
            string ldapPassword = Properties.Settings.Default.LdapPassword;
            string baseDn = Properties.Settings.Default.LdapBaseDn;
            string userFilter = Properties.Settings.Default.LdapFilter ?? "(objectClass=*)";
            bool useSSL = Properties.Settings.Default.LdapUseSSL;

            if (string.IsNullOrWhiteSpace(ldapServer) ||
                string.IsNullOrWhiteSpace(ldapBindDn) ||
                string.IsNullOrWhiteSpace(ldapPassword))
            {
                throw new Exception("La configuration LDAP est incomplète.");
            }

            var identifier = new LdapDirectoryIdentifier(ldapServer, ldapPort);
            var credential = new NetworkCredential(ldapBindDn, ldapPassword);
            using (var connection = new LdapConnection(identifier, credential))
            {
                if (useSSL)
                {
                    connection.SessionOptions.SecureSocketLayer = true;
                    connection.SessionOptions.VerifyServerCertificate += (conn, cert) => true;
                }

                connection.Bind();

                // On cherche le DN de l'utilisateur
                var searchRequest = new SearchRequest(
                    baseDn,
                    $"(&(objectClass=user)(sAMAccountName={username}))",
                    SearchScope.Subtree
                );

                var response = (SearchResponse)connection.SendRequest(searchRequest);

                if (response.Entries.Count == 0)
                    throw new Exception("Utilisateur introuvable dans l'annuaire LDAP.");

                string userDn = response.Entries[0].DistinguishedName;

                // Test du mot de passe de l'utilisateur
                var userCredential = new NetworkCredential(userDn, passwd);
                using (var userConn = new LdapConnection(identifier, userCredential))
                {
                    if (useSSL)
                    {
                        userConn.SessionOptions.SecureSocketLayer = true;
                        userConn.SessionOptions.VerifyServerCertificate += (conn, cert) => true;
                    }

                    userConn.Bind(); // Exception si mot de passe incorrect
                }

                if (this.FindForm() is Main maFenetre)
                {
                    maFenetre.StartUp(username);
                }
            }
        }

        private void Passwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                But_Login_Click(sender, e);
            }
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                But_Login_Click(sender, e);
            }
        }
    }
}