using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CustomerPaymentConfiguration
        : IEntityTypeConfiguration<CustomerPayment>
    {
        public void Configure(EntityTypeBuilder<CustomerPayment> builder)
        {
            builder.ToTable("CustomerPayment", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.PaymentMethodId)
                .IsRequired()
                .HasColumnName("PaymentMethodId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.SerfinsaPaymentId)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.PaymentMethod)
                .WithMany(t => t.CustomerPayments)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK_CustomerPayment_PaymentMethod");
            builder.HasOne(t => t.SerfinsaPayment)
                .WithMany(t => t.CustomerPayments)
                .HasForeignKey(d => d.SerfinsaPaymentId)
                .HasConstraintName("FK_CustomerPayment_SerfinsaPayment");
        }
    }
}