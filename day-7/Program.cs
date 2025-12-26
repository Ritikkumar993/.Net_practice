class Program
{
     public static void Main()
    {
        // Arrays.display();
        // string s=FlipKey.Security();
        // Console.WriteLine(s);

        PayRoll pr=new PayRoll();

        bool check=true;

        while (check){
            Console.WriteLine("1. Register Employee");
            Console.WriteLine("2. Show Overtime Summary");
            Console.WriteLine("3. Calculate Average Monthly Pay");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\n Enter your choice:");

            int choice=int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Select Employee Type (1-Full Time, 2-Contract):");
                    int type=int.Parse(Console.ReadLine());
                          
                    Console.WriteLine("Enter Employee Name:");
                    string name=Console.ReadLine();

                    Console.WriteLine("Enter Hourly Rate:");
                    double  rate=double.Parse(Console.ReadLine());


                    if (type == 1)
                    {
                        Console.WriteLine("Enter Monthly Bonus:");
                        double bonus =int.Parse(Console.ReadLine());
                        double[] hr=new double[4];
                        Console.WriteLine("Enter weekly hours (Week 1 to 4):");
                        
                        for(int i = 0; i < 4; i++)
                        {
                            hr[i]=int.Parse(Console.ReadLine());
                        }
                                               
                       
                        pr.RegisterEmployee(new FullTimeEmployee
                        {
                            EmployeeName =name,
                            HourlyRate=rate,
                            MonthlyBonus=bonus,
                            WeeklyHours =hr
                        });

                    }
                    else if (type == 2)
                    {
                        double[] hr=new double[4];
                        Console.WriteLine("Enter weekly hours (Week 1 to 4):");
                        
                        for(int i = 0; i < 4; i++)
                        {
                            hr[i]=int.Parse(Console.ReadLine());
                        }
                                               
                       
                        pr.RegisterEmployee(new ContractEmployee
                        {
                            EmployeeName =name,
                            HourlyRate=rate,
                            WeeklyHours =hr
                        });

                    }
                    else
                    {
                        Console.WriteLine("Invalid option");
                        break;
                    }
                    Console.WriteLine("Employee registered successfully");
                    break;
                case 2:
                    Console.WriteLine("Enter hours threshold:");
                    int threshold=int.Parse(Console.ReadLine());
                    var record=pr.GetOvertimeWeekCounts(PayRoll.PayrollBoard,threshold);
                    if(record.Count == 0)
                    {
                        Console.WriteLine("No overtime recorded this month");
                    }
                    else
                    {
                        foreach(var it in record)
                        {
                            Console.WriteLine(it.Key+"-"+it.Value);
                        }
                    }
                    break;
                case 3:
                    double avg=pr.CalculateAverageMonthlyPay();
                    Console.WriteLine("\nOverall average monthly pay: "+avg);
                    break;
                case 4:
                    check=false;
                    Console.WriteLine("Logging off — Payroll processed successfully!");
                    break;
                default:
                    Console.WriteLine("Invalide Choices");
                    break;

            }

        }


    }
}