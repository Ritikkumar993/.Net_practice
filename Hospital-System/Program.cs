using System;
class Program
{
    public static void Main()
    {
        
        Cardiologist cd = new Cardiologist("Ritik",101,251627,"cardio");
        cd.Display();
        Cardiologist cd1 = new Cardiologist("Ritik",101,251627,"cardio");

        Console.WriteLine("Total Doctors:"+Cardiologist.TotalDoctors);
        
    }
}