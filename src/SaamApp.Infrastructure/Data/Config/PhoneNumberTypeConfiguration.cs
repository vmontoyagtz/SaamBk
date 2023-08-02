using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class PhoneNumberTypeConfiguration
        : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.ToTable("PhoneNumberType", "dbo");
            builder.HasKey(t => t.PhoneNumberTypeId);
            builder.Property(t => t.PhoneNumberTypeId)
                .IsRequired()
                .HasColumnName("PhoneNumberTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.PhoneNumberTypeName)
                .IsRequired()
                .HasColumnName("PhoneNumberTypeName")
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