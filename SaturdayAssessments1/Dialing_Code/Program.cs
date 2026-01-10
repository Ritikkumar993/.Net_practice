
using DialingCodesApp;
class Program
    {
        public static void Main()
        {
            Dictionary<int, string> emptyDict = DialingCodes.GetEmptyDictionary();
            Console.WriteLine(emptyDict.Count);

            Dictionary<int, string> existingDict = DialingCodes.GetExistingDirectory();
            existingDict.Add(1, "United States of America");
            existingDict.Add(55, "Brazil");
            existingDict.Add(91, "India");

            foreach (var it in existingDict)
            {
                Console.WriteLine(it.Key + " -> " + it.Value);
            }

            Dictionary<int, string> singleEntryDict =
                DialingCodes.AddCountryToEmptyDictonary(81, "Japan");

            foreach (var it in singleEntryDict)
            {
                Console.WriteLine(it.Key + " -> " + it.Value);
            }

            DialingCodes.AddCountryToExistingDictionary(
                existingDict, 44, "United Kingdom");

            string country =
                DialingCodes.GetCountryNameFromDictionary(existingDict, 91);
            Console.WriteLine(country);

            bool exists =
                DialingCodes.CheckCodeExists(existingDict, 55);
            Console.WriteLine(exists);

            DialingCodes.UpdateDictonary(
                existingDict, 55, "Federative Republic of Brazil");

            DialingCodes.RemoveCountryFromDictionary(existingDict, 1);

            string longestName =
                DialingCodes.FindLongestCountryName(existingDict);
            Console.WriteLine(longestName);
        }
    }