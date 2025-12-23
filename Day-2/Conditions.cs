namespace HelloWorldApp{
class Conditions
{
    public void solve()
    {
        int count=0;

            while (count <= 5)
            {
                Console.WriteLine(count);
                count++;
            }

            do
            {
                Console.WriteLine(count);
                count++;
            }while(count<=5);

        for(int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"5 X {i} = {5*i}");
        }



        for(int num = 20; num <= 30; num++)
        {
            Console.WriteLine($"Table of {num}");
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} X {i} = {num*i}");
            }
        }



    }

}
}