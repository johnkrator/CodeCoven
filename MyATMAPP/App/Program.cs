using MyATMAPP.AppUI;

namespace MyATMAPP.App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DisplayScreen.Welcome();
            ATMApp atmApp = new ATMApp();

            atmApp.CheckUserCardNumberAndPassword();
            /*long cardNumber = UserValidator.Convert<long>("your card number!");
            Console.WriteLine($"\nYour card number is {cardNumber}");*/

            AppUtility.ClickEnterToContinue();
        }
    }
}