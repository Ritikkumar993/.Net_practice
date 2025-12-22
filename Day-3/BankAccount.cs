
using System.Diagnostics;

namespace HelloWorldApp
{
    class Employees
    {
        public string Name;
        public double salary;

        public void person(string Name, string city, int age,char gender='M')
        {
            Console.WriteLine("Name:"+Name+ "\n age:"+age+"\n city:"+city+"\n gender:"+gender);
        }

    
     

        public void DisplayDetails()
        {
            Console.WriteLine(Name+" earns "+salary);
            
        }

        public void namearr(string name)
        {
            foreach(char ch in name)
            {
                Console.WriteLine(ch);
            }
        }


    }
    
    class BankAccount
    {
        public int AccNum;
        public readonly int AccountId;// readonly  decleration in constractor
        private double Balance;

        public void Deposit(double amount)
        {
            
            Balance+=amount;
            Console.WriteLine("Updated Balance is "+Balance);
        }

        

    }


}


// static, 
// const, 
// readonly
// 