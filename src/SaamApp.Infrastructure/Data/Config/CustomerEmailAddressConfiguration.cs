using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CustomerEmailAddressConfiguration
        : IEntityTypeConfiguration<CustomerEmailAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerEmailAddress> builder)
        {
            builder.ToTable("CustomerEmailAddress", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.EmailAddressId)
                .IsRequired()
                .HasColumnName("EmailAddressId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.EmailAddressTypeId)
                .IsRequired()
                .HasColumnName("EmailAddressTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.CustomerEmailAddresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerEmailAddress_Customer");
            builder.HasOne(t => t.EmailAddress)
                .WithMany(t => t.CustomerEmailAddresses)
                .HasForeignKey(d => d.EmailAddressId)
                .HasConstraintName("FK_CustomerEmailAddress_EmailAddress");
            builder.HasOne(t => t.EmailAddressType)
                .WithMany(t => t.CustomerEmailAddresses)
                .HasForeignKey(d => d.EmailAddressTypeId)
                .HasConstraintName("FK_CustomerEmailAddress_EmailAddressType");
        }
    }
}