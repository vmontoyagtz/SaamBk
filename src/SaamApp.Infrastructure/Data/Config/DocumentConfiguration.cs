using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class DocumentConfiguration
        : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Document", "dbo");
            builder.HasKey(t => t.DocumentId);
            builder.Property(t => t.DocumentId)
                .IsRequired()
                .HasColumnName("DocumentId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.DocumentUri)
                .IsRequired()
                .HasColumnName("DocumentUri")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.DocumentToken)
                .IsRequired()
                .HasColumnName("DocumentToken")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.DocumentSecuredUrl)
                .IsRequired()
                .HasColumnName("DocumentSecuredUrl")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.DocumentTitle)
                .IsRequired()
                .HasColumnName("DocumentTitle")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.DocumentDescription)
                .IsRequired()
                .HasColumnName("DocumentDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}