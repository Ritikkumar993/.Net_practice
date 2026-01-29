using System.Collections.Generic;
using System.Security.AccessControl;
public class Student
{
    public String? Name;
    public int Age;
    public int Marks;

    public Student(){}
}

class Program
{
    static void Main()
    {
        List<Student> studentlist = new List<Student>()
        {
            new Student{Name="Ritik",Age=22,Marks=95},
            new Student{Name="Aryan",Age=21,Marks=90},
            new Student{Name="Aman",Age=23,Marks=93},
            new Student{Name="Kundan",Age=22,Marks=93},
            new Student{Name="Mohit",Age=21,Marks=91},          
        };

        // var result = studentlist.OrderByDescending(it => it.Marks).ThenBy( k => k.Age).ToList();
        // studentlist=result;

        // studentlist.Sort((a,b) =>
        // {
        //     int cmp = b.Marks.CompareTo(a.Marks);
        //     return cmp!=0? cmp: a.Age.CompareTo(b.Age);
        // });

        studentlist.Sort(new Cmp());


        

        foreach(var it in studentlist){
            Console.WriteLine($"Name:{it.Name} Marks:{it.Marks} Age:{it.Age}");
        }
    }

    
}

internal class Cmp:IComparer<Student>
{
    public int Compare(Student? a, Student? b)
    {
        if (a == null && b == null) return 0;
        if (a == null) return -1;
        if (b == null) return 1;
        int cmp = b.Marks.CompareTo(a.Marks);
        return cmp!=0? cmp: a.Age.CompareTo(b.Age);
    }
}
