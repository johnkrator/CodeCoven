using System;
using System.Collections.Generic;
using System.Linq;
using ATMConsoleApp.AppUI;
using ATMConsoleApp.Domain.Entities;
using ATMConsoleApp.Domain.Enums;
using ATMConsoleApp.Domain.Interfaces;
using ConsoleTables;

namespace ATMConsoleApp.App
{
    internal class ATMApp : IUserLogin, IUserAccountActions, ITransaction
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;
        private List<Transaction> listOfTransactions;
        private const decimal minimumKeptAmount = 500;
        private readonly DisplayScreen screen;

        public ATMApp()
        {
            screen = new DisplayScreen();
        }

        public void Run()
        {
            DisplayScreen.Welcome();
            CheckUserCardNumberAndPassword();
            DisplayScreen.WelcomeCustomer(selectedAccount._FullName);
            while (true)
            {
                DisplayScreen.DisplayAppMenu();
                ProcessMenuOptions();
            }
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
                    var internalTransfer = screen.InternalTransferForm();
                    ProcessInternalTransfer(internalTransfer);
                    break;
                case (int)AppMenu.ViewTransaction:
                    ViewTransaction();
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
            var transactionAmt = UserValidator.Convert<int>($"amount {DisplayScreen.currency}");

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
                MakeWithDrawal();
                return;
            }
            else if (selectedAmount != 0)
            {
                transactionAmount = selectedAmount;
            }
            else
            {
                transactionAmount = UserValidator.Convert<int>($"amount {DisplayScreen.currency}");
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
            Console.WriteLine($"{DisplayScreen.currency}1000 X {thousandNoteCount} = {1000 * thousandNoteCount}");
            Console.WriteLine($"{DisplayScreen.currency}500 X {fiveHundredNotesCount} = {500 * fiveHundredNotesCount}");
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
            var filteredTransactionList =
                listOfTransactions.Where(t => t.UserBankAccountId == selectedAccount._Id).ToList();

            // Check if transaction exist
            if (filteredTransactionList.Count <= 0)
            {
                AppUtility.PrintMessage($"You have no transaction yet.", true);
            }
            else
            {
                var table = new ConsoleTable("Id", "Transaction Date", "Type", "Descriptions",
                    "Amount" + DisplayScreen.currency);
                foreach (var transaction in filteredTransactionList)
                {
                    table.AddRow(transaction.TransactionId, transaction.TransactionDate, transaction.TransactionType,
                        transaction.Description, transaction.TransactionAmount);
                }

                table.Options.EnableCount = false;
                table.Write();
                AppUtility.PrintMessage($"You have {filteredTransactionList.Count} transaction(s)", true);
            }
        }

        private void ProcessInternalTransfer(InternalTransfer internalTransfer)
        {
            if (internalTransfer.TransferAmount <= 0)
            {
                AppUtility.PrintMessage($"Amount needs to be more than zero. Try again", false);
                return;
            }

            // Check sender's account balance
            if (internalTransfer.TransferAmount > selectedAccount._AccountBalance)
            {
                AppUtility.PrintMessage(
                    $"Transfer failed! You do not have enough balance to transfer {AppUtility.FormatAmount(internalTransfer.TransferAmount)}",
                    false);
                return;
            }

            // Check minimum amount kept
            if ((selectedAccount._AccountBalance - internalTransfer.TransferAmount) < minimumKeptAmount)
            {
                AppUtility.PrintMessage(
                    $"Transfer failed! Your account needs to have a minimum of {AppUtility.FormatAmount(minimumKeptAmount)}",
                    false);
                return;
            }

            // Check if receiver's bank account number is valid
            var selectBankAccountReceiver = (from userAccount in userAccountList
                where userAccount._AccountNumber == internalTransfer.RecipientBankAccountNumber
                select userAccount).FirstOrDefault();

            if (selectBankAccountReceiver == null)
            {
                AppUtility.PrintMessage($"Transfer failed. Receiver bank account number is invalid", false);
                return;
            }

            // Check receiver's name
            if (selectBankAccountReceiver._FullName != internalTransfer.RecipientBankAccountName)
            {
                AppUtility.PrintMessage($"Transfer failed! Recipient's account name does not match", false);
                return;
            }

            // Add transaction to transaction's sender's record
            InsertTranction(selectedAccount._Id, TransactionType.Transfer, -internalTransfer.TransferAmount,
                $"Transfered to {selectBankAccountReceiver._AccountNumber} ({selectBankAccountReceiver._FullName})");

            // Update sender's account
            selectedAccount._AccountBalance -= internalTransfer.TransferAmount;

            // Add transaction record receiver
            InsertTranction(selectBankAccountReceiver._Id, TransactionType.Transfer, internalTransfer.TransferAmount,
                $"Transfered {selectedAccount._AccountNumber} ({selectedAccount._FullName})");

            // Update receiver's account balance
            selectBankAccountReceiver._AccountBalance += internalTransfer.TransferAmount;

            // Print success message
            AppUtility.PrintMessage(
                $"You have successfully transfered {AppUtility.FormatAmount(internalTransfer.TransferAmount)} to {internalTransfer.RecipientBankAccountName}",
                true);
        }
    }
}
