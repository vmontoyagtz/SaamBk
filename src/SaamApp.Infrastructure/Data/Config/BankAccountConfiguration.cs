using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class BankAccountConfiguration
        : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccount", "dbo");
            builder.HasKey(t => t.BankAccountId);
            builder.Property(t => t.BankAccountId)
                .IsRequired()
                .HasColumnName("BankAccountId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.BankAccountName)
                .IsRequired()
                .HasColumnName("BankAccountName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BankAccountNumber)
                .IsRequired()
                .HasColumnName("BankAccountNumber")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BankAccountNotificationPhoneNumber)
                .IsRequired()
                .HasColumnName("BankAccountNotificationPhoneNumber")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BankAccountNotificationEmailAddress)
                .IsRequired()
                .HasColumnName("BankAccountNotificationEmailAddress")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IsDefault)
                .IsRequired()
                .HasColumnName("IsDefault")
                .HasColumnType("bit");
            builder.Property(t => t.BankId)
                .IsRequired()
                .HasColumnName("BankId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Bank)
                .WithMany(t => t.BankAccounts)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_BankAccount_Bank");
        }
    }
}