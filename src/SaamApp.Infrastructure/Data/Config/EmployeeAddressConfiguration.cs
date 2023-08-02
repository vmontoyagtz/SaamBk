using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class EmployeeAddressConfiguration
        : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.ToTable("EmployeeAddress", "dbo");
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
            builder.Property(t => t.EmployeeId)
                .IsRequired()
                .HasColumnName("EmployeeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Address)
                .WithMany(t => t.EmployeeAddresses)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_EmployeeAddress_Address");
            builder.HasOne(t => t.AddressType)
                .WithMany(t => t.EmployeeAddresses)
                .HasForeignKey(d => d.AddressTypeId)
                .HasConstraintName("FK_EmployeeAddress_AddressType");
            builder.HasOne(t => t.Employee)
                .WithMany(t => t.EmployeeAddresses)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeAddress_Employee");
        }
    }
}