using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AiMemoryConfiguration
        : IEntityTypeConfiguration<AiMemory>
    {
        public void Configure(EntityTypeBuilder<AiMemory> builder)
        {
            builder.ToTable("AiMemory", "dbo");
            builder.HasKey(t => t.AiMemoryId);
            builder.Property(t => t.AiMemoryId)
                .IsRequired()
                .HasColumnName("AiMemoryId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ModelId)
                .IsRequired()
                .HasColumnName("ModelId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.Question)
                .HasColumnName("Question")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Response)
                .HasColumnName("Response")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.InteractionTime)
                .IsRequired()
                .HasColumnName("InteractionTime")
                .HasColumnType("datetime");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}