using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class GiftCodeRedemptionConfiguration
        : IEntityTypeConfiguration<GiftCodeRedemption>
    {
        public void Configure(EntityTypeBuilder<GiftCodeRedemption> builder)
        {
            builder.ToTable("GiftCodeRedemption", "dbo");
            builder.HasKey(t => t.GiftCodeRedemptionId);
            builder.Property(t => t.GiftCodeRedemptionId)
                .IsRequired()
                .HasColumnName("GiftCodeRedemptionId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.GiftCodeRedemptionDate)
                .IsRequired()
                .HasColumnName("GiftCodeRedemptionDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.GiftCodeId)
                .IsRequired()
                .HasColumnName("GiftCodeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.GiftCodeRedemptions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_GiftCodeRedemption_Customer");
            builder.HasOne(t => t.GiftCode)
                .WithMany(t => t.GiftCodeRedemptions)
                .HasForeignKey(d => d.GiftCodeId)
                .HasConstraintName("FK_GiftCodeRedemption_GiftCode");
        }
    }
}