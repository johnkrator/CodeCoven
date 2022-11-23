using MyATMAPP.AppUI;
using MyATMAPP.Domain.Entities;
using MyATMAPP.Domain.Interfaces;

namespace MyATMAPP.App
{
    internal class ATMApp : IUserLogin
    {
        private List<UserAccount>? userAccountList;
        private UserAccount selectedAccounts;

        public void InitializeData()
        {
            userAccountList = new List<UserAccount>()
            {
                new UserAccount{_Id=1,_FullName="James Jones",_AccountNumber=0001,_CardNumber=321321,_CardPin=1234,_AccountBalance=50000.00m,_IsLocked=false },
                new UserAccount{_Id=2,_FullName="Peter O",_AccountNumber=0002,_CardNumber=3213222,_CardPin=1235,_AccountBalance=5000.00m,_IsLocked=false },
                new UserAccount{_Id=3,_FullName="Mark",_AccountNumber=0003,_CardNumber=321311,_CardPin=1232,_AccountBalance=10000.00m,_IsLocked=true }
            };
        }

        public void CheckUserCardNumberAndPassword()
        {
            bool isCorrectLogin = false;
            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount._CardNumber = UserValidator.Convert<long>("your card number");
            tempUserAccount._CardPin = Convert.ToInt32(AppUtility.GetSecretInput("Enter your account pin"));

            // Waiting dotted counter
            Console.WriteLine("\nChecking card number and pin...");
            int timer = 10;
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200); // Delays the timer for 200 milliseconds
            }
            Console.Clear();
        }
    }
}
