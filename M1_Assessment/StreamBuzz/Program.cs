﻿// See https://aka.ms/new-console-template for more information


class Program{
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
        Console.WriteLine("Creator registered successfully!");
    }

    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> store = new Dictionary<string, int>();

        foreach(var obj in records)
        {
            int count = 0;
            foreach(double weeklyLikes in obj.WeeklyLikes)
            {
                if(weeklyLikes >= likeThreshold)
                {
                    count++;
                }
            }
            if(count > 0)
            {
                store.Add(obj.CreatorName, count);
            }
        }
        return store;
    }
    public double CalculateAverageLikes()
    {
        int n = EngagementBoard.Count;
        double total = 0;
        foreach (var obj in EngagementBoard)
        {
            double sum = 0;
            foreach (double weeklyLikes in obj.WeeklyLikes)
            {
                sum += weeklyLikes;
            }  
            int length = obj.WeeklyLikes.Length;
            total += sum / length;          
        }

        return total / n;
    }
    public static void Main()
    {
        Console.WriteLine("Welcome to StreamBuzz Application!");
        int choice = 0;

        while(choice != 4)
        {
            Console.WriteLine(" 1. Register Creator. \n 2. Show Top Posts. \n 3. Calculate Average Likes. \n 4. Exit.");
            Console.Write("Enter your choice: ");
            
            while(!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Warning: Invalid Input!");
            }

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter Creator Name: ");
                        string creatorName = Console.ReadLine();

                        Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                        double[] weeklyLikes = new double[4];

                        for(int i=0; i<4; i++)
                        {
                            weeklyLikes[i] = int.Parse(Console.ReadLine());
                        }

                        CreatorStats creator = new CreatorStats
                        {
                            CreatorName = creatorName,
                            WeeklyLikes = weeklyLikes
                        };

                        Program program = new Program();
                        program.RegisterCreator(creator);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter like threshold:");
                        int likeThreshold;

                        while(!int.TryParse(Console.ReadLine(), out likeThreshold) || likeThreshold < 0)
                        {
                            Console.WriteLine("Warning: Invalid Input!");
                        }

                        Program program = new Program();
                        Dictionary<string, int> dict = program.GetTopPostCounts(EngagementBoard, likeThreshold);

                        if(dict.Count == 0)
                        {
                            Console.WriteLine("No top-performing posts this week");
                        }
                        else
                        {
                            foreach (var obj in dict)
                            {
                                Console.WriteLine($"{obj.Key} - {obj.Value}");
                            }
                        }                      

                        break;
                    }
                case 3:
                    {
                        Program program = new Program();
                        double avg = program.CalculateAverageLikes();
                        Console.WriteLine("Overall average weekly likes: " + avg);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Warning: Choose From Menu Only!");
                        break;
                    }
            }
        }
    }
}