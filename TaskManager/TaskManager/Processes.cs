using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TaskManager
{
    public class Processes
    {
        public static void SelectCommand()
        {
            Console.Write(
                "\nPlease select a command to continue: \n1. List all running task\n2. Start a task\n3. Create a custom process\n4. Create a custom thread and a background thread\n5. Check if a thread is alive\n*******************************************\n\n");
            var option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListAllRunningTasks();
                    break;
                case 2:
                    StartAndKillATask();
                    break;
                case 3:
                    CreateACustomProcess();
                    break;
                case 4:
                    CreateCustomThreadAndBackgroundThread();
                    break;
                case 5:
                    IsThreadAliveOrSleeping();
                    break;
                default:
                    Console.WriteLine("Invalid entry. Please enter a valid option to continue.");
                    break;
            }
        }

        // 1. List all running processes
        public static void ListAllRunningTasks()
        {
            try
            {
                var runningProcesses = from proc in Process.GetProcesses()
                    orderby proc.Id
                    select proc;

                foreach (var p in runningProcesses)
                {
                    var info = $"-> PID: {p.Id}\tName: {p.ProcessName}";
                    Console.WriteLine(info);
                }

                Console.WriteLine("**************************************");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // 2. Start and kill all running browser task
        public static void StartAndKillATask()
        {
            Process proc = null;

            // Start a process
            try
            {
                // Open chrome browser
                proc = Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "www.codewars.com");
                Console.WriteLine(proc.ProcessName);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            // Kills Task flow
            Console.WriteLine($"-> Hit enter to kill: {proc.ProcessName}");
            Console.ReadLine();

            // Kills all of chrome.exe processes
            try
            {
                foreach (var p in Process.GetProcessesByName(proc.ProcessName))
                {
                    p.Kill();
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // 3. Creates a custom process
        public static void CreateACustomProcess()
        {
            Process theProc = null;

            try
            {
                theProc = Process.GetProcessById(Process.GetCurrentProcess().Id);
                Console.WriteLine(theProc.ProcessName);

                Console.WriteLine($"\nHere are the process used by: {theProc.ProcessName}");
                ProcessThreadCollection theThreads = theProc.Threads;

                foreach (ProcessThread pt in theThreads)
                {
                    var info =
                        $"-> Thread ID: {pt.Id}\tStart time: {pt.StartTime.ToShortTimeString()}\tPriority: {pt.PriorityLevel}\tName: {pt.PriorityBoostEnabled}";
                    Console.WriteLine(info);
                }

                Console.WriteLine("*****************************\n");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // 4. Creates a custom thread
        public static void CreateCustomThreadAndBackgroundThread()
        {
            Console.WriteLine("\n**********The Amazing Thread App*************\n");
            Console.WriteLine("Do you want [1] or [2] threads?");

            var threadCount = Console.ReadLine();
            Test(threadCount);
        }

        private static void Test(string input)
        {
            if (input == "1")
            {
                PrintNumbers();
            }
            else
            {
                ThreadStart threadStart = new ThreadStart(PrintNumbers);
                Thread backgroundThread = new Thread(threadStart);
                backgroundThread.Name = "Secondary";
                backgroundThread.Start();
            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine($"\n-> Executing PrintNumbers() {Thread.CurrentThread.Name}");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(2000);
            }

            Console.WriteLine();
        }

        // 5. Checks if a thread isAlive
        public static void IsThreadAliveOrSleeping()
        {
            Console.WriteLine("Is thread sleeping");
        }

        public void PrintMessage()
        {
            SelectCommand();
        }
    }
}
