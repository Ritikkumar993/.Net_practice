using System.Globalization;
using System.IO.Pipelines;

namespace HelloWorldApp{
class Calculator
{
    int number1;
    int number2;

    int result;

    int rem;
    public void Add()
    {
        Console.WriteLine("Enter first number");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter seciond number");
        number2=Convert.ToInt32(Console.ReadLine());
        result=number1+number2;
        Console.WriteLine($"Addition to two number is {result}");
        
    }
    public void Sub()
    {
        Console.WriteLine("Enter first number");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter seciond number");
        number2=Convert.ToInt32(Console.ReadLine());
        result=number1-number2;
        Console.WriteLine($"Subtraction of the two number is {result}");
        
    }
    public void Multiply()
    {
        Console.WriteLine("Enter first number1");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the second number");
        number2=Convert.ToInt32(Console.ReadLine());
        result=number1*number2;
        Console.WriteLine($"Multiply of two numbers {result}");

    }
    public void Divide()
    {
        Console.WriteLine("Enter first number1");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the second number");
        number2=Convert.ToInt32(Console.ReadLine());
        result=number1/number2;
        rem=result%number2;
        Console.WriteLine($"Devision of two numbers {result}");
        Console.WriteLine($"Reminder is {rem}");

    }

    
}
}