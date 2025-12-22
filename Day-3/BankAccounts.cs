namespace HelloWorldApp
{
    class  BankAccounts
    {
        private int AccountNo;
        private double Balance;

        static String BankName="State Bank Of India";


        public BankAccounts(int AccNum,double initialBalance)
        {
           
            AccountNo=AccNum;
            Balance=initialBalance;

        }

        public void Deposit(double addmoney)
        {
            if (addmoney > 0)
            {
                Balance+=addmoney;
                Console.WriteLine("Amount deposited successfully.");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }

    public void Deposit(ref double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            amount = 0; // cleared after deposit
            Console.WriteLine("Amount deposited using ref.");
            }
            else
            {
                 Console.WriteLine($"Invalid!, Amount Should be in Positive");
            }

        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
            Console.WriteLine($"Withdraw Successfully  Balance is {Balance}");
        }

        public bool Withdraw(double amount, out string message)
        {
            if (Balance >= amount)
            {
                message = "Withdraw Successfully!";
                Balance-=amount;
                return true;
            }
            else if(Balance < amount)
            {
                message="Balance is to low";
                return false;
            }
            
            message="Insufficient balance";
            return false;
            
        }

        public void Display()
        {
            
            Console.WriteLine($"Account No :{AccountNo}");
            Console.WriteLine($"Bank Name :{BankName}");
            Console.WriteLine("You Balance is "+Balance);
            
        }

    }
}