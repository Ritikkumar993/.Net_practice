class Program
{
    static void Main()
    {
        int feet = int.Parse(Console.ReadLine());
        double centimeters =Convert(feet);
        Console.WriteLine($"{centimeters}");
    }

    static double Convert(int feet)
    {
        double cm = (double)feet*30.48;
        return cm;
    }
}