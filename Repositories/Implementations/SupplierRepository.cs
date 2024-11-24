using SupplySyncBackend.Repositories;
using SupplySyncBackend.Models;
using SupplySyncBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace SupplySyncBackend.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int supplierId)
        {
            return await _context.Suppliers.FindAsync(supplierId);
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersByProductCategoryAsync(string category)
        {
            return await _context.Suppliers
                .Include(s => s.Products)
                .Where(s => s.Products.Any(p => p.Category == category))
                .ToListAsync();
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplierAsync(int supplierId)
        {
            var supplier = await _context.Suppliers.FindAsync(supplierId);
            if (supplier == null) throw new Exception("Supplier not found.");

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
