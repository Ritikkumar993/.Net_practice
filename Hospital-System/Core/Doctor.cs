class Doctor
{
    public static int TotalDoctors;
    private readonly int licenceno;  
    public string Name { get; set; }
    public int Age { get; set; }

    // public int licenceNo{get{return licenceno;}}
    public string specilization;

    static Doctor()
    {
        TotalDoctors =0;
    }
    public Doctor(string name,int age,int licno,string spec)
    {
        Name=name;
        Age=age;
        licenceno=licno;
        TotalDoctors++;
        specilization=spec;
        Console.WriteLine($"Doctor created: {Name}, Age: {Age}, License: {licenceno}. TotalDoctors = {TotalDoctors}");

    }


}

class Cardiologist:Doctor
{
    public Cardiologist(string name,int age,int licno,string spec):base(name,age,licno,spec)
    {
        
    }
    public  void Display()
    {
        Console.WriteLine($"Total Doctors :{TotalDoctors}");
    }
    
}