using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class ReportTypeConfiguration
        : IEntityTypeConfiguration<ReportType>
    {
        public void Configure(EntityTypeBuilder<ReportType> builder)
        {
            builder.ToTable("ReportType", "dbo");
            builder.HasKey(t => t.ReportTypeId);
            builder.Property(t => t.ReportTypeId)
                .IsRequired()
                .HasColumnName("ReportTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ReportTypeName)
                .IsRequired()
                .HasColumnName("ReportTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.ReportTypeDescription)
                .HasColumnName("ReportTypeDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}