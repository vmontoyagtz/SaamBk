using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorIdentityDocumentConfiguration
        : IEntityTypeConfiguration<AdvisorIdentityDocument>
    {
        public void Configure(EntityTypeBuilder<AdvisorIdentityDocument> builder)
        {
            builder.ToTable("AdvisorIdentityDocument", "dbo");
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
            builder.Property(t => t.IdentityDocumentId)
                .IsRequired()
                .HasColumnName("IdentityDocumentId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorIdentityDocuments)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorIdentityDocument_Advisor");
            builder.HasOne(t => t.Document)
                .WithMany(t => t.AdvisorIdentityDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_AdvisorIdentityDocument_Document");
            builder.HasOne(t => t.DocumentType)
                .WithMany(t => t.AdvisorIdentityDocuments)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_AdvisorIdentityDocument_DocumentType");
            builder.HasOne(t => t.IdentityDocument)
                .WithMany(t => t.AdvisorIdentityDocuments)
                .HasForeignKey(d => d.IdentityDocumentId)
                .HasConstraintName("FK_AdvisorIdentityDocument_IdentityDocument");
        }
    }
}