

using System.Text.RegularExpressions;

class Shipment
{
    public string ShipmentCode { get; set; } 
    public string TransportMode{ get; set; }
    public double Weight { get; set; }
    public int StorageDays {get; set; }

}

class ShipmentDetails:Shipment
{
    public double RatePerKg(string s)
    {
        switch (s)
        {
            case "Sea":
                return 15.00;
            case "Air":
                return 50.00;
            case "Land":
                return 25.00;
        }
        return 0.00;
    }
    public bool ValidateShipCode(string shipmentCode)
    {
        // if(shipmentCode.Length!=7) return false;

        // string pattern=@"^GC#[0-9]{4}$";

        //x_%3      

        string pattern = @"[]";
        if(Regex.IsMatch(shipmentCode,pattern)) return true;

        // if(!shipmentCode.StartsWith("GC#")) return true;
        // string sub= shipmentCode.Substring(3);

        // foreach(char ch in sub)
        // {
        //     if(!char.IsDigit(ch)) return false;
        // }
        
        return false;
    }

    public double CalculateTotalCost()
    {
        double TotalCost = (Weight*RatePerKg(TransportMode))+Math.Sqrt(StorageDays);
        return TotalCost;
    }

}

class Program
{
    static void Main()
    {
        try
        {
        

            
        ShipmentDetails details = new ShipmentDetails();
        Console.WriteLine("Enter ShipmentCode");
        string shipmentCode=Console.ReadLine();

        if (details.ValidateShipCode(shipmentCode))
        {
            details.ShipmentCode=shipmentCode;
            Console.Write("Mode:");
            details.TransportMode=Console.ReadLine();
            Console.Write("Weight:");
            details.Weight=Convert.ToDouble(Console.ReadLine());
            Console.Write("Storage:");
            details.StorageDays=Convert.ToInt32(Console.ReadLine());

            double total = details.CalculateTotalCost();
            Console.WriteLine($"The total shipping cost is {Math.Round(total,2):F2}");
            
            
        }
        else
        {
            Console.WriteLine("Invalid shipment Code");
        }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }




    }
}