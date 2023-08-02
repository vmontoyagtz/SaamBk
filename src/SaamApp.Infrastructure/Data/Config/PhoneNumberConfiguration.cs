using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class PhoneNumberConfiguration
        : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumber", "dbo");
            builder.HasKey(t => t.PhoneNumberId);
            builder.Property(t => t.PhoneNumberId)
                .IsRequired()
                .HasColumnName("PhoneNumberId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.PhoneNumberString)
                .IsRequired()
                .HasColumnName("PhoneNumberString")
                .HasColumnType("nvarchar(max)");
        }
    }
}