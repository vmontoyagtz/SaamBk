using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorDocumentConfiguration
        : IEntityTypeConfiguration<AdvisorDocument>
    {
        public void Configure(EntityTypeBuilder<AdvisorDocument> builder)
        {
            builder.ToTable("AdvisorDocument", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.DocumentId)
                .IsRequired()
                .HasColumnName("DocumentId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.DocumentTypeId)
                .IsRequired()
                .HasColumnName("DocumentTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorDocuments)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorDocument_Advisor");
            builder.HasOne(t => t.Document)
                .WithMany(t => t.AdvisorDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_AdvisorDocument_Document");
            builder.HasOne(t => t.DocumentType)
                .WithMany(t => t.AdvisorDocuments)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_AdvisorDocument_DocumentType");
        }
    }
}