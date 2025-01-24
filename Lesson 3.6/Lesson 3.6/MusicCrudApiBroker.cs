using System.Text;
using System.Text.Json;

namespace Lesson_3._6;

public class MusicCrudApiBroker
{
    private HttpClient _httpClient;
    private string _baseUrl;
    public MusicCrudApiBroker()
    {
        _baseUrl = "https://localhost:7199/api/Cars";
        _httpClient = new HttpClient();
        var id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        Delete(id);
        GetAll();

    }
    public void GetAll()
    {
        var url = $"{_baseUrl}/getAllCars";

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
        var url = $"{_baseUrl}/addCar";
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
        var url = $"{_baseUrl}/deleteCarDto/{id}";

        var response = _httpClient.DeleteAsync(url).Result;
        response.EnsureSuccessStatusCode();


        Console.WriteLine($"Car with ID {id} seccessfully deleted.");
    }
}
