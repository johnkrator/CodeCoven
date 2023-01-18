using BLL.ServiceInterfaces;
using DATA.Models;

namespace BLL.ServiceImplementation;

public class ProductService : IProduct
{
    private List<ProductModel> _productModels = new List<ProductModel>();

    public void GetProducts()
    {
        throw new NotImplementedException();
    }
}
