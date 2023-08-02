using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AiSessionConfiguration
        : IEntityTypeConfiguration<AiSession>
    {
        public void Configure(EntityTypeBuilder<AiSession> builder)
        {
            builder.ToTable("AiSession", "dbo");
            builder.HasKey(t => t.AiSessionId);
            builder.Property(t => t.AiSessionId)
                .IsRequired()
                .HasColumnName("AiSessionId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.StartTime)
                .IsRequired()
                .HasColumnName("StartTime")
                .HasColumnType("datetime");
            builder.Property(t => t.EndTime)
                .HasColumnName("EndTime")
                .HasColumnType("datetime");
            builder.Property(t => t.NumberOfInteractions)
                .IsRequired()
                .HasColumnName("NumberOfInteractions")
                .HasColumnType("int");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.AiSessions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_AiSession_Customer");
        }
    }
}