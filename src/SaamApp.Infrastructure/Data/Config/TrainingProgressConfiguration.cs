using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TrainingProgressConfiguration
        : IEntityTypeConfiguration<TrainingProgress>
    {
        public void Configure(EntityTypeBuilder<TrainingProgress> builder)
        {
            builder.ToTable("TrainingProgress", "dbo");
            builder.HasKey(t => t.TrainingProgressId);
            builder.Property(t => t.TrainingProgressId)
                .IsRequired()
                .HasColumnName("TrainingProgressId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TrainingProgressPercentage)
                .IsRequired()
                .HasColumnName("TrainingProgressPercentage")
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
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TrainingLessonId)
                .IsRequired()
                .HasColumnName("TrainingLessonId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.TrainingProgresses)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_TrainingProgress_Advisor");
            builder.HasOne(t => t.TrainingLesson)
                .WithMany(t => t.TrainingProgresses)
                .HasForeignKey(d => d.TrainingLessonId)
                .HasConstraintName("FK_TrainingProgress_TrainingLesson");
        }
    }
}