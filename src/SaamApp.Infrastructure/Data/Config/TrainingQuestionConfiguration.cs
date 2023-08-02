using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TrainingQuestionConfiguration
        : IEntityTypeConfiguration<TrainingQuestion>
    {
        public void Configure(EntityTypeBuilder<TrainingQuestion> builder)
        {
            builder.ToTable("TrainingQuestion", "dbo");
            builder.HasKey(t => t.TrainingQuestionId);
            builder.Property(t => t.TrainingQuestionId)
                .IsRequired()
                .HasColumnName("TrainingQuestionId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.TrainingQuestionValue)
                .HasColumnName("TrainingQuestionValue")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}