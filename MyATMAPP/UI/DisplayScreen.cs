namespace MyATMAPP.UI
{

    // static because, I wouldn't want to instantiate the class before using it
    public static class DisplayScreen
    {
        internal static void Welcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "My ATM Application!";

            Console.WriteLine("\nHello there! Welcome to Jhon's Remote Banking App.");

            Console.WriteLine("\nDisclaimer: Know that this can accept and validate actual ATM cards.");
            Console.WriteLine("Welcome! Please insert your ATM card");

            PressEnterToContinue();

        }

        public static void PressEnterToContinue()
        {
            Console.WriteLine($"\nPlease press enter to continue");
            Console.ReadLine();
        }
    }
}
