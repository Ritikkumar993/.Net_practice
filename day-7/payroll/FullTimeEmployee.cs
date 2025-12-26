using System;
using System.Collections.Generic;
using System.Linq;
class FullTimeEmployee:EmployeeRecord
{
    public double HourlyRate{get;set;}
    public double MonthlyBonus{get;set;}
    public override double GetMonthlyPay()
    {
        return WeeklyHours.Sum()*HourlyRate+MonthlyBonus;
    }

}