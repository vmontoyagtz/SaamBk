using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class ComissionConfiguration
        : IEntityTypeConfiguration<Comission>
    {
        public void Configure(EntityTypeBuilder<Comission> builder)
        {
            builder.ToTable("Comission", "dbo");
            builder.HasKey(t => t.ComissionId);
            builder.Property(t => t.ComissionId)
                .IsRequired()
                .HasColumnName("ComissionId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.RegionAreaAdvisorCategoryId)
                .IsRequired()
                .HasColumnName("RegionAreaAdvisorCategoryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ComissionPercentage)
                .IsRequired()
                .HasColumnName("ComissionPercentage")
                .HasColumnType("decimal(18,2)");
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
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.IsDefault)
                .IsRequired()
                .HasColumnName("IsDefault")
                .HasColumnType("bit");
            builder.HasOne(t => t.RegionAreaAdvisorCategory)
                .WithMany(t => t.Comissions)
                .HasForeignKey(d => d.RegionAreaAdvisorCategoryId)
                .HasConstraintName("FK_Comission_RegionAreaAdvisorCategory");
        }
    }
}