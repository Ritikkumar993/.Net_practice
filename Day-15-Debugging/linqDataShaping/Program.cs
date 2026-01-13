
using System.Linq;

class Student
{
    public String Name;
    public String Grade;
    public int marks;
}

class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>();

        Student student = new Student
        {
            Name = "Ritik",
            marks = 89
        };
        students.Add(student);

        student = new Student
        {
            Name = "Roman",
            marks = 90
        };
        students.Add(student);

        student = new Student
        {
            Name = "Aryan",
            marks = 90
        };
        students.Add(student);

        var result = students.Select(s => new 
        {   
            s.Name,
            Grade = s.marks > 60 ? "Pass" : "Fail",
            s.marks
        });

        var HighToLow = result.OrderByDescending(e => e.marks).ThenBy(e=>e.Name);
        Console.WriteLine(HighToLow.GetType());
        foreach(var res in HighToLow)
        {
            Console.WriteLine($"Name: {res.Name}\nGrade: {res.Grade}");
        }

        int[] arr = { 1, 2, 4, 10, 6 };
        //int first = arr.ToList().First();
        //int last = arr.ToList().Last();
        int last = arr.ToList().Last(n=> n>6);
        int first = arr.ToList().First(n=> n>9);
        int single = arr.ToList().Single()
        Console.WriteLine(first);
        Console.WriteLine(last);

    }
}