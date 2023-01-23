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

    public static string GetUserInput(string prompt)
    {
        Console.WriteLine($"\nEnter {prompt}");
        return Console.ReadLine();
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
        PressEnterToContinue();
    }
}
