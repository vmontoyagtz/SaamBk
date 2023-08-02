using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AccountTypeConfiguration
        : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.ToTable("AccountType", "dbo");
            builder.HasKey(t => t.AccountTypeId);
            builder.Property(t => t.AccountTypeId)
                .IsRequired()
                .HasColumnName("AccountTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AccountTypeCode)
                .IsRequired()
                .HasColumnName("AccountTypeCode")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AccountTypeName)
                .IsRequired()
                .HasColumnName("AccountTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AccountTypeDescription)
                .IsRequired()
                .HasColumnName("AccountTypeDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}