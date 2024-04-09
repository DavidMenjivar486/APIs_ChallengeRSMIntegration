namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AdvWorksDbContext _context;
        public ProductCategoryRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProductCategory(ProductCategory productCategory)
        {
            await _context.AddAsync(productCategory);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProductCategory(ProductCategory productCategory)
        {
            _context.Remove(productCategory);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategories()
        {
            return await _context.Set<ProductCategory>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductCategory?> GetProductCategoryById(int id)
        {
            return await _context.ProductCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(d=>d.ProductCategoryId == id);
        }

        public async Task<int> UpdateProductCategory(ProductCategory productCategory)
        {
            _context.Update(productCategory);

            return await _context.SaveChangesAsync();
        }
    }
}