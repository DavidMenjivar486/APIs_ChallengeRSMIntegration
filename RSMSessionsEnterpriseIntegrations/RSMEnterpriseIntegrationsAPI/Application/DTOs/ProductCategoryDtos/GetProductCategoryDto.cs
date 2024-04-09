namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class GetProductCategoryDto
    {
        public int ProductCategoryId { get; set; }
        public string? Name { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;      
    }
}