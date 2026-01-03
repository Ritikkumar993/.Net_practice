using System.Text;
class Program
{
    public static void Main()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello Hello");
        sb.Append(" ");
        sb.Append("World");
        sb.AppendLine();
        sb.AppendLine("Line");
        sb.Insert(0,"start");
        sb.Remove(0,5);
        sb.Replace("Hello","new");
        Console.WriteLine(sb.ToString());
        sb.Clear();
        Console.WriteLine(sb.ToString());
        Console.WriteLine("Total memory before loop is "+GC.GetTotalMemory(false));

        for(int i = 0; i < 10000; i++)
        {
            sb.Append(i);
        }
        string result = sb.ToString();
        Console.WriteLine("Total memory after loop is "+GC.GetTotalMemory(false));

        StringBuilder sb1 = new StringBuilder("Hello");
        StringBuilder sb2 = new StringBuilder("Hello");

        Console.WriteLine(sb1.Equals(sb2));
        StringBuilder sb3=sb2;
        Console.WriteLine(sb3.Equals(sb2));
        Console.WriteLine(object.ReferenceEquals(sb2,sb1));
        
        Console.WriteLine(sb1==sb2);

        String str1="Hello";
        String str2="Hello";

        Console.WriteLine("str1 == str2:"+str1 == str2);
        Console.WriteLine("str1.Equals(str2) :"+str1.Equals(str2));
        Console.WriteLine("object ReferenceEquals "+object.ReferenceEquals(str1,str2));



    }
}