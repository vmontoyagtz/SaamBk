using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AppointmentScheduleConfiguration
        : IEntityTypeConfiguration<AppointmentSchedule>
    {
        public void Configure(EntityTypeBuilder<AppointmentSchedule> builder)
        {
            builder.ToTable("AppointmentSchedule", "dbo");
            builder.HasKey(t => t.AppointmentScheduleId);
            builder.Property(t => t.AppointmentScheduleId)
                .IsRequired()
                .HasColumnName("AppointmentScheduleId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CustomerId)
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ScheduledTime)
                .IsRequired()
                .HasColumnName("ScheduledTime")
                .HasColumnType("datetime2");
            builder.Property(t => t.Duration)
                .IsRequired()
                .HasColumnName("Duration")
                .HasColumnType("int");
            builder.Property(t => t.IsCancelled)
                .HasColumnName("IsCancelled")
                .HasColumnType("bit");
            builder.Property(t => t.CancellationReason)
                .HasColumnName("CancellationReason")
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
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.AppointmentStatus)
                .IsRequired()
                .HasColumnName("AppointmentStatus")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);
            builder.Property(t => t.Notes)
                .HasColumnName("Notes")
                .HasColumnType("nvarchar(max)");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AppointmentSchedules)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AppointmentSchedule_Advisor");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.AppointmentSchedules)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_AppointmentSchedule_Customer");
        }
    }
}