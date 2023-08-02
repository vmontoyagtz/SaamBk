using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TemplateTypeConfiguration
        : IEntityTypeConfiguration<TemplateType>
    {
        public void Configure(EntityTypeBuilder<TemplateType> builder)
        {
            builder.ToTable("TemplateType", "dbo");
            builder.HasKey(t => t.TemplateTypeId);
            builder.Property(t => t.TemplateTypeId)
                .IsRequired()
                .HasColumnName("TemplateTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TemplateTypeName)
                .IsRequired()
                .HasColumnName("TemplateTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TemplateTypeDescription)
                .HasColumnName("TemplateTypeDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}