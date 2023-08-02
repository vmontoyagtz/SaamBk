using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class MessageTypeConfiguration
        : IEntityTypeConfiguration<MessageType>
    {
        public void Configure(EntityTypeBuilder<MessageType> builder)
        {
            builder.ToTable("MessageType", "dbo");
            builder.HasKey(t => t.MessageTypeId);
            builder.Property(t => t.MessageTypeId)
                .IsRequired()
                .HasColumnName("MessageTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.MessageTypeName)
                .IsRequired()
                .HasColumnName("MessageTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.MessageTypeDescription)
                .HasColumnName("MessageTypeDescription")
                .HasColumnType("nvarchar(max)");
        }
    }
}