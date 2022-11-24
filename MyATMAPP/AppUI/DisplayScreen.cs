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

        internal static void PrintLockScreen()
        {
            Console.Clear();
            AppUtility.PrintMessage("Oops! Your account is locked. Please go to nearest branch to unlock your account.");
            AppUtility.ClickEnterToContinue();
            Environment.Exit(1);
        }
        
        internal static void WelcomeCustomer(string fullName)
        {
            Console.WriteLine($"Welcome back, {fullName}");
            AppUtility.ClickEnterToContinue();
        }

        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\nTransaction Menu");
            Console.WriteLine("................\n");
            Console.WriteLine("0. Account Balance");
            Console.WriteLine("1. Cash Deposit");
            Console.WriteLine("2. Withdrawal");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Transactions");
            Console.WriteLine("5. Logout");
        }

        internal static void LogOutProgress()
        {
            Console.WriteLine("Thank you for your patronage");
            AppUtility.PrintDotAnimation();
            Console.Clear();
        }
    }
}
