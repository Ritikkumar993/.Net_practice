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
        
        foreach(string text in inputlog)
        {
            
        }
    }
}