using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class RegionAreaAdvisorCategoryConfiguration
        : IEntityTypeConfiguration<RegionAreaAdvisorCategory>
    {
        public void Configure(EntityTypeBuilder<RegionAreaAdvisorCategory> builder)
        {
            builder.ToTable("RegionAreaAdvisorCategory", "dbo");
            builder.HasKey(t => t.RegionAreaAdvisorCategoryId);
            builder.Property(t => t.RegionAreaAdvisorCategoryId)
                .IsRequired()
                .HasColumnName("RegionAreaAdvisorCategoryId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AreaId)
                .IsRequired()
                .HasColumnName("AreaId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CategoryId)
                .IsRequired()
                .HasColumnName("CategoryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.RegionId)
                .IsRequired()
                .HasColumnName("RegionId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.RegionAreaAdvisorCategories)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_RegionAreaAdvisorCategory_Advisor");
            builder.HasOne(t => t.Area)
                .WithMany(t => t.RegionAreaAdvisorCategories)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_RegionAreaAdvisorCategory_Area");
            builder.HasOne(t => t.Category)
                .WithMany(t => t.RegionAreaAdvisorCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_RegionAreaAdvisorCategory_Category");
            builder.HasOne(t => t.Region)
                .WithMany(t => t.RegionAreaAdvisorCategories)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_RegionAreaAdvisorCategory_Region");
        }
    }
}