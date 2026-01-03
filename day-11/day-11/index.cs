class BankAccount
{
    private double balance{get;set;}
    
    public void deposit(double amount)
    {
        balance+=amount;
    }
    public void withdraw(double amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficent balance");
        }
        else
        {
            balance-=amount;
            Console.WriteLine("Current balance is "+balance);

        }
    }
}



class Animal
{
    public virtual void sound()
    {
        Console.WriteLine("Animal make a sound");
    }
}

class Dog : Animal
{
    public override void sound()
    {
        Console.WriteLine("Dog barks");
    }
}
class Program
{
    public static void Main()
    {
        Animal a = new Dog();
        a.Sound();
    }
}

// leetcode, dotnetfiddle.net, hackerrank.com
 