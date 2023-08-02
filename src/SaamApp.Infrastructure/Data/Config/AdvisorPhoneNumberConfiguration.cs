using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorPhoneNumberConfiguration
        : IEntityTypeConfiguration<AdvisorPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<AdvisorPhoneNumber> builder)
        {
            builder.ToTable("AdvisorPhoneNumber", "dbo");
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
            builder.Property(t => t.PhoneNumberId)
                .IsRequired()
                .HasColumnName("PhoneNumberId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.PhoneNumberTypeId)
                .IsRequired()
                .HasColumnName("PhoneNumberTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorPhoneNumbers)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorPhoneNumber_Advisor");
            builder.HasOne(t => t.PhoneNumber)
                .WithMany(t => t.AdvisorPhoneNumbers)
                .HasForeignKey(d => d.PhoneNumberId)
                .HasConstraintName("FK_AdvisorPhoneNumber_PhoneNumber");
            builder.HasOne(t => t.PhoneNumberType)
                .WithMany(t => t.AdvisorPhoneNumbers)
                .HasForeignKey(d => d.PhoneNumberTypeId)
                .HasConstraintName("FK_AdvisorPhoneNumber_PhoneNumberType");
        }
    }
}