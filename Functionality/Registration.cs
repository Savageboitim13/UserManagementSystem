using UMS.Backend.DB;
using UMS.Utility;

namespace UMS.Functionality {
    internal class Registration {
        public static void CreateAccount() {
            // Prompting the user for input and creating a user object
            Account user = new Account() {
                Username = UserInput.Get("\nUsername\n", true),
                Password = UserInput.Get("\nPassword\n", true)
            };

            // Validating account via RegEx requirements and looking for a duplicated username
            if (DataValidator.IsAccountValid(user) && DataManager.UsernameExists(user.Username)) {
                // Loading account into MariaDB
                DataManager.LoadAccount(user);
                System.Console.WriteLine("Registered!");
            }
        }
    }
}
