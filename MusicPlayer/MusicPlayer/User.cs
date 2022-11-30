using System;

namespace MusicPlayer
{
    public class User
    {
        private string _Username;
        private string _Password;
        private string _ConfirmUsername;
        private string _ConfirmPassword;

        public User()
        {
            
        }

        public void UserAuth()
        {
            Console.WriteLine("\nEnter username to signup: ");
            _Username = Console.ReadLine();

            Console.WriteLine("Enter password to signup: ");
            _Password = Console.ReadLine();
            
            Console.WriteLine("\nEnter username to login: ");
            _ConfirmUsername = Console.ReadLine();

            Console.WriteLine("Enter password to login: ");
            _ConfirmPassword = Console.ReadLine();

            if (_Username == _ConfirmUsername && _Password == _ConfirmPassword)
            {
                Console.WriteLine($"\nWelcome, {_Username}.");    
            }
            else
            {
                Console.WriteLine("\nWrong user input. Please try again.");
            }
        }

        public void Run()
        {
            UserAuth();
        }
    }
}
