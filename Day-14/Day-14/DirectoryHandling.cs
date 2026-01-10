class DirectoryHandling
{
    public static void Create()
    {
        Directory.CreateDirectory("Logs");
        if (Directory.Exists("Logs"))
        {

            Console.WriteLine("Logs Directory is created");
        }

        DirectoryInfo dir = new DirectoryInfo("Dirlog");
        if (!dir.Exists)
        {
            dir.Create();
            Console.WriteLine("Directory dirlog is created");
        }

        
    }
}