using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AiErrorLogConfiguration
        : IEntityTypeConfiguration<AiErrorLog>
    {
        public void Configure(EntityTypeBuilder<AiErrorLog> builder)
        {
            builder.ToTable("AiErrorLog", "dbo");
            builder.HasKey(t => t.AiErrorLogId);
            builder.Property(t => t.AiErrorLogId)
                .IsRequired()
                .HasColumnName("AiErrorLogId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ModelId)
                .IsRequired()
                .HasColumnName("ModelId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ErrorTime)
                .IsRequired()
                .HasColumnName("ErrorTime")
                .HasColumnType("datetime");
            builder.Property(t => t.ErrorMessage)
                .HasColumnName("ErrorMessage")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}