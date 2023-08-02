using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class EmployeeConfiguration
        : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee", "dbo");
            builder.HasKey(t => t.EmployeeId);
            builder.Property(t => t.EmployeeId)
                .IsRequired()
                .HasColumnName("EmployeeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.EmployeeFirstName)
                .IsRequired()
                .HasColumnName("EmployeeFirstName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.EmployeeLastName)
                .IsRequired()
                .HasColumnName("EmployeeLastName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.EmployeeNumber)
                .HasColumnName("EmployeeNumber")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.EmployeeJobTitle)
                .HasColumnName("EmployeeJobTitle")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.EmployeeHireDate)
                .HasColumnName("EmployeeHireDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit");
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