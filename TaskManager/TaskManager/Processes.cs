using System;

namespace TaskManager
{
    public class Processes
    {
        public static void ListAllAppInMySystem()
        {
            Console.WriteLine("\nAll apps in my system");
        }

        public static void StartAnApp()
        {
            Console.WriteLine("Start an app");
        }

        public static void KillAnApp()
        {
            Console.WriteLine("Kill an app");
        }

        public static void CustomProcess()
        {
            Console.WriteLine("Custom process");
        }

        public static void IsThreadAlive()
        {
            Console.WriteLine("Is thread alive?");
        }

        public static void IsThreadSleeping()
        {
            Console.WriteLine("Is thread sleeping");
        }

        public void PrintMessage()
        {
            ListAllAppInMySystem();
            StartAnApp();
            KillAnApp();
            CustomProcess();
            IsThreadAlive();
            IsThreadSleeping();
        }
    }
}
