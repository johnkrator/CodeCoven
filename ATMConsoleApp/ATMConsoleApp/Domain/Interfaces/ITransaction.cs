using ATMConsoleApp.Domain.Enums;

namespace ATMConsoleApp.Domain.Interfaces
{
    public interface ITransaction
    {
        void InsertTranction(long _userBankAccountId, TransactionType _tranType, decimal _tranAmount, string _desc);
        void ViewTransaction();
    }
}
