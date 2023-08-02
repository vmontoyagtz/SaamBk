using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class InvoiceConfiguration
        : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice", "dbo");
            builder.HasKey(t => t.InvoiceId);
            builder.Property(t => t.InvoiceId)
                .IsRequired()
                .HasColumnName("InvoiceId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.InvoiceNumber)
                .IsRequired()
                .HasColumnName("InvoiceNumber")
                .HasColumnType("int");
            builder.Property(t => t.AccountName)
                .IsRequired()
                .HasColumnName("AccountName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CustomerName)
                .IsRequired()
                .HasColumnName("CustomerName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.PaymentState)
                .IsRequired()
                .HasColumnName("PaymentState")
                .HasColumnType("int");
            builder.Property(t => t.InternalComments)
                .HasColumnName("InternalComments")
                .HasColumnType("nvarchar(max)");
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
            builder.Property(t => t.InvoicedDate)
                .HasColumnName("InvoicedDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.InvoicingNote)
                .IsRequired()
                .HasColumnName("InvoicingNote")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TotalSale)
                .HasColumnName("TotalSale")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.TotalSaleTax)
                .HasColumnName("TotalSaleTax")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.AccountId)
                .IsRequired()
                .HasColumnName("AccountId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.FinancialAccountingPeriodId)
                .IsRequired()
                .HasColumnName("FinancialAccountingPeriodId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Account)
                .WithMany(t => t.Invoices)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Invoice_Account");
            builder.HasOne(t => t.FinancialAccountingPeriod)
                .WithMany(t => t.Invoices)
                .HasForeignKey(d => d.FinancialAccountingPeriodId)
                .HasConstraintName("FK_Invoice_FinancialAccountingPeriod");
        }
    }
}