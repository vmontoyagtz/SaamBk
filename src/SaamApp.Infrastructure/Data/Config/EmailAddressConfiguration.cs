using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class EmailAddressConfiguration
        : IEntityTypeConfiguration<EmailAddress>
    {
        public void Configure(EntityTypeBuilder<EmailAddress> builder)
        {
            builder.ToTable("EmailAddress", "dbo");
            builder.HasKey(t => t.EmailAddressId);
            builder.Property(t => t.EmailAddressId)
                .IsRequired()
                .HasColumnName("EmailAddressId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.EmailAddressString)
                .IsRequired()
                .HasColumnName("EmailAddressString")
                .HasColumnType("nvarchar(max)");
        }
    }
}