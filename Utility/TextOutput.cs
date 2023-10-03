using System;

namespace UMS.Utility {
    // Changing text color based on parameter
    public class TextOutput {
        public static void Success(string output) {
            Colored(output, "green");
            Console.ResetColor();
        }

        public static void Failure(string output) {
            Colored(output, "red");
            Console.ResetColor();
        }

        public static void Informative(string output) {
            Colored(output, "darkyellow");
            Console.ResetColor();
        }

        public static void Important(string output) {
            Colored(output, "magenta");
        }

        public static void Colored(string output, string color) {
            // Setting foreground color
            switch (color) {
                case "black":
                Console.ForegroundColor = ConsoleColor.Black;
                break;

                case "darkblue":
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                break;

                case "darkgreen":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;

                case "darkcyan":
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;

                case "darkred":
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;

                case "darkmagenta":
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;

                case "darkyellow":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;

                case "gray":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;

                case "darkgray":
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;

                case "blue":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;

                case "green":
                Console.ForegroundColor = ConsoleColor.Green;
                break;

                case "cyan":
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;

                case "red":
                Console.ForegroundColor = ConsoleColor.Red;
                break;

                case "magenta":
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;

                case "yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

                case "white":
                Console.ForegroundColor = ConsoleColor.White;
                break;

                default:
                Colored("\nInvalid color input!\n", "red");
                break;
            }

            // Outputing and resetting
            Console.WriteLine(output);
            Console.ResetColor();
        }
    }
}
