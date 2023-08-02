using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class FinancialAccountingPeriodConfiguration
        : IEntityTypeConfiguration<FinancialAccountingPeriod>
    {
        public void Configure(EntityTypeBuilder<FinancialAccountingPeriod> builder)
        {
            builder.ToTable("FinancialAccountingPeriod", "dbo");
            builder.HasKey(t => t.FinancialAccountingPeriodId);
            builder.Property(t => t.FinancialAccountingPeriodId)
                .IsRequired()
                .HasColumnName("FinancialAccountingPeriodId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AccountingPeriod)
                .IsRequired()
                .HasColumnName("AccountingPeriod")
                .HasColumnType("int");
            builder.Property(t => t.PeriodStartDate)
                .IsRequired()
                .HasColumnName("PeriodStartDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.PeriodEndDate)
                .IsRequired()
                .HasColumnName("PeriodEndDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.ZippedStatementsUrl)
                .HasColumnName("ZippedStatementsUrl")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.ZippedStatementsSharedAccessSignatureUrl)
                .HasColumnName("ZippedStatementsSharedAccessSignatureUrl")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IsStatementsJobRunning)
                .HasColumnName("IsStatementsJobRunning")
                .HasColumnType("bit");
            builder.Property(t => t.SettingsJson)
                .HasColumnName("SettingsJson")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}