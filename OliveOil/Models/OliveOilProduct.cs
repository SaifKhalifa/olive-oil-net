namespace OliveOil.Models;

public class OliveOilProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
    public decimal PricePerLiter { get; set; }
    public int QuantityInStock { get; set; }
}
