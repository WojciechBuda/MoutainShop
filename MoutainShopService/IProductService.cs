using MoutainShop.Domain.Models;

namespace MoutainShopService
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task DeleteProduct(int productId);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<Product> UpdateProduct(Product product);
    }
}