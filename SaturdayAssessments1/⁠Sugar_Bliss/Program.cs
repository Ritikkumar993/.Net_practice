class Chocolate
{
    public string? Flavour{get;set;}
    public int Quantity{get;set;}
    public int PricePerUnit{get;set;}
    public double TotalPrice{get;set;}
    public double DiscountedPrice{get;set;}

    public bool ValidateCholateFlavour()
    {
        if(Flavour=="Dark" || Flavour=="Milk" || Flavour == "White")
        {
            return true;
        }
        return false;
    }


}

class Program
{
    public static Chocolate CalculateDiscountPrice(Chocolate chocolate)
    {
        if (chocolate.ValidateCholateFlavour())
        {
            string? flavour=chocolate.Flavour;
            double dis=0;
            if (flavour == "Dark")
            {
                dis=0.18;
            }
            else if (flavour == "Milk")
            {
                dis=0.12;
            }
            else if(flavour=="White")
            {
                dis=0.06;
            }
            chocolate.TotalPrice=chocolate.Quantity*chocolate.PricePerUnit;
            chocolate.DiscountedPrice=chocolate.TotalPrice-(chocolate.TotalPrice*dis);
            // chocolate.TotalPrice=chocolate.TotalPrice-chocolate.DiscountedPrice;
        }
        return chocolate;
    }
    public static void Main()
    {
        Console.WriteLine("Enter the flavour");
        string? flavour =Console.ReadLine();
        Console.WriteLine("Enter the quantity");
        int quantity = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the price per unit");
        int priceperunit = Convert.ToInt32(Console.ReadLine());

        Chocolate chocolate = new Chocolate()
        {
          Flavour=flavour,
          Quantity=quantity,
          PricePerUnit=priceperunit  
        };
        if (!chocolate.ValidateCholateFlavour())
        {
            Console.WriteLine("Invalid flavour");
        }
        else
        {
            Chocolate res = new Chocolate();
            res = Program.CalculateDiscountPrice(chocolate);
            Console.WriteLine($"Flavour: {res.Flavour}");
            Console.WriteLine($"Quantity: {res.Quantity}");
            Console.WriteLine($"Price Per Unit: {res.PricePerUnit}");
            Console.WriteLine($"Total Price: {res.TotalPrice}");
            Console.WriteLine($"Discounted Price: {res.DiscountedPrice}");
        }


    }
}