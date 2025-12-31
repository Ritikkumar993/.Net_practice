

// // Log Parsing Utility

// INPUT–OUTPUT SAMPLES
// Log Analysis Utility Using Regex (C#)

// Task 1: Validate Log Line Format
// Method
// public bool IsValidLine(string text)

// Input Samples and Output
// Input Log Line
// Output
// [INF] Application started
// true
// [ERR] Database connection failed
// true
// [WRN] Low memory warning
// true
// INF Application started
// false
// [INFO] Application started
// false
// [ABC] Unknown message
// false


// Task 2: Split Log Line Using Delimiters
// Method
// public string[] SplitLogLine(string text)

// Input
// "[INF] User login<***>Session created<====>Access granted"

// Output
// [
//   "[INF] User login",
//   "Session created",
//   "Access granted"
// ]


// Task 3: Count Quoted Password Occurrences
// Method
// public int CountQuotedPasswords(string lines)

// Input
// User said "password123 is weak"
// Admin noted "PASSWORD456 expired"
// No issue found

// Output
// 2

// Explanation
// Only quoted text is counted
// Case-insensitive matching

// Task 4: Remove End-of-Line Markers
// Method
// public string RemoveEndOfLineText(string line)

// Input
// "Transaction completed successfully end-of-line456"

// Output
// "Transaction completed successfully "


// Task 5: Identify and Label Weak Passwords
// Method
// public string[] ListLinesWithPasswords(string[] lines)

// Input
// string[] lines =
// {
//     "User entered password123 during login",
//     "System startup completed",
//     "Admin reset passwordABC",
//     "Backup process finished"
// };

// Output
// {
//     "password123: User entered password123 during login",
//     "--------: System startup completed",
//     "passwordABC: Admin reset passwordABC",
//     "--------: Backup process finished"
// }

namespace LogProcessing;
class Program
{
    public static void Main()
    {
        LogParser lp=new LogParser();
        string[] inputlog =
        [
            // "[INF] Application started",
            // "[INF] User login<***>Session created<====>Access granted",//task (1 & 2)
            // "[ERR] Database connection failed",
            // "[WRN] Low memory warning",
            // "INF Application started",
            // "[INFO] user passwordReset456 completed successfully",
            // "[INFO] Application started",
            // "[ABC] Unknown message",
            "[DBG] <***> service=payment <====> txnId=TXN112233 amount=$1200 status=SUCCESS"            
        ];

        foreach(string text in inputlog)
        {
           Console.WriteLine(lp.IsValidLine(text));
           string[] it=lp.SplitLogLine(text);
           foreach (string item in it)
           {
                Console.WriteLine(item);
           }
        }

        //task3
        string lines = "User said \"password123 is weak\" Admin noted \"PASSWORD456 expired\"No issue found";
        Console.WriteLine(lp.CountQuotedPasswords(lines));

        string task4="Transaction completed successfully end-of-line456";
        Console.WriteLine(lp.RemoveEndOfLineText(task4));

        string[] liness =
        {
            "User entered password123 during login",
            "System startup completed",
            "Admin reset passwordABC",
            "Backup process finished"
        };
        string[] ls= lp.ListLinesWithPasswords(liness);
        foreach(string line in ls)
        {
            Console.WriteLine(line);
        }

    }
}