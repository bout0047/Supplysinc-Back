using SupplySyncBackend.Models;

namespace SupplySyncBackend.Repositories
{
    public interface ISupplierRepository
    {
        Task<Supplier?> GetSupplierByIdAsync(int supplierId);
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<IEnumerable<Supplier>> GetSuppliersByProductCategoryAsync(string category);
        Task AddSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(Supplier supplier);
        Task DeleteSupplierAsync(int supplierId);
    }
}
