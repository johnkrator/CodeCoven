namespace ConsoleATM.App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ATMApp atmApp = new ATMApp();
            atmApp.InitializeData();
            atmApp.Run();
        }
    }
}
