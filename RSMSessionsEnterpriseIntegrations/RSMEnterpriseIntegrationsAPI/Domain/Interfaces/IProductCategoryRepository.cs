namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{    
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public interface IProductCategoryRepository
    {
        Task<ProductCategory?> GetProductCategoryById(int id);
        Task<IEnumerable<ProductCategory>> GetAllProductCategories();
        Task<int> CreateProductCategory(ProductCategory productCategory);
        Task<int> UpdateProductCategory(ProductCategory productCategoryDto);
        Task<int> DeleteProductCategory(ProductCategory id);
    }
}