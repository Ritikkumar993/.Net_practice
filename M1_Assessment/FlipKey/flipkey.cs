using System.Text;

class FlipKey
{
    public static string Security()
    {
        Console.WriteLine("Enter the word");
        string? word=Console.ReadLine();
        if (word.Length < 6)
        {
            // Console.WriteLine("Invalid input");
            return "Invalid input";
        }

        if (word == null)
        {
            return "";
        }
        word=word.ToLower();
    
        StringBuilder ss=new StringBuilder();
        
        foreach(char ch in word)
        {
            if(ch>='a' && ch <= 'z')
            {                
                if (ch % 2 != 0)
                {
                    ss.Append(ch);
                }
            }
            else
            {
                // Console.WriteLine("Invalid input");
                return "Invalid input";
            }
        }

        StringBuilder sr = new StringBuilder();
        for(int i = ss.Length - 1; i >= 0; i--)
        {
            sr.Append(ss[i]);
        }
        for(int i = 0; i < sr.Length; i++)
        {
            if (i % 2 == 0)
            {
                sr[i]=Char.ToUpper(sr[i]);
            }
        }
        Console.Write("The generated key is - ");
        return sr.ToString();

    }

}