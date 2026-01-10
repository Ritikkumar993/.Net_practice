using System.Text.Json;

class DeSerializejson
{
    public static void Create()
    {
        string json = File.ReadAllText("user.json");
        User user = JsonSerializer.Deserialize<User>(json);
        Console.WriteLine($"User Loaded: {user.Id}, {user.Name}");
    }
}