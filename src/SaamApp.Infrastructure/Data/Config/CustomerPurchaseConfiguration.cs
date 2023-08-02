using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CustomerPurchaseConfiguration
        : IEntityTypeConfiguration<CustomerPurchase>
    {
        public void Configure(EntityTypeBuilder<CustomerPurchase> builder)
        {
            builder.ToTable("CustomerPurchase", "dbo");
            builder.HasKey(t => t.CustomerPurchaseId);
            builder.Property(t => t.CustomerPurchaseId)
                .IsRequired()
                .HasColumnName("CustomerPurchaseId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ReferenceId)
                .IsRequired()
                .HasColumnName("ReferenceId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ReferenceIdDescription)
                .IsRequired()
                .HasColumnName("ReferenceIdDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TransactionAmount)
                .IsRequired()
                .HasColumnName("TransactionAmount")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.CustomerPurchaseTotal)
                .IsRequired()
                .HasColumnName("CustomerPurchaseTotal")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.IsPositive)
                .IsRequired()
                .HasColumnName("IsPositive")
                .HasColumnType("bit");
            builder.Property(t => t.IsNegative)
                .IsRequired()
                .HasColumnName("IsNegative")
                .HasColumnType("bit");
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
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.CustomerPurchases)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerPurchase_Customer");
        }
    }
}