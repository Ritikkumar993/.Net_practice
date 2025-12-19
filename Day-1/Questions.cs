

namespace HelloWorldApp
{
    class Questions
    {
        public void solve()
        {
            //1
            // char ch;
            // Console.WriteLine("Enter any Character");
            // ch = Convert.ToChar(Console.ReadLine());
            // switch (ch)
            // {
            //     case 'a':
            //     case 'e':
            //     case 'i':
            //     case 'o':
            //     case 'u':
            //     case 'A':
            //     case 'E':
            //     case 'I':
            //     case 'O':
            //     case 'U':
            //         Console.WriteLine($"The character '{ch}' is a Vovel");
            //         break;
            //     default:
            //         Console.WriteLine($"The character '{ch}' is a consonate");
            //         break;
            // }

            //2
            // string s = string.Empty;
            // Console.WriteLine("Enter String");
            // s = Console.ReadLine();
            // s = s.ToUpper();
            // int len = s.Length;
            // Console.WriteLine($"Original string length: {len}");
            // Console.WriteLine($"Uppercase string: {s}");


            //3 
            // 1 2
            // 3
            // -1
            // 2
            // a+b
            // 1





            int a = 0, b = 0;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Before swap: a = {a}, b = {b}");

            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine($"After swap: a = {a}, b = {b}");









        }
    }
}