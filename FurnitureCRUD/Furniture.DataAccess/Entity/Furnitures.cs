namespace Furniture.DataAccess.Entity;

public class Furnitures
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Material { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string Dimensions { get; set; }
    public int YearManufactured { get; set; }
    public bool IsAvailable { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public decimal Weight { get; set; }
}
