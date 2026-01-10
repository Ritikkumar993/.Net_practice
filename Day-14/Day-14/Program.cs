using System;
using System.IO;
using System.Reflection.PortableExecutable;
class Program
{
    public static void Main()
    {
        // string path ="data2.txt";
        // File.WriteAllText(path,"File I/O Example in c#");
        // File.AppendAllText(path,"File I/O Example in c#");

        // Console.WriteLine("Data written to file");

        // string content = File.ReadAllText("data2.txt");
        // Console.WriteLine("File Content :");
        // Console.WriteLine(content);

        // using( StreamWriter writer = new StreamWriter("log.txt"))
        // {
        //     writer.WriteLine("Application started.");
        //     writer.WriteLine("Processing Data");
        //     writer.WriteLine("Application Closed");
        // }

        // using (StreamReader reader = new StreamReader())
        // {
        //     string line;
        //     while((line= reader.ReadLine()) != null)
        //     {
        //         Console.WriteLine();
        //     }
        // }

        User user = new User{Id = 1,Name="Alice"};

        // using ( StreamWriter writer = new StreamWriter("user.txt"))
        // {
        //     writer.WriteLine(user.Id);    
        //     writer.WriteLine(user.Name);
        //     user.Id =2;
        //     user.Name="Bob";
        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        // }
       

        // using ( StreamReader reader = new StreamReader("user.txt"))
        // {
          
        //     while((user.Id=int.Parse(reader.ReadLine()))!=null && (user.Name = reader.ReadLine()) != null)
        //     {
        //         Console.WriteLine($"user id : {user.Id} user name: {user.Name}");
        //     }
        // }


        using(BinaryWriter writer = new BinaryWriter(File.Open("user.bin", FileMode.Create)))
        {
            writer.Write(user.Id);
            writer.Write(user.Name);
        }

        Console.WriteLine("Binary Write is done");



        using(BinaryReader reader = new BinaryReader(File.Open("user.bin", FileMode.Open)))
        {
            
            Console.WriteLine(reader.ReadInt32());
            Console.WriteLine(reader.ReadString());
        }

        FileInfoExample file= new FileInfoExample();
        file.Create();

        DirectoryHandling.Create();

        Serializatobject.Create();
        
        DeSerializejson.Create();

        XMLSerializer.Create();



    }
}