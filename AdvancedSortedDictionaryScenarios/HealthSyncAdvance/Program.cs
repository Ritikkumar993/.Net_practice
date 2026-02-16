using System.Text.RegularExpressions;

abstract class Consultant
{
    public abstract double CalculateGrossPayout();
    public virtual double TDS()
    {
        return 10;
    }
    
}

class InHouse:Consultant
{
    public double MonthlyStipend { get; set; }
    public double Gross{get; private set;}
    public double NetPayout{get; private set;}

    public override double CalculateGrossPayout()
    {
        double allowance = MonthlyStipend*0.20;
        double bonus=MonthlyStipend*0.10;

        Gross=MonthlyStipend+allowance+bonus;
        return Gross;
    }

    public override double TDS()
    {
        if (Gross > 5000)
        {
            NetPayout=Gross-(Gross*0.15);
            return 15;
        }
        NetPayout=Gross-(Gross*0.05);
        return 5;
    }


    
}

class Visiting : Consultant
{
    public double Fee { get; set; }
    public double Visits { get; set; }

    public double Gross{get; private set;}
    public double NetPayout{get; private set;}

    public override double CalculateGrossPayout()
    {
        Gross=Fee*Visits;

        return Gross;
    }
    public override double TDS()
    {
        NetPayout=Gross-(Gross*0.10);
        return 10;
    }
}
class Program
{
    static bool ValidateConsultantId(string Id)
    {
        string pattern = @"^DR[0-9]{4}$";

        if (Regex.IsMatch(Id, pattern))
        {
            return true;
        }
        return false;
        
    }
    static void Main()
    {
        try
        {
            
        InHouse inhouse= new();
        Visiting visiting = new();

        bool check = true;
        while (check)
        {
            Console.WriteLine("1.In-House Consultant");
            Console.WriteLine("2.Visiting Consultant");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Enter your Choice");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    string? str1= Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(str1)) throw new ArgumentException();
                    string[] arr1=str1.Split();

                    if(!Program.ValidateConsultantId(arr1[0])){
                        Console.WriteLine("Invalid doctor id(Process terminates).");
                        break;
                    }
                    inhouse.MonthlyStipend=double.Parse(arr1[1]);
                    double gross=inhouse.CalculateGrossPayout();
                    double tds =inhouse.TDS();
                    double net =inhouse.NetPayout;
                    Console.WriteLine($"Gross: {gross:F2} | TDS Applied: {tds}% | Net Payout: {net:F2}");
                    break;
                case 2:
                    string? str2= Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(str2)) throw new ArgumentException();
                    string[] arr2=str2.Split();

                    if(!Program.ValidateConsultantId(arr2[0])){
                        Console.WriteLine("Invalid doctor id(Process terminates).");
                        break;
                    }

                    visiting.Visits=double.Parse(arr2[1]);
                    visiting.Fee =double.Parse(arr2[2]);
                    double gross2=visiting.CalculateGrossPayout();
                    double tds2 = visiting.TDS();
                    double net2= visiting.NetPayout;

                    Console.WriteLine($"Gross: {gross2:F2} | TDS Applied: {tds2}% | Net Payout: {net2:F2}");
                    break;
                case 3:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Invalid Choice input");
                    break;
            }
        }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
    }
}

