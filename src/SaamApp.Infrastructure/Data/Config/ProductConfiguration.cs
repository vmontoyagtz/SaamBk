using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class ProductConfiguration
        : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "dbo");
            builder.HasKey(t => t.ProductId);
            builder.Property(t => t.ProductId)
                .IsRequired()
                .HasColumnName("ProductId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ProductName)
                .IsRequired()
                .HasColumnName("ProductName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.ProductDescription)
                .HasColumnName("ProductDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.ProductUnitPrice)
                .IsRequired()
                .HasColumnName("ProductUnitPrice")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.ProductIsActive)
                .IsRequired()
                .HasColumnName("ProductIsActive")
                .HasColumnType("bit");
            builder.Property(t => t.ProductMinimumCharacters)
                .IsRequired()
                .HasColumnName("ProductMinimumCharacters")
                .HasColumnType("int");
            builder.Property(t => t.ProductMinimumCallMinutes)
                .IsRequired()
                .HasColumnName("ProductMinimumCallMinutes")
                .HasColumnType("int");
            builder.Property(t => t.ProductChargeRatePerCharacter)
                .IsRequired()
                .HasColumnName("ProductChargeRatePerCharacter")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.ProductChargeRateCallPerSecond)
                .IsRequired()
                .HasColumnName("ProductChargeRateCallPerSecond")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("bit");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}