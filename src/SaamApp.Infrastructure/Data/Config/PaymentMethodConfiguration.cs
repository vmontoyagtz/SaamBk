using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class PaymentMethodConfiguration
        : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethod", "dbo");
            builder.HasKey(t => t.PaymentMethodId);
            builder.Property(t => t.PaymentMethodId)
                .IsRequired()
                .HasColumnName("PaymentMethodId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.PaymentFrequencyCode)
                .IsRequired()
                .HasColumnName("PaymentFrequencyCode")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.PaymentMethodName)
                .IsRequired()
                .HasColumnName("PaymentMethodName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.PaymentMethodDescription)
                .IsRequired()
                .HasColumnName("PaymentMethodDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}