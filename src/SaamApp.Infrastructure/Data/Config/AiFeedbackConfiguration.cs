using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AiFeedbackConfiguration
        : IEntityTypeConfiguration<AiFeedback>
    {
        public void Configure(EntityTypeBuilder<AiFeedback> builder)
        {
            builder.ToTable("AiFeedback", "dbo");
            builder.HasKey(t => t.AiFeedbackId);
            builder.Property(t => t.AiFeedbackId)
                .IsRequired()
                .HasColumnName("AiFeedbackId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ModelId)
                .IsRequired()
                .HasColumnName("ModelId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.Question)
                .HasColumnName("Question")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Response)
                .HasColumnName("Response")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.UserFeedback)
                .HasColumnName("UserFeedback")
                .HasColumnType("bit");
            builder.Property(t => t.AISessionId)
                .IsRequired()
                .HasColumnName("AISessionId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.InteractionTime)
                .IsRequired()
                .HasColumnName("InteractionTime")
                .HasColumnType("datetime");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.AiFeedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_AiFeedback_Customer");
        }
    }
}