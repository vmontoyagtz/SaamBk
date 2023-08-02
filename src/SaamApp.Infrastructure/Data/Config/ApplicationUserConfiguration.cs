using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class ApplicationUserConfiguration
        : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUser", "dbo");
            builder.HasKey(t => t.ApplicationUserId);
            builder.Property(t => t.ApplicationUserId)
                .IsRequired()
                .HasColumnName("ApplicationUserId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.LastName)
                .HasColumnName("LastName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Username)
                .IsRequired()
                .HasColumnName("Username")
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
            builder.Property(t => t.IsLoginAllowed)
                .IsRequired()
                .HasColumnName("IsLoginAllowed")
                .HasColumnType("bit");
            builder.Property(t => t.LastLogin)
                .HasColumnName("LastLogin")
                .HasColumnType("datetime2");
            builder.Property(t => t.LastFailedLogin)
                .HasColumnName("LastFailedLogin")
                .HasColumnType("datetime2");
            builder.Property(t => t.FailedLoginCount)
                .IsRequired()
                .HasColumnName("FailedLoginCount")
                .HasColumnType("int");
            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IsAccountVerified)
                .IsRequired()
                .HasColumnName("IsAccountVerified")
                .HasColumnType("bit");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.HashedPassword)
                .HasColumnName("HashedPassword")
                .HasColumnType("nvarchar(max)");
        }
    }
}