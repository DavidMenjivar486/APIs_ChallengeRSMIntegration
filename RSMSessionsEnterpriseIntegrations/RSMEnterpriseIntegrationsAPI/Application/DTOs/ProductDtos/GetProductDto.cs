namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class GetProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? ProductNumber { get; set;}
        public string? Color { get; set; }                
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int DaysToManufacture { get; set; }        
    }
}