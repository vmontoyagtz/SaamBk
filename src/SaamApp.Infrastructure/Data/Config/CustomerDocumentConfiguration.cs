using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CustomerDocumentConfiguration
        : IEntityTypeConfiguration<CustomerDocument>
    {
        public void Configure(EntityTypeBuilder<CustomerDocument> builder)
        {
            builder.ToTable("CustomerDocument", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.DocumentId)
                .IsRequired()
                .HasColumnName("DocumentId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.DocumentTypeId)
                .IsRequired()
                .HasColumnName("DocumentTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.CustomerDocuments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerDocument_Customer");
            builder.HasOne(t => t.Document)
                .WithMany(t => t.CustomerDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_CustomerDocument_Document");
            builder.HasOne(t => t.DocumentType)
                .WithMany(t => t.CustomerDocuments)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_CustomerDocument_DocumentType");
        }
    }
}