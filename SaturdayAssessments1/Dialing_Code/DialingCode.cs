using System;
using System.Collections.Generic;

namespace DialingCodesApp
{
    public static class DialingCodes
    {
        static Dictionary<int, string> reg = new Dictionary<int, string>();

        public static Dictionary<int, string> GetEmptyDictionary()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            return dic;
        }

        public static Dictionary<int, string> GetExistingDirectory()
        {
            return reg;
        }

        public static Dictionary<int, string> AddCountryToEmptyDictonary(int CountryCode, string CountryName)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(CountryCode, CountryName);
            return dic;
        }

        public static Dictionary<int, string> AddCountryToExistingDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode,
            string countryName)
        {
            existingDictionary[countryCode] = countryName;
            return existingDictionary;
        }

        public static string GetCountryNameFromDictionary(
            Dictionary<int, string> existingDictionary,
            int CountryCode)
        {
            if (existingDictionary.ContainsKey(CountryCode))
            {
                return existingDictionary[CountryCode];
            }
            return "";
        }

        public static bool CheckCodeExists(
            Dictionary<int, string> existingDictionary,
            int countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }

        public static Dictionary<int, string> UpdateDictonary(
            Dictionary<int, string> existingDictionary,
            int countryCode,
            string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode] = countryName;
            }
            return existingDictionary;
        }

        public static Dictionary<int, string> RemoveCountryFromDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary.Remove(countryCode);
            }
            return existingDictionary;
        }

        public static string FindLongestCountryName(
            Dictionary<int, string> existingDictionary)
        {
            string res = "";
            foreach (var it in existingDictionary)
            {
                if (it.Value.Length > res.Length)
                {
                    res = it.Value;
                }
            }
            return res;
        }
    }

    
}
