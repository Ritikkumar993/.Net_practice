


class Bike
{
    public string? Model{get;set;}
    public string? Brand{get;set;}
    public int PricePerDay{get; set;}

    
}
class BikeUtility
{
    public void AddBikeDetails(string? model, string? brand, int pricePerDay)
    {
        int Key = Program.bikeDetails.Count+1;
        Bike b= new Bike();
        b.Model=model;
        b.Brand=brand;
        b.PricePerDay=pricePerDay;
        Program.bikeDetails.Add(Key,b);
        
    }
    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> groups = new SortedDictionary<string, List<Bike>>();
        foreach (var  bike in Program.bikeDetails.Values)
        {
            if (!groups.ContainsKey(bike.Brand))
            {
                groups[bike.Brand]=new List<Bike>();
            }
            groups[bike.Brand].Add(bike);
            
        }
        return groups;
    }
}



class Program
{
    public static SortedDictionary<int, Bike> bikeDetails=new SortedDictionary<int, Bike>();
    
    public static void Main()
    {
        BikeUtility bikeUtility = new BikeUtility();

        bool check=true;
        while (check)
        {
            
            Console.WriteLine("1. Add Bike Details");

            Console.WriteLine("2. Group Bikes By Brand");

            Console.WriteLine("3. Exit");
        
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the Bike Brand:");
                    string? brand=Console.ReadLine();
                    Console.WriteLine("Enter the Bike Model:");
                    string? Model=Console.ReadLine();
                    Console.WriteLine("Enter the Bike Price:");
                    int Price = Convert.ToInt32(Console.ReadLine());
                    bikeUtility.AddBikeDetails(Model,brand,Price);
                    break;
                case 2:
                    Console.WriteLine("Grouping Bike Based on Brands...");
                    var BikeGrouping = bikeUtility.GroupBikesByBrand();
                    Console.WriteLine("Grouping is Successfully Completed");
                    Console.WriteLine("Group of Bikes and there Models and Pricings");
                    foreach(var Brand in BikeGrouping)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Brand is {Brand.Key}");
                        Console.WriteLine();
                        foreach(Bike bike in Brand.Value)
                        {
                            Console.WriteLine($"Model            |    {bike.Model}");
                            Console.WriteLine($"Pricing Per Day  |    {bike.PricePerDay}");
                            Console.WriteLine();
                        }
                    }
                    break;
                case 3:
                    check=false;
                    break;
                default:
                    Console.WriteLine("Invaild Choice");
                    break;
            }


        }

    }
}




// 1. Add Bike Details
// 2. Group Bikes By Brand
// 3. Exit
// Enter your choice
// 1
// Enter the Bike Brand:
// RE
// Enter the Bike Model:
// Interceptor 650cc
// Enter the Bike Price:
// 6000
// 1. Add Bike Details
// 2. Group Bikes By Brand
// 3. Exit
// Enter your choice
// 1
// Enter the Bike Brand:
// JAVA
// Enter the Bike Model:
// Bomber 650
// Enter the Bike Price:
// 4000
// 1. Add Bike Details
// 2. Group Bikes By Brand
// 3. Exit
// Enter your choice
// 1
// Enter the Bike Brand:
// RE
// Enter the Bike Model:
// Metor 350
// Enter the Bike Price:
// 5000
// 1. Add Bike Details
// 2. Group Bikes By Brand
// 3. Exit
// Enter your choice
// 2
// Grouping Bike Based on Brands...
// Grouping is Successfully Completed
// Group of Bikes and there Models and Pricings

// Brand is JAVA

// Model            |    Bomber 650
// Pricing Per Day  |    4000


// Brand is RE

// Model            |    Interceptor 650cc
// Pricing Per Day  |    6000

// Model            |    Metor 350
// Pricing Per Day  |    5000

// 1. Add Bike Details
// 2. Group Bikes By Brand
// 3. Exit
// Enter your choice
