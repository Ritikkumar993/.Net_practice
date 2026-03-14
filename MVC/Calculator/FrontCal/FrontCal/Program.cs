using BLCalc;
class Program
{
    static void Main()
    {
        BLCalculator bl = new();
        var list = bl.reverse();
        foreach(string it in list)
        {
            Console.WriteLine(it);
        }

    }
}