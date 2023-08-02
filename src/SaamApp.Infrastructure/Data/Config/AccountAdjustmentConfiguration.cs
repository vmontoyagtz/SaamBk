using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AccountAdjustmentConfiguration
        : IEntityTypeConfiguration<AccountAdjustment>
    {
        public void Configure(EntityTypeBuilder<AccountAdjustment> builder)
        {
            builder.ToTable("AccountAdjustment", "dbo");
            builder.HasKey(t => t.AccountAdjustmentId);
            builder.Property(t => t.AccountAdjustmentId)
                .IsRequired()
                .HasColumnName("AccountAdjustmentId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AdjustmentReason)
                .IsRequired()
                .HasColumnName("AdjustmentReason")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.TotalChargeCredited)
                .HasColumnName("TotalChargeCredited")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TotalTaxCredited)
                .IsRequired()
                .HasColumnName("TotalTaxCredited")
                .HasColumnType("bigint");
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
            builder.Property(t => t.AccountId)
                .IsRequired()
                .HasColumnName("AccountId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.AccountAdjustmentRefId)
                .IsRequired()
                .HasColumnName("AccountAdjustmentRefId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Account)
                .WithMany(t => t.AccountAdjustments)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_AccountAdjustment_Account");
            builder.HasOne(t => t.AccountAdjustmentRef)
                .WithMany(t => t.AccountAdjustments)
                .HasForeignKey(d => d.AccountAdjustmentRefId)
                .HasConstraintName("FK_AccountAdjustment_AccountAdjustmentRef");
        }
    }
}