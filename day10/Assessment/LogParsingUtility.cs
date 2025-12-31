
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace LogProcessing
{
        
    class LogParser
    {
        // [TRC], [DBG], [INF], [WRN], [ERR], [FTL]
        private readonly string validLineRegexPattern=@"\[(TRC|DBG|INF|WRN|ERR|FTL)\].*";

        private readonly string splitLineRegexPattern=@"<\*\*\*>|<====>|<\^\*>";
        private readonly string quotedPasswordRegexPattern=@"""[^""]*password[^""]*""";
        // private readonly string quotedPasswordRegexPattern=@"""[^""]*password[^""]""";
        private readonly string endOfLineRegexPattern=@"end-of-line\d*$";
        private readonly string weakPasswordRegexPattern=@"password[a-zA-Z0-9]*";

        public bool IsValidLine(string text)
        {
            bool match=Regex.IsMatch(text,validLineRegexPattern);
            return match;
        }
        public string[] SplitLogLine(string text)
        {
            string[] matchs=Regex.Split(text,splitLineRegexPattern);           
            
            return matchs;
            
        }

        public int CountQuotedPasswords(string lines)
        {
            
            int count=Regex.Matches(lines,quotedPasswordRegexPattern,RegexOptions.IgnoreCase).Count;
            return count;
        }

        public string RemoveEndOfLineText(string line)
        {
            return Regex.Replace(line,endOfLineRegexPattern,"");
        }

        public string[] ListLinesWithPasswords(string[] lines)
        {
            int n=lines.Length;
            string[] result=new string[n];
            int i=0;
            foreach(string line in lines)
            {
               
                string l="";
                if (Regex.IsMatch(line, weakPasswordRegexPattern))
                {
                    l= Regex.Match(line,weakPasswordRegexPattern)+": "+line;
                }
                else
                {
                    l= "--------: "+line;
                    
                }
                result[i++]=l;
            }
            return result;
        }

    }
}