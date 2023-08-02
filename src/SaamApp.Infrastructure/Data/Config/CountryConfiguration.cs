using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CountryConfiguration
        : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country", "dbo");
            builder.HasKey(t => t.CountryId);
            builder.Property(t => t.CountryId)
                .IsRequired()
                .HasColumnName("CountryId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.CountryName)
                .IsRequired()
                .HasColumnName("CountryName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CountryCode)
                .IsRequired()
                .HasColumnName("CountryCode")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.RegionId)
                .IsRequired()
                .HasColumnName("RegionId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Region)
                .WithMany(t => t.Countries)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_Country_Region");
        }
    }
}