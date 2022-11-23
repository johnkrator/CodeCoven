using MyATMAPP.Domain.Entities;

namespace MyATMAPP.AppUI
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

            // App utility
            AppUtility.ClickEnterToContinue();

        }

        internal static UserAccount UserLoginForm()
        {
            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount._CardNumber = UserValidator.Convert<long>("your card number");
            tempUserAccount._CardPin = Convert.ToInt32(AppUtility.GetSecretInput("Enter your account pin"));
            return tempUserAccount;
        }

        internal static void LoginProgress()
        {
            // Login progress dot animation
            AppUtility.PrintDotAnimation();
        }
    }
}
