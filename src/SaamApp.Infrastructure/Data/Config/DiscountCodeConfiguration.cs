using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class DiscountCodeConfiguration
        : IEntityTypeConfiguration<DiscountCode>
    {
        public void Configure(EntityTypeBuilder<DiscountCode> builder)
        {
            builder.ToTable("DiscountCode", "dbo");
            builder.HasKey(t => t.DiscountCodeId);
            builder.Property(t => t.DiscountCodeId)
                .IsRequired()
                .HasColumnName("DiscountCodeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.DiscountCodeName)
                .IsRequired()
                .HasColumnName("DiscountCodeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.DiscountCodeValue)
                .IsRequired()
                .HasColumnName("DiscountCodeValue")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.DiscountCodePercentage)
                .IsRequired()
                .HasColumnName("DiscountCodePercentage")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.DiscountCodeStartDate)
                .IsRequired()
                .HasColumnName("DiscountCodeStartDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.DiscountCodeEndDate)
                .HasColumnName("DiscountCodeEndDate")
                .HasColumnType("datetime2");
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
            builder.Property(t => t.RegionId)
                .IsRequired()
                .HasColumnName("RegionId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Region)
                .WithMany(t => t.DiscountCodes)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_DiscountCode_Region");
        }
    }
}