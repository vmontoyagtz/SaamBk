using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class NotificationConfiguration
        : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notification", "dbo");
            builder.HasKey(t => t.NotificationId);
            builder.Property(t => t.NotificationId)
                .IsRequired()
                .HasColumnName("NotificationId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ApplicationUserId)
                .IsRequired()
                .HasColumnName("ApplicationUserId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.NotificationText)
                .IsRequired()
                .HasColumnName("NotificationText")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IsRead)
                .IsRequired()
                .HasColumnName("IsRead")
                .HasColumnType("bit");
            builder.Property(t => t.NotificationTime)
                .IsRequired()
                .HasColumnName("NotificationTime")
                .HasColumnType("datetime2");
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