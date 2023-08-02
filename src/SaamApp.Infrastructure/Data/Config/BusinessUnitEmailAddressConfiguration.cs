using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class BusinessUnitEmailAddressConfiguration
        : IEntityTypeConfiguration<BusinessUnitEmailAddress>
    {
        public void Configure(EntityTypeBuilder<BusinessUnitEmailAddress> builder)
        {
            builder.ToTable("BusinessUnitEmailAddress", "dbo");
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
            builder.Property(t => t.EmailAddressId)
                .IsRequired()
                .HasColumnName("EmailAddressId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.EmailAddressTypeId)
                .IsRequired()
                .HasColumnName("EmailAddressTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.BusinessUnit)
                .WithMany(t => t.BusinessUnitEmailAddresses)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_BusinessUnitEmailAddress_BusinessUnit");
            builder.HasOne(t => t.EmailAddress)
                .WithMany(t => t.BusinessUnitEmailAddresses)
                .HasForeignKey(d => d.EmailAddressId)
                .HasConstraintName("FK_BusinessUnitEmailAddress_EmailAddress");
            builder.HasOne(t => t.EmailAddressType)
                .WithMany(t => t.BusinessUnitEmailAddresses)
                .HasForeignKey(d => d.EmailAddressTypeId)
                .HasConstraintName("FK_BusinessUnitEmailAddress_EmailAddressType");
        }
    }
}