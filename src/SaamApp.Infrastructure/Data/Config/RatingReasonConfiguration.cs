using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class RatingReasonConfiguration
        : IEntityTypeConfiguration<RatingReason>
    {
        public void Configure(EntityTypeBuilder<RatingReason> builder)
        {
            builder.ToTable("RatingReason", "dbo");
            builder.HasKey(t => t.RatingReasonId);
            builder.Property(t => t.RatingReasonId)
                .IsRequired()
                .HasColumnName("RatingReasonId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.RatingReasonDescription)
                .IsRequired()
                .HasColumnName("RatingReasonDescription")
                .HasColumnType("nvarchar(max)");
        }
    }
}