public class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPrecision = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Critical Machinery State (Worn/Faulty/Critical):");
            string state = Console.ReadLine();

            RobotHazardAuditor auditor = new RobotHazardAuditor();
            double risk = auditor.CalculateHazardRisk(armPrecision, workerDensity, state);

            Console.WriteLine($"Robot Hazard Risk Score: {risk}");
        }catch(RobotSafetyException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}