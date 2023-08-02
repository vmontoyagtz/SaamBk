using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AppConfigParamConfiguration
        : IEntityTypeConfiguration<AppConfigParam>
    {
        public void Configure(EntityTypeBuilder<AppConfigParam> builder)
        {
            builder.ToTable("AppConfigParam", "dbo");
            builder.HasKey(t => t.AppConfigParamId);
            builder.Property(t => t.AppConfigParamId)
                .IsRequired()
                .HasColumnName("AppConfigParamId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AppConfigParamName)
                .IsRequired()
                .HasColumnName("AppConfigParamName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AppConfigParamValue)
                .IsRequired()
                .HasColumnName("AppConfigParamValue")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AppConfigParamDescription)
                .IsRequired()
                .HasColumnName("AppConfigParamDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CustomerLowBalance)
                .IsRequired()
                .HasColumnName("CustomerLowBalance")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.AppConfigSettingsJson)
                .HasColumnName("AppConfigSettingsJson")
                .HasColumnType("nvarchar(max)");
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