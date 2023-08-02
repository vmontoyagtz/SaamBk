using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class BankConfiguration
        : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("Bank", "dbo");
            builder.HasKey(t => t.BankId);
            builder.Property(t => t.BankId)
                .IsRequired()
                .HasColumnName("BankId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.BankName)
                .IsRequired()
                .HasColumnName("BankName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BankSwiftCodeInfo)
                .HasColumnName("BankSwiftCodeInfo")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BankAddress)
                .IsRequired()
                .HasColumnName("BankAddress")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BankPhoneNumber)
                .IsRequired()
                .HasColumnName("BankPhoneNumber")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BankEmailAddress)
                .IsRequired()
                .HasColumnName("BankEmailAddress")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BankNotes)
                .IsRequired()
                .HasColumnName("BankNotes")
                .HasColumnType("nvarchar(max)");
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