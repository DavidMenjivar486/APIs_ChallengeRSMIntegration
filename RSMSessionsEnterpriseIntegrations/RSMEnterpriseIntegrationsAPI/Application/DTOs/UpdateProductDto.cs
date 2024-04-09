namespace RSMEnterpriseIntegrationsAPI.Domain.Models
{
    public class UpdateProductDto
    { 
        public int ProductId { get; set; }       
        public string? Name { get; set; }
        public string? ProductNumber { get; set;}
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int DaysToManufacture { get; set; }
        public DateTime SellStartDate { get; set; } = DateTime.Now;

    }
}