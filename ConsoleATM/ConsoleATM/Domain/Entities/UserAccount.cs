namespace ConsoleATM.Domain.Entities
{
    public class UserAccount
    {
        public int _Id { get; set; }
        public long _CardNumber { get; set; }
        public int _CardPin { get; set; }
        public long _AccountNumber { get; set; }
        public string _FullName { get; set; }
        public decimal _AccountBalance { get; set; }
        public int _TotalLogin { get; set; }
        public bool _IsLocked { get; set; }
    }
}
