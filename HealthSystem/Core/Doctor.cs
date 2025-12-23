class Doctor
{
    static int TotalDoctors;
    private readonly int licenceno;  
    public string Name { get; set; }
    public int Age { get; set; }

    public int licenceNo{get{return licenceno;}}


    public Doctor(string name,int age,int licno)
    {
        Name=name;
        Age=age;
        licenceno=licno;
        TotalDoctors++;
        Console.WriteLine($"Doctor created: {Name}, Age: {Age}, License: {LicenseNumber}. TotalDoctors = {TotalDoctors}");

    }


}