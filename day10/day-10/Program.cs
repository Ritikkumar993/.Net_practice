// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;


// Console.WriteLine("Hello, World!");
// string sentence="abc123";
// string pattern=@"\d";

// string sentence="123_123";
// string pattern=@"\d";


// string sentence="amount_5000";
// string pattern=@"\d+";
// string pattern=@"\d*";//null

// string sentence="10 20 40";
// string pattern=@"\d+";

// string sentence="10A20B40C";
// string pattern=@"\D";

// string sentence="10A20B40C!@_abc _0!\t!";
// string pattern=@"\w";//woard character
// string pattern=@"\W";//non-woard character
// string pattern=@"\s";// whitespace
// string pattern=@"\S";// non whitespace

// string sentence="?10A20B40C!@_abc _0!\t!C:\abc\file.txt?";
// string sentence="HelloC:\abc\file.txt?Hello";
// string sentence="Hello";
// string pattern=@"\.txt";
// string pattern=@"\\";
// string pattern=@"\?";
// string pattern=@"Hello$";
// string pattern=@"lo$";
// string pattern=@"^Hello$";

//split we have to do 

// string sentence="2025-12-09, 2025-12-30, 2025";
// string pattern=@"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";


// string sentence="Amount=5000";
// string pattern=@"Amount=(?<value>\d+)";


// string sentence="apple a123e a!-@e";
// string sentence="graple apples a123e a!-@e";
// string pattern=@"a...e";
// string sentence="ritik.12217900@lpu.in";
// string pattern=@"\b[\w.-]+@[\w-]+\.\w{2,}\b";
string pattern= @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,}$";

List<string> Emails = new List<string>
{
    "john.doe@gmail.com",
    "alice_123@yahoo.in",
    "mark.smith@company.com",
    "support-abc@banking.co.in",
    "user.nametag@domain.org",
  "john.doe@gmail",          // Missing domain extension
    "alice@@yahoo.com",        // Double @
    "mark.smith@.com",         // Domain missing name
    "support@banking..com",    // Double dot in domain
    "user name@gmail.com",     // Space not allowed
    "@domain.com",             // Missing username
    "admin@domain",            // No top-level domain
    "info@domain,com",         // Comma instead of dot
    "finance#dept@corp.com",   // Invalid character #
    "plainaddress",             // Missing @ and domain
    "ritik.12217900@lpu.in"
};

foreach(string it in Emails)
{
    if (Regex.IsMatch(it, pattern))
    {
        Console.WriteLine("VAild: "+it);
    }
    else
    {
        Console.WriteLine("InVAild: "+it);
    }
}



// bool result = Regex.IsMatch(sentence,pattern);
// Match m=Regex.Match(sentence,pattern);
// Console.WriteLine(m.Value);
// Console.WriteLine(m.Groups["year"].Value);
// Console.WriteLine(m.Groups["month"].Value);
// Console.WriteLine(m.Groups["date"].Value);

// MatchCollection matches=Regex.Matches(sentence,pattern);
Console.WriteLine("Matches:");

// foreach(Match match in matches)
// {
//     Console.WriteLine(match);
//    Console.WriteLine(match.Groups["year"].Value);
//     Console.WriteLine(match.Groups["month"].Value);
//     Console.WriteLine(match.Groups["date"].Value);    
    // Console.WriteLine(match.Groups[1].Value);
    // Console.WriteLine(match.Groups[2].Value);
    // Console.WriteLine(match.Groups[3].Value);    
    
// }

// Console.WriteLine(result);

