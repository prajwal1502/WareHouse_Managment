
using InvManagement1.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvManagement1.Services
{
    public interface IServiceSupplier
    {
        Task<List<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(int supplierId);
        Task CreateSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(int supplierId, Supplier updatedSupplier);
        Task DeleteSupplierAsync(int supplierId);
    }
}
