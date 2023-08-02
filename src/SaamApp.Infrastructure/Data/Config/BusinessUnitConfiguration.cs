using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class BusinessUnitConfiguration
        : IEntityTypeConfiguration<BusinessUnit>
    {
        public void Configure(EntityTypeBuilder<BusinessUnit> builder)
        {
            builder.ToTable("BusinessUnit", "dbo");
            builder.HasKey(t => t.BusinessUnitId);
            builder.Property(t => t.BusinessUnitId)
                .IsRequired()
                .HasColumnName("BusinessUnitId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.BusinessUnitName)
                .IsRequired()
                .HasColumnName("BusinessUnitName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BusinessAddressId)
                .IsRequired()
                .HasColumnName("BusinessAddressId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.BusinessPhoneNumberId)
                .IsRequired()
                .HasColumnName("BusinessPhoneNumberId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.BusinessEmailAddressId)
                .IsRequired()
                .HasColumnName("BusinessEmailAddressId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("bit");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}