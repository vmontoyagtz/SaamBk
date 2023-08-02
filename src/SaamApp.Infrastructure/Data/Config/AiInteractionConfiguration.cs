using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AiInteractionConfiguration
        : IEntityTypeConfiguration<AiInteraction>
    {
        public void Configure(EntityTypeBuilder<AiInteraction> builder)
        {
            builder.ToTable("AiInteraction", "dbo");
            builder.HasKey(t => t.AiInteractionId);
            builder.Property(t => t.AiInteractionId)
                .IsRequired()
                .HasColumnName("AiInteractionId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.Question)
                .HasColumnName("Question")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Answer)
                .HasColumnName("Answer")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.AiRobotId)
                .IsRequired()
                .HasColumnName("AiRobotId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.InteractionTime)
                .IsRequired()
                .HasColumnName("InteractionTime")
                .HasColumnType("datetime");
            builder.Property(t => t.IsSuccessful)
                .IsRequired()
                .HasColumnName("IsSuccessful")
                .HasColumnType("bit");
            builder.Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.AiRobot)
                .WithMany(t => t.AiInteractions)
                .HasForeignKey(d => d.AiRobotId)
                .HasConstraintName("FK_AiInteraction_AiRobot");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.AiInteractions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_AiInteraction_Customer");
        }
    }
}