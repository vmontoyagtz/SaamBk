using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class EmployeeEmailAddressConfiguration
        : IEntityTypeConfiguration<EmployeeEmailAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeEmailAddress> builder)
        {
            builder.ToTable("EmployeeEmailAddress", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.EmailAddressId)
                .IsRequired()
                .HasColumnName("EmailAddressId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.EmailAddressTypeId)
                .IsRequired()
                .HasColumnName("EmailAddressTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.EmployeeId)
                .IsRequired()
                .HasColumnName("EmployeeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.EmailAddress)
                .WithMany(t => t.EmployeeEmailAddresses)
                .HasForeignKey(d => d.EmailAddressId)
                .HasConstraintName("FK_EmployeeEmailAddress_EmailAddress");
            builder.HasOne(t => t.EmailAddressType)
                .WithMany(t => t.EmployeeEmailAddresses)
                .HasForeignKey(d => d.EmailAddressTypeId)
                .HasConstraintName("FK_EmployeeEmailAddress_EmailAddressType");
            builder.HasOne(t => t.Employee)
                .WithMany(t => t.EmployeeEmailAddresses)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeEmailAddress_Employee");
        }
    }
}