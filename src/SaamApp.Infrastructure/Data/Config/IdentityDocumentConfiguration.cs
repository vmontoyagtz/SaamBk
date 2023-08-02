using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class IdentityDocumentConfiguration
        : IEntityTypeConfiguration<IdentityDocument>
    {
        public void Configure(EntityTypeBuilder<IdentityDocument> builder)
        {
            builder.ToTable("IdentityDocument", "dbo");
            builder.HasKey(t => t.IdentityDocumentId);
            builder.Property(t => t.IdentityDocumentId)
                .IsRequired()
                .HasColumnName("IdentityDocumentId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.IdentityDocumentName)
                .IsRequired()
                .HasColumnName("IdentityDocumentName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IdentityDocumentNumber)
                .IsRequired()
                .HasColumnName("IdentityDocumentNumber")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IdentityDocumentDescription)
                .HasColumnName("IdentityDocumentDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CountryId)
                .IsRequired()
                .HasColumnName("CountryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Country)
                .WithMany(t => t.IdentityDocuments)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_IdentityDocument_Country");
        }
    }
}