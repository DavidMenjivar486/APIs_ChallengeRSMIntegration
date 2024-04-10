namespace RSMEnterpriseIntegrationsAPI.Domain.Models
{
    public class SalesOrderHeader
    {
        public int SalesOrderHeaderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now; 
        public int CustomerID { get; set;}
        public int BillToAddressID { get; set; }
        public int ShipToAddressID { get; set; }
        public int ShipMethodID { get; set; }
        public decimal SubTotal { get; set;}
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }

    }
}