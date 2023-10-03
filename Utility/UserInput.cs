using System;
using UMS.Backend;

namespace UMS.Utility {
    internal class UserInput {

        public static string Get(string message, bool require = false) {
            Console.Write($"\n{message}");

            // Skipping requirements if user tries to login
            if (require) {
                StdMsgs.Requirements(message.ToLower().Trim());
            }

            Console.Write("\n> ");

            // If nothing is given : return empty string
            return Console.ReadLine() ?? string.Empty;
        }

        public static ConsoleKeyInfo GetKey(string message) {
            Console.Write($"\n{message}");

            Console.Write("\n> ");

            // Return the read key
            return Console.ReadKey();
        }

        // Copied code (StackOverflow) : Masks input with '*'
        public static string GetMaskedInput(string message) {
            string input = string.Empty;
            ConsoleKey key;

            Console.Write($"\n{message}\n> ");

            do {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && input.Length > 0) {
                    Console.Write("\b \b");
                    input = input[0..^1];
                } else if (!char.IsControl(keyInfo.KeyChar)) {
                    Console.Write("*");
                    input += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return DataHasher.HashData(input);
        }
    }
}