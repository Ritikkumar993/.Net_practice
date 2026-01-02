using System.Text.RegularExpressions;

namespace LogParserProgram
{
    class LogParser
    {
        // YYYY-MM-DDTHH:MM:SSZ
        private string sevrityAndTimestamp=@"\[(INFO|WARN|ERROR|DEBUG|CRITICAL)\] \d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}Z";
        private string serviceNameandUserID=@"service=(?<service>[a-z]+)(?:\s+userId=(?<userId>USR_\d+))?";

        private string weakPasswordpattern=@"(?i)\bpassword(?:=[\'""]?[a-z0-9]+[\'""]?|[a-z0-9]+)\b";
        private string extractTransactionData=@"txnId=(?<txnId>\bTXN\d+\b)\s+amount=(?<amount>[$₹]\d+)";

        private string ignoredMasked=@"(?i)\bpassword(?!=(?:\*+|X+|#+))(?:=[a-z0-9]+)";
        public bool SevrityAndTimestamp(string line)
        {
            return Regex.IsMatch(line,sevrityAndTimestamp);
        }

        //task2
        public void ServiceNameandUserID(string line)
        {
            if (Regex.IsMatch(line, serviceNameandUserID))
            {  
                Match match=Regex.Match(line,serviceNameandUserID);
                Console.WriteLine("service->"+match.Groups["service"].Value);
                Console.WriteLine(match.Groups["userId"].Success?"userId->"+match.Groups["userId"].Value:"userId->userId is Not present");
            }
            else
            {
                Console.WriteLine("Do not have service and userId");
            }
        }

        public string WeakPasswordCheck(string line)
        {
            if(Regex.IsMatch(line, weakPasswordpattern))
            {
                Match s=Regex.Match(line,weakPasswordpattern);
                return s.Value;
            }
            return "";
        }

        public void ExtractTransactionData(string lines)
        {
            if (Regex.IsMatch(lines, extractTransactionData))
            {
                Match m=Regex.Match(lines,extractTransactionData);
                Console.WriteLine("txnId->"+m.Groups["txnId"].Value);
                Console.WriteLine("amount->"+m.Groups["amount"].Value);
            }
        }
        public bool IgnoredMasked(string line)
        {
            return Regex.IsMatch(line,ignoredMasked);
        }
    }
}