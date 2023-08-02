using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class UserSessionConfiguration
        : IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> builder)
        {
            builder.ToTable("UserSession", "dbo");
            builder.HasKey(t => t.SessionId);
            builder.Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ApplicationUserId)
                .IsRequired()
                .HasColumnName("ApplicationUserId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.LoginTime)
                .IsRequired()
                .HasColumnName("LoginTime")
                .HasColumnType("datetime2");
            builder.Property(t => t.LogoutTime)
                .HasColumnName("LogoutTime")
                .HasColumnType("datetime2");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}