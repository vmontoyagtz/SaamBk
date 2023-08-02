using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class EmailAddressTypeConfiguration
        : IEntityTypeConfiguration<EmailAddressType>
    {
        public void Configure(EntityTypeBuilder<EmailAddressType> builder)
        {
            builder.ToTable("EmailAddressType", "dbo");
            builder.HasKey(t => t.EmailAddressTypeId);
            builder.Property(t => t.EmailAddressTypeId)
                .IsRequired()
                .HasColumnName("EmailAddressTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.EmailAddressTypeName)
                .IsRequired()
                .HasColumnName("EmailAddressTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}