using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TrainingQuizHistoryConfiguration
        : IEntityTypeConfiguration<TrainingQuizHistory>
    {
        public void Configure(EntityTypeBuilder<TrainingQuizHistory> builder)
        {
            builder.ToTable("TrainingQuizHistory", "dbo");
            builder.HasKey(t => t.TrainingQuizHistoryId);
            builder.Property(t => t.TrainingQuizHistoryId)
                .IsRequired()
                .HasColumnName("TrainingQuizHistoryId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TrainingQuizHistoryAction)
                .IsRequired()
                .HasColumnName("TrainingQuizHistoryAction")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingQuizHistoryStage)
                .IsRequired()
                .HasColumnName("TrainingQuizHistoryStage")
                .HasColumnType("int");
            builder.Property(t => t.HistoryDate)
                .IsRequired()
                .HasColumnName("HistoryDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.TrainingQuizHistories)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_TrainingQuizHistory_Advisor");
        }
    }
}