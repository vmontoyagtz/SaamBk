using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class DiscountCodeRedemptionConfiguration
        : IEntityTypeConfiguration<DiscountCodeRedemption>
    {
        public void Configure(EntityTypeBuilder<DiscountCodeRedemption> builder)
        {
            builder.ToTable("DiscountCodeRedemption", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.DiscountCodeRedemptionDate)
                .IsRequired()
                .HasColumnName("DiscountCodeRedemptionDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.DiscountCodeId)
                .IsRequired()
                .HasColumnName("DiscountCodeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.DiscountCodeRedemptions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_DiscountCodeRedemption_Customer");
            builder.HasOne(t => t.DiscountCode)
                .WithMany(t => t.DiscountCodeRedemptions)
                .HasForeignKey(d => d.DiscountCodeId)
                .HasConstraintName("FK_DiscountCodeRedemption_DiscountCode");
        }
    }
}