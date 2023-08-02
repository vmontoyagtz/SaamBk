using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class GiftCodeConfiguration
        : IEntityTypeConfiguration<GiftCode>
    {
        public void Configure(EntityTypeBuilder<GiftCode> builder)
        {
            builder.ToTable("GiftCode", "dbo");
            builder.HasKey(t => t.GiftCodeId);
            builder.Property(t => t.GiftCodeId)
                .IsRequired()
                .HasColumnName("GiftCodeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.GiftCodeName)
                .HasColumnName("GiftCodeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.GiftCodeValue)
                .IsRequired()
                .HasColumnName("GiftCodeValue")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.GiftCodeAmount)
                .IsRequired()
                .HasColumnName("GiftCodeAmount")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.GiftCodeStartDate)
                .IsRequired()
                .HasColumnName("GiftCodeStartDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.GiftCodeEndDate)
                .HasColumnName("GiftCodeEndDate")
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
                .WithMany(t => t.GiftCodes)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_GiftCode_Region");
        }
    }
}