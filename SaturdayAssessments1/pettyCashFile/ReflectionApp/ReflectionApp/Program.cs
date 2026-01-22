using System;
using System.Reflection;



class Program
{
    static void Main()
    {
        string dllpath = @"K:\\csharp\\dot_net\\SaturdayAssessments1\\pettyCashFile\\PettyCash\\PettyCash\\bin\\Debug\\net10.0\\PettyCash.dll";

        Assembly assembly = Assembly.LoadFrom(dllpath);

        Console.WriteLine("ASSEMBLY LOADED");
        Console.WriteLine("----------------");

        foreach (Type type in assembly.GetTypes())
        {
            Console.WriteLine($"Type: {type.Name}");

            if (type.IsInterface)
                Console.WriteLine("  → This is an INTERFACE");

            if (type.IsClass)
                Console.WriteLine("  → This is a CLASS");
            if (type.Name == "ClassB")
            {

                Console.WriteLine("  Members:");
                foreach (var member in type.GetMembers())
                {
                    Console.WriteLine($"     {member.MemberType} : {member.Name}");
                }

                Console.WriteLine();
            }
        }
    }
}
