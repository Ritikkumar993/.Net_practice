namespace LogParserProgram;
class Program
{
    public static void Main()
    {
        LogParser lp=new LogParser();
        string[] inputlog =
        [
            "[INFO] 2025-03-21T14:22:19Z service=auth userId=USR_1023 action=LOGIN_SUCCESSip=192.168.1.10",
            "[WARN] 2025-03-21T14:22:22Z service=auth userId=USR_2045 passwordTemp123LOGIN_FAILED",
            "[ERROR] 2025-03-21T14:22:30Z service=payment txnId=TXN998877 amount=₹45,000.50status=FAILED",
            "[DEBUG] <***> service=payment <===> txnId=TXN112233 amount=$1200 status=SUCCESS",
            "[INFO] user passwordReset456 completed successfully",
            "[CRITICAL] service=db query=SELECT * FROM users WHERE password='abc123'",
            "[KUBE] pod=api-gateway-7f9d8 container=nginx restartCount=3",
            
        ];
        
        //task1
        foreach(string text in inputlog)
        {
            if (lp.SevrityAndTimestamp(text))
            {

                //task2
                Console.WriteLine("True");
                lp.ServiceNameandUserID(text);

                
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        //task3 & task5
        // string line="[INFO] user passwordReset456 completed successfully";
        string line="[CRITICAL] service=\"db query=SELECT * FROM users WHERE password='bc123'\"";
        Console.Write("Password is ");
        Console.WriteLine(lp.WeakPasswordCheck(line));
        
        string task4="[DEBUG] <***> service=payment <===> txnId=TXN112233 amount=$1200 status=SUCCESS";
        lp.ExtractTransactionData(task4);


        string task5="[CRITICAL] service=\"db query=SELECT * FROM users WHERE password=bc12*\"";
        Console.WriteLine(lp.IgnoredMasked(task5));


    }
}