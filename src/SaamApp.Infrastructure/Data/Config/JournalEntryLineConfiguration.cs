using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class JournalEntryLineConfiguration
        : IEntityTypeConfiguration<JournalEntryLine>
    {
        public void Configure(EntityTypeBuilder<JournalEntryLine> builder)
        {
            builder.ToTable("JournalEntryLine", "dbo");
            builder.HasKey(t => t.JournalEntryLineId);
            builder.Property(t => t.JournalEntryLineId)
                .IsRequired()
                .HasColumnName("JournalEntryLineId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TaxAmount)
                .HasColumnName("TaxAmount")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.Amount)
                .HasColumnName("Amount")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.JournalEntryTypeRefId)
                .IsRequired()
                .HasColumnName("JournalEntryTypeRefId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.JournalEntryTypeName)
                .IsRequired()
                .HasColumnName("JournalEntryTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IsDebit)
                .IsRequired()
                .HasColumnName("IsDebit")
                .HasColumnType("bit");
            builder.Property(t => t.IsCredit)
                .IsRequired()
                .HasColumnName("IsCredit")
                .HasColumnType("bit");
            builder.Property(t => t.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.Notes)
                .HasColumnName("Notes")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AccountId)
                .IsRequired()
                .HasColumnName("AccountId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.FinancialAccountingPeriodId)
                .IsRequired()
                .HasColumnName("FinancialAccountingPeriodId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.JournalEntryId)
                .IsRequired()
                .HasColumnName("JournalEntryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Account)
                .WithMany(t => t.JournalEntryLines)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_JournalEntryLine_Account");
            builder.HasOne(t => t.FinancialAccountingPeriod)
                .WithMany(t => t.JournalEntryLines)
                .HasForeignKey(d => d.FinancialAccountingPeriodId)
                .HasConstraintName("FK_JournalEntryLine_FinancialAccountingPeriod");
            builder.HasOne(t => t.JournalEntry)
                .WithMany(t => t.JournalEntryLines)
                .HasForeignKey(d => d.JournalEntryId)
                .HasConstraintName("FK_JournalEntryLine_JournalEntry");
        }
    }
}