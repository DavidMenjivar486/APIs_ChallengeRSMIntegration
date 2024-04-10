namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder.ToTable(nameof(SalesOrderHeader), "Sales");

            builder.HasKey(e => e.SalesOrderHeaderId);
            builder.Property(e => e.SalesOrderHeaderId).HasColumnName("SalesOrderID");
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();
            builder.Property(e => e.CustomerID).IsRequired();
            builder.Property(e => e.BillToAddressID).IsRequired();
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.CustomerID).IsRequired();
            builder.Property(e => e.BillToAddressID).IsRequired();
            builder.Property(e => e.ShipMethodID).IsRequired();
            builder.Property(e => e.SubTotal).IsRequired().HasPrecision(6,2);
            builder.Property(e => e.TaxAmt).IsRequired().HasPrecision(6,2);
            builder.Property(e => e.Freight).IsRequired().HasPrecision(6,2);                           
        }
    }
}