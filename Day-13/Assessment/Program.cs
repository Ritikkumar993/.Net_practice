using System;
using System.ComponentModel;
using Microsoft.VisualBasic;


namespace EcommerceAssessment
{

    public delegate void OrderCallback(string status);

    class Program
    {

        public static void Main()
        {
            Repositry<Order> repo = new Repositry<Order>();
            repo.Add(new Order {OrderId = 1, CustomerName = "Alice", Amount = 5000});
            repo.Add(new Order {OrderId = 2, CustomerName = "Bob", Amount = 2000});
            repo.Add(new Order {OrderId = 3, CustomerName = "Charlie", Amount = 10000});

            Func<double,double> taxCalulator = value =>value*0.10;
            Func<double,double> discountCalculator = value =>500;


            Predicate<Order> validation = order => order.Amount >=3000;
           
            OrderCallback callback = message => Console.WriteLine(message);

            Action<string> Logger = message =>Console.WriteLine("Log Entry: "+message);
            Action<string> Notifier = message =>Console.WriteLine("Notification: "+message);

            OrderProcessor processor = new OrderProcessor();
            processor.OrderProcessed+=Logger;
            processor.OrderProcessed+=Notifier;


            foreach(var order in repo.GetAll())
            {
                processor.ProcessOrder(order,taxCalulator,discountCalculator,validation,callback);
                Console.WriteLine();
            }

            List<Order> processedOrders = repo.GetAll();
            processedOrders.Sort((a,b) =>b.Amount.CompareTo(a.Amount));

            Console.WriteLine("Sorted Oders (Decending Amount):");
            foreach (var order in processedOrders)
            {
                Console.WriteLine(order.ToString());
            }


        }
    }
}