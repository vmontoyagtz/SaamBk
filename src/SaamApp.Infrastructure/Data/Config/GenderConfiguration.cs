using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class GenderConfiguration
        : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender", "dbo");
            builder.HasKey(t => t.GenderId);
            builder.Property(t => t.GenderId)
                .IsRequired()
                .HasColumnName("GenderId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.GenderName)
                .IsRequired()
                .HasColumnName("GenderName")
                .HasColumnType("nvarchar(max)");
        }
    }
}