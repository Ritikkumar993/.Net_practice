class Debit
    {
        
        public static void ATMWithdrawalLimitValidation()
        {
   
            int limit=40000;
            Console.WriteLine("Enter the amount to withdraw");
            int amount=int.Parse(Console.ReadLine());
            if (amount <= limit)
            {
                Console.WriteLine("Withdrawal permitted within daily limit.");
            }
            else
            {
                Console.WriteLine("Daily ATM withdrawal limit exceeded.");
            }

        }
        public static void EMIBurdenEvaluation()
        {
            Console.WriteLine("Enter the monthly income");
            int mIncome=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter EMI amount");
            int EMI=int.Parse(Console.ReadLine());

            int val=100*EMI/mIncome;
            Console.WriteLine($"{val}");
            if (val <= 40)
            {
                Console.WriteLine("EMI is financially manageable.");
            }
            else
            {
                 Console.WriteLine("EMI exceeds safe income limit.");
            }
            

        }
        public static void TransactionBasedDailySpendingCalculator()
        {
            int balance=0;
            Console.WriteLine("Enter 10 tansactions");
            for(int i = 0; i<10; i++)
            {
                int amount=int.Parse(Console.ReadLine());
                           
                if(amount <0){
                    Console.WriteLine("Invalid amount");
                    continue;
                }
                balance+=amount;
            }
            Console.WriteLine($"your balance is {balance}");            
        }
        public static void MinimumBalanceComplianceCheck()
        {
             Console.WriteLine($"Enter your current balance.");     
             int bal=int.Parse(Console.ReadLine());
             int minbal=2000;
            if (bal < minbal)
            {
                Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
            }
            else
            {
                Console.WriteLine("Minimum balance requirement satisfied");
            }
        }
        public static void  menu()
        {
            bool check=true;
            while (check)
            {
                Console.WriteLine("1.ATM Withdrawal Limit Validation");
                Console.WriteLine("2.EMI Burden Evaluation");
                Console.WriteLine("3.Transaction-Based Daily Spending Calculator");
                Console.WriteLine("4.Minimum Balance Compliance Check");
                Console.WriteLine("5.BACK");
                int val=int.Parse(Console.ReadLine());
                switch (val)
                {
                    case 1:
                        ATMWithdrawalLimitValidation();
                        break;
                    case 2:
                        EMIBurdenEvaluation();
                        break;
                    case 3:
                        TransactionBasedDailySpendingCalculator();
                        break;
                    case 4:
                        MinimumBalanceComplianceCheck();
                        break;
                    case 5:
                        check=false;
                        break;

                }

            }
            
        }
    }