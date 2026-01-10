using System.Text.Json;

// class User
// {
//     public int Id{get;set;}
//     public string Name{get;set;}
// }

class Serializatobject{
    public static void Create()
    {
        User user = new User{Id =1, Name ="Alice"};

        string json = JsonSerializer.Serialize(user);
        File.WriteAllText("user.json",json);
        Console.WriteLine("User object to Serialized to json");
    }
}