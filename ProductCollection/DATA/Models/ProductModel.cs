namespace DATA.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public int OrderCount { get; set; }
}
