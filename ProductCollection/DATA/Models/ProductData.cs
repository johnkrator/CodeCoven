namespace DATA.Models;

public class ProductData
{
    public static void InitializedData()
    {
        List<ProductModel> products = new List<ProductModel>()
        {
            new ProductModel
            {
                Id = 1, Name = "Dell Xps", Quantity = 30, Price = 1500, Category = "PCs", OrderCount = 1000
            },
            new ProductModel
            {
                Id = 2, Name = "Ergonomic Chair", Quantity = 400, Price = 200, Category = "Chairs", OrderCount = 4000
            },
            new ProductModel
                { Id = 3, Name = "Table", Quantity = 500, Price = 250, Category = "Tables", OrderCount = 3000 }
        };
    }
}
