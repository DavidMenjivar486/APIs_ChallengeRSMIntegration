namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }
        
        public async Task<int> CreateProduct(CreateProductDto productDto)
        {
            if (productDto is null 
                || string.IsNullOrWhiteSpace(productDto.Name) 
                || string.IsNullOrWhiteSpace(productDto.ProductNumber)
                || string.IsNullOrWhiteSpace(productDto.Color)
                || short.IsNegative(productDto.SafetyStockLevel)
                || short.IsNegative(productDto.ReorderPoint)
                || decimal.IsNegative(productDto.StandardCost)
                || decimal.IsNegative(productDto.ListPrice)
                || int.IsNegative(productDto.DaysToManufacture))
            {
                throw new BadRequestException("Department info is not valid.");
            }

            Product product = new()
            {                
                Name = productDto.Name,
                ProductNumber = productDto.ProductNumber,
                Color = productDto.Color,
                SafetyStockLevel = productDto.SafetyStockLevel,
                ReorderPoint = productDto.ReorderPoint,
                StandardCost = productDto.StandardCost,
                ListPrice = productDto.ListPrice,
                DaysToManufacture = productDto.DaysToManufacture,
            };

            return await _productRepository.CreateProduct(product);
        }
        public async Task<GetProductDto?> GetProductById(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("ProductId is not valid");
            }

            var product = await ValidateProductExistence(id);
            
            GetProductDto dto = new()
            {
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                Color = product.Color,
                StandardCost = product.StandardCost,
                ListPrice = product.ListPrice,
                DaysToManufacture = product.DaysToManufacture,
                ProductId = product.ProductId
            };
            return dto;
        }
        public async Task<IEnumerable<GetProductDto>> GetAll()
        {
            var products = await _productRepository.GetAllProducts();
            List<GetProductDto> productsDto = [];

            foreach (var product in products)
            {
                GetProductDto dto = new()
                {
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    Color = product.Color,
                    StandardCost = product.StandardCost,
                    ListPrice = product.ListPrice,
                    DaysToManufacture = product.DaysToManufacture,
                    ProductId = product.ProductId
                };

                productsDto.Add(dto);
            }
                        

            return productsDto; 
        }

        public async Task<int> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ProductId is not valid.");
            }
            var product = await ValidateProductExistence(id);
            return await _productRepository.DeleteProduct(product);
        }
        private async Task<Product> ValidateProductExistence(int id)
        {
            var existingProduct = await _productRepository.GetProductById(id) 
                ?? throw new NotFoundException($"Product with Id: {id} was not found.");

            return existingProduct;
        }

        public async Task<int> UpdateProduct(UpdateProductDto productDto)
        {
            if(productDto is null)
            {
                throw new BadRequestException("Product info is not valid.");
            }
            var product = await ValidateProductExistence(productDto.ProductId);
            
            product.Name = string.IsNullOrWhiteSpace(productDto.Name) ? product.Name : productDto.Name;
            product.ProductNumber = string.IsNullOrWhiteSpace(productDto.ProductNumber) ? product.ProductNumber : productDto.ProductNumber;
            product.Color = string.IsNullOrWhiteSpace(productDto.ProductNumber) ? product.ProductNumber : productDto.ProductNumber;
            product.SafetyStockLevel = short.IsNegative(productDto.SafetyStockLevel) ? product.SafetyStockLevel : productDto.SafetyStockLevel;
            product.ReorderPoint = short.IsNegative(productDto.ReorderPoint) ? product.ReorderPoint : productDto.ReorderPoint;
            product.StandardCost = decimal.IsNegative(productDto.StandardCost) ? product.StandardCost : productDto.StandardCost;
            product.ListPrice = decimal.IsNegative(productDto.ListPrice) ? product.ListPrice : productDto.ListPrice;
            product.DaysToManufacture = int.IsNegative(productDto.DaysToManufacture) ? product.DaysToManufacture : productDto.DaysToManufacture;
            product.ProductId = productDto.ProductId;
            return await _productRepository.UpdateProduct(product);
        }
        

    }
}