namespace HelloWorldApp
{
    class Wallet
    {
        private double money;
        public void AddMoney(double amount)
        {
            money+=amount;
            Console.WriteLine(amount+" is added to your wallet");

        }

        public double getbalance()
        {
            return money;
        }
    }
}