using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class BusinessUnitAddressConfiguration
        : IEntityTypeConfiguration<BusinessUnitAddress>
    {
        public void Configure(EntityTypeBuilder<BusinessUnitAddress> builder)
        {
            builder.ToTable("BusinessUnitAddress", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.AddressId)
                .IsRequired()
                .HasColumnName("AddressId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.AddressTypeId)
                .IsRequired()
                .HasColumnName("AddressTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.BusinessUnitId)
                .IsRequired()
                .HasColumnName("BusinessUnitId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Address)
                .WithMany(t => t.BusinessUnitAddresses)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_BusinessUnitAddress_Address");
            builder.HasOne(t => t.AddressType)
                .WithMany(t => t.BusinessUnitAddresses)
                .HasForeignKey(d => d.AddressTypeId)
                .HasConstraintName("FK_BusinessUnitAddress_AddressType");
            builder.HasOne(t => t.BusinessUnit)
                .WithMany(t => t.BusinessUnitAddresses)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_BusinessUnitAddress_BusinessUnit");
        }
    }
}