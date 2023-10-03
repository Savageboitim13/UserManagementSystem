using System;

namespace UMS.Utility {
    internal class StdMsgs {
        public static void Welcome() {
            Console.WriteLine("Welcome to my 'Text-Based User-Management-System with Hashed File-System Storage in C# (TB-UMS-HFSS)'!\n", "green");
        }

        public static void EndApplication() {
            Console.WriteLine("\nPress enter to close...", "white");
            Console.ReadKey();
        }

        public static void Requirements(string message) {
            // Writes requirements depending on the message
            if (message == "username") {
                // Username requirements
                Console.WriteLine("\nNo special characters\nLength: 2-16", "magenta");
            } else if (message == "password") {
                // Password requirements
                string[] requirements = new string[] {
                        "\n1 capital letter",
                        "1 number (digit)",
                        "1 special character",
                        "Length: 6-128"
                    };

                // Prints the password requirements
                foreach (string requirement in requirements) { Console.WriteLine(requirement, "magenta"); }
            }
        }

        public static void DisplayError(string fieldName) {
            Console.WriteLine($"You didn't give a valid {fieldName}!", "red");
        }
    }
}
