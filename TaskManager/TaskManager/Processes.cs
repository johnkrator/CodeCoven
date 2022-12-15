using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TaskManager
{
    public class Processes
    {
        private static ThreadStart _threadStart;

        public static void SelectCommand()
        {
            Console.Write(
                "\nPlease select a command to continue: \n1. List all running task\n2. Start a task\n3. Create a custom process\n4. Create a custom thread\n5. View current thread list\n6. Check thread current status\n*******************************************\n\n");
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
                    CreateACustomProcess(fileName: "random");
                    break;
                case 4:
                    CreateCustomThread(threadName: "task");
                    break;
                case 5:
                    ViewCurrentThreadList();
                    break;
                case 6:
                    CheckThreadState();
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
            Process process;

            // Start a process
            try
            {
                // Open chrome browser
                process = Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "www.codewars.com");
                Console.WriteLine(process.ProcessName);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            // Kills Task flow
            Console.WriteLine($"-> Hit enter to kill: {process.ProcessName}");
            Console.ReadLine();

            // Kills all of chrome.exe processes
            try
            {
                foreach (var p in Process.GetProcessesByName(process.ProcessName))
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
        public static void CreateACustomProcess(string fileName)
        {
            try
            {
                Process newProcess = new Process();
                newProcess.StartInfo.FileName = fileName;

                Console.WriteLine($"\nSuccessfully created and added {fileName} process!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // 4. Creates a custom thread
        public static void CreateCustomThread(string threadName)
        {
            var thread = new Thread(_threadStart);
            threadName = threadName;
            thread.Start();
            Console.WriteLine($"{threadName} has been created");
        }

        // *****************************
        //method to view list of current threads
        public static void ViewCurrentThreadList()
        {
            ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;

            foreach (ProcessThread thread in currentThreads)
            {
                Console.WriteLine($"\n Thread id: {thread.Id}");
            }
        }

        public static void CheckThreadState()
        {
            Thread thread;
            thread = Thread.CurrentThread;
            Console.WriteLine($"Is thread alive? : {thread.IsAlive}");
        }

        public void PrintMessage()
        {
            SelectCommand();
        }
    }
}
