namespace MyATMAPP.AppUI
{
    // This class was created to allow for decoupling
    public static class AppUtility
    {
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
