using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AuditLogConfiguration
        : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable("AuditLog", "dbo");
            builder.HasKey(t => t.AuditLogId);
            builder.Property(t => t.AuditLogId)
                .IsRequired()
                .HasColumnName("AuditLogId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.EventDateUTC)
                .IsRequired()
                .HasColumnName("EventDateUTC")
                .HasColumnType("datetime2");
            builder.Property(t => t.ApplicationUserId)
                .IsRequired()
                .HasColumnName("ApplicationUserId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.UserName)
                .HasColumnName("UserName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.UserRoles)
                .HasColumnName("UserRoles")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.EventType)
                .IsRequired()
                .HasColumnName("EventType")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TableName)
                .HasColumnName("TableName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.RecordId)
                .IsRequired()
                .HasColumnName("RecordId")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.OperationType)
                .HasColumnName("OperationType")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.OldValues)
                .HasColumnName("OldValues")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.NewValues)
                .HasColumnName("NewValues")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.ChangesMade)
                .HasColumnName("ChangesMade")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.ChangeReason)
                .HasColumnName("ChangeReason")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.OperationResult)
                .HasColumnName("OperationResult")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AffectedFields)
                .HasColumnName("AffectedFields")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IpAddress)
                .HasColumnName("IpAddress")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.UserAgent)
                .HasColumnName("UserAgent")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AdditionalInfo)
                .HasColumnName("AdditionalInfo")
                .HasColumnType("nvarchar(max)");
        }
    }
}