using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Course { get; set; }
    public int Marks { get; set; }

}

class StudentUtility
{
    public Dictionary<string, string> GetStudentDetails(string id)
    {
        Dictionary<string, string> res = new Dictionary<string, string>();

        foreach(var it in Program.studentDetails)
        {
            if(it.Value.Id == id)
            {
                res.Add(id, it.Value.Name + '_' + it.Value.Course);
                return res;
            }
        }

        return res;
        
    }

    public Dictionary<string, Student> UpdateStudentMarks(string id, int marks)
    {
        Dictionary<string, Student> update = new Dictionary<string, Student>();
        foreach(var it in  Program.studentDetails){
            if (it.Value.Id == id)
            {
                it.Value.Marks = marks;
                update.Add(id, it.Value);
                return update;
            }
        }
        return update;
    }

}


class Program
{
    public static Dictionary<int, Student> studentDetails= new Dictionary<int, Student>();

    public static void Main()
    {
        studentDetails.Add(1, new Student { Id = "ST01", Name = "Alice", Course = "DataScience", Marks = 80 });

        bool check = true;

        while (check)
        {
            Console.WriteLine("1. Get Student Details");
            Console.WriteLine("2. Update Marks");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice");
            int choice = int.Parse(Console.ReadLine());

            StudentUtility su = new StudentUtility();



            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the student id");
                    string id = Console.ReadLine();
                    Dictionary<string, string> ans = su.GetStudentDetails(id);
                    if (ans.Count > 0)
                    {
                        foreach (var it in ans) {
                            Console.WriteLine($"{ it.Key} {it.Value}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Student id not found");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the student id");
                    string Id = Console.ReadLine();
                    Console.WriteLine("Enter the student updated Marks");
                    int marks = int.Parse(Console.ReadLine());
                    Dictionary<string, Student> an = su.UpdateStudentMarks(Id,marks);

                    if (an.Count > 0)
                    {
                        Console.WriteLine("Updated marks are");

                        Console.WriteLine($"{Id} {an[Id].Marks}");
                    }
                    else
                    {
                        Console.WriteLine("Student id not found");
                    }
                    break;
                case 3:
                    check = false;
                    Console.WriteLine("Exit");
                    break;
            }
        }
    }


}