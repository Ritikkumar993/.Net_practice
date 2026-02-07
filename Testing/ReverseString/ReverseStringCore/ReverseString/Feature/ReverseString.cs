using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseStrings.Feature
{
    public class ReverseString
    {
        public string reverseStr(string str)
        {
            StringBuilder ss = new StringBuilder();
            for(int i=str.Length-1; i>=0; i--)
            {
                ss.Append(str[i]);
            }
            return ss.ToString();
        }
    }
}
