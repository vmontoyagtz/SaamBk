using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class FaqConfiguration
        : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.ToTable("Faq", "dbo");
            builder.HasKey(t => t.FaqId);
            builder.Property(t => t.FaqId)
                .IsRequired()
                .HasColumnName("FaqId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.FaqQuestion)
                .IsRequired()
                .HasColumnName("FaqQuestion")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.FaqAnswer)
                .IsRequired()
                .HasColumnName("FaqAnswer")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}