using Xunit;
using Moq;
using SupplySyncBackend.Repositories;
using SupplySyncBackend.Data;
using Microsoft.EntityFrameworkCore;

public class ProductRepositoryTests
{
    private readonly Mock<ApplicationDbContext> _dbContextMock;
    private readonly ProductRepository _productRepository;

    public ProductRepositoryTests()
    {
        _dbContextMock = new Mock<ApplicationDbContext>();
        _productRepository = new ProductRepository(_dbContextMock.Object);
    }

    [Fact]
    public async Task AddProduct_AddsProduct()
    {
        var product = new Product { Name = "Test Product" };
        await _productRepository.AddProduct(product);

        _dbContextMock.Verify(db => db.Products.AddAsync(product, default), Times.Once);
    }
}
