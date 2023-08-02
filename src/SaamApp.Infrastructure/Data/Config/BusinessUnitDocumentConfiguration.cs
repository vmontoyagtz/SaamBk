using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class BusinessUnitDocumentConfiguration
        : IEntityTypeConfiguration<BusinessUnitDocument>
    {
        public void Configure(EntityTypeBuilder<BusinessUnitDocument> builder)
        {
            builder.ToTable("BusinessUnitDocument", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.BusinessUnitId)
                .IsRequired()
                .HasColumnName("BusinessUnitId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.DocumentId)
                .IsRequired()
                .HasColumnName("DocumentId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.DocumentTypeId)
                .IsRequired()
                .HasColumnName("DocumentTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.BusinessUnit)
                .WithMany(t => t.BusinessUnitDocuments)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_BusinessUnitDocument_BusinessUnit");
            builder.HasOne(t => t.Document)
                .WithMany(t => t.BusinessUnitDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_BusinessUnitDocument_Document");
            builder.HasOne(t => t.DocumentType)
                .WithMany(t => t.BusinessUnitDocuments)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_BusinessUnitDocument_DocumentType");
        }
    }
}