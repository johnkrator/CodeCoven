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
                new UserAccount{_Id=3,_FullName="Mark",_AccountNumber=0003,_CardNumber=321311,_CardPin=1232,_AccountBalance=10000.00m,_IsLocked=true },
                new UserAccount{_Id=4,_FullName="Jude",_AccountNumber=0004,_CardNumber=321313,_CardPin=12329,_AccountBalance=60000.00m,_IsLocked=false }
            };
        }

        public void CheckUserCardNumberAndPassword()
        {
            bool isCorrectLogin = false;
            UserAccount inputAccount = DisplayScreen.UserLoginForm();

            // Login progress
            DisplayScreen.LoginProgress();
        }

    }
}
