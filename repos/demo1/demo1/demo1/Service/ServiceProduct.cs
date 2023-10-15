using InvManagement1.Data;
using InvManagement1.models;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvManagement1.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly InvManagement1Context _context;

        public ServiceProduct(InvManagement1Context context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Product.FindAsync(productId);
        }

        public async Task CreateProductAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int productId, Product updatedProduct)
        {
            var existingProduct = await _context.Product.FindAsync(productId);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Quantity = updatedProduct.Quantity;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            var productToDelete = await _context.Product.FindAsync(productId);
            if (productToDelete != null)
            {
                _context.Product.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
