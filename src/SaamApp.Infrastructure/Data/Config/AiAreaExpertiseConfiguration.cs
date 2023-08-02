using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AiAreaExpertiseConfiguration
        : IEntityTypeConfiguration<AiAreaExpertise>
    {
        public void Configure(EntityTypeBuilder<AiAreaExpertise> builder)
        {
            builder.ToTable("AiAreaExpertise", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.ModelId)
                .IsRequired()
                .HasColumnName("ModelId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.RegionAreaAdvisorCategoryId)
                .IsRequired()
                .HasColumnName("RegionAreaAdvisorCategoryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.RegionAreaAdvisorCategory)
                .WithMany(t => t.AiAreaExpertises)
                .HasForeignKey(d => d.RegionAreaAdvisorCategoryId)
                .HasConstraintName("FK_AiAreaExpertise_RegionAreaAdvisorCategory");
        }
    }
}