using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace ATMConsoleApp.AppUI
{
    // This class was created to allow for decoupling
    public static class AppUtility
    {
        private static long transactionId;
        private static CultureInfo culture = new CultureInfo("en-US");

        public static long GetTransactionId()
        {
            return ++transactionId;
        }

        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            StringBuilder input = new StringBuilder();

            while (true)
            {
                if (isPrompt) Console.WriteLine(prompt);
                isPrompt = false;

                ConsoleKeyInfo
                    inputKey = Console.ReadKey(true); // Reads key strokes. True means, key inputs should be hidden

                if (inputKey.Key == ConsoleKey.Enter)
                {
                    if (input.Length == 6)
                    {
                        break;
                    }
                    else
                    {
                        PrintMessage("\nPlease enter 6 digits.", false);
                        isPrompt = true;
                        input.Clear();
                        continue;
                    }
                }

                if (inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }
                else if (inputKey.Key != ConsoleKey.Backspace)
                {
                    input.Append(inputKey.KeyChar);
                    Console.Write(asterics + "*");
                }
            }

            return input.ToString();
        }

        public static void PrintMessage(string message, bool success = true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(message);
            Console.ResetColor();
            ClickEnterToContinue();
        }

        public static string GetUserInput(string prompt)
        {
            Console.WriteLine($"\nEnter {prompt}");
            return Console.ReadLine();
        }


        public static void ClickEnterToContinue()
        {
            Console.WriteLine($"\nPlease press enter to continue");
            Console.ReadLine();
        }

        public static void PrintDotAnimation(int timer = 10)
        {
            Console.WriteLine("\nChecking card number and pin...");
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200); //Delays the timer for 200 milliseconds
            }

            Console.Clear();
        }

        public static string FormatAmount(decimal amt)
        {
            return String.Format(culture, "{0:C2}", amt);
        }
    }
}
