// using System.Reflection;


// class Employee
// {
//     public string Name{get; set;}
//     private int _Id;
//     public Employee(string name, int id)
//     {
//         Name=name;
//         _Id=id;
//         Console.WriteLine("Name: "+Name+"\n"+"Id"+_Id);
//     }
//     public void Work(string greet, string k)
//     {
//         Console.WriteLine("Working "+greet+" "+k);
//     }
    
// }
// class Program
// {
//     static void Main()
//     {
        
//         // Assembly assembly = Assembly.GetExecutingAssembly();
//         // Console.WriteLine(assembly);

//         // Console.WriteLine(Assembly.Load("Day-16"));
//         // Console.WriteLine(Assembly.LoadFrom("K:/csharp/dot_net/DigitalWallet/DigitalWallet/bin/Debug/net10.0/DigitalWallet.dll"));

//         // Employee emp= new Employee("Ritik", 191);
//         // Console.WriteLine(emp.GetType()); 

//         // Type type  = typeof(Employee);
//         // Console.WriteLine(type);

//         // Type type2 = emp.GetType();
//         // Console.WriteLine(type2);

//         // Type type3 = Type.GetType("Day-16.Models.Employee");
//         // Console.WriteLine(type3);

//         // MethodInfo method = type.GetMethod("Work");
//         // object[] ob =new object[]{"Good","kk"};
//         // method.Invoke(emp,ob);

//         // PropertyInfo prop = type.GetProperty("Name");
//         // prop.SetValue(emp, "John");
//         // Console.WriteLine(emp.Name);

//         // FieldInfo field = type.GetField(
//         //     "_Id",
//         //     BindingFlags.NonPublic | BindingFlags.Instance

//         // );
//         // Console.WriteLine(field);

//         // Console.WriteLine(field.GetValue(emp));
//         // field.SetValue(emp, 190);
//         // Console.WriteLine(field.GetValue(emp));
        
//         // Console.WriteLine("ConstructorInfo ");

//         // // ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
//         // // object obj =ctor.Invoke(null);
//         // // obj.Name="Ritik";
//         // // Console.WriteLine(obj.Name);

//         // ConstructorInfo ctor = type.GetConstructor(
//         //     new Type[] { typeof(string), typeof(int) }
//         // );
//         // object obj = ctor.Invoke(new object[] { "Amit", 101 });


//         // Console.WriteLine("ParameterInfo ");
//         // ParameterInfo[] parameters = method.GetParameters();

//         // Console.WriteLine(parameters.Length);


//         // Console.WriteLine("ParameterInfo");

//         // foreach (ParameterInfo p in parameters)
//         // {
//         //     Console.WriteLine($"{p.Name} - {p.ParameterType}");
//         // }

//         Assembly assembly = Assembly.GetExecutingAssembly();

//         foreach (Type type in assembly.GetTypes())
//         {
//             Console.WriteLine("Class: " + type.Name);

//             foreach (MethodInfo method in type.GetMethods())
//             {
//                 Console.WriteLine("  Method: " + method.Name);
//             }
//         }
//     }
// }


using System;
using System.Reflection;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Work()
    {
        Console.WriteLine("Employee working");
    }
}

class Program
{
    static void Main()
    {
        Type type = typeof(Employee);

        Console.WriteLine("Class Name: " + type.Name);
        Console.WriteLine("Namespace: " + type.Namespace);

        Console.WriteLine("\nProperties:");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine($"{prop.Name} - {prop.PropertyType}");
        }

        Console.WriteLine("\nMethods:");
        foreach (MethodInfo method in type.GetMethods())
        {
            Console.WriteLine(method.Name);
        }
    }
}

