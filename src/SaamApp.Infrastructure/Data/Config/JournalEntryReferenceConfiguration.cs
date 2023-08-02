using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class JournalEntryReferenceConfiguration
        : IEntityTypeConfiguration<JournalEntryReference>
    {
        public void Configure(EntityTypeBuilder<JournalEntryReference> builder)
        {
            builder.ToTable("JournalEntryReference", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.JournalEntryTypeRefId)
                .IsRequired()
                .HasColumnName("JournalEntryTypeRefId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.JournalEntryTypeName)
                .IsRequired()
                .HasColumnName("JournalEntryTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.JournalEntryLineId)
                .IsRequired()
                .HasColumnName("JournalEntryLineId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.JournalEntryLine)
                .WithMany(t => t.JournalEntryReferences)
                .HasForeignKey(d => d.JournalEntryLineId)
                .HasConstraintName("FK_JournalEntryReference_JournalEntryLine");
        }
    }
}