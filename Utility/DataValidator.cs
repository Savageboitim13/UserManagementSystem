using System.Text.RegularExpressions;
using UMS.Backend.DB;

namespace UMS.Utility {
    internal class DataValidator {
        public static bool IsAccountValid(Account user) {
            /* RegEx checks the username / password
             * (?=.*[A-Z])        : At least one uppercase letter.
             * (?=.*[a-z])        : At least one lowercase letter.
             * (?=.*\d)           : At least one digit (number).
             * (?=.*[^A-Za-z0-9]) : At least one special character.
             * .{2, 15}           : Length - 2-15 characters.
             * .{6, 128}           : Length - 6-18 characters.
             */

            string username = user.Username;
            string password = user.Password;

            // Validationpatterns
            string namePattern = "^[A-Za-z0-9]{2,16}$";
            string passPattern = "^(?=.*[A-Z])(?=.*[\\W_])(?=.*[0-9])(?=.*[a-zA-Z\\s]).{8,128}$";

            // Validating username / password with RegEx patterns
            bool namePassvalid = Regex.IsMatch(username, namePattern) && Regex.IsMatch(password, passPattern);
            bool namePassEmpty = username == string.Empty || password == string.Empty;

            return namePassvalid && !namePassEmpty;
        }
    }
}
