using MyATMAPP.AppUI;
using MyATMAPP.Domain.Entities;
using MyATMAPP.Domain.Interfaces;

namespace MyATMAPP.App
{
    internal class ATMApp : IUserLogin
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

        public void InitializeData()
        {
            userAccountList = new List<UserAccount>()
            {
                new UserAccount{_Id=1,_FullName="James Jones",_AccountNumber=0001,_CardNumber=321321,_CardPin=123456,_AccountBalance=50000.00m,_IsLocked=false },
                new UserAccount{_Id=2,_FullName="Peter O",_AccountNumber=0002,_CardNumber=3213222,_CardPin=123564,_AccountBalance=5000.00m,_IsLocked=false },
                new UserAccount{_Id=3,_FullName="Mark",_AccountNumber=0003,_CardNumber=321311,_CardPin=123220,_AccountBalance=10000.00m,_IsLocked=true },
                new UserAccount{_Id=4,_FullName="Jude",_AccountNumber=0004,_CardNumber=321313,_CardPin=123293,_AccountBalance=60000.00m,_IsLocked=false }
            };
        }

        public void CheckUserCardNumberAndPassword()
        {
            bool isCorrectLogin = false;
            while (isCorrectLogin == false)
            {
                UserAccount inputAccount = DisplayScreen.UserLoginForm();
                DisplayScreen.LoginProgress();
                foreach (UserAccount account in userAccountList)
                {
                    selectedAccount = account;
                    if (inputAccount._CardNumber.Equals(selectedAccount._CardNumber))
                    {
                        selectedAccount._TotalLogin++;

                        if (inputAccount._CardPin.Equals(selectedAccount._CardPin))
                        {
                            selectedAccount = account;

                            if (selectedAccount._IsLocked || selectedAccount._TotalLogin > 3)
                            {
                                // Print lock screen
                                DisplayScreen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccount._TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                    }
                }
                if (isCorrectLogin == false)
                {
                    AppUtility.PrintMessage("\nInvalid card number or PIN.", false);
                    selectedAccount._IsLocked = selectedAccount._TotalLogin == 3;
                    if (selectedAccount._IsLocked)
                    {
                        DisplayScreen.PrintLockScreen();
                    }
                }
                Console.Clear();
            }
        }
        public void Welcome()
        {
            Console.WriteLine($"Welcome back, {selectedAccount._FullName}");
        }

    }
}
