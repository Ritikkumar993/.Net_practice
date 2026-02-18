

class CakeOrder
{
    Dictionary<string,double> orderMap= new Dictionary<string, double>();

    public void addOrderDetails(string orderId, double cakeCost)
    {
        orderMap.Add(orderId,cakeCost);
    }

    public Dictionary<string, double> findOrdersAboveSpecifiedCost(double cakeCost)
    {
        return orderMap.Where(c => c.Value>cakeCost).ToDictionary();
    }

}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter number of cake orders to be added");
        int n = Int32.Parse(Console.ReadLine());

        CakeOrder orders = new CakeOrder();
        Console.WriteLine("Enter the cake order details (Order Id: CakeCost)");

        for(int i = 0; i < n; i++)
        {
            string[] strArr=Console.ReadLine().Split(':');
            
            string ID = strArr[0];
            double cakeCost =Double.Parse(strArr[1]);

            orders.addOrderDetails(ID,cakeCost);           
            
        }
        Console.WriteLine("Enter the cost to search the cake orders");
        double searchByCost = Double.Parse(Console.ReadLine());

        Console.WriteLine("Cake Orders above the specified cost");

        var res = orders.findOrdersAboveSpecifiedCost(searchByCost);

        foreach(var it in res)
        {
            Console.WriteLine($"Order ID:{it.Key}, Cake Cost:{it.Value:F1}");
        }

        
    }
}



