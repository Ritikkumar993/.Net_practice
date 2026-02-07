using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

class Program
{
    static int counter = 0;
    static object lockobj = new object();
    static async Task Main()
    {
        // Thread thread = new Thread(new ParameterizedThreadStart(PrintMessage));
        // thread.Start("Hello from thread");



        // Thread worker = new Thread(DoWork);
        // worker.Start();
        // Console.WriteLine("Main thread continues...");



        // Parallel.For( 0, 5 , i=> {
        //    Console.WriteLine($"processing time {i}"); 
        // });



        // int[] number  = new int[10];
        // for (int i= 0; i < number.Length; i++)
        // {
        //     number[i]=i+1;
        // }

        // int sum = 0;

        // Parallel.For(0, number.Length, 
        // () => 0,
        // (i, loopState, localSum)=>
        // {
        //     Console.WriteLine($" localSum : {localSum+number[i]}");
        //     return localSum+number[i];
        // },
        // localSum =>
        // {
        //     Console.WriteLine($"Parllel execution for  Sum : {sum} localsum {localSum}");
        //     Interlocked.Add(ref sum, localSum);
        // });

        // Console.WriteLine("Sum "+sum);

      
        //    Console.WriteLine( await GetDataAsync());

        // Console.WriteLine("starting reading file...");

        // string content = await File.ReadAllTextAsync("data.txt");

        // Console.WriteLine("File content:");

        // Console.WriteLine(content);

        // Console.WriteLine("End of program");

        Console.WriteLine("---------------Process-----------------");
        // Process currprocess = Process.GetCurrentProcess();
        // Console.WriteLine("Current Process ID: "+currprocess);
        // Console.WriteLine("Current Process Name: "+currprocess.ProcessName);
        // Console.WriteLine("Current Process Start Time: "+currprocess.StartTime);
        // Console.WriteLine("Current Process Thread: "+currprocess.Threads);

        // Create a new thread
        // Thread worker = new Thread(DoWork);

        // // Start the thread
        // worker.Start();

        // Console.WriteLine("Main thread continues...");

        // // Optional: Wait for worker thread to finish
        // worker.Join();
        // Console.WriteLine("Main thread finished");

        // Process.Start("notepad.exe");


        // Thread t1  = new Thread(Increment);
        // Thread t2  = new Thread(Increment);
        // t1.Start();
        // t2.Start();
        // t1.Join();
        // t2.Join();

        // Console.WriteLine("Final Counter Value: "+counter);


        // Parallel.For(1, 5, i=>{
        //     Console.WriteLine("Current i VAlue: "+i+" Running on Therad:  "+Task.CurrentId);
        // });

        try
        {
            Task t = Task.Run(()=> throw new Exception("Task error"));
            t.Wait(); 
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.InnerExceptions[0].Message);
        }
        catch (Exception ex)
        {
            
        }

        Task t1 = Task.Run(()=> Console.WriteLine("Task 1"));
        Task t2 = Task.Run(()=> Console.WriteLine("Task 2"));

        Task.WhenAll(t1,t2).ContinueWith(k =>Console.WriteLine("All task Completed"));

        // t3.Start();

        Task<int> t3 = Task.Run(()=>42);
        t3.ContinueWith(resultTask => Console.WriteLine("Result: "+resultTask.Result));



    }

    static void Increment()
    {
        for(int i=0;i < 1_00_000; i++)
        {
            lock (lockobj)
            {
                counter++;
                // Console.WriteLine($"Counter value: {counter}");
            }
        }
    }
    static void DoWork()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Worker thread: " + i);
            Thread.Sleep(500); // Simulate work
        }
    }
    static async Task<int> GetDataAsync()
    {
        await Task.Delay(1000);
        return 42;
    }
    static void PrintMessage(object message)
    {
        Console.WriteLine(message);
    }

    // static void DoWork()
    // {
    //     for(int i=1;i <= 5; i++)
    //     {
    //         Console.WriteLine("Worker thread: "+i);
    //         Thread.Sleep(5000);
    //     }
    // }

   

}