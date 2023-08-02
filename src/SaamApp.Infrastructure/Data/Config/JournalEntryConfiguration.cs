using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class JournalEntryConfiguration
        : IEntityTypeConfiguration<JournalEntry>
    {
        public void Configure(EntityTypeBuilder<JournalEntry> builder)
        {
            builder.ToTable("JournalEntry", "dbo");
            builder.HasKey(t => t.JournalEntryId);
            builder.Property(t => t.JournalEntryId)
                .IsRequired()
                .HasColumnName("JournalEntryId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ReferenceId)
                .IsRequired()
                .HasColumnName("ReferenceId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ReferenceIdDescription)
                .HasColumnName("ReferenceIdDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TransactionDate)
                .IsRequired()
                .HasColumnName("TransactionDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.JournalEntryTypeId)
                .IsRequired()
                .HasColumnName("JournalEntryTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TotalTaxAmount)
                .HasColumnName("TotalTaxAmount")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.TotalAmount)
                .IsRequired()
                .HasColumnName("TotalAmount")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}