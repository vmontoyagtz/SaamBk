using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TemplateCategoryConfiguration
        : IEntityTypeConfiguration<TemplateCategory>
    {
        public void Configure(EntityTypeBuilder<TemplateCategory> builder)
        {
            builder.ToTable("TemplateCategory", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.RegionAreaAdvisorCategoryId)
                .IsRequired()
                .HasColumnName("RegionAreaAdvisorCategoryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ComissionId)
                .IsRequired()
                .HasColumnName("ComissionId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TemplateId)
                .IsRequired()
                .HasColumnName("TemplateId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Comission)
                .WithMany(t => t.TemplateCategories)
                .HasForeignKey(d => d.ComissionId)
                .HasConstraintName("FK_TemplateCategory_Comission");
            builder.HasOne(t => t.RegionAreaAdvisorCategory)
                .WithMany(t => t.TemplateCategories)
                .HasForeignKey(d => d.RegionAreaAdvisorCategoryId)
                .HasConstraintName("FK_TemplateCategory_RegionAreaAdvisorCategory");
            builder.HasOne(t => t.Template)
                .WithMany(t => t.TemplateCategories)
                .HasForeignKey(d => d.TemplateId)
                .HasConstraintName("FK_TemplateCategory_Template");
        }
    }
}