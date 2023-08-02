using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TemplateDocumentConfiguration
        : IEntityTypeConfiguration<TemplateDocument>
    {
        public void Configure(EntityTypeBuilder<TemplateDocument> builder)
        {
            builder.ToTable("TemplateDocument", "dbo");
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
            builder.Property(t => t.TemplateId)
                .IsRequired()
                .HasColumnName("TemplateId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Document)
                .WithMany(t => t.TemplateDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_TemplateDocument_Document");
            builder.HasOne(t => t.DocumentType)
                .WithMany(t => t.TemplateDocuments)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_TemplateDocument_DocumentType");
            builder.HasOne(t => t.Template)
                .WithMany(t => t.TemplateDocuments)
                .HasForeignKey(d => d.TemplateId)
                .HasConstraintName("FK_TemplateDocument_Template");
        }
    }
}