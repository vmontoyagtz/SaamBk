using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AccountConfiguration
        : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account", "dbo");
            builder.HasKey(t => t.AccountId);
            builder.Property(t => t.AccountId)
                .IsRequired()
                .HasColumnName("AccountId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AccountNumber)
                .IsRequired()
                .HasColumnName("AccountNumber")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AccountName)
                .IsRequired()
                .HasColumnName("AccountName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AccountDescription)
                .IsRequired()
                .HasColumnName("AccountDescription")
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
            builder.Property(t => t.AccountStateTypeId)
                .IsRequired()
                .HasColumnName("AccountStateTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.AccountTypeId)
                .IsRequired()
                .HasColumnName("AccountTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TaxInformationId)
                .IsRequired()
                .HasColumnName("TaxInformationId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.AccountStateType)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.AccountStateTypeId)
                .HasConstraintName("FK_Account_AccountStateType");
            builder.HasOne(t => t.AccountType)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.AccountTypeId)
                .HasConstraintName("FK_Account_AccountType");
            builder.HasOne(t => t.TaxInformation)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.TaxInformationId)
                .HasConstraintName("FK_Account_TaxInformation");
        }
    }
}