using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorAddressConfiguration
        : IEntityTypeConfiguration<AdvisorAddress>
    {
        public void Configure(EntityTypeBuilder<AdvisorAddress> builder)
        {
            builder.ToTable("AdvisorAddress", "dbo");
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
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Address)
                .WithMany(t => t.AdvisorAddresses)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_AdvisorAddress_Address");
            builder.HasOne(t => t.AddressType)
                .WithMany(t => t.AdvisorAddresses)
                .HasForeignKey(d => d.AddressTypeId)
                .HasConstraintName("FK_AdvisorAddress_AddressType");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorAddresses)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorAddress_Advisor");
        }
    }
}