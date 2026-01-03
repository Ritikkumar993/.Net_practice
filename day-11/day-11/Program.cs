using System;
// using System.Data.Common;
class Program
{
    static(int sum, int avg,int diff)Calculate(int a,int b)
    {
        return (a+b,a+b/2,a-b);
    }

    public static void Main()
    {
        Console.WriteLine("Creating Objects...");
        for(int i = 0; i < 5; i++)
        {
            Myclass obj = new Myclass();
        }
        Console.WriteLine("Forcing Garbage Collection....");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Garbage Collection is Completed");
        var data = new {Name="Ritik",Age=21};
        Console.WriteLine(data.GetType());
        // Console.WriteLine("Namr:"+data.Name);

        Console.WriteLine("Tupple types.............");
        var student = (Id:101,Name:"Ritik",0);//TUPPLE
        Console.WriteLine(student.GetType());

        var Cal=Calculate(1,2);
        
        Console.WriteLine("Sum: "+Cal.sum+" Avg:"+Cal.avg+" Diff: "+Cal.diff);

        static(bool isValid,string message)ValidUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return (false,"Invalid Username");
            }
            return (true,"Valid Username");
        }
        var response = ValidUser("Ritik");
        Console.WriteLine(response.message);

        // var (a,b,c)=(1,2,3);
        var person =(Id: 1,Name:"Ritik", City:"jalandher");

        var (id,_,_)=person;
        Console.WriteLine(id+" ");
        // Console.WriteLine(id.GetType());
        // Console.WriteLine(name.GetType());

        var s = new Student { Id=1, Name="Amit" };
        // var s = new Student { Id = 1, Name = "Amit" };
        var (sid,sname) = s;
        Console.WriteLine(s.GetType());
        Console.WriteLine(sid);

        int[] number={1,2,3,4,5,6,7,8};
        var evenNumber=number.Where(n=>n%2==0);
        var sele=number.Where(n=>n>3).Select(n=>n*2);
        foreach(var it in sele)
        {
            Console.Write(it+" ");
        }
            Console.WriteLine("\n"+sele+" ");
        Console.WriteLine("\n"+sele.GetType());//IEnumerable interface
        Console.WriteLine("\n"+evenNumber.GetType());//IEnumerable interface

           
      
        List<Student> students= new List<Student>
        {
            new Student{Id=1,Name="Ritik",marks=80},
            new Student{Id=2,Name="Rohit",marks=70},
            new Student{Id=3,Name="Rohan",marks=90},
            
        };
        var result = students.Select(s => new
        {
           s.Name,
           Grade=s.marks>60?"Pass":"Fail" 
        });
        foreach(var it in result)
        {
            Console.WriteLine("Name:"+it.Name+"\n"+"Grade:"+it.Grade);
        }
        Console.WriteLine(result.GetType());
        Console.WriteLine(result.ToList());
        Console.WriteLine(result.GetType());

        //orderby & orderbydecending
        List<int> list= new List<int>{1,4,2,5,7,8,3,5};
        var li=list.OrderByDescending(n=>n);
        foreach(var it in li)
        {
            Console.Write(it+" ");
        }
        Console.WriteLine();

        var sortstudents=students.OrderByDescending(n=>n.marks);
        // var sortstudents=students.OrderBy(n=>n.marks);

        foreach(var it in sortstudents)
        {
            Console.WriteLine(it.Name+" "+it.marks);
        }

        
        Console.WriteLine("--------------------IDispose-----------------");
        for(int i = 0; i < 5; i++)
        {
            using(ResourceHandler handler =new ResourceHandler())
            {
                Console.WriteLine("hello");
            }
        }
        Console.WriteLine("Garbage Collection Large Object Heap......");


        GC.Collect(); 
        GC.WaitForPendingFinalizers();

        Console.WriteLine($"Total Memory Before GC: {GC.GetTotalMemory(false)} bytes");

        for (int i = 0; i < 10000; i++)
        {
            object obj = new object(); // Gen 0 allocation
        }

        Console.WriteLine($"Total Memory After Object Creation: {GC.GetTotalMemory(false)} bytes");

        GC.Collect(); 
        GC.WaitForPendingFinalizers();

        Console.WriteLine($"Total Memory After GC: {GC.GetTotalMemory(false)} bytes");
        Console.WriteLine($"Generation of a new object: {GC.GetGeneration(new object())}");
        Console.WriteLine($"Generation of a new object: {GC.GetGeneration(students)}");


    

    }
}

class Myclass
{
    
    ~Myclass(){
        Console.WriteLine("Finalizer called, Object Collected");
    }
}

class Student
{ 
    public string Name { get; set; }

    public int age{get;set;}

    public void Display()
    {
      Console.WriteLine("Name: "+Name);
      Console.WriteLine("Age: "+Age);
    }
}

class ResourceHandler : IDisposable
{
    public ResourceHandler()
    {
        Console.WriteLine("Resource acquired.");
    }
    public void Dispose()
    {
        Console.WriteLine("Resourse released");
    }
}