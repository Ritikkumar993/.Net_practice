abstract class EmployeeRecord
{
    public string EmployeeName{get;set;}
    public double[] WeeklyHours{get;set;}

    public abstract double GetMonthlyPay();
}