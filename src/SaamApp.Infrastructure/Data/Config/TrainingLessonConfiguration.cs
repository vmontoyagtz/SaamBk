using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TrainingLessonConfiguration
        : IEntityTypeConfiguration<TrainingLesson>
    {
        public void Configure(EntityTypeBuilder<TrainingLesson> builder)
        {
            builder.ToTable("TrainingLesson", "dbo");
            builder.HasKey(t => t.TrainingLessonId);
            builder.Property(t => t.TrainingLessonId)
                .IsRequired()
                .HasColumnName("TrainingLessonId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TrainingLessonTitle)
                .IsRequired()
                .HasColumnName("TrainingLessonTitle")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingLessonDescription)
                .IsRequired()
                .HasColumnName("TrainingLessonDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingLessonVimeoVideoId)
                .IsRequired()
                .HasColumnName("TrainingLessonVimeoVideoId")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingLessonVideoDuration)
                .IsRequired()
                .HasColumnName("TrainingLessonVideoDuration")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingLessonUserType)
                .IsRequired()
                .HasColumnName("TrainingLessonUserType")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingLessonPreviousLesson)
                .HasColumnName("TrainingLessonPreviousLesson")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}