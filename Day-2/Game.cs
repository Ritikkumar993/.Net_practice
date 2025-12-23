
// using System.Data;
// using System.Runtime.CompilerServices;

// namespace HelloWorldApp
// {
//     class Game
//     {
//         public void play()
//         {
//             Console.WriteLine("GAME BEGINS");
//             for(int i = 1; i <= 10; i++)
//             {
//                 Console.WriteLine($"player killed e{i}");
//                 if(i==4)
//                 {
//                     Console.WriteLine($"e{i} is invisible skipping e{i}");

//                 }
//             }
//             Console.WriteLine("GAME END");
            
//         }

//         public void fci()
//         {
//             bool check=true;
//             while (check)
//             {
//                 //CREDIT
//                 Console.WriteLine("1.Credit");

//                 //DEBIT
//                 Console.WriteLine("2.Debit");

//                 // Income Tax Calculation
//                 Console.WriteLine("3.Income Tax Calculation");

//                 // Exit Program
//                 Console.WriteLine("4.Exit Program");
//                 int val=Convert.ToInt32(Console.ReadLine());
//                 switch (val)
//                 {
//                     case 1:
                        
//                         Credit.menu();
//                         break;
//                     case 2:
//                         Debit.menu();
//                         break;
//                     case 3:
//                         Console.WriteLine("Enter your anual income to calculate tax");
//                         int anualincome=Convert.ToInt32(Console.ReadLine());
                       
//                         if (anualincome <= 250000)
//                         {
//                             int tax1=0;
//                             Console.WriteLine($"Your calculated tax is:{tax1}");
//                         }
//                         else if(anualincome > 250000 && anualincome<=500000)
//                         {
//                             int tax2=anualincome*5/100;
//                             Console.WriteLine($"Your calculated tax is:{tax2}");
//                         }
//                         else if(anualincome>500000 && anualincome<=100000)
//                         {
//                             int tax3=anualincome*20/100;
//                             Console.WriteLine($"Your calculated tax is:{tax3}");
//                         }
//                         else
//                         {
//                             int tax4=anualincome*30/100;
//                             Console.WriteLine($"Your calculated tax is:{tax4}");
//                         }
//                         break;
//                     case 4:
//                         check=false;
//                         break;
//                     default:
//                         Console.WriteLine("you intered invalid options");
//                         break;
//                 }
//             }
//         }
//     }

//     class Credit
//     {

//         public static void  NetSalaryCreditCalculation()
//         {
//             Console.WriteLine("Enters your gross salary.");
//             int salary=int.Parse(Console.ReadLine());
//             int deduct=salary*10/100;
//             int net=salary-deduct;
//             Console.WriteLine($"Net salary credited: ₹{net}");
//         }
//         public static void FixedDepositMaturityCalculation()
//         {
//             Console.WriteLine("enters principa amount");
//             int p=int.Parse(Console.ReadLine());
//             Console.WriteLine("enter rate of interest");
//             int r=int.Parse(Console.ReadLine());
//             Console.WriteLine("enter time period in months");
//             int t=int.Parse(Console.ReadLine());
//             t=t/12;
//             int total=p*r*t/100;
//             Console.WriteLine($"Fixed Deposit maturity amount: ₹{total}");
            
//         }
//         public static void CreditCardRewardPointsEvaluation()
//         {
//             Console.WriteLine("User total credit card spending");
//             int spending=int.Parse(Console.ReadLine());
//             int rewardPoint=spending/100;
//             Console.WriteLine($"Reward points earned: {rewardPoint}");
//         }
//         public static void EmployeeBonusEligibilityCheck()
//         {
//             Console.WriteLine("Enter Annual salary");
//             int AnnualSalary=int.Parse(Console.ReadLine());
//             Console.WriteLine("Enter Years of service");
//             int YearOfService=int.Parse(Console.ReadLine());

//             if(AnnualSalary>=500000 && YearOfService >= 3)
//             {
//                 Console.WriteLine("Employee is eligible for bonus");
//             }
//             else
//             {
//                 Console.WriteLine("Employee is not eligible for bonus.");
//             }

//         }
//         public static void menu()
//         {
//             bool check=true;
//             while (check)
//             {
//                 Console.WriteLine($"1.Net Salary Credit Calculation");
//                 Console.WriteLine($"2.Fixed Deposit Maturity Calculation");
//                 Console.WriteLine($"3.Credit Card Reward Points Evaluation");
//                 Console.WriteLine($"4.Employee Bonus Eligibility Check");
//                 Console.WriteLine($"5.BACK");
//                 int val=int.Parse(Console.ReadLine());
//                 switch (val)
//                 {
//                     case 1:
//                          NetSalaryCreditCalculation();
//                         break;
//                     case 2:
//                         FixedDepositMaturityCalculation();
//                         break;
//                     case 3:
//                         CreditCardRewardPointsEvaluation();
//                         break;
//                     case 4:
//                         EmployeeBonusEligibilityCheck();
//                         break;
//                     case 5:
//                         check=false;
//                         break;
//                     default:
//                         Console.WriteLine("Invalid optins");
//                         break;
//                 }   
//             }
//         }
        
//     }

    
//     class Debit
//     {
        
//         public static void ATMWithdrawalLimitValidation()
//         {
   
//             int limit=40000;
//             Console.WriteLine("Enter the amount to withdraw");
//             int amount=int.Parse(Console.ReadLine());
//             if (amount <= limit)
//             {
//                 Console.WriteLine("Withdrawal permitted within daily limit.");
//             }
//             else
//             {
//                 Console.WriteLine("Daily ATM withdrawal limit exceeded.");
//             }

//         }
//         public static void EMIBurdenEvaluation()
//         {
//             Console.WriteLine("Enter the monthly income");
//             int mIncome=int.Parse(Console.ReadLine());
//             Console.WriteLine("Enter EMI amount");
//             int EMI=int.Parse(Console.ReadLine());

//             int val=100*EMI/mIncome;
//             Console.WriteLine($"{val}");
//             if (val <= 40)
//             {
//                 Console.WriteLine("EMI is financially manageable.");
//             }
//             else
//             {
//                  Console.WriteLine("EMI exceeds safe income limit.");
//             }
            

//         }
//         public static void TransactionBasedDailySpendingCalculator()
//         {
//             int balance=0;
//             Console.WriteLine("Enter 10 tansactions");
//             for(int i = 0; i<10; i++)
//             {
//                 int amount=int.Parse(Console.ReadLine());
                           
//                 if(amount <0){
//                     Console.WriteLine("Invalid amount");
//                     continue;
//                 }
//                 balance+=amount;
//             }
//             Console.WriteLine($"your balance is {balance}");            
//         }
//         public static void MinimumBalanceComplianceCheck()
//         {
//              Console.WriteLine($"Enter your current balance.");     
//              int bal=int.Parse(Console.ReadLine());
//              int minbal=2000;
//             if (bal < minbal)
//             {
//                 Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
//             }
//             else
//             {
//                 Console.WriteLine("Minimum balance requirement satisfied");
//             }
//         }
//         public static void  menu()
//         {
//             bool check=true;
//             while (check)
//             {
//                 Console.WriteLine("1.ATM Withdrawal Limit Validation");
//                 Console.WriteLine("2.EMI Burden Evaluation");
//                 Console.WriteLine("3.Transaction-Based Daily Spending Calculator");
//                 Console.WriteLine("4.Minimum Balance Compliance Check");
//                 Console.WriteLine("5.BACK");
//                 int val=int.Parse(Console.ReadLine());
//                 switch (val)
//                 {
//                     case 1:
//                         ATMWithdrawalLimitValidation();
//                         break;
//                     case 2:
//                         EMIBurdenEvaluation();
//                         break;
//                     case 3:
//                         TransactionBasedDailySpendingCalculator();
//                         break;
//                     case 4:
//                         MinimumBalanceComplianceCheck();
//                         break;
//                     case 5:
//                         check=false;
//                         break;

//                 }

//             }
            
//         }
//     }


// }