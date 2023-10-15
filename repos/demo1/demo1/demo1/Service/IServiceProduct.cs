
using InvManagement1.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvManagement1.Services
{
    public interface IServiceProduct
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(int productId, Product updatedProduct);
        Task DeleteProductAsync(int productId);
    }
}
