using System;
using System.Collections.Generic;
namespace DialingCodesApp
{
    class Program
    {
        public static void Main()
        {
            //task1
            Dictionary<int, string> emptyDict =DialingCodes.GetEmptyDictionary();
            Console.WriteLine(emptyDict.Count);

            //task2
            Dictionary<int, string> existingDict= DialingCodes.GetExistingDirectory();
            existingDict.Add(1,"United States of America");
            existingDict.Add(55,"Brazil");
            existingDict.Add(91,"India");

            // Console.WriteLine("Existing Dictionary key -> value ");
            foreach(var it in existingDict)
            {
                Console.WriteLine("Code: "+it.Key + "  Country: "+it.Value);
            }

            //task3
            Dictionary<int, string> singleEntryDict = DialingCodes.AddCountryToEmptyDictonary(81,"Japan");
            // Console.WriteLine("Single entry Contains:");
            foreach(var it in singleEntryDict)
            {
                Console.WriteLine("Code: "+it.Key + "  Country: "+it.Value);
            }

            // task4
            DialingCodes.AddCountryToExistingDictionary(existingDict,44,"United Kingdom");
            // foreach(var it in existingDict)
            // {
            //     Console.WriteLine("Code: "+it.Key + "  Country"+it.Value);
            // }

            //task5
            string country = DialingCodes.GetCountryNameFromDictionary(existingDict,91);
            Console.WriteLine(country);

            //task6
            bool exist =DialingCodes.CheckCodeExists(existingDict,55);
            Console.WriteLine(exist);

            //task7
            DialingCodes.UpdateDictonary(existingDict,55,"Fedrerative Republic of Brazil");
            // Console.WriteLine(existingDict[55]);

            //task8
            DialingCodes.RemoveCountryFromDictionary(existingDict,1);
            // Console.WriteLine(emptyDict.ContainsKey(1));

            //task9
            string longestName =DialingCodes.FindLongestCountryName(existingDict);
            Console.WriteLine(longestName);

            
        }
    }

}

