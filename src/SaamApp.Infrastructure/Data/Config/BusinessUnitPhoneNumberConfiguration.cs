using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class BusinessUnitPhoneNumberConfiguration
        : IEntityTypeConfiguration<BusinessUnitPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<BusinessUnitPhoneNumber> builder)
        {
            builder.ToTable("BusinessUnitPhoneNumber", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.BusinessUnitId)
                .IsRequired()
                .HasColumnName("BusinessUnitId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.PhoneNumberId)
                .IsRequired()
                .HasColumnName("PhoneNumberId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.PhoneNumberTypeId)
                .IsRequired()
                .HasColumnName("PhoneNumberTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.BusinessUnit)
                .WithMany(t => t.BusinessUnitPhoneNumbers)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_BusinessUnitPhoneNumber_BusinessUnit");
            builder.HasOne(t => t.PhoneNumber)
                .WithMany(t => t.BusinessUnitPhoneNumbers)
                .HasForeignKey(d => d.PhoneNumberId)
                .HasConstraintName("FK_BusinessUnitPhoneNumber_PhoneNumber");
            builder.HasOne(t => t.PhoneNumberType)
                .WithMany(t => t.BusinessUnitPhoneNumbers)
                .HasForeignKey(d => d.PhoneNumberTypeId)
                .HasConstraintName("FK_BusinessUnitPhoneNumber_PhoneNumberType");
        }
    }
}