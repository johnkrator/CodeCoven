using System;
using System.Collections.Generic;
using ConsoleATM.AppUI;
using ConsoleATM.Domain.Entities;
using ConsoleATM.Domain.Enums;
using ConsoleATM.Domain.Interfaces;

namespace ConsoleATM.App
{
    internal class ATMApp : IUserLogin, IUserAccountActions, ITransaction
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;
        private List<Transaction> listOfTransactions;
        private const decimal minimumKeptAmount = 500;

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
            listOfTransactions = new List<Transaction>();
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
                    PlaceDeposit();
                    break;
                case (int)AppMenu.MakeWithdrawal:
                    MakeWithDrawal();
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
            Console.WriteLine($"\nOnly multiples of 500 and 1000 are allowed!");
            var transactionAmt = UserValidator.Convert<int>($"amount {DisplayScreen.cur}");

            //Simulate counting
            Console.WriteLine($"\nChecking and counting bank notes.");
            AppUtility.PrintDotAnimation();
            Console.WriteLine("");

            if (transactionAmt <= 0)
            {
                AppUtility.PrintMessage("Amount needs to be greater than zero. Try again.", false);
                return;
            }

            if (transactionAmt % 500 != 0)
            {
                AppUtility.PrintMessage("Enter deposit amount in multiples of 500 or 1000. Please try again.");
            }

            //Check if user wishes to continue
            if (PreviewBankNoteCount(transactionAmt) == false)
            {
                AppUtility.PrintMessage($"You have cancelled your action.", false);
                return;
            }

            //Bind transaction details to transaction object
            InsertTranction(selectedAccount._Id, TransactionType.Deposit, transactionAmt, "");

            //Update account balance
            selectedAccount._AccountBalance += transactionAmt;

            //Display success message
            AppUtility.PrintMessage($"Your deposit of {AppUtility.FormatAmount(transactionAmt)} was successful.", true);
        }

        public void MakeWithDrawal()
        {
            var transactionAmount = 0;
            int selectedAmount = DisplayScreen.SelectAmount();

            if (selectedAmount == -1)
            {
                selectedAmount = DisplayScreen.SelectAmount();
            }
            else if (selectedAmount != 0)
            {
                transactionAmount = selectedAmount;
            }
            else
            {
                transactionAmount = UserValidator.Convert<int>($"amount {DisplayScreen.cur}");
            }

            // input validation
            if (transactionAmount <= 0)
            {
                AppUtility.PrintMessage($"Amount needs to be greater than zero. Please try again.", false);
                return;
            }

            if (transactionAmount % 500 != 0)
            {
                AppUtility.PrintMessage($"You can only withdraw amount in multiples of 500 and 1000. Please try again",
                    false);
                return;
            }

            // Business logic validation
            if (transactionAmount > selectedAccount._AccountBalance)
            {
                AppUtility.PrintMessage(
                    $"Withdrawal failed! Your balance is too low to withdraw {AppUtility.FormatAmount(transactionAmount)}",
                    false);
                return;
            }

            if ((selectedAccount._AccountBalance - transactionAmount) < minimumKeptAmount)
            {
                AppUtility.PrintMessage(
                    $"Withdrawal failed! Your account needs to have a minimum of {AppUtility.FormatAmount(minimumKeptAmount)}",
                    false);
                return;
            }

            // Bind withdrawal details to transaction object
            InsertTranction(selectedAccount._Id, TransactionType.WithDrawal, -transactionAmount, "");

            // Update account balance 
            selectedAccount._AccountBalance -= transactionAmount;

            // Success message
            AppUtility.PrintMessage($"You have successfully withdrawn {AppUtility.FormatAmount(transactionAmount)}",
                true);
        }

        public bool PreviewBankNoteCount(int amount)
        {
            int thousandNoteCount = amount / 1000;
            int fiveHundredNotesCount = (amount % 1000) / 500;

            Console.WriteLine("\nSummary: ");
            Console.WriteLine($"{DisplayScreen.cur}1000 X {thousandNoteCount} = {1000 * thousandNoteCount}");
            Console.WriteLine($"{DisplayScreen.cur}500 X {fiveHundredNotesCount} = {500 * fiveHundredNotesCount}");
            Console.WriteLine($"Total amount: {AppUtility.FormatAmount(amount)}\n\n");

            int opt = UserValidator.Convert<int>("Enter 1 to confirm");
            return opt.Equals(1);
        }

        public void InsertTranction(long _userBankAccountId, TransactionType _tranType, decimal _tranAmount,
            string _desc)
        {
            //Create a new transaction object
            var transaction = new Transaction()
            {
                TransactionId = AppUtility.GetTransactionId(),
                UserBankAccountId = _userBankAccountId,
                TransactionDate = DateTime.Now,
                TransactionType = _tranType,
                TransactionAmount = _tranAmount,
                Description = _desc
            };

            //Add transaction object to the list
            listOfTransactions.Add(transaction);
        }

        public void ViewTransaction()
        {
            var transactionAmount = 0;
            int selectedAmount = DisplayScreen.SelectAmount();
            if (selectedAmount == -1)
            {
                selectedAmount = DisplayScreen.SelectAmount();
            }
            else if (selectedAmount != 0)
            {
                transactionAmount = selectedAmount;
            }
            else
            {
                transactionAmount = UserValidator.Convert<int>($"amount {DisplayScreen.cur}");
            }

            //input validation
            if (transactionAmount <= 0)
            {
                AppUtility.PrintMessage("Amount needs to be greater than zero.", false);
                return;
            }

            if (transactionAmount % 500 != 0)
            {
                AppUtility.PrintMessage("You can only withdraw in the multiple of 500 or 1000", false);
                return;
            }
        }

        private void ProcessInternalTransfer(InternalTransfer internalTransfer)
        {
            Console.WriteLine("hello transfer processing");
        }
    }
}
