namespace UI.AppDisplayScreen;

public class Utility
{
    public static void Welcome()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nWelcome There!");
    }

    public static void PressEnterToContinue()
    {
        Console.WriteLine("\nPlease press enter to continue");
        Console.ReadLine();
    }
}
