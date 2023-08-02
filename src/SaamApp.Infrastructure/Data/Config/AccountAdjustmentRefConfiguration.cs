using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AccountAdjustmentRefConfiguration
        : IEntityTypeConfiguration<AccountAdjustmentRef>
    {
        public void Configure(EntityTypeBuilder<AccountAdjustmentRef> builder)
        {
            builder.ToTable("AccountAdjustmentRef", "dbo");
            builder.HasKey(t => t.AccountAdjustmentRefId);
            builder.Property(t => t.AccountAdjustmentRefId)
                .IsRequired()
                .HasColumnName("AccountAdjustmentRefId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AccountAdjustmentRefName)
                .IsRequired()
                .HasColumnName("AccountAdjustmentRefName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AccountAdjustmentRefDescription)
                .IsRequired()
                .HasColumnName("AccountAdjustmentRefDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}