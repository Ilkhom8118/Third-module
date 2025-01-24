using System.Text.Json.Serialization;

namespace Lesson_3._6;

public class Car
{
    //[JsonPropertyName("id")]
    public Guid? Id { get; set; }
    //[JsonPropertyName("year")]
    public int Year { get; set; }
    //[JsonPropertyName("mileAge")]
    public int MileAge { get; set; }
    //[JsonPropertyName("brand")]
    public string Brand { get; set; }
    //[JsonPropertyName("model")]
    public string Model { get; set; }
    //[JsonPropertyName("price")]
    public double Price { get; set; }
    //[JsonPropertyName("color")]
    public string Color { get; set; }
    //[JsonPropertyName("e ngineCapasity")]
    public double EngineCapasity { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Year: {Year}, Milage: {MileAge}, Brand: {Brand}," +
            $" Model: {Model}, Price: {Price},Color: {Color}, " +
            $"EngineCapasity: {EngineCapasity}";
    }
}
