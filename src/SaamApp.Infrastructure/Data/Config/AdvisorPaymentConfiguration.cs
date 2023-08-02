using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorPaymentConfiguration
        : IEntityTypeConfiguration<AdvisorPayment>
    {
        public void Configure(EntityTypeBuilder<AdvisorPayment> builder)
        {
            builder.ToTable("AdvisorPayment", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.AdvisorPaymentDescription)
                .IsRequired()
                .HasColumnName("AdvisorPaymentDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AdvisorPaymentsAmount)
                .IsRequired()
                .HasColumnName("AdvisorPaymentsAmount")
                .HasColumnType("decimal(18,2)");
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
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.BankAccountId)
                .IsRequired()
                .HasColumnName("BankAccountId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.PaymentMethodId)
                .IsRequired()
                .HasColumnName("PaymentMethodId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorPayments)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorPayment_Advisor");
            builder.HasOne(t => t.BankAccount)
                .WithMany(t => t.AdvisorPayments)
                .HasForeignKey(d => d.BankAccountId)
                .HasConstraintName("FK_AdvisorPayment_BankAccount");
            builder.HasOne(t => t.PaymentMethod)
                .WithMany(t => t.AdvisorPayments)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK_AdvisorPayment_PaymentMethod");
        }
    }
}