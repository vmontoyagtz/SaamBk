using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class PrepaidPackageConfiguration
        : IEntityTypeConfiguration<PrepaidPackage>
    {
        public void Configure(EntityTypeBuilder<PrepaidPackage> builder)
        {
            builder.ToTable("PrepaidPackage", "dbo");
            builder.HasKey(t => t.PrepaidPackageId);
            builder.Property(t => t.PrepaidPackageId)
                .IsRequired()
                .HasColumnName("PrepaidPackageId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.PrepaidPackageName)
                .IsRequired()
                .HasColumnName("PrepaidPackageName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.PrepaidPackagePrice)
                .IsRequired()
                .HasColumnName("PrepaidPackagePrice")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.PrepaidPackageIsActive)
                .HasColumnName("PrepaidPackageIsActive")
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
            builder.Property(t => t.RegionId)
                .IsRequired()
                .HasColumnName("RegionId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Region)
                .WithMany(t => t.PrepaidPackages)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_PrepaidPackage_Region");
        }
    }
}