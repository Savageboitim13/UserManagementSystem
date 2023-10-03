using MySqlConnector;
using System.Collections.Generic;

namespace UMS.Backend.DB {
    internal class DataManager {
        private static MySqlConnection connection = Connection.Create();

        public static void LoadAccount(Account user) {
            using MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO Accounts (Username, Password) VALUES (@user, @pass);";
            cmd.Parameters.AddWithValue("@user", user.Username);
            cmd.Parameters.AddWithValue("@pass", user.Password);
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public static bool UsernameExists(string username) {
            List<string> usernames = new List<string>();

            using MySqlCommand cmd = new MySqlCommand($"SELECT * FROM Accounts WHERE Username = '{username}';");
            cmd.Connection = connection;
            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                usernames.Add(reader.GetString(1));
            }

            if(usernames.Contains(username)) {
                return false;
            } else {
                return true;
            }
        }
    }
}