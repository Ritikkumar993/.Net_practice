class Program
{
    static void Main()
    {
        Dictionary<int,double> Dict =new Dictionary<int, double>(){
           {1,20000},
            {4,40000},
            {5,15000}
        };
        
        List<int> Ids =new List<int>() {
            {1},
            {4},
            {5}
        };

        double total =0.00;
        foreach(int it in Ids)
        {
            total+=Dict[it];
        }
        Console.WriteLine(total);
    }
}