using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorEmailAddressConfiguration
        : IEntityTypeConfiguration<AdvisorEmailAddress>
    {
        public void Configure(EntityTypeBuilder<AdvisorEmailAddress> builder)
        {
            builder.ToTable("AdvisorEmailAddress", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.EmailAddressId)
                .IsRequired()
                .HasColumnName("EmailAddressId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.EmailAddressTypeId)
                .IsRequired()
                .HasColumnName("EmailAddressTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorEmailAddresses)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorEmailAddress_Advisor");
            builder.HasOne(t => t.EmailAddress)
                .WithMany(t => t.AdvisorEmailAddresses)
                .HasForeignKey(d => d.EmailAddressId)
                .HasConstraintName("FK_AdvisorEmailAddress_EmailAddress");
            builder.HasOne(t => t.EmailAddressType)
                .WithMany(t => t.AdvisorEmailAddresses)
                .HasForeignKey(d => d.EmailAddressTypeId)
                .HasConstraintName("FK_AdvisorEmailAddress_EmailAddressType");
        }
    }
}