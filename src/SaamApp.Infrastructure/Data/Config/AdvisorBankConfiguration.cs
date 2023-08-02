using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorBankConfiguration
        : IEntityTypeConfiguration<AdvisorBank>
    {
        public void Configure(EntityTypeBuilder<AdvisorBank> builder)
        {
            builder.ToTable("AdvisorBank", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.IsDefault)
                .IsRequired()
                .HasColumnName("IsDefault")
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
                .WithMany(t => t.AdvisorBanks)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorBank_Advisor");
            builder.HasOne(t => t.BankAccount)
                .WithMany(t => t.AdvisorBanks)
                .HasForeignKey(d => d.BankAccountId)
                .HasConstraintName("FK_AdvisorBank_BankAccount");
        }
    }
}