using CarDataAccess.Entity;

namespace CarCRUDService.Extension;

public static class ExtensionMetod
{
    public static void TotalSumma(this List<Car> obj)
    {
        var total = 0d;
        foreach (var sum in obj)
        {
            total += sum.Price;
        }
    }
}
