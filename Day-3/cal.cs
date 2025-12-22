using System.Security.Cryptography.X509Certificates;

namespace HelloWorldApp
{
    
    class Cal
    {
      
        // public static void Divide(int a, int b, out int quotient, out int remainder)
        // {
        //     quotient = a / b;
        //     remainder = a % b;
        // }
        // public static void Print(in int x)
        // {
        //     Console.WriteLine(x);
        // }

        // public static void Calculator()
        // {
            
        //     int add(int a,int b)
        //     {
        //         return a+b;
        //     }
        //     int sum=add(5,6);
        //     Console.WriteLine(sum);
            
        // }

        static int num=10;
        public static  void Lambda()
        {

            static int Square(int x)
            {
                Console.WriteLine(num);
                return x * x;
            }
            Func<int, int, int> squareLambda = (x,y) => x * x*y;

            Console.WriteLine(Square(num));
            Console.WriteLine(squareLambda(num,2));
        }


    }

}