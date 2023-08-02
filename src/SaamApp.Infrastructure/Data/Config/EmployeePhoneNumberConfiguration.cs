using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class EmployeePhoneNumberConfiguration
        : IEntityTypeConfiguration<EmployeePhoneNumber>
    {
        public void Configure(EntityTypeBuilder<EmployeePhoneNumber> builder)
        {
            builder.ToTable("EmployeePhoneNumber", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.EmployeeId)
                .IsRequired()
                .HasColumnName("EmployeeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.PhoneNumberId)
                .IsRequired()
                .HasColumnName("PhoneNumberId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.PhoneNumberTypeId)
                .IsRequired()
                .HasColumnName("PhoneNumberTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Employee)
                .WithMany(t => t.EmployeePhoneNumbers)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeePhoneNumber_Employee");
            builder.HasOne(t => t.PhoneNumber)
                .WithMany(t => t.EmployeePhoneNumbers)
                .HasForeignKey(d => d.PhoneNumberId)
                .HasConstraintName("FK_EmployeePhoneNumber_PhoneNumber");
            builder.HasOne(t => t.PhoneNumberType)
                .WithMany(t => t.EmployeePhoneNumbers)
                .HasForeignKey(d => d.PhoneNumberTypeId)
                .HasConstraintName("FK_EmployeePhoneNumber_PhoneNumberType");
        }
    }
}