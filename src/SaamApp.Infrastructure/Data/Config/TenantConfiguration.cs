using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TenantConfiguration
        : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenant", "dbo");
            builder.HasKey(t => t.TenantId);
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Logo)
                .HasColumnName("Logo")
                .HasColumnType("varbinary(max)");
            builder.Property(t => t.ContactPerson)
                .HasColumnName("ContactPerson")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BillingFrequency)
                .HasColumnName("BillingFrequency")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.NextBillingDate)
                .HasColumnName("NextBillingDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.PaymentMethod)
                .HasColumnName("PaymentMethod")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IsSuspended)
                .IsRequired()
                .HasColumnName("IsSuspended")
                .HasColumnType("bit");
            builder.Property(t => t.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.SettingsJson)
                .HasColumnName("SettingsJson")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("bit");
        }
    }
}