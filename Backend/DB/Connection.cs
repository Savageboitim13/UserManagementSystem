// Libraries for funtionality (SSH, MariaDB)
using MySqlConnector;
using Renci.SshNet;
// System (ConfigurationManager, NameValueCollection, List<>)
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace UMS.Backend.DB {
    internal class Connection {
        // Reading all keys from App.config
        private static readonly NameValueCollection AS = ConfigurationManager.AppSettings;
        private static readonly MySqlConnection connection = Create();

        // Estabilish SSH connection via Username & Password or via SSHKeyFile & PassPhrase
        private static (SshClient SshClient, uint Port) ConnectSsh(string sshHostName, string sshUserName, string sshPassword = null,
            string KeyFilePath = null, string PassPhrase = null, int sshPort = 22, string databaseServer = "127.0.0.1", int databasePort = 3306) {

            // Checking for required arguments
            if (string.IsNullOrEmpty(sshHostName) || 
                string.IsNullOrEmpty(sshUserName) || 
                (string.IsNullOrEmpty(sshPassword) && string.IsNullOrEmpty(KeyFilePath)) ||
                string.IsNullOrEmpty(databaseServer)) {
                throw new ArgumentException("All required parameters must be specified.");
            }


            // Configuring authentication method order
            List<AuthenticationMethod> authenticationMethods = new List<AuthenticationMethod>();
            PrivateKeyFile SshKeyFile = new PrivateKeyFile(KeyFilePath, string.IsNullOrEmpty(PassPhrase) ? null : PassPhrase);

            if (!string.IsNullOrEmpty(KeyFilePath)) {
                authenticationMethods.Add(new PrivateKeyAuthenticationMethod(sshUserName, SshKeyFile));
            }
            if (!string.IsNullOrEmpty(sshPassword)) {
                authenticationMethods.Add(new PasswordAuthenticationMethod(sshUserName, sshPassword));
            }

            // Establishing SSH connection
            SshClient sshClient = new SshClient(new ConnectionInfo(sshHostName, sshPort, sshUserName, authenticationMethods.ToArray()));
            sshClient.Connect();

            // Forwarding a local port to DB-server and port
            ForwardedPortLocal forwardedPort = new ForwardedPortLocal("127.0.0.1", databaseServer, (uint) databasePort);
            sshClient.AddForwardedPort(forwardedPort);
            forwardedPort.Start();

            // Returning the client and the BoundPort
            return (sshClient, forwardedPort.Port);
        }

        public static MySqlConnection Create() {            
            // Establishing SSH connection - getting sshClient and localPort
            var (sshClient, localPort) = ConnectSsh(AS["sshHost"], AS["sshUser"], KeyFilePath: "/home/venenjean/.ssh/id_ed25519", PassPhrase: AS["sshPassPhrase"]);
            
            // Connecting to DB through SSH forwaded connection - disposing sshClient
            using (sshClient) {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder {
                    Server = "127.0.0.1",
                    Port = localPort,
                    UserID = AS["dbUser"],
                    Password = AS["dbPass"],
                    Database = AS["dbName"]
                };

                MySqlConnection connection = new MySqlConnection(csb.ConnectionString);
                connection.Open();

                return connection;
            }
        }
    }
}