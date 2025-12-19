namespace HelloWorldApp
{
    
    class Credit
    {
        public static void  NetSalaryCreditCalculation()
        {
            Console.WriteLine("Enters your gross salary.");
            int salary=int.Parse(Console.ReadLine());
            int deduct=salary*10/100;
            int net=salary-deduct;
            Console.WriteLine($"Net salary credited: ₹{net}");
        }
        public static void FixedDepositMaturityCalculation()
        {
            Console.WriteLine("enters principa amount");
            int p=int.Parse(Console.ReadLine());
            Console.WriteLine("enter rate of interest");
            int r=int.Parse(Console.ReadLine());
            Console.WriteLine("enter time period in months");
            int t=int.Parse(Console.ReadLine());
            t=t/12;
            int total=p*r*t/100;
            Console.WriteLine($"Fixed Deposit maturity amount: ₹{total}");
            
        }
        public static void CreditCardRewardPointsEvaluation()
        {
            Console.WriteLine("User total credit card spending");
            int spending=int.Parse(Console.ReadLine());
            int rewardPoint=spending/100;
            Console.WriteLine($"Reward points earned: {rewardPoint}");
        }
        public static void EmployeeBonusEligibilityCheck()
        {
            Console.WriteLine("Enter Annual salary");
            int AnnualSalary=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Years of service");
            int YearOfService=int.Parse(Console.ReadLine());

            if(AnnualSalary>=500000 && YearOfService >= 3)
            {
                Console.WriteLine("Employee is eligible for bonus");
            }
            else
            {
                Console.WriteLine("Employee is not eligible for bonus.");
            }

        }
        public static void menu()
        {
            bool check=true;
            while (check)
            {
                Console.WriteLine($"1.Net Salary Credit Calculation");
                Console.WriteLine($"2.Fixed Deposit Maturity Calculation");
                Console.WriteLine($"3.Credit Card Reward Points Evaluation");
                Console.WriteLine($"4.Employee Bonus Eligibility Check");
                Console.WriteLine($"5.BACK");
                int val=int.Parse(Console.ReadLine());
                switch (val)
                {
                    case 1:
                         NetSalaryCreditCalculation();
                        break;
                    case 2:
                        FixedDepositMaturityCalculation();
                        break;
                    case 3:
                        CreditCardRewardPointsEvaluation();
                        break;
                    case 4:
                        EmployeeBonusEligibilityCheck();
                        break;
                    case 5:
                        check=false;
                        break;
                    default:
                        Console.WriteLine("Invalid optins");
                        break;
                }   
            }
        }
        
    }
   
}