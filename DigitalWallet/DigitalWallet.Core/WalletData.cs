namespace DigitalWallet.Core
{
    public class WalletData
    {
        //valu Type
        public int UserId;
        public decimal Balance;
        public bool IsActive;

        //Refrence Type
        public string? UserName;

        //array to store last transaction
        public decimal[]? RecentTransactions;
    }
}