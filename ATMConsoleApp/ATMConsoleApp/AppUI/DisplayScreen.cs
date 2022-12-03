using System;
using ATMConsoleApp.Domain.Entities;

namespace ATMConsoleApp.AppUI
{
    // static because, I wouldn't want to instantiate the class before using it
    public class DisplayScreen
    {
        internal static string cur = "N ";

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
            AppUtility.PrintMessage(
                "Oops! Your account is locked. Please go to nearest branch to unlock your account.");
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

        internal static int SelectAmount()
        {
            Console.WriteLine($"1. {cur}500                5. {cur}10,000");
            Console.WriteLine($"2. {cur}1,000              6. {cur}15,000");
            Console.WriteLine($"3. {cur}2,000              7. {cur}20,000");
            Console.WriteLine($"4. {cur}5,000              8. {cur}40,000");
            Console.WriteLine($"0: Other");

            int selectedAmount = UserValidator.Convert<int>("Option: ");
            switch (selectedAmount)
            {
                case 1:
                    return 500;
                    break;
                case 2:
                    return 1000;
                    break;
                case 3:
                    return 2000;
                    break;
                case 4:
                    return 5000;
                    break;
                case 5:
                    return 10000;
                    break;
                case 6:
                    return 15000;
                    break;
                case 7:
                    return 20000;
                    break;
                case 8:
                    return 40000;
                    break;
                case 0:
                    return 0;
                    break;
                default:
                    AppUtility.PrintMessage("Invalid input. Please try again.", false);
                    return -1;
                    break;
            }
        }

        internal InternalTransfer InternalTransferForm()
        {
            var internalTransfer = new InternalTransfer();
            internalTransfer.RecipientBankAccountNumber = UserValidator.Convert<long>($"recipient's account number: ");
            internalTransfer.TransferAmount = UserValidator.Convert<decimal>($"amount {cur}");
            internalTransfer.RecipientBankAccountName = AppUtility.GetUserInput($"recipient's name:");
            return internalTransfer; // Using this to collect the data for the transfer
        }
    }
}
