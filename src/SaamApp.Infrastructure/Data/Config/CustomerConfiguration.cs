using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CustomerConfiguration
        : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "dbo");
            builder.HasKey(t => t.CustomerId);
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.CustomerFirstName)
                .IsRequired()
                .HasColumnName("CustomerFirstName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CustomerLastName)
                .IsRequired()
                .HasColumnName("CustomerLastName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CustomerProfileThumbnailPath)
                .HasColumnName("CustomerProfileThumbnailPath")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CustomerBirthDate)
                .HasColumnName("CustomerBirthDate")
                .HasColumnType("datetime2");
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
            builder.Property(t => t.GenderId)
                .IsRequired()
                .HasColumnName("GenderId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Gender)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Customer_Gender");
        }
    }
}