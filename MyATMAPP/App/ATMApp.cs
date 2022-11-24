using MyATMAPP.AppUI;
using MyATMAPP.Domain.Entities;
using MyATMAPP.Domain.Enums;
using MyATMAPP.Domain.Interfaces;

namespace MyATMAPP.App
{
    internal class ATMApp : IUserLogin, IUserAccountActions
    {
        private List<UserAccount>? userAccountList;
        private UserAccount? selectedAccount;

        public void Run()
        {
            DisplayScreen.Welcome();
            CheckUserCardNumberAndPassword();
            DisplayScreen.WelcomeCustomer(selectedAccount._FullName);
            DisplayScreen.DisplayAppMenu();
            ProcessMenuOptions();
        }

        public void InitializeData()
        {
            userAccountList = new List<UserAccount>()
            {
                new UserAccount
                {
                    _Id = 1, _FullName = "John Chukwu", _AccountNumber = 0001, _CardNumber = 1111, _CardPin = 222222,
                    _AccountBalance = 50000.00m, _IsLocked = false
                },
                new UserAccount
                {
                    _Id = 2, _FullName = "Peter Okoye", _AccountNumber = 0002, _CardNumber = 2222, _CardPin = 333333,
                    _AccountBalance = 5000.00m, _IsLocked = false
                },
                new UserAccount
                {
                    _Id = 3, _FullName = "Mark Engees", _AccountNumber = 0003, _CardNumber = 3333, _CardPin = 444444,
                    _AccountBalance = 10000.00m, _IsLocked = true
                },
                new UserAccount
                {
                    _Id = 4, _FullName = "Jude Nnam", _AccountNumber = 0004, _CardNumber = 4444, _CardPin = 555555,
                    _AccountBalance = 60000.00m, _IsLocked = false
                }
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

        private void ProcessMenuOptions()
        {
            switch (UserValidator.Convert<int>("an option to continue"))
            {
                case (int)AppMenu.CheckBalance:
                    CheckBalance();
                    break;
                case (int)AppMenu.PlaceDeposit:
                    Console.WriteLine("Placing deposit...");
                    break;
                case (int)AppMenu.MakeWithdrawal:
                    Console.WriteLine("Making withdrawal...");
                    break;
                case (int)AppMenu.InternalTransfer:
                    Console.WriteLine("Making transfer...");
                    break;
                case (int)AppMenu.ViewTransaction:
                    Console.WriteLine("Loading transactions...");
                    break;
                case (int)AppMenu.Logout:
                    DisplayScreen.LoginProgress();
                    AppUtility.PrintMessage("You successfully logged out. Please collect your ATM card.");
                    Run();
                    break;
                default:
                    AppUtility.PrintMessage("Invalid option", false);
                    break;
            }
        }

        public void CheckBalance()
        {
            AppUtility.PrintMessage(
                $"Your account balance is: {AppUtility.FormatAmount(selectedAccount._AccountBalance)}");
        }

        public void PlaceDeposit()
        {
            throw new NotImplementedException();
        }

        public void MakeWithDrawal()
        {
            throw new NotImplementedException();
        }
    }
}
