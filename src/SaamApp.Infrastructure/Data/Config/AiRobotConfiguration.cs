using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AiRobotConfiguration
        : IEntityTypeConfiguration<AiRobot>
    {
        public void Configure(EntityTypeBuilder<AiRobot> builder)
        {
            builder.ToTable("AiRobot", "dbo");
            builder.HasKey(t => t.AiRobotId);
            builder.Property(t => t.AiRobotId)
                .IsRequired()
                .HasColumnName("AiRobotId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AiRobotName)
                .IsRequired()
                .HasColumnName("AiRobotName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AiRobotDescription)
                .HasColumnName("AiRobotDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AiRobotUnitPrice)
                .IsRequired()
                .HasColumnName("AiRobotUnitPrice")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.AiRobotIsActive)
                .IsRequired()
                .HasColumnName("AiRobotIsActive")
                .HasColumnType("bit");
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