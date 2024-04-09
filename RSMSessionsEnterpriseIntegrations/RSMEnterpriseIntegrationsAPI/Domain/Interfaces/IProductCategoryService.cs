namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public interface IProductCategoryService
    {
        Task<GetProductCategoryDto?> GetProductCategoryById(int id);
        Task<IEnumerable<GetProductCategoryDto>> GetAll();
        Task<int> CreateProductCategory(CreateProductCategoryDto productCategoryDto);
        Task<int> UpdateProductCategory(UpdateProductCategoryDto productCategoryDto);
        Task<int> DeleteProductCategory(int id);
    }
}