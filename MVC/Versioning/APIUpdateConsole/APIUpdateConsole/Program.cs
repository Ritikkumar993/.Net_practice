using System;
using System.Text.Json;
using System.Text.Json.Serialization;
class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();
        string url = "https://localhost:7091/api/students";
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

            var students = JsonSerializer.Deserialize<List<string>>(json);



            foreach(var student in students)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine("API call failed");
        }

    }
}