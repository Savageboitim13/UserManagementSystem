using System;
using UMS.Functionality;

namespace UMS.Utility {
    internal class Panel {
        public static void Display() {
            ConsoleKeyInfo option;

            do {
                option = UserInput.GetKey("1. Sign In\n2. Register\n3. Guest\n");
            } while (option.Equals(1) || option.Equals(2) || option.Equals(3));

            switch(option.ToString()) {
                case "1":
                    LogIn.Execute();
                    break;
                case "2":
                    Registration.CreateAccount();
                    break;
                case "3":
                    Console.WriteLine("Welcome guest!");
                    break;
            }
        }
    }
}