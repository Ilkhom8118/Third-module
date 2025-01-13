namespace CarService.Sevice.DTOs;

public class CarBaseDto
{
    public Guid? Id { get; set; }
    public string Model { get; set; }
    public string Brend { get; set; }
    public double MaximumSpeed { get; set; }
    public string Color { get; set; }
    public int YearManufactured { get; set; }
    public string FuelType { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}
