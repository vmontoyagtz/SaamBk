using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorLoginConfiguration
        : IEntityTypeConfiguration<AdvisorLogin>
    {
        public void Configure(EntityTypeBuilder<AdvisorLogin> builder)
        {
            builder.ToTable("AdvisorLogin", "dbo");
            builder.HasKey(t => t.AdvisorLoginId);
            builder.Property(t => t.AdvisorLoginId)
                .IsRequired()
                .HasColumnName("AdvisorLoginId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AdvisorLoginDateTime)
                .IsRequired()
                .HasColumnName("AdvisorLoginDateTime")
                .HasColumnType("datetime2");
            builder.Property(t => t.AdvisorLoginStage)
                .IsRequired()
                .HasColumnName("AdvisorLoginStage")
                .HasColumnType("bit");
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorLogins)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorLogin_Advisor");
        }
    }
}