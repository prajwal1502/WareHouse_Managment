
using InvManagement1.Data;
using InvManagement1.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvManagement1.Services
{
    public class ServiceSupplier : IServiceSupplier
    {
        private readonly InvManagement1Context _context;

        public ServiceSupplier(InvManagement1Context context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Supplier.ToListAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(int supplierId)
        {
            return await _context.Supplier.FindAsync(supplierId);
        }

        public async Task CreateSupplierAsync(Supplier supplier)
        {
            if (_context.Supplier == null)
            {
                throw new InvalidOperationException("Suppliers table is not available.");
            }

            _context.Supplier.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSupplierAsync(int supplierId, Supplier updatedSupplier)
        {
            var existingSupplier = await _context.Supplier.FindAsync(supplierId);
            if (existingSupplier == null)
            {
                throw new InvalidOperationException("Supplier not found.");
            }

            existingSupplier.SupplierName = updatedSupplier.SupplierName;
            existingSupplier.ContactName = updatedSupplier.ContactName;
            existingSupplier.Email = updatedSupplier.Email;
            existingSupplier.Phone = updatedSupplier.Phone;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplierAsync(int supplierId)
        {
            var supplier = await _context.Supplier.FindAsync(supplierId);
            if (supplier == null)
            {
                throw new InvalidOperationException("Supplier not found.");
            }

            _context.Supplier.Remove(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
