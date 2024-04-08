namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(nameof(Department), "HumanResources");

            builder.HasKey(e => e.DepartmentId);
            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.GroupName).IsRequired();
        }
    }
}
