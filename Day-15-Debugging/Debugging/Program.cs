using System.Diagnostics;

class User
{
    public int Age { get; set; }

}


class Program
{
    static void Main()
    {
        Trace.WriteLine("Application Started");
        //int a = 10;
        //int b = 0;
        //try
        //{
        //    int res=a/b;
        //    Console.WriteLine(res);

        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Error: {ex.Message} ");
        //}

        //Calculator.Start();

        //int total = 0;
        //for (int i = 0; i < 5; i++)
        //{
        //    total += i;
        //}
        //Console.WriteLine(total);
        List<User> users = new List<User>();
        User user = new User
        {
            Age = 21
        };
        users.Add(user);
        user = new User
        {
            Age = 51
        };
        users.Add(user);
        user = new User
        {
            Age = 81
        };
        users.Add(user);
        user = new User
        {
            Age = 90
        };
        users.Add(user);

        foreach(var u in users)
        {
            Console.WriteLine($"User Age: {u.Age}");
        }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(3);
        queue.Enqueue(4);

        while (queue.Count > 0)
        {

           int k= queue.Dequeue();
           Console.WriteLine(k);
        }




    }
}