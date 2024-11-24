namespace SupplySyncBackend.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierResponseDto>> GetAllSuppliers();
        Task<SupplierResponseDto?> GetSupplierById(int id);
        Task<SupplierDto> AddSupplier(SupplierDto supplierDto);
        Task<bool> UpdateSupplier(int id, SupplierDto supplierDto);
        Task<bool> DeleteSupplier(int id);
    }
}
