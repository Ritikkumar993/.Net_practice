using System.Security.AccessControl;

class ForensicReport
{
    private Dictionary<string, DateTime> _reportDisc = new Dictionary<string, DateTime>();

    public void addReportDetails(string reportingOfficerName, DateTime reportFiledDate)
    {
        if (_reportDisc.ContainsKey(reportingOfficerName))
        {
            _reportDisc[reportingOfficerName]=reportFiledDate;
        }
        else
        {
        _reportDisc.Add(reportingOfficerName,reportFiledDate);
            
        }
        return;
    }

    public List<string> getOfficersWhoFiledReportsonDate(DateTime reportFiledDate)
    {
        return _reportDisc.Where(r => r.Value==reportFiledDate).Select(x => x.Key).ToList();
    }
    
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter number of reports to be added");
        int n = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Forensic reports (Reporting Officer: Report Filed Date)");
        
        ForensicReport fr = new ForensicReport();

        for (int i=0;i<n;i++)
        {
            string[] strArr = Console.ReadLine().Split(':');
            string reportingOfficer = strArr[0];
            DateTime date = DateTime.Parse(strArr[1]);

            fr.addReportDetails(reportingOfficer,date);
        }
        Console.WriteLine("Enter the filed date to identify the reporting officers");
        DateTime date1 = DateTime.Parse(Console.ReadLine());

        var list = fr.getOfficersWhoFiledReportsonDate(date1);
        Console.WriteLine("Reports filed on the 2020-06-29 are by");
        foreach (string it in list)
        {
            Console.WriteLine(it);
        }

    }
}