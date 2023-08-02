using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AiModelConfiguration
        : IEntityTypeConfiguration<AiModel>
    {
        public void Configure(EntityTypeBuilder<AiModel> builder)
        {
            builder.ToTable("AiModel", "dbo");
            builder.HasKey(t => t.AiModelId);
            builder.Property(t => t.AiModelId)
                .IsRequired()
                .HasColumnName("AiModelId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ModelName)
                .IsRequired()
                .HasColumnName("ModelName")
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);
            builder.Property(t => t.ModelDescription)
                .HasColumnName("ModelDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingData)
                .HasColumnName("TrainingData")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TrainingDate)
                .IsRequired()
                .HasColumnName("TrainingDate")
                .HasColumnType("datetime");
            builder.Property(t => t.Accuracy)
                .IsRequired()
                .HasColumnName("Accuracy")
                .HasColumnType("decimal(5,2)");
            builder.Property(t => t.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("bit");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}