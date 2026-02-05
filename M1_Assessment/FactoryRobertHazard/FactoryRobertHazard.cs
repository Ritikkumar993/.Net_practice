class RobotSafetyException : Exception
{
    public RobotSafetyException(string message) : base(message){}
}

public class RobotHazardAuditor : Exception
{
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        if(armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }
        if(workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }
        
        double RiskMachineryState;
        if(machineryState == "Worn")
        {
            RiskMachineryState = 1.3;
        }else if(machineryState == "Faulty")
        {
            RiskMachineryState = 2.0;
        }else if(machineryState == "Critical")
        {
            RiskMachineryState = 3.0;
        }
        else
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        double HazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * RiskMachineryState);

        return HazardRisk;
    }
}