using MyATMAPP.AppUI;

namespace MyATMAPP.App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DisplayScreen.Welcome();
            long cardNumber = UserValidator.Convert<long>("your card number!");
            Console.WriteLine($"Your card number is {cardNumber}");
        }
    }
}