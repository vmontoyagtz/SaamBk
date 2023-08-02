using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorBankTransferInfoConfiguration
        : IEntityTypeConfiguration<AdvisorBankTransferInfo>
    {
        public void Configure(EntityTypeBuilder<AdvisorBankTransferInfo> builder)
        {
            builder.ToTable("AdvisorBankTransferInfo", "dbo");
            builder.HasKey(t => t.AdvisorBankTransferInfoId);
            builder.Property(t => t.AdvisorBankTransferInfoId)
                .IsRequired()
                .HasColumnName("AdvisorBankTransferInfoId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.BankTransferNotes)
                .HasColumnName("BankTransferNotes")
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
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.BankAccountId)
                .IsRequired()
                .HasColumnName("BankAccountId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorBankTransferInfoes)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorBankTransferInfo_Advisor");
            builder.HasOne(t => t.BankAccount)
                .WithMany(t => t.AdvisorBankTransferInfoes)
                .HasForeignKey(d => d.BankAccountId)
                .HasConstraintName("FK_AdvisorBankTransferInfo_BankAccount");
        }
    }
}