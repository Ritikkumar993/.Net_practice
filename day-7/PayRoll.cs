class PayRoll
{
    public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();

    public void RegisterEmployee(EmployeeRecord record)
    {
        
        PayrollBoard.Add(record);
    }

    public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
    {
        Dictionary<string,int> gCount =new Dictionary<string, int>();
        
        foreach(var emp in records)
        {
            int count=emp.WeeklyHours.Count(h=> h>=hoursThreshold);
            if (count > 0)
            {
                gCount[emp.EmployeeName]=count;
            }
        }

        return gCount;
    }

    public double CalculateAverageMonthlyPay()
    {
        if(PayrollBoard.Count == 0)
        {
            return 0;
        }
        return PayrollBoard.Average(e=>e.GetMonthlyPay());
    }

}