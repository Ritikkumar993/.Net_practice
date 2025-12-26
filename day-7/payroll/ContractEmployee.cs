class ContractEmployee:EmployeeRecord
{
    public Double HourlyRate{get;set;}
    public override double GetMonthlyPay()
    {
        return WeeklyHours.Sum()*HourlyRate;
    }
}