using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class ReportConfiguration
        : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Report", "dbo");
            builder.HasKey(t => t.ReportId);
            builder.Property(t => t.ReportId)
                .IsRequired()
                .HasColumnName("ReportId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ReportName)
                .IsRequired()
                .HasColumnName("ReportName")
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);
            builder.Property(t => t.ReportTypeId)
                .IsRequired()
                .HasColumnName("ReportTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.Module)
                .IsRequired()
                .HasColumnName("Module")
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);
            builder.Property(t => t.IsListReport)
                .HasColumnName("IsListReport")
                .HasColumnType("bit");
            builder.Property(t => t.IsFormReport)
                .HasColumnName("IsFormReport")
                .HasColumnType("bit");
            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);
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
            builder.Property(t => t.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit");
            builder.Property(t => t.ReportJson)
                .HasColumnName("ReportJson")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.FrontEndMethodToCall)
                .HasColumnName("FrontEndMethodToCall")
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);
            builder.Property(t => t.ApiMethodToCall)
                .HasColumnName("ApiMethodToCall")
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);
            builder.Property(t => t.ParametersJson)
                .HasColumnName("ParametersJson")
                .HasColumnType("nvarchar(max)");
            builder.HasOne(t => t.ReportType)
                .WithMany(t => t.Reports)
                .HasForeignKey(d => d.ReportTypeId)
                .HasConstraintName("FK_Report_ReportType");
        }
    }
}