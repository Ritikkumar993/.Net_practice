using System;
using System.Runtime.Intrinsics.X86;

interface IParser
{
    float[] Parser(string str);
}

public interface IRounder
{
    float Round(float val);
}

class SensorDataNormalizer:IParser, IRounder
{
    public float[] Parser(string str)
    {
        string[] arr = str.Split(',');

        List<float> result = new();
        foreach(var it in arr)
        {
            string val=it.Trim();
            if(string.IsNullOrEmpty(val)||val.Equals("null",StringComparison.OrdinalIgnoreCase))
                continue;
            
            if(float.TryParse(val,out float num) && !float.IsNaN(num))
            {
                result.Add(Round(num));
            }
        }
        return result.ToArray();
    }
    
    public float Round(float val)
    {
        return (float)Math.Round(val,2);
    }
}


class Program
{
    static void Main()
    {
        string str =" 24.5678, 18.9, null, , 31.0049, error, 29, 17.999, NaN ";
        SensorDataNormalizer sdn = new();
        var result = sdn.Parser(str);
        Console.Write("{");
        foreach(var it in result)
        {
            Console.Write($" {it:F2}");
        }
        Console.WriteLine(" }");
    }
}