using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TemplateConfiguration
        : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("Template", "dbo");
            builder.HasKey(t => t.TemplateId);
            builder.Property(t => t.TemplateId)
                .IsRequired()
                .HasColumnName("TemplateId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TemplateName)
                .IsRequired()
                .HasColumnName("TemplateName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TemplateDescription)
                .HasColumnName("TemplateDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TemplateUnitPrice)
                .IsRequired()
                .HasColumnName("TemplateUnitPrice")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.TemplateIsActive)
                .IsRequired()
                .HasColumnName("TemplateIsActive")
                .HasColumnType("bit");
            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("bit");
            builder.Property(t => t.TemplateTypeId)
                .IsRequired()
                .HasColumnName("TemplateTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.TemplateType)
                .WithMany(t => t.Templates)
                .HasForeignKey(d => d.TemplateTypeId)
                .HasConstraintName("FK_Template_TemplateType");
        }
    }
}