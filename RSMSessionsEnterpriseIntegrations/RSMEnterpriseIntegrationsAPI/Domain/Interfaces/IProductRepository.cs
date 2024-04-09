namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{    
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public interface IProductRepository
    {
        Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<int> CreateProduct(Product product);
        Task<int> UpdateProduct(Product productDto);
        Task<int> DeleteProduct(Product id);
    }
}