using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class PaymentFrequencyConfiguration
        : IEntityTypeConfiguration<PaymentFrequency>
    {
        public void Configure(EntityTypeBuilder<PaymentFrequency> builder)
        {
            builder.ToTable("PaymentFrequency", "dbo");
            builder.HasKey(t => t.PaymentFrequencyId);
            builder.Property(t => t.PaymentFrequencyId)
                .IsRequired()
                .HasColumnName("PaymentFrequencyId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.PaymentFrequencyName)
                .IsRequired()
                .HasColumnName("PaymentFrequencyName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.PaymentFrequencyValue)
                .IsRequired()
                .HasColumnName("PaymentFrequencyValue")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}