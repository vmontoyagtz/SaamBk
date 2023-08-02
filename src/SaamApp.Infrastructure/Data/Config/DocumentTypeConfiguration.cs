using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class DocumentTypeConfiguration
        : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentType", "dbo");
            builder.HasKey(t => t.DocumentTypeId);
            builder.Property(t => t.DocumentTypeId)
                .IsRequired()
                .HasColumnName("DocumentTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.DocumentTypeName)
                .IsRequired()
                .HasColumnName("DocumentTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.DocumentTypeDescription)
                .HasColumnName("DocumentTypeDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}