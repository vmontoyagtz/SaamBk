using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AccountStateTypeConfiguration
        : IEntityTypeConfiguration<AccountStateType>
    {
        public void Configure(EntityTypeBuilder<AccountStateType> builder)
        {
            builder.ToTable("AccountStateType", "dbo");
            builder.HasKey(t => t.AccountStateTypeId);
            builder.Property(t => t.AccountStateTypeId)
                .IsRequired()
                .HasColumnName("AccountStateTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AccountStateTypeCode)
                .IsRequired()
                .HasColumnName("AccountStateTypeCode")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AccountStateTypeName)
                .IsRequired()
                .HasColumnName("AccountStateTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AccountStateTypeDescription)
                .HasColumnName("AccountStateTypeDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}