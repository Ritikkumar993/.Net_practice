using System.IO.Pipelines;

namespace HelloWorldApp
{
    class MathOps
    {
        
        // public int add(int a,int b)
        // {
        //     return a+b;            
        // }
        

        public static int add(int a,int b)
        {
            return a+b;
        }

        // public static double add(double a,double b)
        // {
        //     return a+b;            
        // }

        // public static double add(double a,double b, double c)
        // {
        //     return a+b+c;
        // }


        //refrence
        // int b,int c,int a=10,
        // "b:"+b+"\nc:"+c+"\na:"+a+
        public void sum(params int[] nums)
        {
            int sum=0;
            foreach(int it in nums)
            { 
                sum+=it;
            }
            Console.WriteLine("\nsum:"+sum);
        }

        
        public void Increasebyten(ref int a)
        {
            a=a+10;
        }

        public void display(int x)
        {
            Console.WriteLine(x);
        }

        public void Process()
        {
            string status = "Processing...";

            void PrintMsg()
            {
                Console.WriteLine(status);
            }

            PrintMsg();
        }



    }
}

