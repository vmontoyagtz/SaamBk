using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TaxpayerTypeConfiguration
        : IEntityTypeConfiguration<TaxpayerType>
    {
        public void Configure(EntityTypeBuilder<TaxpayerType> builder)
        {
            builder.ToTable("TaxpayerType", "dbo");
            builder.HasKey(t => t.TaxpayerTypeId);
            builder.Property(t => t.TaxpayerTypeId)
                .IsRequired()
                .HasColumnName("TaxpayerTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TaxpayerTypeName)
                .IsRequired()
                .HasColumnName("TaxpayerTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}