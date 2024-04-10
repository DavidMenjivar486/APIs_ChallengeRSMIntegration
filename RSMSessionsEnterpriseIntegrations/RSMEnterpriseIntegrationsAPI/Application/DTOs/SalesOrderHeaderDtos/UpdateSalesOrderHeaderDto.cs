namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class UpdateSalesOrderHeaderDto
    {        
        public int SalesOrderHeaderId { get; set; } 
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now;          
        public decimal SubTotal { get; set;}
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
    }
}