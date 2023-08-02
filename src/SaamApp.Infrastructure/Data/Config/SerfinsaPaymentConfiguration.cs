using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class SerfinsaPaymentConfiguration
        : IEntityTypeConfiguration<SerfinsaPayment>
    {
        public void Configure(EntityTypeBuilder<SerfinsaPayment> builder)
        {
            builder.ToTable("SerfinsaPayment", "dbo");
            builder.HasKey(t => t.SerfinsaPaymentId);
            builder.Property(t => t.SerfinsaPaymentId)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.SerfinsaPaymentAmount)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentAmount")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.SerfinsaPaymentTime)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentTime")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.SerfinsaPaymentDate)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentDate")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.SerfinsaPaymentReferenceNumber)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentReferenceNumber")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.SerfinsaPaymentAuditNo)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentAuditNo")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.SerfinsaPaymentTimeMessageType)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentTimeMessageType")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.SerfinsaPaymentTimeAuthorize)
                .HasColumnName("SerfinsaPaymentTimeAuthorize")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.SerfinsaPaymentTimeAnswer)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentTimeAnswer")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.SerfinsaPaymentTimeType)
                .IsRequired()
                .HasColumnName("SerfinsaPaymentTimeType")
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
            builder.Property(t => t.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("bit");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.DiscountCodeId)
                .IsRequired()
                .HasColumnName("DiscountCodeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.PrepaidPackageId)
                .IsRequired()
                .HasColumnName("PrepaidPackageId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.SerfinsaPayments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_SerfinsaPayment_Customer");
            builder.HasOne(t => t.DiscountCode)
                .WithMany(t => t.SerfinsaPayments)
                .HasForeignKey(d => d.DiscountCodeId)
                .HasConstraintName("FK_SerfinsaPayment_DiscountCode");
            builder.HasOne(t => t.PrepaidPackage)
                .WithMany(t => t.SerfinsaPayments)
                .HasForeignKey(d => d.PrepaidPackageId)
                .HasConstraintName("FK_SerfinsaPayment_PrepaidPackage");
        }
    }
}