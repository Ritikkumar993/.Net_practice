using System.Xml.Serialization;

class XMLSerializer
{
    public static void Create()
    {
        User user = new User{Id = 1, Name = "Alice"};
        XmlSerializer serializer = new XmlSerializer(typeof(User));
        using (FileStream fs = new FileStream("user.xml",FileMode.Create))
        {
            serializer.Serialize(fs,user);
        }
        Console.WriteLine("XML Serialized");
        Console.WriteLine(typeof(User));
    }
}