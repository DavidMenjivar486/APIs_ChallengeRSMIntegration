namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public interface IProductService
    {
        Task<GetProductDto?> GetProductById(int id);
        Task<IEnumerable<GetProductDto>> GetAll();
        Task<int> CreateProduct(CreateProductDto productDto);
        Task<int> UpdateProduct(UpdateProductDto departmentDto);
        Task<int> DeleteProduct(int id);
    }
}