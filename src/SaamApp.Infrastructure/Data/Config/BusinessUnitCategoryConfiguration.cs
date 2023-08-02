using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class BusinessUnitCategoryConfiguration
        : IEntityTypeConfiguration<BusinessUnitCategory>
    {
        public void Configure(EntityTypeBuilder<BusinessUnitCategory> builder)
        {
            builder.ToTable("BusinessUnitCategory", "dbo");
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
            builder.Property(t => t.BusinessUnitId)
                .IsRequired()
                .HasColumnName("BusinessUnitId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.BusinessUnit)
                .WithMany(t => t.BusinessUnitCategories)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_BusinessUnitCategory_BusinessUnit");
            builder.HasOne(t => t.RegionAreaAdvisorCategory)
                .WithMany(t => t.BusinessUnitCategories)
                .HasForeignKey(d => d.RegionAreaAdvisorCategoryId)
                .HasConstraintName("FK_BusinessUnitCategory_RegionAreaAdvisorCategory");
        }
    }
}