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
                "\nPlease select a command to continue: \n1. List all running task\n2. Start a task\n3. Create a custom process\n4. Create a custom thread" +
                "\n5. View current thread list\n6. Check thread current status\n*******************************************\n\n");
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
                    CreateCustomThread();
                    Thread thread = new Thread(new ThreadStart(CreateCustomThread));
                    thread.Start();
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

        public static void CreateACustomProcess()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "notepad";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static void CreateCustomThread()
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"New thread created!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static void ViewCurrentThreadList()
        {
            try
            {
                ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;

                foreach (ProcessThread thread in currentThreads)
                {
                    Console.WriteLine($"\n Thread id: {thread.Id}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static void CheckThreadState()
        {
            try
            {
                Thread thread;
                thread = Thread.CurrentThread;
                Console.WriteLine($"Is thread alive? : {thread.IsAlive}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void PrintMessage()
        {
            SelectCommand();
        }
    }
}
