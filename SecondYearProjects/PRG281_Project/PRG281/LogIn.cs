using System;

namespace PRG281
{
    internal class LogIn
    {
        public static bool ShowLogin()
        {
            Loading.ShowLoading();
            Boolean LoggedIn = false;
            // Loop until successful login
            while (!LoggedIn)
            {
                if (!LoggedIn)
                {
                    Console.Clear();
                    // Display login prompt
                    Console.WriteLine("=== Login ===");
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = ReadPassword();

                    // Simple hardcoded authentication for demonstration
                    if (username == "admin" && password == "password")
                    {
                        Console.WriteLine("Login successful!");
                        System.Threading.Thread.Sleep(1000); // Pause for a moment
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password.");
                        System.Threading.Thread.Sleep(1000); // Pause for a moment
                    }
                }
            }
            // Add a return statement to satisfy all code paths
            return false;
        }

        // Reads password input without echoing to the console
        private static string ReadPassword()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, pass.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
    }
}