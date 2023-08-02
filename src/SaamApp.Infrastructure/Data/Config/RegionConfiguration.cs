using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class RegionConfiguration
        : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region", "dbo");
            builder.HasKey(t => t.RegionId);
            builder.Property(t => t.RegionId)
                .IsRequired()
                .HasColumnName("RegionId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.RegionName)
                .IsRequired()
                .HasColumnName("RegionName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.RegionCode)
                .IsRequired()
                .HasColumnName("RegionCode")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}