using MyATMAPP.Domain.Enums;

namespace MyATMAPP.Domain.Interfaces;

public interface ITransaction
{
    void InsertTranction(long _userBankAccountId, TransactionType _tranType, decimal _tranAmount, string _desc);
    void ViewTransaction();
}
