namespace CarCRUDService.DTOs;

public class CarDto
{
    public Guid? Id { get; set; }
    public int Year { get; set; }
    public int MileAge { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }
    public string Color { get; set; }
    public double EngineCapasity { get; set; }
}
