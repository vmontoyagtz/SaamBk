using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TrainingQuestionOptionConfiguration
        : IEntityTypeConfiguration<TrainingQuestionOption>
    {
        public void Configure(EntityTypeBuilder<TrainingQuestionOption> builder)
        {
            builder.ToTable("TrainingQuestionOption", "dbo");
            builder.HasKey(t => t.TrainingQuestionOptionId);
            builder.Property(t => t.TrainingQuestionOptionId)
                .IsRequired()
                .HasColumnName("TrainingQuestionOptionId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TrainingQuestionOptionValue)
                .IsRequired()
                .HasColumnName("TrainingQuestionOptionValue")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingQuestionOptionAnswer)
                .IsRequired()
                .HasColumnName("TrainingQuestionOptionAnswer")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingQuestionId)
                .IsRequired()
                .HasColumnName("TrainingQuestionId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.TrainingQuestion)
                .WithMany(t => t.TrainingQuestionOptions)
                .HasForeignKey(d => d.TrainingQuestionId)
                .HasConstraintName("FK_TrainingQuestionOption_TrainingQuestion");
        }
    }
}