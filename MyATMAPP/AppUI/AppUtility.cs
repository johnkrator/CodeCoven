using System.Text;

namespace MyATMAPP.AppUI
{
    // This class was created to allow for decoupling
    public static class AppUtility
    {
        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            StringBuilder input = new StringBuilder();

            while (true)
            {
                if (isPrompt) Console.WriteLine(prompt);
                isPrompt = false;

                ConsoleKeyInfo inputKey = Console.ReadKey(true); // Reads key strokes. True means, key inputs should be hidden

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

        public static string? GetUserInput(string prompt)
        {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }


        public static void ClickEnterToContinue()
        {
            Console.WriteLine($"\nPlease press enter to continue");
            Console.ReadLine();
        }
    }
}
