namespace RSMEnterpriseIntegrationsAPI.Domain.Models
{
    public class CreateProductCategoryDto
    {        
        public int ProductCategoryId { get; set; }
        public string? Name { get; set; }       
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}