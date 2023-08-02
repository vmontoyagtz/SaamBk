using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class VoiceNoteDocumentConfiguration
        : IEntityTypeConfiguration<VoiceNoteDocument>
    {
        public void Configure(EntityTypeBuilder<VoiceNoteDocument> builder)
        {
            builder.ToTable("VoiceNoteDocument", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.DocumentId)
                .IsRequired()
                .HasColumnName("DocumentId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.DocumentTypeId)
                .IsRequired()
                .HasColumnName("DocumentTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.MessageId)
                .IsRequired()
                .HasColumnName("MessageId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Document)
                .WithMany(t => t.VoiceNoteDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_VoiceNoteDocument_Document");
            builder.HasOne(t => t.DocumentType)
                .WithMany(t => t.VoiceNoteDocuments)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_VoiceNoteDocument_DocumentType");
            builder.HasOne(t => t.Message)
                .WithMany(t => t.VoiceNoteDocuments)
                .HasForeignKey(d => d.MessageId)
                .HasConstraintName("FK_VoiceNoteDocument_Message");
        }
    }
}