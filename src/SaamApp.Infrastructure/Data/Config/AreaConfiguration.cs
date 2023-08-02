using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AreaConfiguration
        : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Area", "dbo");
            builder.HasKey(t => t.AreaId);
            builder.Property(t => t.AreaId)
                .IsRequired()
                .HasColumnName("AreaId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AreaName)
                .IsRequired()
                .HasColumnName("AreaName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AreaDescription)
                .IsRequired()
                .HasColumnName("AreaDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AreaColor)
                .IsRequired()
                .HasColumnName("AreaColor")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AreaImage)
                .IsRequired()
                .HasColumnName("AreaImage")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AreaStage)
                .IsRequired()
                .HasColumnName("AreaStage")
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
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}