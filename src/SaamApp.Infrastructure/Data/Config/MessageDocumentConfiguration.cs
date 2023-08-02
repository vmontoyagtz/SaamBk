using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class MessageDocumentConfiguration
        : IEntityTypeConfiguration<MessageDocument>
    {
        public void Configure(EntityTypeBuilder<MessageDocument> builder)
        {
            builder.ToTable("MessageDocument", "dbo");
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
                .WithMany(t => t.MessageDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_MessageDocument_Document");
            builder.HasOne(t => t.DocumentType)
                .WithMany(t => t.MessageDocuments)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_MessageDocument_DocumentType");
            builder.HasOne(t => t.Message)
                .WithMany(t => t.MessageDocuments)
                .HasForeignKey(d => d.MessageId)
                .HasConstraintName("FK_MessageDocument_Message");
        }
    }
}