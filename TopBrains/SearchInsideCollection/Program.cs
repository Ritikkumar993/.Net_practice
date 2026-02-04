using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{  
    // Hardcoded item details (already provided in template)
    public static SortedDictionary<string, long> itemDetails =
        new SortedDictionary<string, long>()
        {
            { "Pen", 150 },
            { "Notebook", 300 },
            { "Pencil", 100 },
            { "Eraser", 50 }
        };

    // Find item details by sold count
    public static SortedDictionary<string, long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string, long> result = new SortedDictionary<string, long>();

        //Write your Logic below
        if(itemDetails.ContainsValue(soldCount)){
            foreach(var it in itemDetails)
            {
                if (it.Value == soldCount)
                {
                    result.Add(it.Key, it.Value);
                }
            }
        }
        return result;

    }

    // Find minimum and maximum sold items
    public static List<string> FindMinandMaxSoldItems()
    {
        List<string> result = new List<string>();

        //Write your Logic below
        double mn = itemDetails.Min(r => r.Value);
        double mx = itemDetails.Max(r => r.Value);

        bool c1=true , c2 = true;
        foreach(var it in itemDetails)
        {
            if (mn == it.Value && c1)
            {
                result.Add(it.Key);
                c1=false;
            }
            if (mx == it.Value && c2)
            {
                result.Add(it.Key);
                c2=false;
            }
        }


        return result;
    }

    // Sort items by sold count
    public static Dictionary<string, long> SortByCount()
    {
        Dictionary<string, long> sortedResult =new Dictionary<string, long>();
          //Write your logic below 
        var sd = itemDetails.OrderBy(r => r.Value);
        foreach(var it in sd)
        {
            sortedResult.Add(it.Key, it.Value);
        }
        return sortedResult;
    }

    static void Main(string[] args)
    {
        // Hardcoded sold count
        long soldCount = 100;

        // Call FindItemDetails
        SortedDictionary<string, long> foundItems = FindItemDetails(soldCount);

        if (foundItems.Count == 0)
        {
            Console.WriteLine("Invalid sold count");
        }
        else
        {
            Console.WriteLine("Item Details:");
            foreach (var item in foundItems)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }

        // Find minimum and maximum sold items
        List<string> minMaxItems = FindMinandMaxSoldItems();
       //Write your code below
       Console.WriteLine($"Minimum Sold Item: {minMaxItems[0]}");
       Console.WriteLine($"Maximum Sold Item: {minMaxItems[1]}");
       

        // Sort items by sold count
        Dictionary<string, long> sortedItems = SortByCount();
        Console.WriteLine("Items Sorted by Sold Count:");
        //Write your code below
        foreach(var it in sortedItems)
        {
            Console.WriteLine($"{it.Key} : {it.Value}");
        }
        
    }
    
}



// Item Details:
// Pencil : 100
// Minimum Sold Item: Eraser
// Maximum Sold Item: Notebook
// Items Sorted by Sold Count:
// Eraser : 50
// Pencil : 100
// Pen : 150
// Notebook : 300

