using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class PrepaidPackageRedemptionConfiguration
        : IEntityTypeConfiguration<PrepaidPackageRedemption>
    {
        public void Configure(EntityTypeBuilder<PrepaidPackageRedemption> builder)
        {
            builder.ToTable("PrepaidPackageRedemption", "dbo");
            builder.HasKey(t => t.PrepaidPackageRedemptionId);
            builder.Property(t => t.PrepaidPackageRedemptionId)
                .IsRequired()
                .HasColumnName("PrepaidPackageRedemptionId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.PrepaidPackageAmount)
                .IsRequired()
                .HasColumnName("PrepaidPackageAmount")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.PrepaidPackageRedemptionDate)
                .IsRequired()
                .HasColumnName("PrepaidPackageRedemptionDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.PrepaidPackageId)
                .IsRequired()
                .HasColumnName("PrepaidPackageId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.PrepaidPackageRedemptions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_PrepaidPackageRedemption_Customer");
            builder.HasOne(t => t.PrepaidPackage)
                .WithMany(t => t.PrepaidPackageRedemptions)
                .HasForeignKey(d => d.PrepaidPackageId)
                .HasConstraintName("FK_PrepaidPackageRedemption_PrepaidPackage");
        }
    }
}