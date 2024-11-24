namespace SupplySyncBackend.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProducts();
        Task<ProductResponseDto?> GetProductById(int id);
        Task<ProductDto> AddProduct(ProductDto productDto);
        Task<bool> UpdateProduct(int id, ProductDto productDto);
        Task<bool> DeleteProduct(int id);
    }
}
