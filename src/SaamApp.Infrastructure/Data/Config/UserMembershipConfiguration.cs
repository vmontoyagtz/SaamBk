using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class UserMembershipConfiguration
        : IEntityTypeConfiguration<UserMembership>
    {
        public void Configure(EntityTypeBuilder<UserMembership> builder)
        {
            builder.ToTable("UserMembership", "dbo");
            builder.HasKey(t => t.UserMembershipId);
            builder.Property(t => t.UserMembershipId)
                .IsRequired()
                .HasColumnName("UserMembershipId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.Username)
                .IsRequired()
                .HasColumnName("Username")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ApplicationUserId)
                .IsRequired()
                .HasColumnName("ApplicationUserId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.IsOwner)
                .HasColumnName("IsOwner")
                .HasColumnType("bit");
            builder.Property(t => t.OwnerSince)
                .HasColumnName("OwnerSince")
                .HasColumnType("datetime2");
            builder.Property(t => t.IsAdmin)
                .HasColumnName("IsAdmin")
                .HasColumnType("bit");
            builder.Property(t => t.AdminSince)
                .HasColumnName("AdminSince")
                .HasColumnType("datetime2");
            builder.Property(t => t.IsAllowedToRunMobile)
                .HasColumnName("IsAllowedToRunMobile")
                .HasColumnType("bit");
            builder.Property(t => t.LastLogin)
                .HasColumnName("LastLogin")
                .HasColumnType("datetime2");
            builder.Property(t => t.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.LastPasswordChange)
                .HasColumnName("LastPasswordChange")
                .HasColumnType("datetime2");
            builder.Property(t => t.FailedLoginAttempts)
                .IsRequired()
                .HasColumnName("FailedLoginAttempts")
                .HasColumnType("int");
            builder.Property(t => t.IsLocked)
                .IsRequired()
                .HasColumnName("IsLocked")
                .HasColumnType("bit");
            builder.Property(t => t.LockedUntil)
                .HasColumnName("LockedUntil")
                .HasColumnType("datetime2");
            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasColumnType("bit");
        }
    }
}