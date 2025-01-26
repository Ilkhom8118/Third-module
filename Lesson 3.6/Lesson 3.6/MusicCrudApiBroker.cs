using System.Text;
using System.Text.Json;

namespace Lesson_3._6;

public class MusicCrudApiBroker
{
    private HttpClient _httpClient;
    private string _baseUrl;
    public MusicCrudApiBroker()
    {
        _baseUrl = "https://localhost:7121/api/Furniture";
        _httpClient = new HttpClient();
        var id = Guid.Parse("660b51e9-064f-4ec4-a3ff-0376919a27f5");
        Delete(id);
        GetAll();

    }
    public void GetAll()
    {
        var url = $"{_baseUrl}/getAllSofa";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        var responceContent = response.Content.ReadAsStringAsync().Result;
        response.EnsureSuccessStatusCode();

        JsonSerializerOptions option = new JsonSerializerOptions();
        option.PropertyNameCaseInsensitive = true;

        var car = JsonSerializer.Deserialize<Car[]>(responceContent, option);
        foreach (var c in car)
        {
            Console.WriteLine(c);
        }
    }
    public void Add()
    {
        var url = $"{_baseUrl}/addFurniture";
        var car = new Car()
        {
            Brand = "BMW",
            Color = "Black",
            Year = 2024,
            Model = "M5",
            Price = 20000,
            EngineCapasity = 5,
        };

        var json = JsonSerializer.Serialize(car);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = _httpClient.PostAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);
    }
    public async void Delete(Guid id)
    {
        var url = $"{_baseUrl}/deleteFurniture?id={id}";

        var response = _httpClient.DeleteAsync(url).Result;
        response.EnsureSuccessStatusCode();


        Console.WriteLine($"Car with ID {id} seccessfully deleted.");
    }
}
